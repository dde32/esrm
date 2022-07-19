using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using ESRM.Win.Views;
using DevExpress.XtraEditors;
using System.IO;

namespace ESRM.Win.Panels
{
    public partial class SoundsParams : ScalableControl
    {
        IESRMViewModel _appViewModel;
        public IESRMViewModel AppViewModel
        {
            get { return _appViewModel; }
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        public SoundsParams()
        {
            InitializeComponent();
        }

        public void SetParams(IESRMViewModel appViewModel)
        {
           _appViewModel = appViewModel;
            DoBinding();
        }


        #region BINDING

        protected override void DoBinding()
        {
            base.DoBinding();

            foreach (Control c in panelFill.Controls)
            {
                int tag = Convert.ToInt32(c.Tag != null ? c.Tag : 0);

                if (c is ESRMButton && c.Tag != null)
                {
                    if (c.Name.Contains("File"))
                        (c as ESRMButton).Visible = _appViewModel.SoundSettings.Get((SoundEnum)tag).UseSound;
                    else
                        (c as ESRMButton).ForeColor = _appViewModel.SoundSettings.Get((SoundEnum)tag).UseSound ? Color.YellowGreen : Color.Red;
                }
                else if (c is Label && c.Tag != null)
                {
                    SoundSetting setting = _appViewModel.SoundSettings.Get((SoundEnum)tag);

                    (c as Label).Text = !string.IsNullOrEmpty(setting.SoundPath) ? Path.GetFileName(setting.SoundPath) : string.Empty;
                    (c as Label).Visible = setting.UseSound;
                }
            }
        }


        #endregion


        private void EnableSound_Click(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32((sender as ESRMButton).Tag);
            _appViewModel.SoundSettings.SwitchUseSound((SoundEnum)tag);
            DoBinding();
        }

        private void BrowseFile_Click(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32((sender as ESRMButton).Tag);
            string filePath = _appViewModel.SoundSettings.Get((SoundEnum)tag).SoundPath;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = Path.GetDirectoryName(filePath);
                if (dlg.ShowDialog() == DialogResult.OK)
                    _appViewModel.SoundSettings.SetSoundPath((SoundEnum)tag, dlg.FileName);
                dlg.Dispose();
            }
                DoBinding();

        }

        private void PlaySound(object sender, EventArgs e)
        {

        }
    }
}
