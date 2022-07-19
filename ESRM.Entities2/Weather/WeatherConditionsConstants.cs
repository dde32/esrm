using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities.Weather
{
    public static class WeatherConditionsConstants
    {
        public static int MinTemperature = 20;
        public static int IntermediateTemperature = 35;


        public static int WinterMinTemp = 8;
        public static int WinterMaxTemp = 15;

        public static int SpringMinTemp = 10;
        public static int SpringMaxTemp = 25;

        public static int SummerMinTemp = 20;
        public static int SummerMaxTemp = 35;

        public static int AutomunMinTemp = 10;
        public static int AutomunMaxTemp = 20;


        public static int TrackDeltaTemperature_SunnyMin = 8;
        public static int TrackDeltaTemperature_SunnyMax = 20;

        public static int TrackDeltaTemperature_RainingMin = 0;
        public static int TrackDeltaTemperature_RainingMax = 8;

        public static int TrackDeltaTemperature_NightgMin = 0;
        public static int TrackDeltaTemperature_NightMax = 8;

        // matrice des probabilités de passage d'un weathertype à un autre weathertype
        public static int[,] EvolutionProbabilities = new int[7, 7]
        { { 0, 45, 20, 20, 5, 5, 5 },
          { 40, 0, 20, 15, 10, 10, 5 } ,
          { 15, 20, 0, 35, 10, 10, 10 } ,
          { 15, 15, 20, 0, 15, 15, 20 } ,
          { 10, 10, 15, 15, 0, 25, 25 } ,
          { 10, 10, 15, 15, 30, 0, 30 } ,
          { 10, 25, 25, 10, 20, 20, 0 } };
    }

}
