using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ESRM.Entities
{
    [DataContract]
    public class PilotStatistics
    {
        [IgnoreDataMember]
        public string TeamName
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public Pilot Pilot
        {
            get;
            set;
        }


        [IgnoreDataMember]
        public TimeSpan? BestLap
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public TimeSpan? AverageLap
        {
            get;
            set;
        }


        [IgnoreDataMember]
        public bool FastestLap { get; set; }

        [IgnoreDataMember]
        public int LapCount { get; set; }
        public int PitStopCount { get; set; }

        public int IncidentCount { get; set; }

        public int TrackCallCount { get; set; }

        //public int StattsForRaceUI
        //{
        //    get {return string.Format("");
        //}


        public string BestLapForUI
        {
            get
            {
                if (BestLap.HasValue == false)
                    return string.Empty;

                return string.Format("{0}'{1}", BestLap.Value.Seconds.ToString("D2"), BestLap.Value.Milliseconds.ToString("D3"));
            }
        }
        public string AverageLapForUI
        {
            get
            {
                if (AverageLap.HasValue == false)
                    return string.Empty;
                return string.Format("{0}'{1}", AverageLap.Value.Seconds.ToString("D2"), AverageLap.Value.Milliseconds.ToString("D3"));
            }
        }

        public PilotStatistics()
        {
            Reset();
        }

        public void Reset()
        {
            IncidentCount = 0;
            BestLap = null;
            AverageLap = null;
            PitStopCount = 0;
            TrackCallCount = 0;
            FastestLap = false;
            LapCount = 0;
        }


        public void ProcessLapTime(TimeSpan lapTime)
        {
            LapCount++;
            if (!BestLap.HasValue || lapTime < BestLap.Value)
            {
                BestLap = lapTime;
            }
        }

        public void AddPitStop()
        {
            PitStopCount++;
        }

        public void AddTrackCall()
        {
            TrackCallCount++;
        }

        public void AddIncident()
        {
            IncidentCount++;
        }

    }
}
