using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class TimeAttackRace : Race
    {
        public event EventHandler LevelChangedEvent;

        public TimeAttackRace(RaceParameters parameters)
            : base()
        {
            this.RaceParams = parameters;
            _state = RaceState.NotStarted;

            RaceParams.FuelImpact = false;
            RaceParams.Damages = DamagesEnum.None;
            Init(parameters.DigitalParams);
        }


        public override void ResetRace(bool resetPosition,bool resetQualifPosition)
        {
            base.ResetRace(resetPosition, resetQualifPosition);

            RaceParams.FuelImpact = false;
            RaceParams.Damages = DamagesEnum.None;
            RaceParams.LapCount = null;

            foreach (KeyValuePair<int, TeamInRace> entry in Teams)
            {
               entry.Value.TimeAttackBonusMalus = RaceParams.TimeAttackStartBonus;
                entry.Value.TimeAttackTimeLeft = this.RaceParams.TimeAttackLapTarget + entry.Value.TimeAttackBonusMalus;
            }

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

        public override void DoEndOfLap(int laneId, TimeSpan passTime, bool forceExitPitLane, bool isJokerLap)
        {
            base.DoEndOfLap(laneId, passTime,forceExitPitLane,false);

            // gestion du level de la team
            if (Teams[laneId-1].LapCount / Teams[laneId-1].TimeAttackLevel == 10)
            {
                Teams[laneId - 1].TimeAttackLevel++;
                Teams[laneId - 1].TimeAttackTimeLeft = Teams[laneId - 1].TimeAttackLapTarget ;
                Teams[laneId - 1].TimeAttackTimeLeft = Teams[laneId - 1].TimeAttackTimeLeft.Add( TimeSpan.FromMilliseconds((this.RaceParams.TimeAttackStartBonus.TotalMilliseconds * (1 - (Teams[laneId - 1].TimeAttackLevel / 10)))));

                OnLevelChanged();
            }
        }

        protected override void DoClassement()//, out int countFinished)
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
                    else
                    {
                        int lapDiff = _classement[i - 1].LapCount - _classement[i].LapCount;
                        if (lapDiff < 2 && !_classement[i].IsInFirstLap && !_classement[i - 1].IsInFirstLap)
                        {
                            TimeSpan gap = (_classement[i].LastLapEnd - _classement[i - 1].LastLapEnd);
                            _classement[i].Statisitics.Gap = string.Format("+{0}", gap.ToString(@"ss\.ff"));
                        }
                        else if (_classement[i].LapCount > 1)
                            _classement[i].Statisitics.Gap = string.Format("{0} {1}", lapDiff-1, Textes.Laps);
                    }
                }
                _classement[i].Statisitics.Position = i + 1;
            }
        }


        protected override void CheckIfTeamFinishRace(TeamInRace team, bool oneFinished)
        {

            //// si au moins une équipe a terminé la course et que la fin de course est standard, tout le monde à terminé
            //if (oneFinished && this.RaceParams.EndRaceType == EndRaceType.Standard)
            //{
            //    team.Finish();
            //    OnTeamFinish(team.Id);
            //}
            //else
            //{
            //    // si la course est une course à nombre de tour défini
            //    if (this.RaceParams.RaceType == RaceType.GP)
            //    {
            //        // l'équipe en cours vient de terminer la course (nombre tour et état pas encore finish)
            //        if (team.LapCount >= this.RaceParams.Laps)
            //        {
            //            team.Finish();
            //            OnTeamFinish(team.Id);
            //        }
            //    }
            //    // Est ce que l'équipe qui vient de terminer le tour a fini la course.
            //    else if ((this.RaceParams.RaceType == RaceType.Endurance || this.RaceParams.RaceType == RaceType.Qualification) && RaceDuration >= this.RaceParams.TimeLimit.Value)
            //    {
            //        team.Finish();
            //        OnTeamFinish(team.Id);
            //    }
            //}
        }


        public override void CheckForRaceEnd()
        {
            int countFinished = Teams.Count(t => t.Value.State == TeamState.Finished);

            // pour que la course soit terminé il y a deux options.
            // soit il y a une seule équipe engagée et dans ce cas c'est le timer qui détermine la fin de course (TimeCounter à 0)
            // Soit il y a plusieurs équipes et dans ce cas la couse est terminée quand il y a une seule auto.
            if (countFinished == Teams.Count)
                Finish();



        }

        private void OnLevelChanged()
        {
            if (LevelChangedEvent != null)
                LevelChangedEvent(this, EventArgs.Empty);
        }
    }
}
