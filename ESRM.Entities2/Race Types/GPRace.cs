using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class GPRace : Race
    {
        public GPRace(RaceParameters parameters) : base()
        {
            this.RaceParams = parameters;
            _state = RaceState.NotStarted;
            Init(parameters.DigitalParams);
        }

        public override string GetTitle()
        {
            return string.Format("{0} {1} laps", Textes.GrandPrix, this.RaceParams.LapCount.Value);
        }

        protected override void PerformRandomIncident()
        {
            base.PerformRandomIncident();
        }


        // Calcul de l'intervalle entre le déclenchement possible entre deux incidents aléatoires.
        // l'echelle va de très rare = 1 à très fréquent = 5
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

        public override void CheckForRaceEnd()
        {
            int countFinished = Teams.Count(t => t.Value.State == TeamState.Finished);
            int countRacingTeams = Teams.Count(t => t.Value.LapCount > 0);
            if (countRacingTeams == 0)
                countRacingTeams = Teams.Count;

            // vérifie l'état de la course et si besoin déclenche l'event fin de course
            if ((countFinished > 0 && this.RaceParams.EndRaceType == EndRaceType.FirstFinish) || (countFinished == countRacingTeams))
                Finish();
        }
    }
}
