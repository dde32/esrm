using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities
{
    [DataContract]
    public class Record
    {
        public Record()
        {
        }

        public Record(string pilotName, TimeSpan lapTime, string carName)
        {
            PilotName = pilotName;
            LapTime = lapTime;
            CarName = carName;
            Date = DateTime.Now;
        }

        [DataMember]
        public string PilotName
        {
            get;
            set;
        }

        [DataMember]
        public string CarName
        {
            get;
            set;
        }

        [DataMember]
        public TimeSpan LapTime
        {
            get;
            set;
        }
        public string LapTimeForUI
        {
            get
            {
                return string.Format("{0}'{1}",LapTime.Seconds.ToString("D2"), LapTime.Milliseconds.ToString("D3"));
            }
        }


        [DataMember]
        public DateTime Date
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Record objAsPart = obj as Record;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return PilotName.GetHashCode() ^ CarName.GetHashCode();
        }

        public bool Equals(Record other)
        {
            if (other == null) return false;
            return (this.PilotName.Equals(other.PilotName) && CarName.Equals(other.CarName));
        }
    }


    public class RecordList : List<Record>
    {
        public RecordList()
        {

        }

        public void ComputeLapsOnRaceEnd(TeamInRaceCollection teams)
        {
            foreach (TeamInRace t in teams.Values)
            {
                if (t.Pilot1 != null && t.Statisitics.StatsByPilot.ContainsKey(t.Pilot1) && t.Statisitics.StatsByPilot[t.Pilot1].BestLap.HasValue)
                {
                    Record tmp = new Record(t.Pilot1.Name, t.Statisitics.StatsByPilot[t.Pilot1].BestLap.Value, t.Car.Name);
                    tmp.Date = DateTime.Now;

                    //t.Statisitics.StatsByPilot[t.Pilot1].BestLap
                    // recherche si le couple PIlot / Car est présent dans la liste
                    // si c'est le cas on compare le laptime pour savoir si on a un nouveau record
                    // sinon on ajoute le record
                    int idxFound = -1;
                    for(int i = 0; i < this.Count; i++)
                    {
                        if (this[i].PilotName == tmp.PilotName && this[i].CarName == tmp.CarName)
                        {
                            idxFound = i;
                            break;
                        }
                    }

                    if( (idxFound > -1 && this[idxFound].LapTime > tmp.LapTime)) // record existant mais battu 
                    {
                        this[idxFound] = tmp;
                    }
                    else if(idxFound == -1)
                    {
                        this.Add(tmp);
                    }
                }                   
            }
        }
    }
}
