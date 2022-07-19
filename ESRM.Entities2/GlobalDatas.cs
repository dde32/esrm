using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public static class GlobalDatas
    {
        public static int MAXBRAKEINTERVALFORTIRES = 6;   // intervalle maximal entre deux freinages selon les pneus
        public static int INTERVALBETWEENTWOSIGNALS = 25; // intervalle de temps en milli secondes entre deux signaux de la PB

        public static int MAXBRAKEINTERVAL = 10;
        public static double MAXACCELERATIONDELTA = 50;

        public static int POWERBASEMAXTHROTTLEVALUE = 63;

        public static int DELTAFORBIGACCELERATIONDETECT = (int)(0.75 * MAXACCELERATIONDELTA);
        public static int DELTAFORBIGBRAKINGDETECT = (int)(0.75 * MAXACCELERATIONDELTA);

        public static int LOWTIRESLEVEL = 25;
        public static int LOWFUELLEVEL = 25;
        public static int LOWHEALTHLEVEL = 25;
        public static int PITSTOPREFRESHINTERVAL = 1000;

        public static BrakeTriggerValue BTV_0 = new BrakeTriggerValue(0, (float)0, 0, 0);
        public static BrakeTriggerValue BTV_1 = new BrakeTriggerValue(1, (float)0.166, 6, 1);
        public static BrakeTriggerValue BTV_2 = new BrakeTriggerValue(2, (float)0.2, 5, 1);
        public static BrakeTriggerValue BTV_3 = new BrakeTriggerValue(3, (float)0.25, 4, 1);
        public static BrakeTriggerValue BTV_4 = new BrakeTriggerValue(4, (float)0.333, 3, 1);
        public static BrakeTriggerValue BTV_5 = new BrakeTriggerValue(5, (float)0.5, 4, 2);
        public static BrakeTriggerValue BTV_6 = new BrakeTriggerValue(6, (float)0.6, 5, 3);
        public static BrakeTriggerValue BTV_7 = new BrakeTriggerValue(7, (float)0.666, 5, 3);
        public static BrakeTriggerValue BTV_8 = new BrakeTriggerValue(8, (float)0.75, 4, 3);
        public static BrakeTriggerValue BTV_9 = new BrakeTriggerValue(9, (float)0.833, 6, 5);
        public static BrakeTriggerValue BTV_10 = new BrakeTriggerValue(10, (float)1, 1, 1);

    //    public static BrakeTriggerValue BTV_0 = new BrakeTriggerValue(0, (float)0, 0, 0);
    //    public static BrakeTriggerValue BTV_1 = new BrakeTriggerValue(1, (float)0.166, 8, 1);
    //    public static BrakeTriggerValue BTV_2 = new BrakeTriggerValue(2, (float)0.2, 7, 1);
    //    public static BrakeTriggerValue BTV_3 = new BrakeTriggerValue(3, (float)0.25, 6, 1);
    //    public static BrakeTriggerValue BTV_4 = new BrakeTriggerValue(4, (float)0.333, 5, 1);
    //    public static BrakeTriggerValue BTV_5 = new BrakeTriggerValue(5, (float)0.5, 4, 1);
    //    public static BrakeTriggerValue BTV_6 = new BrakeTriggerValue(6, (float)0.6, 3, 1);
    //    public static BrakeTriggerValue BTV_7 = new BrakeTriggerValue(7, (float)0.666, 3, 2);
    //    public static BrakeTriggerValue BTV_8 = new BrakeTriggerValue(8, (float)0.75, 4, 3);
    //    public static BrakeTriggerValue BTV_9 = new BrakeTriggerValue(9, (float)0.833, 5, 4);
    //    public static BrakeTriggerValue BTV_10 = new BrakeTriggerValue(10, (float)1, 1, 1);
    }
}
