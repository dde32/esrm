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
    public partial class GaragePage : BasePage
    {

        public Car Car { get; set; }
        public Image currentSelectedImage { get; set; }
        BindingList<Car> _datasource;

        public GaragePage()
        {
            InitializeComponent();
            _datasource = new BindingList<Car>();
            CarsView.InitNewRow += CarsView_InitNewRow;
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
            foreach (Car c in appViewModel.Cars)
                _datasource.Add(c);

            grid.DataSource = _datasource;
            this.CarsView.ExpandAllGroups();
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
            DirectoryInfo destFolder = new DirectoryInfo(Path.Combine(Program.DataPath, "Images", "Cars"));
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
                CarsView.InvalidateRow(CarsView.FocusedRowHandle);
                CarsView.ValidateEditor();
                CarsView.RefreshRow(CurrentRowIdx().Value);

            }
        }

        public Car CurrentRow()
        {
            if (CarsView.SelectedRowsCount > 0)
                return (Car)CarsView.GetRow(CarsView.GetSelectedRows()[0]);
            else if (CarsView.RowCount > 0)
                return (Car)CarsView.GetRow(0);
            else return null;
        }

        private int? CurrentRowIdx()
        {
            if (CarsView.SelectedRowsCount > 0)
                return CarsView.GetSelectedRows()[0];
            else if (CarsView.RowCount > 0)
                return 0;
            else return null;
        }

        private void repositoryItemButtonDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (CarsView.RowCount > 0)
            {
                if (MessageBox.Show(string.Format(Textes.MessageConfirmDeleteCar, CurrentRow().Name), "ESRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CarsView.DeleteRow(CurrentRowIdx().Value);
                    CarsView.Invalidate();
                    CarsView.RefreshData();
                    Save();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Validate();
            CarsView.AddNewRow();
        }

        public void Save()
        {
            appViewModel.Cars.Clear();
            appViewModel.Cars.AddRange(_datasource);

            AppViewModel.SaveCars();
        }

        private void CarsView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CarsView.FocusedRowHandle = e.RowHandle;
            CarsView.FocusedColumn = colName;
            CarsView.EditingValue = colName;
            CarsView.ShowEditor();
        }

        private void View_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == colTitleBrake)
                e.Value = Textes.Brake;
            else if (e.Column == colTitleMaxP)
                e.Value = Textes.MaxPower;
            else if (e.Column == colTitleResistance)
                e.Value = Textes.Resistance;
            else if (e.Column == colTitleConsumption)
                e.Value = Textes.Consumption;
            else if (e.Column == colInCarProTitle)
                e.Value = "InCarPro";

        }
    }
}
