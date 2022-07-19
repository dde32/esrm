using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESRM.Entities
{
    public class PBReceiveDataEventArgs : EventArgs
    {
        public string Datas { get; set; }
        public object DataPacket { get; set; }
        public PBReceiveDataEventArgs(string datas,object dataPacket)
        {
            Datas = datas;
            DataPacket = dataPacket;
        }
    }

    public class LaneIdEventArgs : EventArgs
    {
        public int LaneId { get; set; }
        public LaneIdEventArgs(int id)
        {
            LaneId = id;
        }
    }


    public class TeamIdEventArgs : EventArgs
    {
        int _laneId;
        public int LaneId { get { return _laneId; } }

        public TeamIdEventArgs(int laneId)
        {
            _laneId = laneId;
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        string _error;
        public string Error { get { return _error; } }

        public ErrorEventArgs(string error)
        {
            _error = error;
        }
    }

    public class TeamIdChangedEventArgs : EventArgs
    {
        int _oldLaneId;
        int _newLaneId;
        public int OldLaneId { get { return _oldLaneId; } }
        public int NewLaneId { get { return _newLaneId; } }

        public TeamIdChangedEventArgs(int oldLaneId,int newLaneId)
        {
            _oldLaneId = oldLaneId;
            _newLaneId = newLaneId;
        }
    }


   public class ThrottleInfosRecordedEventArgs : EventArgs
   {
       int _laneId;
       TimeSpan _passTime;

       public int LaneId { get { return _laneId; } }
       public TimeSpan PassTime { get { return _passTime; } }

       public ThrottleInfosRecordedEventArgs(int laneId, TimeSpan passTime)
       {
           _laneId = laneId;
           _passTime = passTime;
       }
   }

    public class ThrottleParsedEventArgs : EventArgs
    {
        int _laneId;
        int? _throttleValue;

        public int LaneId { get { return _laneId; } }
        public int? ThrotthleValue { get { return _throttleValue; } }

        public ThrottleParsedEventArgs(int laneId, int? throttleValue)
        {
            _laneId = laneId;
            _throttleValue = throttleValue;
        }
    }

    public class LapEndedEventArgs : EventArgs
    {
        int _laneId;
        TimeSpan _passTime;
        //int? _throttleValue;
        //List<HandSetThrotthleInfo> _lapThrotthleInfos;

        public int LaneId { get { return _laneId; } }
        public TimeSpan PassTime { get { return _passTime; } }

        public LapEndedEventArgs(int laneId, TimeSpan passTime)
        {
            _laneId = laneId;
            _passTime = passTime;
        }
    }
}
