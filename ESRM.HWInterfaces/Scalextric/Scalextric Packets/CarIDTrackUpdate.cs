using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ESRM.HWInterfaces.Scalextric
{
    public class CarIDTrackUpdate
    {
        public int CarID { get; set; }
        public bool GameTime { get; set; }
        public bool Invalid { get; set; }


        public CarIDTrackUpdate(byte data)
        {
            //CarID = BitConverter.ToUInt16(carBytes, 0) - 248; // - 248 car seuls les 3 premiers bits comptes tous les autres sont à 1 par défaut donc on doit retirer 248 du total.
            CarID = data - 248;

        }

        private int getIntFromBitArray(BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}
