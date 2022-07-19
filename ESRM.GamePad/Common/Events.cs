using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESRM.GamePads.Common
{
    public delegate void GamePadTriggerventHandler(object sender, GamePadTriggerEventArgs e);
    
    public class GamePadTriggerEventArgs : EventArgs
    {
        public double Value { get; set; }
        public GamePadTriggerEventArgs(double value)
        {
            Value = value;
        }
    }

}
