using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class Qualification : Race
    {

        public Qualification(RaceParameters parameters)
            : base()
        {
            this.RaceParams = parameters;
            _state = RaceState.NotStarted;
            Init(parameters.DigitalParams);
        }

        public override string GetTitle()
        {
            string duration = string.Empty;
            if (this.RaceParams.TimeLimit.HasValue)
            {
                if (this.RaceParams.TimeLimit.Value.Hours > 1)
                    duration = string.Format("{0} Hours {1} min.", this.RaceParams.TimeLimit.Value.ToString(@"h"), this.RaceParams.TimeLimit.Value.ToString(@"mm"));
                else if (this.RaceParams.TimeLimit.Value.Hours > 0)
                    duration = string.Format("{0} Hour {1} min.", this.RaceParams.TimeLimit.Value.ToString(@"h"), this.RaceParams.TimeLimit.Value.ToString(@"mm"));
                else
                    duration = string.Format("{0} min.", RaceParams.TimeLimit.Value.ToString(@"mm"));
                return string.Format("{0} {1}", Textes.Qualification, duration);
            }
            else
                return string.Format("{0} {1} laps", Textes.Qualification, this.RaceParams.LapCount.Value);


        }

        //protected override void Init(IDigitalParamsBase digitalParams)
        //{
        //    base.Init(digitalParams);
        //}

        //public override void ResetRace()
        //{
        //    base.ResetRace();
        //}

        protected override void InitIncidentInterval()
        {
        }

        public override void DoEndOfLap(int laneId, TimeSpan passTime, bool forceExitPitLane, bool isJokerLap)
        {
            base.DoEndOfLap(laneId, passTime,forceExitPitLane, false);

            if (RaceDuration >= this.RaceParams.TimeLimit.Value)
                Teams[laneId].Finish();
        }

        protected override void DoClassement()
        {
            if (_classement.Count == 0)
                _classement.AddRange(Teams.Values);
            _classement.Sort();


            // calcul de la position et du gap mais aussi controle de chaque équipe pour savoir si elles ont terminé la course
            for (int i = 0; i < _classement.Count; i++)
            {
                if (_classement[i].LapCount > 0 && _classement[i].State != TeamState.Finished)
                {
                    if (i == 0) // si l'équipe est en tête, pas de Gap
                        _classement[i].Statisitics.Gap = string.Empty;
                    else if(FastestLap.HasValue && _classement[i].Statisitics.TeamBestLap.HasValue)
                    {
                            TimeSpan gap = FastestLap.Value - _classement[i].Statisitics.TeamBestLap.Value;
                            _classement[i].Statisitics.Gap = string.Format("+{0}", gap.ToString(@"ss\.ff"));

                    }
                }
                _classement[i].Statisitics.Position = i + 1;
                _classement[i].Statisitics.InitialPosition = i + 1; 
            }

            CheckForRaceEnd();
        }

        public override void CheckForRaceEnd()
        {
            int countFinished = Teams.Count(t => t.Value.State == TeamState.Finished);
            int countRacingTeams = Teams.Count(t => t.Value.LapCount > 0);
            if (countRacingTeams == 0)
                countRacingTeams = Teams.Count;


            if (RaceDuration >= this.RaceParams.TimeLimit.Value && countFinished == countRacingTeams)
                Finish();

        }
    }
}
