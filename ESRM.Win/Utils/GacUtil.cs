using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESRM.Win
{
    public static class GacUtil
    {
        public static bool IsAssemblyInGAC(string assemblyFullName)
        {
            try
            {
                return Assembly.ReflectionOnlyLoad(assemblyFullName)
                               .GlobalAssemblyCache;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool IsAssemblyInGAC(Assembly assembly)
        {
            return assembly.GlobalAssemblyCache;
        }
    }
}
