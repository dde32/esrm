/// -------------------------------------------------------------------------------------------------------
/// This file is part of Carrera .NET API Project. It is subject to the license terms in the LICENSE file 
/// found in the top-level directory of this distribution and at http://carreradotnet.codeplex.com/license. 
/// 
/// No part of Carrera .NET API Project, including this file, may be copied, modified, propagated, 
/// or distributed except according to the terms contained in the LICENSE file.
/// -------------------------------------------------------------------------------------------------------

using System;
namespace CarreraDotNet
{
    interface IPcUnit
    {
        /// <summary>Occurs when a car passes the finish line.</summary>
        event AbstractControlUnit.FinishLinePassedHandler FinishLinePassed;

        /// <summary>Occurs when a race is started.</summary>
        event AbstractControlUnit.RaceStartedHandler RaceStarted;

        /// <summary>Occurs when a car passes a sector.</summary>
        event AbstractControlUnit.SectorPassedHandler SectorPassed;

        /// <summary>Gets the version number of the connected Control Unit.</summary>
        /// <value>The combined Hardware and Software version number.</value>
        /// <remarks>The version number gets read at the Connect() call. It is empty if the Pc Unit is not connected.</remarks>
        string VersionNumber { get; }
    }
}
