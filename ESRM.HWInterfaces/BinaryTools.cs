using System;
using System.Collections;

namespace ESRM.HWInterfaces
{
    public class BinaryTools
    {
        public static BitArray ToBinary(int numeral)
        {
            return new BitArray(new[] { numeral });
        }

        public static int ToNumeral(BitArray binary)
        {
            if (binary == null)
                throw new ArgumentNullException("binary");
            if (binary.Length > 32)
                throw new ArgumentException("must be at most 32 bits long");

            var result = new int[1];
            binary.CopyTo(result, 0);
            return result[0];
        }

        public static byte ToByte(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }
    }
}
