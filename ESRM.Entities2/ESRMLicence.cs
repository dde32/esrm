using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portable.Licensing;

namespace ESRM.Entities
{
    public class ESRMLicence 
    {
        private  Portable.Licensing.License _licence;

        private bool _isTrial;

        public bool IsTrial
        {
            get
            {
                return (_isTrial && _licence == null) || (_licence != null && _licence.Type == LicenseType.Trial);
            }
        }

        public string LimitationDescription
        {
            get { return string.Format(" {0} {1}, {2} {3}, {4} {5}", LapCountLimit, Textes.MaxLaps, TimeLimit, Textes.TimeLimit, TeamLimit,Textes.MaxTeams); }
        }

        public int? LapCountLimit 
        { 
            get
            {
                if (!IsTrial && _licence == null)
                    return null;
                    if (IsTrial)
                        return 10;

                if (_licence.ProductFeatures != null && _licence.ProductFeatures.Contains("LapCountLimit"))
                {
                    string value  =  _licence.ProductFeatures.Get("LapCountLimit");
                    if (!string.IsNullOrEmpty(value))
                        return Convert.ToInt16(value);
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        public TimeSpan? TimeLimit
        {
            get
            {
                if (!IsTrial && _licence == null)
                    return null;
                if (IsTrial)
                    return new TimeSpan(0, 2,0);

                if (_licence.ProductFeatures != null && _licence.ProductFeatures.Contains("TimeLimit"))
                {
                    string value = _licence.ProductFeatures.Get("TimeLimit");
                    if (!string.IsNullOrEmpty(value))
                        return TimeSpan.Parse(value);
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        public int? TeamLimit
        {
            get
            {
                if (!IsTrial && _licence == null)
                    return null;
                if (IsTrial)
                    return 4;

                if (_licence.ProductFeatures != null && _licence.ProductFeatures.Contains("TeamLimit"))
                {
                    string value = _licence.ProductFeatures.Get("TeamLimit");
                    if (!string.IsNullOrEmpty(value))
                        return Convert.ToInt16(value);
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        public int? TimeAttackLevelLimit
        {
            get
            {
                if (!IsTrial && _licence == null)
                    return null;
                if (IsTrial)
                    return 2;

                if (_licence.ProductFeatures != null && _licence.ProductFeatures.Contains("TimeAttackLevelLimit"))
                {
                    string value = _licence.ProductFeatures.Get("TimeAttackLevelLimit");
                    if (!string.IsNullOrEmpty(value))
                        return Convert.ToInt16(value);
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        public ESRMLicence(Portable.Licensing.License lic,bool isTrial = true)
        {
            _licence = lic;
            _isTrial = isTrial;
        }

         
    }
}
