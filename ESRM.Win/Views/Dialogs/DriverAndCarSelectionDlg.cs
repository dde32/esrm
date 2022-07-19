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
    public partial class DriverAndCarSelectionDlg : Form
    {

        protected IESRMViewModel AppViewModel
        {
            get;
            set;
        }


        public DriverAndCarSelectionDlg(IESRMViewModel appModel)
        {
            InitializeComponent();
            AppViewModel = appModel;
            driverAndCarSelectionPage.InitPage(AppViewModel);

        }


    }

 
}
