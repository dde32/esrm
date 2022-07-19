using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ESRM.Entities
{
    public class Tools
    {
        public static byte[] LoadFromResource(string name)
        {
            string[] test = typeof(Tools).Assembly.GetManifestResourceNames();
            using (Stream stream = typeof(Tools).Assembly.GetManifestResourceStream( "ESRM.Entities." + name))
            {
                MemoryStream buffer = new MemoryStream();
                stream.CopyTo(buffer);

                return buffer.ToArray();
            }
        }

    }
}
