using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ESRM.Entities.Race_entities
{
    [DataContract]
    public class ESRMEvent
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public List<Pilot> Drivers { get; set; }
        [DataMember]
        public List<Car> Cars { get; set; }
        [DataMember]
        public List<Race> Races { get; set; }
        [DataMember]
        public EventStatistics EventStatisitics { get; set; }


        public ESRMEvent()
        {
            Drivers = new List<Pilot>();
            Cars = new List<Car>();
            Races = new List<Race>();
            EventStatisitics = new EventStatistics();
        }
    }

    [DataContract]
    public class EventStatistics
    {
        [DataMember]
        List<PilotStatistics> DriversStats { get; set; }

        public EventStatistics()
        {
            DriversStats = new List<PilotStatistics>();
        }

    }
}
