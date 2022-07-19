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
    public partial class RecordsForm : Form
    {

        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }

        public RecordsForm()
        {
            InitializeComponent();
        }

        public RecordsForm(IESRMViewModel appViewModel)
        {
            InitializeComponent();
            AppViewModel = appViewModel;
            SetDlgSize();
            gridRecords.DataSource = AppViewModel.Records;
        }
        public void SetDlgSize()
        {
            this.Size = new Size(this.Width, Screen.GetBounds(this).Height - 100);
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            AppViewModel.SaveRecords();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
                Close();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridViewRecords.DeleteSelectedRows();
        }
    }

 
}
