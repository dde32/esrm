using ESRM.Entities;
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
    public partial class BeforeStartRaceDlg : Form
    {
        protected IESRMViewModel _appViewModel;

        public BeforeStartRaceDlg(IESRMViewModel appViewModel)
        {
            InitializeComponent();
            _appViewModel = appViewModel;
            lblConsign.Text = string.Format("{0} {1}{2}{3}", Textes.BeforeStartRaceConsign1, Environment.NewLine, Environment.NewLine, Textes.BeforeStartRaceConsign2);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnNotShowAgain_Click(object sender, EventArgs e)
        {
            _appViewModel.DigitalParams.ShowRaceStartConsign = !_appViewModel.DigitalParams.ShowRaceStartConsign;
            if (!_appViewModel.DigitalParams.ShowRaceStartConsign)
                btnNotShowAgain.ForeColor = Color.GreenYellow;
            else
                btnNotShowAgain.ForeColor = Color.White;
        }
    }
}
