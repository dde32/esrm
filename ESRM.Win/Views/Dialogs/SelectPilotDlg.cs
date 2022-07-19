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
using ESRM.Entities;

namespace ESRM.Win
{
    public partial class SelectPilotDlg : Form
    {

        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }
        public Pilot Pilot { get; set; }
        public Image currentSelectedImage { get; set; }


        public SelectPilotDlg(IESRMViewModel appModel)
        {
            InitializeComponent();
            AppViewModel = appModel;
            SetDlgSize();
            pilotPage1.SetDatas(AppViewModel);

            panelSelect.Visible = true;
        }


        public void SetDlgSize()
        {
            this.Size = new Size(this.Width, Screen.GetBounds(this).Height - 100);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Pilot = pilotPage1.CurrentRow();
            SavePilotes();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SavePilotes()
        {
            pilotPage1.Save();
        }
    }

 
}
