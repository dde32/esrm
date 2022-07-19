using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using System.Windows.Threading;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System.IO;

namespace ESRM.Win.Views
{
    public partial class PilotPage : BasePage
    {

        public Pilot Pilot { get; set; }
        public Image currentSelectedImage { get; set; }
        BindingList<Pilot> _datasource;

        public PilotPage()
        {
            InitializeComponent();
            _datasource = new BindingList<Pilot>();
            PilotsView.InitNewRow += PilotsView_InitNewRow;
            colGroup.Group();
        }



        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);
            colGroup.UnGroup();

            SetGridDataSource();
        }

        public void SetDatas(IESRMViewModel datas)
        {
            this.appViewModel = datas;

            SetGridDataSource();
        }

        void SetGridDataSource()
        {

            _datasource.Clear();
            foreach (Pilot c in appViewModel.Pilots)
                _datasource.Add(c);

            grid.DataSource = _datasource;
            this.PilotsView.ExpandAllGroups();
        }

        public override void OnNavigatedFrom(INavigationArgs args)
        {
            Save();
            base.OnNavigatedFrom(args);
        }


        protected override void btnMouseHover(object sender, EventArgs e)
        {
            base.btnMouseHover(sender, e);
        }

        protected override void btnMouseLeave(object sender, EventArgs e)
        {
            base.btnMouseLeave(sender, e);
        }

        private void repositoryItemButtonSelectImage_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DirectoryInfo destFolder = new DirectoryInfo(Path.Combine(Program.DataPath, "Images", "Pilotes"));
            openFileDialog1.InitialDirectory = destFolder.FullName;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo finfo = new FileInfo(openFileDialog1.FileName);
                string destinationFile = Path.Combine(destFolder.FullName, finfo.Name);
                if (!Directory.Exists(destFolder.FullName))
                    Directory.CreateDirectory(destFolder.FullName);
                if (openFileDialog1.FileName != destinationFile)
                    File.Copy(openFileDialog1.FileName, destinationFile, true);
                Image newImage = new Bitmap(destinationFile);
                CurrentRow().Image = ImageHelper.ImageToByteArray(newImage);
                PilotsView.Invalidate();
                PilotsView.RefreshRow(CurrentRowIdx().Value);
            }
        }

        public Pilot CurrentRow()
        {
            if (PilotsView.SelectedRowsCount > 0)
                return (Pilot)PilotsView.GetRow(PilotsView.GetSelectedRows()[0]);
            else if(PilotsView.RowCount > 0)
                return (Pilot)PilotsView.GetRow(0);
            else return null;
        }

        private int? CurrentRowIdx()
        {
            if (PilotsView.SelectedRowsCount > 0)
                return PilotsView.GetSelectedRows()[0];
            else if (PilotsView.RowCount > 0)
                return 0;
            else return null;
        }

        private void repositoryItemButtonDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (PilotsView.RowCount > 0)
            {
                if (MessageBox.Show(string.Format(Textes.MessageConfirmDeleteCar, CurrentRow().Name),"ESRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PilotsView.DeleteRow(CurrentRowIdx().Value);
                    PilotsView.Invalidate();
                    PilotsView.RefreshData();
                    Save();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PilotsView.AddNewRow();
        }

        private void PilotsView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            PilotsView.FocusedColumn = colName;
            PilotsView.EditingValue = colName;
            PilotsView.ShowEditor();
        }

        public void Save()
        {
            appViewModel.Pilots.Clear();
            appViewModel.Pilots.AddRange(_datasource);
            AppViewModel.SavePilots();
        }

        private void PilotsView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            // affichage du nom de l'équipe et ID du handset
            if (e.Column == colName && e.RowHandle < PilotsView.RowCount)
            {
                 e.Appearance.ForeColor = Color.FromArgb((PilotsView.GetRow(e.RowHandle) as Pilot).Color);
            }

        }
    }
}
