using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class PracticeRace : Race
    {
        public PracticeRace(RaceParameters parameters)
            : base()
        {
            this.RaceParams = parameters;
            _state = RaceState.NotStarted;

            //RaceParams.FuelImpact = false;
            //RaceParams.Damages = DamagesEnum.None;

            Init(parameters.DigitalParams);
        }
        public override void ResetRace(bool resetPosition, bool resetQualifPosition)
        {
            base.ResetRace(resetPosition, resetQualifPosition);

            //RaceParams.FuelImpact = false;
            //RaceParams.Damages = DamagesEnum.None;
            RaceParams.LapCount = null;
        }
        public override string GetTitle()
        {
            string duration = string.Empty;
            if (this.RaceParams.TimeLimit.Value.Hours > 1)
                duration = string.Format("{0} Hours {1} min.", this.RaceParams.TimeLimit.Value.ToString(@"hh"), this.RaceParams.TimeLimit.Value.ToString(@"mm"));
            else if (this.RaceParams.TimeLimit.Value.Hours > 0)
                duration = string.Format("{0} Hour {1} min.", this.RaceParams.TimeLimit.Value.ToString(@"hh"), this.RaceParams.TimeLimit.Value.ToString(@"mm"));
            else
                duration = string.Format("{0} min.", RaceParams.TimeLimit.Value.ToString(@"mm"));

            return string.Format("{0} {1}", Textes.Practice, duration);
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


        public override void DoEndOfLap(int laneId, TimeSpan passTime,bool forceExitPitLane,bool isJokerLap)
        {
            base.DoEndOfLap(laneId, passTime,forceExitPitLane, false);
            if (RaceDuration >= this.RaceParams.TimeLimit.Value)
                Teams[laneId].Finish();
        }

        public override void CheckForRaceEnd()
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


        protected override void DoClassement()//, out int countFinished)
        {
            if (_classement.Count == 0)
                _classement.AddRange(Teams.Values);


            base.DoClassement();

            //_classement.Sort();

        }

        //public override void CheckForRaceEnd()
        //{
        //    int countFinished = Teams.Count(t => t.Value.State == TeamState.Finished);

        //    // pour que la course soit terminé il y a deux options.
        //    // soit il y a une seule équipe engagée et dans ce cas c'est le timer qui détermine la fin de course (TimeCounter à 0)
        //    // Soit il y a plusieurs équipes et dans ce cas la couse est terminée quand il y a une seule auto.
        //    if (countFinished == Teams.Count)
        //        Finish();
        //}
    }
}
