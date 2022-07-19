using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using Portable.Licensing;

namespace ESRM.LicenceGenerator
{
    public partial class Form1 : Form
    {
        string _passPhrase  = "ESRM déchire tout";
        private const string privateKey = "MIICITAjBgoqhkiG9w0BDAEDMBUEEL4Fo7Po0W3AMEKUq0dlQfQCAQoEggH4gn0lmlug+BhfYskpGbztOPh09u154etk3fSp8ru8jrBvvPmn89OfLAmTNwim+TjnI8RkpoumhIefjTZbCGys7XRms6QUOyX2Bhj83rJRsikrloJq8r0SV8WfxfZBBw4GoAmTYg12vbzsE8Bz8nU60KxJSmv342Bsj5JzEE94vlWwntc7obt+EayTdBKD5pyFmefRCWybRTBQH7td7ny8Ve6VFoSIyTCpc22UrTKH2d5XtSWjLKe4B4r62J3MqN9ffLpDCXqPxhFlmuOeO1a2THFesBHuH3hP9uXnYeXBO4P1egBBlOPGKubbsJVqRcUgfHyI1qzuiVRywSjFfjsHw4BmYaPiUv7y7jnLR0j8tjeh1nCTK+H+hUk5pK23Uswdyn2yjym6ZEAPdZiRqz4/L13IsdDuX6qD6GEUa4ZhmS9FXsCzaYgszcubcg9rxwaeoYKWaqCNkT1dFOEBTnNA+KgnhghORkd1K9dOJbf0hfAFz8FPL3XyoUs+NBJCISQEyDmv8LgbFvNAmLiUxyIZkHFWolqojh8T6vZgYvWVc85q2F9igT9r6d/ZCtpeG3oP284vX0oLkgd5GsF/LSefBMHKynYtRl5/0UNQrAvXzK2180xayVTa/OOMUCBjRMBiBK+X7kvZAEmxF75nVoSc2WThnAhMq0KB";
        private const string publicKey = "MIIBKjCB4wYHKoZIzj0CATCB1wIBATAsBgcqhkjOPQEBAiEA/////wAAAAEAAAAAAAAAAAAAAAD///////////////8wWwQg/////wAAAAEAAAAAAAAAAAAAAAD///////////////wEIFrGNdiqOpPns+u9VXaYhrxlHQawzFOw9jvOPD4n0mBLAxUAxJ02CIbnBJNqZnjhE50mt4GffpAEIQNrF9Hy4SxCR/i85uVjpEDydwN9gS3rM6D0oTlF2JjClgIhAP////8AAAAA//////////+85vqtpxeehPO5ysL8YyVRAgEBA0IABLl/AUeTcObJXj1v8lQGF56oMyTTsce+juYmT4fuE+7QkuI+N7a/h1tQqQF+KrRnuoVHRW0/psQ69T9sl536kZk=";

        public Form1()
        {
            InitializeComponent();

            GenerateKeys();

            Guid macAddressGuid;
            NetworkInterface[] networkInterface = NetworkInterface.GetAllNetworkInterfaces();
            string id = networkInterface.FirstOrDefault().Id;
            Guid.TryParse(id, out macAddressGuid);
            edtId.Text = macAddressGuid.ToString();
        }

        public void GenerateKeys()
        {
             
            var keyGenerator = Portable.Licensing.Security.Cryptography.KeyGenerator.Create();
            var keyPair = keyGenerator.GenerateKeyPair();
            var privateKey = keyPair.ToEncryptedPrivateKeyString(_passPhrase);
            var publicKey = keyPair.ToPublicKeyString();           
        }

        public void GenerateTrialLicence()
        {
            Guid licenceId = Guid.Parse(edtId.Text);

            var license = Portable.Licensing.License.New().WithUniqueIdentifier(licenceId).As(LicenseType.Trial).WithProductFeatures(new Dictionary<string, string>  
                                    {  
                                        {"LapCountLimit", this.LapCountMax.Value.ToString()},  
                                        {"TimeLimit", this.TimeLimitMax.Value.ToString()},  
                                        {"TeamLimit", this.TeamsCountMax.Value.ToString()}, 
                                        {"TimeAttackLevelLimit", this.TAMaxLevel.Value.ToString()}  
                                    }).LicensedTo(edtEmail.Text , edtEmail.Text).CreateAndSignWithPrivateKey(privateKey, _passPhrase);

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(Path.Combine(folderBrowserDialog1.SelectedPath, "License.lic"), license.ToString(), Encoding.UTF8);
            }
        }

        private void btnSaveLicenceFile_Click(object sender, EventArgs e)
        {
            Guid licenceId = Guid.Parse(edtId.Text);
            var license = Portable.Licensing.License.New().WithUniqueIdentifier(licenceId).As(LicenseType.Standard).CreateAndSignWithPrivateKey(privateKey, _passPhrase);
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText( Path.Combine(folderBrowserDialog1.SelectedPath,"License.lic"), license.ToString(), Encoding.UTF8);
            }
        }

        private void btnSaveTrialLicence_Click(object sender, EventArgs e)
        {
            GenerateTrialLicence();
        }
    }
}
