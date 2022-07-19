using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using ESRM.Entities;

namespace ESRM.HWInterfaces
{
    public class TimerForPitStop : TimerForHandSet
    {
        public int LaneId
        {
            get{return base.HandSetAssociated.LaneId; }
        }

        public TimerForPitStop(HandSet handSetAssociated) : base(handSetAssociated)
        {
            Interval = GlobalDatas.PITSTOPREFRESHINTERVAL;
        }

        protected override void TimerForHandSet_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            base.TimerForHandSet_Elapsed(sender, e);

            _handSetAssociated.ProcessDoPitStop();

        }
    }

    public class TimerForHandSet_Braking : TimerForHandSet
    {
        public TimerForHandSet_Braking(HandSet handSetAssociated):base(handSetAssociated)
        {
        }

        protected override void TimerForHandSet_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            base.TimerForHandSet_Elapsed(sender, e);

            if (_handSetAssociated.DigitalParams.TrackCallMethod != TrackCallMethodEnum.None || _handSetAssociated.DigitalParams.PitInMethod != PitInMethodEnum.None)
            {
                _handSetAssociated.AddBrakingDuration(new TimeSpan(0, 0, 0, 0, (int)Interval));
            }
        }
    }

    public class TimerForHandSet_LaneChanging : TimerForHandSet
    {
        public TimerForHandSet_LaneChanging(HandSet handSetAssociated)
            : base(handSetAssociated)
        {
        }


        protected override void TimerForHandSet_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            base.TimerForHandSet_Elapsed(sender, e);

            if (_handSetAssociated.DigitalParams.TrackCallMethod != TrackCallMethodEnum.None || _handSetAssociated.DigitalParams.PitInMethod != PitInMethodEnum.None)
            {
                _handSetAssociated.AddLCDuration(new TimeSpan(0,0,0,0,(int)Interval));
            }
        }
    }

    public class TimerForHandSet : System.Timers.Timer, IDisposable
    {
        protected HandSet _handSetAssociated;
        public HandSet HandSetAssociated
        {
            get { return _handSetAssociated; }
        }

        public TimerForHandSet()
        {
            Interval = 500;
            this.Elapsed += TimerForHandSet_Elapsed;
        }



        public TimerForHandSet(HandSet handSetAssociated )
        {
            _handSetAssociated = handSetAssociated;
            Interval = 500;
            this.Elapsed += TimerForHandSet_Elapsed;
        }

         #region DISPOSE
        ~TimerForHandSet()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                _handSetAssociated = null;
            }
        }
        #endregion


        public void StartIfNeeded()
        {
            if (!this.Enabled && (_handSetAssociated.DigitalParams.TrackCallMethod != TrackCallMethodEnum.None || _handSetAssociated.DigitalParams.PitInMethod != PitInMethodEnum.None))
            {
                Start();
            }
        }


        protected virtual void TimerForHandSet_Tick(object sender, EventArgs e)
        {

        }

        protected virtual  void TimerForHandSet_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
        }

    }
}
