using ESRM.Entities;
using System;
using System.Collections.Generic;


namespace ESRM.HWInterfaces
{
    public class HandsetList : IDisposable, IHandsetList
    {
        #region MATERIEL

        public List<IHandSet> HandSetList { get; set; }

        #endregion

        public bool IsTrackCallRunning()
        {
            foreach (IHandSet hs in HandSetList)
            {
                if (hs.TrackCallRunning) return true;
            }

            return false;
        }

        public HandsetList(IDigitalParamsBase digitalParams,int HandSetCount)
        {
            HandSetList = new List<IHandSet>();

            for (int i = 0; i < HandSetCount; i++)
            {
                HandSetList.Add(new HandSet(digitalParams, i+1));
            }
        }

        public IHandSet Get(int id)
        {
            if (HandSetList.Count >= id)
                return HandSetList[id - 1];
            else
                return null;
        }

        public void PitStopRunning(int Laneid)
        {
            if (HandSetList.Count >= Laneid)
            {
                HandSetList[Laneid - 1].PitStopRunning = true;
                HandSetList[Laneid - 1].CanDoPitStop = true;
            }
        }
        public void PitStopEnded(int Laneid)
        {
            if (HandSetList.Count >= Laneid)
            {
                HandSetList[Laneid - 1].PitStopRunning = false;
            }
        }


        #region DISPOSE
        ~HandsetList()
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
                for (int i = 0; i < HandSetList.Count;i++)
                {
                    if (HandSetList[i] != null)
                    {
                        HandSetList[i].Dispose();
                        HandSetList[i] = null;
                    }
                }
                HandSetList.Clear();
            }
        }
        #endregion


    }





}
