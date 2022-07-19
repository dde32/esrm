/// -------------------------------------------------------------------------------------------------------
/// This file is part of Carrera .NET API Project. It is subject to the license terms in the LICENSE file 
/// found in the top-level directory of this distribution and at http://carreradotnet.codeplex.com/license. 
/// 
/// No part of Carrera .NET API Project, including this file, may be copied, modified, propagated, 
/// or distributed except according to the terms contained in the LICENSE file.
/// -------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarreraDotNet
{
    public class FinishLinePassedEventArgs : EventArgs
    {
        /// <summary>Gets the number of the car, that passed the finish line.</summary>
        /// <value>Number of the car from 1-6, with 7 as Ghostcar and 8 as Pacecar.</value>
        public int Car { get; internal set; }

        /// <summary>Gets the lap time of the car.</summary>
        /// <value>If a car passes first time the finish line, lap time is 0. 
        /// Otherwise it is the time since the last finish line crossing in milliseconds.</value>
        public int LapTime { get; internal set; }

        /// <summary>Initializes a new instance of the <see cref="FinishLinePassedEventArgs" /> class.</summary>
        /// <param name="car">Number of the car, that passed the finish line.</param>
        /// <param name="lapTime">Time since the last finish line crossing of the car in milliseconds.</param>
        public FinishLinePassedEventArgs(int car, int lapTime)
        {
            this.Car = car;
            this.LapTime = lapTime;
        }        
    }
}
