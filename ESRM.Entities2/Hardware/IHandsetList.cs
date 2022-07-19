using System.Collections.Generic;

namespace ESRM.Entities
{
    public interface IHandsetList
    {
        List<IHandSet> HandSetList { get; set;}

        IHandSet Get(int id);
        bool IsTrackCallRunning();

        void PitStopRunning(int idx);
        void PitStopEnded(int idx);
    }
}