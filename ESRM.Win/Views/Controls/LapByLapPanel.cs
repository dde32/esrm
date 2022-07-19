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
    public partial class LapByLapPanel : ScalableControl
    {
        List<Lap> _datas;


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

        public LapByLapPanel()
        {
            InitializeComponent();
        }

        public void SetDatas(string teamName, string pilotName,List<Lap> datas)
        {
            lblPilotName.Text = string.Format("{0} - {1}", teamName, pilotName);
            
            _datas = datas.FindAll(l => l.Pilot.Name == pilotName);

            gridControl1.DataSource = _datas;
            gridView1.ExpandAllGroups();
        }

        public void ExportToXls(string rootpath)
        {
            string filename = string.Format("ESRM-PilotStats-{0}-{1}-{2}.xls", lblPilotName.Text , DateTime.Now.ToLongDateString(), DateTime.Now.ToString("hh-mm"));
            string filepath = Path.Combine(rootpath, filename);
            gridControl1.ExportToXls(filepath);

        }



    }
}
