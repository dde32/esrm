using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ESRM.Win
{
    public class FontManager : IDisposable
    {
        PrivateFontCollection pfc = new PrivateFontCollection();
        

        public FontManager()
        {
            try
            {
                AddCGFFont();
                AddEuroStileFont();
                AddEuroStileBoldFont();
                AddFireEyeFont();
                AddRadioStart();
                AddNFS();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (pfc != null)
                {
                    pfc.Dispose();
                    pfc = null;
                }
            }
        }
        private void AddCGFFont()
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Resources", "CGF Locust Resistance.ttf");
            pfc.AddFontFile(file);

        }

        private void AddEuroStileFont()
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Resources", "EUROSTI.TTF");
            pfc.AddFontFile(file);
        }
        private void AddEuroStileBoldFont()
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Resources", "EUROSTIB.TTF");
            pfc.AddFontFile(file);
        }

        private void AddFireEyeFont()
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Resources", "FireyeGF_3_Headline.ttf");
            pfc.AddFontFile(file);
        }
        private void AddRadioStart()
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Resources", "radio stars.ttf");
            pfc.AddFontFile(file);
        }
        private void AddNFS()
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Resources", "need-for-font.regular.ttf");
            pfc.AddFontFile(file);
        }

        

        //private byte[] GetFontResourceBytes(Assembly assembly, string fontResourceName)
        //{
        //    var resourceStream = assembly.GetManifestResourceStream(fontResourceName);
        //    if (resourceStream == null)
        //        throw new Exception(string.Format("Unable to find font '{0}' in embedded resources.", fontResourceName));
        //    var fontBytes = new byte[resourceStream.Length];
        //    resourceStream.Read(fontBytes, 0, (int)resourceStream.Length);
        //    resourceStream.Close();
        //    return fontBytes;



        //    //using (Stream fontStream = assembly.GetManifestResourceStream(fontResourceName))
        //    //{
        //    //    if (null == fontStream)
        //    //    {
        //    //        return;
        //    //    }

        //    //    int fontStreamLength = (int)fontStream.Length;

        //    //    IntPtr data = Marshal.AllocCoTaskMem(fontStreamLength);

        //    //    byte[] fontData = new byte[fontStreamLength];
        //    //    fontStream.Read(fontData, 0, fontStreamLength);

        //    //    Marshal.Copy(fontData, 0, data, fontStreamLength);

        //    //    pfc.AddMemoryFont(data, fontStreamLength);

        //    //    Marshal.FreeCoTaskMem(data);
        //    //}
        //}

        public Font GetCGFFont(float size, FontStyle style)
        {
            return new System.Drawing.Font(pfc.Families[0], size, style);
        }

        public Font GetEuroStyleFont(float size, FontStyle style)
        {
            return new System.Drawing.Font(pfc.Families[1], size, style);
        }

        public Font GetFireEyeFont(float size, FontStyle style)
        {
            return new System.Drawing.Font(pfc.Families[2], size, style);
        }
        public Font GetRadioStarFont(float size, FontStyle style)
        {
            return new System.Drawing.Font(pfc.Families[4], size, style);
        }
        public Font GetNFSFont(float size, FontStyle style)
        {
            return new System.Drawing.Font(pfc.Families[3], size, style);
        }

        public Font GetImpactFont(float size, FontStyle style)
        {
            return new System.Drawing.Font("Impact", size, style);
        }
    }

}
