using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class EnduranceRace : Race
    {
        public EnduranceRace(RaceParameters parameters)
            : base()
        {
            this.RaceParams = parameters;
            _state = RaceState.NotStarted;
            Init(parameters.DigitalParams);
        }


        public override string GetTitle()
        {
            string duration = string.Empty;
            if(this.RaceParams.TimeLimit.Value.Hours > 1 )
                duration =string.Format("{0} Hours {1} min.", this.RaceParams.TimeLimit.Value.ToString(@"hh"), this.RaceParams.TimeLimit.Value.ToString(@"mm"));
            else if (this.RaceParams.TimeLimit.Value.Hours > 0)
                duration = string.Format("1 Hour {0} min.",this.RaceParams.TimeLimit.Value.ToString(@"mm"));
            else
                duration = string.Format("{0} min.", RaceParams.TimeLimit.Value.ToString(@"mm"));
            
            return string.Format("{0} {1}",Textes.Endurance, duration) ;
        }

        //protected override void Init(IDigitalParamsBase digitalParams)
        //{
        //    base.Init(digitalParams);
        //}

        protected override void InitIncidentInterval()
        {
            // MODE GP
            // On calcule une valeur (MaxRamdomValueForIncident) qui servira comme borne max pour un calcul de valeur aléatoire executé à chaque fin de tour.
            // exemple; si la borne max vaut 10 on a une chance sur 10 de déclencher un incident. Plus la borne est haute moins le risque d'incident est élevé.
            // le calcul est basé sur la valeur de PitStopFrequency. Au départ on faisait le calcul sur le nombre de tours total, mais pour une très longue course ce n'était pas du tout adapté.
            // la fréquence de passage au stand est plus sympa à l'utilisation

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

            RaceParams.LapCount = null;
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
    }
}
