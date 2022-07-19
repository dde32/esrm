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
    public class BlackBox : AbstractControlUnit
    {
        private bool isRaceStarted = false;
        private Dictionary<int, int> carLapTimes = new Dictionary<int, int>();

        /// <summary>Occurs when a car passes the finish line.</summary>
        public override event AbstractControlUnit.FinishLinePassedHandler FinishLinePassed;

        /// <summary>Occurs when a race is started.</summary>
        public override event AbstractControlUnit.RaceStartedHandler RaceStarted;

        /// <summary>Occurs when a car passes a sector.</summary>        
        public override event AbstractControlUnit.SectorPassedHandler SectorPassed;

        private int DetermineLapTime(int car, int counterValue)
        {
            if (carLapTimes.ContainsKey(car))
            {
                int lapTime = counterValue - carLapTimes[car];
                carLapTimes[car] = counterValue;
                return lapTime;
            }
            else
            {
                carLapTimes.Add(car, counterValue);
                return 0;
            }           
        }

        /// <summary>
        /// Parses the input applying the BB protocol.
        /// </summary>
        /// <param name="input">The read input as <see cref="StringBuilder"/>.</param>
        /// <exception cref="System.Exception">ERROR!</exception>
        public override void ParseInput(StringBuilder input)
        {
            if (input[0] == '0')
            {
                if (input.Length < 7)
                    return;

                if (input[6] != '$')
                {
                    input.Length = 0;
                    throw new Exception("ERROR!");
                }

                char[] asciiData = new char[5];
                input.CopyTo(1, asciiData, 0, 5);
                this.VersionNumber = GetVersionNumber(asciiData);
                input.Remove(0, 7);
                return;
            }

            if (input[0] == '?')
            {
                if (input.Length > 1)
                {
                    if (input[1] == '#')
                    {
                        input.Remove(0, 2);
                        return;
                    }

                    if (input.Length < 12)
                    {
                        return;
                    }

                    if (input[11] != '$')
                    {
                        input.Length = 0;
                        throw new Exception("ERROR!");
                    }

                    if (FinishLinePassed != null)
                    {
                        int car = int.Parse(input[1].ToString());                        
                        int counterValue;

                        char[] asciiTime = new char[8];
                        input.CopyTo(2, asciiTime, 0, 8);
                        counterValue = GetTime(asciiTime);

                        FinishLinePassed(this, new FinishLinePassedEventArgs(car, DetermineLapTime(car,counterValue)));
                    }

                    input.Remove(0, 12);
                }
                return;
            }

            if (input[0] == 'H')
            {
                if (input.Length < 4)
                    return;

                if (input[3] != '$')
                {
                    input.Length = 0;
                    throw new Exception("ERROR!");
                }

                if (input[1] == '0')
                {
                    if (!isRaceStarted)
                    {
                        isRaceStarted = true;
                        if (RaceStarted != null)
                        {
                            RaceStarted();
                        }
                    }
                }

                if (input[1] == '1')
                {
                    isRaceStarted = false;
                }

                input.Remove(0, 4);
                return;
            }
        }
    }
}
