using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class RallyCrossRace : Race
    {
        public RallyCrossRace(RaceParameters parameters)
            : base()
        {
            this.RaceParams = parameters;
            _state = RaceState.NotStarted;
            Init(parameters.DigitalParams);
        }


        public override string GetTitle()
        {
            string duration = string.Empty;
            if (RaceParams.TimeLimit.HasValue)
            {
                if (this.RaceParams.TimeLimit.Value.Hours > 1)
                    duration = string.Format("{0} Hours {1} min.", this.RaceParams.TimeLimit.Value.ToString(@"hh"), this.RaceParams.TimeLimit.Value.ToString(@"mm"));
                else if (this.RaceParams.TimeLimit.Value.Hours > 0)
                    duration = string.Format("1 Hour {0} min.", this.RaceParams.TimeLimit.Value.ToString(@"mm"));
                else
                    duration = string.Format("{0} min.", RaceParams.TimeLimit.Value.ToString(@"mm"));

                return string.Format("{0} {1}", Textes.RallyCross, duration);
            }
            else
                return string.Format("{0} {1} laps", Textes.RallyCross, this.RaceParams.LapCount.Value);

        }

        //protected override void Init(IDigitalParamsBase digitalParams)
        //{
        //    base.Init(digitalParams);
        //}

        protected override void InitIncidentInterval()
        {
            double probability = 0;
            switch (RaceParams.DamagesFrequency)
            {
                case 1:
                    probability = 1;
                    break;
                case 2:
                    probability = 2;
                    break;
                case 3:
                    probability = 3;
                    break;
                case 4:
                    probability = 4;
                    break;
                case 5:
                    probability = 5;
                    break;
                default:
                    probability = 0;
                    break;
            }

            MaxRamdomValueForIncident = (int)((RaceParams.TireLifeTime * Teams.Count) / probability);
        }

        public override void ResetRace(bool resetPosition, bool resetQualifPosition)
        {
            base.ResetRace(resetPosition, resetQualifPosition);

            //RaceParams.LapCount = null;
        }

        #region RACE STATE

        public override void Start()
        {
            base.Start();
        }

        public override void Pause()
        {
            base.Pause();
        }

        public override void UnPause()
        {
            base.UnPause();
        }

        public override void Finish()
        {
            base.Finish();

        }

        #endregion RACE STATE

        public override void DoEndOfLap(int laneId, TimeSpan passTime, bool forceExitPitLane,bool isJokerLap)
        {
            base.DoEndOfLap(laneId, passTime,forceExitPitLane, isJokerLap);

            if (RaceParams.TimeLimit.HasValue && RaceDuration >= RaceParams.TimeLimit.Value)
                Teams[laneId].Finish();

            if(RaceParams.JokerLapCount > 0 && Teams[laneId].Statisitics.JokerLapCount > RaceParams.JokerLapCount)
                Teams[laneId].State = TeamState.Disqualified;
        }

        public override void TeamEnterPitLane(int laneId, TimeSpan passTime)
        {
            // Si les sensors ne sont pas en remplacement de la ligne d'arrivée, il ne faut pas ajouter de JL LAP mais 
            // simplement conserver un flag qui indique que l'on est passé dans la voie secondaire pour que le prochain AddLap comptabilise un JL

            if (RaceParams.DigitalParams.AddLapOnPitStop == AddlapOnPitStopEnum.No)
                Teams[laneId].PassJokerLapTrackSection();
            else
                DoEndOfLap(laneId, passTime, false,true);
        }

        //public override void TeamExitPitLane(int laneId, TimeSpan passTime)
        //{
        //    Teams[laneId].ExitPitLane(passTime);

        //    if (RaceParams.DigitalParams.AddLapOnPitStop == AddlapOnPitStopEnum.ExitPitLane && !Teams[laneId].PitStopInThisLap)
        //        DoEndOfLap(laneId, passTime, true);

        //}

        protected override void CheckIfTeamFinishRace(TeamInRace team, bool oneFinished)
        {
            // si au moins une équipe a terminé la course et que la fin de course est standard, tout le monde à terminé
            if (oneFinished && this.RaceParams.EndRaceType == EndRaceType.Standard)
            {
                team.Finish();
                OnTeamFinish(team.Id);
            }
            else
            {
                // si la course est une course à nombre de tour défini
                if (this.RaceParams.LapCount.HasValue)
                {
                    // l'équipe en cours vient de terminer la course (nombre tour et état pas encore finish)
                    if (team.LapCount >= this.RaceParams.LapCount)
                    {
                        team.Finish();
                        OnTeamFinish(team.Id);
                    }
                }
                // Est ce que l'équipe qui vient de terminer le tour a fini la course.
                else if (RaceDuration >= this.RaceParams.TimeLimit.Value)
                {
                    team.Finish();
                    OnTeamFinish(team.Id);
                }
            }
        }

        public override void CheckForRaceEnd()
        {
            if (RaceParams.TimeLimit.HasValue)
                CheckForRaceEnd_WithTimeLimit();
            else
                CheckForRaceEnd_WithLapCount();
        }

        public void CheckForRaceEnd_WithTimeLimit()
        {
            int countFinished = Teams.Count(t => t.Value.State == TeamState.Finished);
            int countRacingTeams = Teams.Count(t => t.Value.LapCount > 0);
            if (countRacingTeams == 0)
                countRacingTeams = Teams.Count;


            if (RaceDuration >= this.RaceParams.TimeLimit.Value)
            {
                if (RaceParams.EndRaceType == EndRaceType.FirstFinish && countFinished > 0)
                    Finish();
                else if (countFinished == countRacingTeams)
                    Finish();
            }
        }

        public  void CheckForRaceEnd_WithLapCount()
        {
            int countFinished = Teams.Count(t => t.Value.State == TeamState.Finished);
            int countRacingTeams = Teams.Count;

            // vérifie l'état de la course et si besoin déclenche l'event fin de course
            if ((countFinished > 0 && this.RaceParams.EndRaceType == EndRaceType.FirstFinish) || (countFinished == countRacingTeams))
                Finish();
        }
    }
}
