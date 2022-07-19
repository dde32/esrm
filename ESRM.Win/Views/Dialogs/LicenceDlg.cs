using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace ESRM.Win
{
    public partial class LicenceDlg : Form
    {
        public string EditValue
        {
            get { return edtId.Text; }
        }

        public LicenceDlg(string text)
        {
            InitializeComponent();
            edtId.Text = text;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImportLicence(openFileDialog1.FileName);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(edtId.Text);
        }

        private void ImportLicence(string fileName)
        {
            // 1. on copie le fichier dans le dossier d'execution de l'application

            if (File.Exists(fileName))
            {
                //string destinationFile = Path.Combine(Application.StartupPath, "License.lic");
                string destinationFile = Path.Combine(Program.DataPath, "License.lic");
                if (File.Exists(destinationFile))
                    File.Delete(destinationFile);

                File.Copy(fileName, destinationFile);
                Program.InitLicence();
            }
        }

        private void EmailLicense()
        {
            //string mailto = "mailto: " + to + "&SUBJECT=" + subject + "?BODY=" + body ;
        }
    }

 
}
