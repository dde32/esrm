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
    public partial class SelectCarDlg : Form
    {

        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }
        public Car Car { get; set; }
        public Image currentSelectedImage { get; set; }


        public SelectCarDlg(IESRMViewModel appModel)
        {
            InitializeComponent();
            AppViewModel = appModel;
            SetDlgSize();
            garagePage1.SetDatas(AppViewModel);

        }


        public void SetDlgSize()
        {
            this.Size = new Size(this.Width, Screen.GetBounds(this).Height - 100);
        }


        private void btnSelectOrNew_Click(object sender, EventArgs e)
        {
            panelSelect.Visible = !panelSelect.Visible;
            panelNew.Visible = !panelSelect.Visible;
           // DockPanelsAndSetButtonCaption();

        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            Car = garagePage1.CurrentRow();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
            SaveItems();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!panelNew.Visible)
            {
                Close();
            }
            else
            {
                btnSelectOrNew_Click(this, EventArgs.Empty);
            }
        }

        private void SaveItems()
        {
            garagePage1.Save();
        }

    }

 
}
