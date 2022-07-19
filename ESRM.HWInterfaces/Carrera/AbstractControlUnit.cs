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
    public abstract class AbstractControlUnit : IPcUnit
    {        
        public delegate void RaceStartedHandler();        
        public delegate void FinishLinePassedHandler(object sender, FinishLinePassedEventArgs e);
        public delegate void SectorPassedHandler(object sender, SectorPassedEventArgs e);

        public abstract event FinishLinePassedHandler FinishLinePassed;
        public abstract event RaceStartedHandler RaceStarted;
        public abstract event SectorPassedHandler SectorPassed;

        public abstract void ParseInput(StringBuilder input);

        /// <summary>Gets the version number of the connected Control Unit.</summary>
        /// <value>The combined Hardware and Software version number.</value>
        /// <remarks>The version number gets read at the Connect() call. It is empty if the Pc Unit is not connected.</remarks>
        public string VersionNumber { get; internal set; }

        /// <summary>
        /// Exctracts the version number from the ASCII input.
        /// </summary>
        /// <param name="asciiData">The ASCII data.</param>
        /// <returns>The version numver of the Control Unit as string.</returns>
        protected string GetVersionNumber(char[] asciiData)
        {
            if (!IsChecksumValid(asciiData))
                return string.Empty;

            return new string(asciiData, 0, 4);
        }

        /// <summary>
        /// Exctracts the timestamp of the Control Unit from the ASCII input.
        /// </summary>
        /// <param name="asciiData">The ASCII data.</param>
        /// <returns>The timestamp of the Control Unit as integer value.</returns>
        protected int GetTime(char[] asciiData)
        {
            byte[] time = new byte[8];
            for (int i = 0; i < asciiData.Length; i++)
            {
                time[i] = Convert.ToByte(asciiData[i] - 0x30);
            }

            int counterValue = (time[1] << 28) | (time[0] << 24) | (time[3] << 20) | (time[2] << 16) | (time[5] << 12) | (time[4] << 8) | (time[7] << 4) | time[6];

            return counterValue;
        }

        /// <summary>
        /// Determines whether the checksum of the specified ASCII data is valid.
        /// </summary>
        /// <param name="asciiData">The ASCII data.</param>
        /// <returns>
        ///   <c>true</c> if the checksum of the specified ASCII data is valid; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsChecksumValid(char[] asciiData)
        {
            int sum = 0;
            char checksum = asciiData[asciiData.Length - 1];

            for (int i = 0; i < asciiData.Length - 1; i++)
            {
                if(asciiData[i] >=  0x30)
                {
                    sum += Convert.ToByte(asciiData[i] - 0x30);
                }
                else
                {
                    sum += Convert.ToByte(asciiData[i]);
                }
            }

            return (checksum == Convert.ToChar((sum & 0xF) | 0x30));
        }
    }
}
