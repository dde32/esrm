using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class Lap
    {
        public int Relay
        {
            get;
            set;
        }
        public int Number
        {
            get;
            set;
        }

        public TimeSpan LapTime
        {
            get;
            set;
        }
        public string LapTimeForUI
        {
            get
            {
                return string.Format("{0}'{1}", LapTime.Seconds.ToString("D2"), LapTime.Milliseconds.ToString("D3"));
            }
        }

        public Pilot Pilot
        {
            get;
            set;
        }        
        public bool PitStopInLap { get; set; }
        public int TrackCallCount { get; set; }
        public int IncidentCount { get; set; }

        public double CarHealth { get; set; }
        public double FuelConso { get; set; }
        public double FuelPercent { get; set; }
        public double TiresWear { get; set; }
        public double TiresPercent { get; set; }
        public int Position { get; set; }
        public bool IsJokerLap { get; set; }


        //public bool IsTeamBestLap { get; set; }
        //public bool IsPilotBestLap { get; set; }
        //public bool IsRaceBestLap { get; set; }
    }
}
