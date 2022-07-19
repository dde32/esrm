using ESRM.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace ESRM.GamePads
{
    public static class GamePadFactory
    {
        static bool _isInit;
        static Assembly _windowsGamingInputAssembly;

        public static GlobalGamePadHandSet GetGamePad(EsrmPlayerIndex index)
        {
            InitIfNeeded();

            IESRMGamePad gp = null;

            if (_windowsGamingInputAssembly != null)
            {
                Type gpType = _windowsGamingInputAssembly.GetType("ESRM.GamePadV2.ESRMGamePadv2");

                gp = Activator.CreateInstance(gpType, new object[] { index }) as IESRMGamePad;
            }
            else
            {
                gp = new ESRMGamePad(index);
            }

            GlobalGamePadHandSet result = new GlobalGamePadHandSet(gp);
            return result;
        }

        public static IESRMGamePad GetESRMGamePad(EsrmPlayerIndex index)
        {
            InitIfNeeded();

            IESRMGamePad gp = null;

            if (_windowsGamingInputAssembly != null)
            {
                Type gpType = _windowsGamingInputAssembly.GetType("ESRM.GamePadV2.ESRMGamePadv2");

                gp = Activator.CreateInstance(gpType, new object[] { index }) as IESRMGamePad;
            }
            else
            {
                gp = new ESRMGamePad(index);
            }

            return gp;
        }

        

        static public bool IsConnected(int gpIndex)
        {
            InitIfNeeded();

            if (_windowsGamingInputAssembly != null)
            { 
                Type gpType = _windowsGamingInputAssembly.GetType("ESRM.GamePadV2.ESRMGamePadv2");
                MethodInfo method = gpType.GetMethod("IsConnectedByIndex");
                var result = method.Invoke(null, new object[] { gpIndex });

                return (bool)result;
            }
            else
            {
                return ESRMGamePad.IsConnected(gpIndex);
            }
        }

        static public string GetAPIType()
        {
            InitIfNeeded();
            if (_windowsGamingInputAssembly != null)
                return "Windows.Gaming";
            else
                return "XInput";
        }


        static void InitIfNeeded()
        {
            if (_isInit)
                return;
            _isInit = true;

            try
            {
                if (IsWindowsGamingInputEnabled())
                {
                    if (_windowsGamingInputAssembly == null)
                        _windowsGamingInputAssembly = Assembly.LoadFrom("ESRM.GamePadV2.dll");
                }
            }
            catch(Exception ex)
            {

            }
        }

        //public static bool IsWindowsGamingInputEnabled()
        //{
        //    try
        //    {
        //       // Windows.ApplicationModel.Resources.Core.ResourceContext;
        //        if (ApiInformation.IsTypePresent("Windows.Gaming.Input.Gamepad"))
        //        {
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        static bool IsWindowsGamingInputEnabled()
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

            string productName = (string)reg.GetValue("ProductName");

            return productName.StartsWith("Windows 10") || Environment.OSVersion.Version.Major >= 10;
        }
    }
}
