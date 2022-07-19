using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ESRM.Mobile.Droid
{
//`   public class FontSizeProvider : IFontSizeProvider
//    {

//        public IFontManager FontManager { get; private set; }
//        public IDisplay Display { get; private set; }

//        public FontSizeProvider(IFontManager fontManager, IDisplay display)
//        {
//            FontManager = fontManager;
//            Display = display;


//            var largeFont = Font.SystemFontOfSize(NamedSize.Large);
//            var extraLargeHeight = fontManager.GetHeight(largeFont) * (100 / (Display.Xdpi)) * 3; // scale up
//            _extraLarge = display.HeightRequestInInches(extraLargeHeight);

//            var largeHeight = fontManager.GetHeight(largeFont);
//            var large = display.HeightRequestInInches(largeHeight);

//            var mediumFont = Font.SystemFontOfSize(NamedSize.Medium);
//            var mediumHeight = fontManager.GetHeight(mediumFont);
//            var medium = display.HeightRequestInInches(mediumHeight);

//            Device.GetNamedSize(NamedSize.Large, typeof(Label)), Device.GetNamedSize(NamedSize.Medium, typeof(Label))));
//        }

//        #region IFontSizeProvider implementation

//        private readonly double _extraLarge;
//        public double ExtraLarge
//        {
//            get
//            {
//                return _extraLarge;
//            }
//        }

//        #endregion
//    }`
}