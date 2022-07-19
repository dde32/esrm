using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    [DataContract]
    public class TeamStatistics
    {
        int _initialposition;
        int _position;
        int _tiresSetCount;
        double _totalUsedFuel;
        double _totalUsedHealth;

        public string TeamName;

        // properties modifiée en live par l'objet Course

        public int InitialPosition
        {
            get { return _initialposition; }
            set
            {
                if (_initialposition != value)
                {
                    _initialposition = value;
                    _position = value;
                }
            }
        }
        public int Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                }
            }
        }

        [IgnoreDataMember]
        public string Gap
        {
            get;
            set;
        }
        [IgnoreDataMember]
        public string UsedFuel
        {
            get { return string.Format("{0} {1}", Textes.UsedFuel, _totalUsedFuel); }
        }
        [IgnoreDataMember]
        public string UsedTires
        {
            get { return string.Format("{0} {1}", Textes.UsedTires, _tiresSetCount); }
        }
        [IgnoreDataMember]
        public string UsedHealth
        {
            get { return string.Format("{0} {1}", Textes.UsedHealth, _totalUsedHealth); }
        }



        [IgnoreDataMember]
        public TimeSpan? RelayBestLap
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public TimeSpan? TeamBestLap
        {
            get;
            set;
        }


        [IgnoreDataMember]
        public int PitStopCount { get; set; }

        [IgnoreDataMember]
        public int IncidentCount { get; set; }

        [IgnoreDataMember]
        public int TrackCallCount { get; set; }
        [IgnoreDataMember]
        public int JokerLapCount { get; set; }
              

        [IgnoreDataMember]
        public bool FastestLap { get; set; }

        // Fin des properties modifiée en live par l'objet Course

        [IgnoreDataMember]
        public TimeSpan? AverageLap
        {
            get;
            set;
        }

        public Dictionary<Pilot, PilotStatistics> StatsByPilot { get; set; }



        public TeamStatistics(string teamName)
        {
            TeamName = teamName;
            StatsByPilot = new Dictionary<Pilot, PilotStatistics>();
            Reset(true, true);
        }

        public void Reset(bool resetPosition, bool resetInitialPosition)
        {
            IncidentCount = 0;
            RelayBestLap = null;
            TeamBestLap = null;
            AverageLap = null;
            Gap = string.Empty;
            if (resetInitialPosition)
                _initialposition = 0;
            if (resetPosition)
                _position = _initialposition;
            PitStopCount = 0;
            TrackCallCount = 0;
            FastestLap = false;
            StatsByPilot.Clear();
            _tiresSetCount = 0;
            JokerLapCount = 0;
        }


        public void ProcessLapTime(TimeSpan lapTime, Pilot pilot)
        {
            // Calcul du meilleur tour
            if (!RelayBestLap.HasValue || lapTime < RelayBestLap.Value)
            {
                RelayBestLap = lapTime;
            }
            if (!TeamBestLap.HasValue || lapTime < TeamBestLap.Value)
            {
                TeamBestLap = lapTime;
            }

            if (!StatsByPilot.ContainsKey(pilot))
                StatsByPilot.Add(pilot, new PilotStatistics() { Pilot = pilot, TeamName = TeamName });
            else
                StatsByPilot[pilot].ProcessLapTime(lapTime);
        }

        public void AddPitStop(Pilot pilot)
        {
            if (!StatsByPilot.ContainsKey(pilot))
                StatsByPilot.Add(pilot, new PilotStatistics() { Pilot = pilot, TeamName = TeamName });
            
            StatsByPilot[pilot].AddPitStop();
            PitStopCount++;
        }

        public void AddTrackCall(Pilot pilot)
        {
            if (!StatsByPilot.ContainsKey(pilot))
                StatsByPilot.Add(pilot, new PilotStatistics() { Pilot = pilot, TeamName = TeamName });

            StatsByPilot[pilot].AddTrackCall();
            TrackCallCount++;
        }

        public void AddIncident(Pilot pilot)
        {
            IncidentCount++;
            if (!StatsByPilot.ContainsKey(pilot))
                StatsByPilot.Add(pilot, new PilotStatistics() { Pilot = pilot, TeamName = TeamName });

            StatsByPilot[pilot].AddIncident();
            IncidentCount++;
        }

        public void SetFastestLap(bool isFastest)
        {
            FastestLap = isFastest;
        }

        public void ComputeStats(List<Lap> laps)
        {

            // Calcul du temps moyen de la team et par pilote
            if (laps.Count > 0)
                AverageLap = TimeSpan.FromMilliseconds(laps.Average(l => l.LapTime.TotalMilliseconds));

            foreach (KeyValuePair<Pilot, PilotStatistics> st in StatsByPilot)
            {
                if (laps.Count == 0)
                    st.Value.AverageLap = null;
                else
                    st.Value.AverageLap = TimeSpan.FromMilliseconds(laps.Where(l => l.Pilot == st.Value.Pilot).Average(l => l.LapTime.TotalMilliseconds));
                // si on est fastest on cherche le fastest parmis les pilotes
                // sinon on s'assure de ne pas avoir un piote marqué comme fastest
                if (FastestLap)
                {
                    if (TeamBestLap == laps.Where(l => l.Pilot == st.Value.Pilot).Min(l => l.LapTime))
                        st.Value.FastestLap = true;
                    else
                        st.Value.FastestLap = false;
                }
                else
                    st.Value.FastestLap = false;
            }

            _tiresSetCount = 1;
            _totalUsedFuel = 0;
            _totalUsedHealth = 0;
            for (int i = 0; i < laps.Count; i++)
            {
                if (i > 0 && laps[i].TiresPercent > laps[i - 1].TiresPercent)
                    _tiresSetCount++;

                _totalUsedFuel += laps[i].FuelConso;
                if (i > 0 && laps[i].CarHealth < laps[i - 1].CarHealth)
                    _totalUsedHealth += (laps[i - 1].CarHealth - laps[i].CarHealth );
            }

        }
    }



 



}

