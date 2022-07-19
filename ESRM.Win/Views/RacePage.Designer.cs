using DevExpress.XtraEditors;
using ESRM.Win.Controls.BaseControls;
using System.Drawing;
using System.Windows.Forms;

namespace ESRM.Win.Views
{
    partial class RacePage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RacePage));
            this.colBestLap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.raceGrid = new ESRM.Win.Controls.BaseControls.ESRMGrid();
            this.classicRaceView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPosition = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPilote = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEditPilotName = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colGap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colImagePilote = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPicturePilot = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colLapCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEditLapCount = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colMandatoryLeft = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.bandLaps = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colImageHealth = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPicturePitStopSelection = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colHealth = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemProgressBarCar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.colImageFuel = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFuel = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemProgressBarFuel = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.colImageTires = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTires = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemProgressBarTires = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.colFiller = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colLastLap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCurrentTires = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colImageState = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemImageStates = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colPitStopSelectionImage = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandCarImage = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCurrentCurves = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPitStopSelectionTitle = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colImageCar = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemPictureCar = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colPitStopAction = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemImagePitStop = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.stateImageList = new System.Windows.Forms.ImageList(this.components);
            this.panelLeft = new DevExpress.XtraEditors.PanelControl();
            this.panelWeatherAndTires = new DevExpress.XtraEditors.PanelControl();
            this.panelWeahter = new DevExpress.XtraEditors.PanelControl();
            this.panelCurrentWeather = new DevExpress.XtraEditors.PanelControl();
            this.pbWeather = new DevExpress.XtraEditors.PictureEdit();
            this.lblTemp = new System.Windows.Forms.Label();
            this.panelForecast = new DevExpress.XtraEditors.PanelControl();
            this.pbNextWeather = new DevExpress.XtraEditors.PictureEdit();
            this.lblForecast = new System.Windows.Forms.Label();
            this.panelTires = new DevExpress.XtraEditors.PanelControl();
            this.pbOptimalTires = new DevExpress.XtraEditors.PictureEdit();
            this.panelTemperatures = new DevExpress.XtraEditors.PanelControl();
            this.lblTrackTemperature = new System.Windows.Forms.Label();
            this.panelButtons = new DevExpress.XtraEditors.PanelControl();
            this.panelSeparateur2 = new DevExpress.XtraEditors.PanelControl();
            this.pbStart = new DevExpress.XtraEditors.PictureEdit();
            this.pbStop = new DevExpress.XtraEditors.PictureEdit();
            this.btnGreenFlag = new ESRM.Win.ESRMButton();
            this.panelTitle = new DevExpress.XtraEditors.PanelControl();
            this.labelRaceTime = new System.Windows.Forms.Label();
            this.labelLapsCount = new System.Windows.Forms.Label();
            this.panelControlFlag = new DevExpress.XtraEditors.PanelControl();
            this.pbFlag = new DevExpress.XtraEditors.PictureEdit();
            this.panelTests = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.TiresImageList = new System.Windows.Forms.ImageList(this.components);
            this.WeatherImageList = new System.Windows.Forms.ImageList(this.components);
            this.headerPanel = new DevExpress.XtraEditors.PanelControl();
            this.lblRaceInformation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.raceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicRaceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditPilotName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPicturePilot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditLapCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPicturePitStopSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBarCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBarFuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBarTires)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImagePitStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelWeatherAndTires)).BeginInit();
            this.panelWeatherAndTires.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelWeahter)).BeginInit();
            this.panelWeahter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelCurrentWeather)).BeginInit();
            this.panelCurrentWeather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeather.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelForecast)).BeginInit();
            this.panelForecast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextWeather.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTires)).BeginInit();
            this.panelTires.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOptimalTires.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTemperatures)).BeginInit();
            this.panelTemperatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).BeginInit();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSeparateur2)).BeginInit();
            this.panelSeparateur2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).BeginInit();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlFlag)).BeginInit();
            this.panelControlFlag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTests)).BeginInit();
            this.panelTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // colBestLap
            // 
            this.colBestLap.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colBestLap.AppearanceCell.Font")));
            this.colBestLap.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colBestLap.AppearanceCell.ForeColor")));
            this.colBestLap.AppearanceCell.Options.UseFont = true;
            this.colBestLap.AppearanceCell.Options.UseForeColor = true;
            this.colBestLap.AppearanceCell.Options.UseTextOptions = true;
            this.colBestLap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBestLap.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colBestLap, "colBestLap");
            this.colBestLap.DisplayFormat.FormatString = "ss:mm";
            this.colBestLap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBestLap.FieldName = "BestLapForUI";
            this.colBestLap.Name = "colBestLap";
            this.colBestLap.RowCount = 3;
            this.colBestLap.RowIndex = 3;
            // 
            // raceGrid
            // 
            this.raceGrid.BackgroundImage = global::ESRM.Win.Images.background;
            resources.ApplyResources(this.raceGrid, "raceGrid");
            this.raceGrid.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("raceGrid.EmbeddedNavigator.Margin")));
            this.raceGrid.LookAndFeel.SkinName = "Darkroom";
            this.raceGrid.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.raceGrid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.raceGrid.MainView = this.classicRaceView;
            this.raceGrid.Name = "raceGrid";
            this.raceGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBarFuel,
            this.repositoryItemPicturePilot,
            this.repositoryItemProgressBarTires,
            this.repositoryItemProgressBarCar,
            this.repositoryItemImageStates,
            this.repositoryItemMemoEditLapCount,
            this.repositoryItemImagePitStop,
            this.repositoryItemPicturePitStopSelection,
            this.repositoryItemTextEdit1,
            this.repositoryItemPictureCar,
            this.repositoryItemMemoEditPilotName,
            this.repositoryItemMemoEdit1});
            this.raceGrid.UseDisabledStatePainter = false;
            this.raceGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.classicRaceView});
            this.raceGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.raceGrid_KeyPress);
            // 
            // classicRaceView
            // 
            this.classicRaceView.ActiveFilterEnabled = false;
            this.classicRaceView.Appearance.Empty.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.Empty.BackColor")));
            this.classicRaceView.Appearance.Empty.Options.UseBackColor = true;
            this.classicRaceView.Appearance.Row.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.Row.BackColor")));
            this.classicRaceView.Appearance.Row.Options.UseBackColor = true;
            this.classicRaceView.Appearance.RowSeparator.BackColor = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.RowSeparator.BackColor")));
            this.classicRaceView.Appearance.RowSeparator.BackColor2 = ((System.Drawing.Color)(resources.GetObject("classicRaceView.Appearance.RowSeparator.BackColor2")));
            this.classicRaceView.Appearance.RowSeparator.Options.UseBackColor = true;
            this.classicRaceView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand6,
            this.bandLaps,
            this.gridBand1,
            this.bandCarImage});
            this.classicRaceView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.classicRaceView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colId,
            this.colPilote,
            this.colImagePilote,
            this.colPosition,
            this.colLapCount,
            this.colGap,
            this.colBestLap,
            this.colLastLap,
            this.colFuel,
            this.colTires,
            this.colHealth,
            this.colCurrentTires,
            this.colImageState,
            this.colPitStopSelectionImage,
            this.colImageCar,
            this.colPitStopAction,
            this.colPitStopSelectionTitle,
            this.colImageFuel,
            this.colImageHealth,
            this.colImageTires,
            this.colFiller,
            this.colMandatoryLeft,
            this.colCurrentCurves});
            this.classicRaceView.GridControl = this.raceGrid;
            this.classicRaceView.Name = "classicRaceView";
            this.classicRaceView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.classicRaceView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.classicRaceView.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.classicRaceView.OptionsBehavior.AutoPopulateColumns = false;
            this.classicRaceView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.classicRaceView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.classicRaceView.OptionsBehavior.Editable = false;
            this.classicRaceView.OptionsBehavior.ReadOnly = true;
            this.classicRaceView.OptionsBehavior.SmartVertScrollBar = false;
            this.classicRaceView.OptionsCustomization.AllowBandMoving = false;
            this.classicRaceView.OptionsCustomization.AllowBandResizing = false;
            this.classicRaceView.OptionsCustomization.AllowColumnMoving = false;
            this.classicRaceView.OptionsCustomization.AllowFilter = false;
            this.classicRaceView.OptionsCustomization.AllowGroup = false;
            this.classicRaceView.OptionsCustomization.AllowQuickHideColumns = false;
            this.classicRaceView.OptionsCustomization.AllowRowSizing = true;
            this.classicRaceView.OptionsCustomization.ShowBandsInCustomizationForm = false;
            this.classicRaceView.OptionsDetail.EnableMasterViewMode = false;
            this.classicRaceView.OptionsDetail.ShowDetailTabs = false;
            this.classicRaceView.OptionsDetail.SmartDetailExpand = false;
            this.classicRaceView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.classicRaceView.OptionsFilter.AllowFilterEditor = false;
            this.classicRaceView.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.classicRaceView.OptionsFilter.AllowMRUFilterList = false;
            this.classicRaceView.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.classicRaceView.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.classicRaceView.OptionsFind.AllowFindPanel = false;
            this.classicRaceView.OptionsFind.ClearFindOnClose = false;
            this.classicRaceView.OptionsNavigation.AutoMoveRowFocus = false;
            this.classicRaceView.OptionsNavigation.UseAdvHorzNavigation = false;
            this.classicRaceView.OptionsNavigation.UseAdvVertNavigation = false;
            this.classicRaceView.OptionsNavigation.UseOfficePageNavigation = false;
            this.classicRaceView.OptionsNavigation.UseTabKey = false;
            this.classicRaceView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.classicRaceView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.classicRaceView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.classicRaceView.OptionsView.AllowGlyphSkinning = true;
            this.classicRaceView.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.NeverAnimate;
            this.classicRaceView.OptionsView.ColumnAutoWidth = true;
            this.classicRaceView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.classicRaceView.OptionsView.ShowBands = false;
            this.classicRaceView.OptionsView.ShowColumnHeaders = false;
            this.classicRaceView.OptionsView.ShowDetailButtons = false;
            this.classicRaceView.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.classicRaceView.OptionsView.ShowGroupPanel = false;
            this.classicRaceView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.classicRaceView.OptionsView.ShowIndicator = false;
            this.classicRaceView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.classicRaceView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
            this.classicRaceView.RowHeight = 45;
            this.classicRaceView.RowSeparatorHeight = 2;
            this.classicRaceView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.None;
            this.classicRaceView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPosition, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.classicRaceView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.classicRaceView_RowCellStyle);
            this.classicRaceView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.classicRaceView_CustomUnboundColumnData);
            // 
            // gridBand6
            // 
            resources.ApplyResources(this.gridBand6, "gridBand6");
            this.gridBand6.Columns.Add(this.colId);
            this.gridBand6.Columns.Add(this.colPosition);
            this.gridBand6.Columns.Add(this.colPilote);
            this.gridBand6.Columns.Add(this.colGap);
            this.gridBand6.Columns.Add(this.colImagePilote);
            this.gridBand6.Columns.Add(this.colLapCount);
            this.gridBand6.Columns.Add(this.colMandatoryLeft);
            this.gridBand6.VisibleIndex = 0;
            // 
            // colId
            // 
            this.colId.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colId.AppearanceCell.Font")));
            this.colId.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colId.AppearanceCell.ForeColor")));
            this.colId.AppearanceCell.Options.UseFont = true;
            this.colId.AppearanceCell.Options.UseForeColor = true;
            this.colId.AppearanceCell.Options.UseTextOptions = true;
            this.colId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colId.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            resources.ApplyResources(this.colId, "colId");
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.RowCount = 2;
            // 
            // colPosition
            // 
            this.colPosition.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colPosition.AppearanceCell.Font")));
            this.colPosition.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colPosition.AppearanceCell.ForeColor")));
            this.colPosition.AppearanceCell.Options.UseFont = true;
            this.colPosition.AppearanceCell.Options.UseForeColor = true;
            this.colPosition.AppearanceCell.Options.UseTextOptions = true;
            this.colPosition.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPosition.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colPosition, "colPosition");
            this.colPosition.FieldName = "Position";
            this.colPosition.Name = "colPosition";
            // 
            // colPilote
            // 
            this.colPilote.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colPilote.AppearanceCell.Font")));
            this.colPilote.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colPilote.AppearanceCell.ForeColor")));
            this.colPilote.AppearanceCell.Options.UseFont = true;
            this.colPilote.AppearanceCell.Options.UseForeColor = true;
            this.colPilote.AppearanceCell.Options.UseTextOptions = true;
            this.colPilote.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPilote.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.colPilote.AppearanceHeader.Font = ((System.Drawing.Font)(resources.GetObject("colPilote.AppearanceHeader.Font")));
            this.colPilote.AppearanceHeader.ForeColor = ((System.Drawing.Color)(resources.GetObject("colPilote.AppearanceHeader.ForeColor")));
            this.colPilote.AppearanceHeader.Options.UseFont = true;
            this.colPilote.AppearanceHeader.Options.UseForeColor = true;
            resources.ApplyResources(this.colPilote, "colPilote");
            this.colPilote.ColumnEdit = this.repositoryItemMemoEditPilotName;
            this.colPilote.FieldName = "TeamAndPilotName";
            this.colPilote.Name = "colPilote";
            this.colPilote.RowCount = 2;
            // 
            // repositoryItemMemoEditPilotName
            // 
            this.repositoryItemMemoEditPilotName.AllowMouseWheel = false;
            this.repositoryItemMemoEditPilotName.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEditPilotName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemMemoEditPilotName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.repositoryItemMemoEditPilotName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemMemoEditPilotName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.repositoryItemMemoEditPilotName.LinesCount = 3;
            this.repositoryItemMemoEditPilotName.Name = "repositoryItemMemoEditPilotName";
            // 
            // colGap
            // 
            this.colGap.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colGap.AppearanceCell.Font")));
            this.colGap.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colGap.AppearanceCell.ForeColor")));
            this.colGap.AppearanceCell.Options.UseFont = true;
            this.colGap.AppearanceCell.Options.UseForeColor = true;
            this.colGap.AppearanceCell.Options.UseTextOptions = true;
            this.colGap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGap.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colGap, "colGap");
            this.colGap.FieldName = "Gap";
            this.colGap.Name = "colGap";
            this.colGap.RowCount = 2;
            // 
            // colImagePilote
            // 
            resources.ApplyResources(this.colImagePilote, "colImagePilote");
            this.colImagePilote.ColumnEdit = this.repositoryItemPicturePilot;
            this.colImagePilote.FieldName = "TeamImage";
            this.colImagePilote.Name = "colImagePilote";
            this.colImagePilote.RowCount = 4;
            this.colImagePilote.RowIndex = 1;
            // 
            // repositoryItemPicturePilot
            // 
            this.repositoryItemPicturePilot.ContextButtonOptions.AnimationType = DevExpress.Utils.ContextAnimationType.OpacityAnimation;
            this.repositoryItemPicturePilot.Name = "repositoryItemPicturePilot";
            resources.ApplyResources(this.repositoryItemPicturePilot, "repositoryItemPicturePilot");
            this.repositoryItemPicturePilot.ShowMenu = false;
            this.repositoryItemPicturePilot.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPicturePilot.ZoomAccelerationFactor = 1D;
            // 
            // colLapCount
            // 
            this.colLapCount.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colLapCount.AppearanceCell.Font")));
            this.colLapCount.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colLapCount.AppearanceCell.ForeColor")));
            this.colLapCount.AppearanceCell.Options.UseFont = true;
            this.colLapCount.AppearanceCell.Options.UseForeColor = true;
            this.colLapCount.AppearanceCell.Options.UseTextOptions = true;
            this.colLapCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colLapCount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colLapCount, "colLapCount");
            this.colLapCount.ColumnEdit = this.repositoryItemMemoEditLapCount;
            this.colLapCount.FieldName = "LapCountForUI";
            this.colLapCount.Name = "colLapCount";
            this.colLapCount.RowCount = 4;
            this.colLapCount.RowIndex = 1;
            // 
            // repositoryItemMemoEditLapCount
            // 
            this.repositoryItemMemoEditLapCount.AcceptsTab = true;
            this.repositoryItemMemoEditLapCount.Name = "repositoryItemMemoEditLapCount";
            // 
            // colMandatoryLeft
            // 
            this.colMandatoryLeft.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colMandatoryLeft.AppearanceCell.Font")));
            this.colMandatoryLeft.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colMandatoryLeft.AppearanceCell.ForeColor")));
            this.colMandatoryLeft.AppearanceCell.Options.UseFont = true;
            this.colMandatoryLeft.AppearanceCell.Options.UseForeColor = true;
            resources.ApplyResources(this.colMandatoryLeft, "colMandatoryLeft");
            this.colMandatoryLeft.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colMandatoryLeft.FieldName = "MandatoryPSLeft";
            this.colMandatoryLeft.Name = "colMandatoryLeft";
            this.colMandatoryLeft.RowCount = 4;
            this.colMandatoryLeft.RowIndex = 1;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // bandLaps
            // 
            resources.ApplyResources(this.bandLaps, "bandLaps");
            this.bandLaps.Columns.Add(this.colImageHealth);
            this.bandLaps.Columns.Add(this.colHealth);
            this.bandLaps.Columns.Add(this.colImageFuel);
            this.bandLaps.Columns.Add(this.colFuel);
            this.bandLaps.Columns.Add(this.colImageTires);
            this.bandLaps.Columns.Add(this.colTires);
            this.bandLaps.Columns.Add(this.colFiller);
            this.bandLaps.Columns.Add(this.colBestLap);
            this.bandLaps.VisibleIndex = 1;
            // 
            // colImageHealth
            // 
            resources.ApplyResources(this.colImageHealth, "colImageHealth");
            this.colImageHealth.ColumnEdit = this.repositoryItemPicturePitStopSelection;
            this.colImageHealth.FieldName = "colImageHealth";
            this.colImageHealth.Name = "colImageHealth";
            this.colImageHealth.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            // 
            // repositoryItemPicturePitStopSelection
            // 
            this.repositoryItemPicturePitStopSelection.Caption.Alignment = System.Drawing.ContentAlignment.TopCenter;
            this.repositoryItemPicturePitStopSelection.InitialImage = global::ESRM.Win.Images.empty;
            this.repositoryItemPicturePitStopSelection.Name = "repositoryItemPicturePitStopSelection";
            this.repositoryItemPicturePitStopSelection.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPicturePitStopSelection.ZoomAccelerationFactor = 1D;
            // 
            // colHealth
            // 
            this.colHealth.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colHealth.AppearanceCell.ForeColor")));
            this.colHealth.AppearanceCell.Options.UseForeColor = true;
            resources.ApplyResources(this.colHealth, "colHealth");
            this.colHealth.ColumnEdit = this.repositoryItemProgressBarCar;
            this.colHealth.FieldName = "CarHealthPercent";
            this.colHealth.Name = "colHealth";
            // 
            // repositoryItemProgressBarCar
            // 
            this.repositoryItemProgressBarCar.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("repositoryItemProgressBarCar.Appearance.ForeColor")));
            resources.ApplyResources(this.repositoryItemProgressBarCar, "repositoryItemProgressBarCar");
            this.repositoryItemProgressBarCar.EndColor = System.Drawing.Color.Gold;
            this.repositoryItemProgressBarCar.Name = "repositoryItemProgressBarCar";
            this.repositoryItemProgressBarCar.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.repositoryItemProgressBarCar.ShowTitle = true;
            this.repositoryItemProgressBarCar.StartColor = System.Drawing.Color.Goldenrod;
            this.repositoryItemProgressBarCar.Step = 1;
            this.repositoryItemProgressBarCar.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.repositoryItemProgressBarCar_CustomDisplayText);
            // 
            // colImageFuel
            // 
            resources.ApplyResources(this.colImageFuel, "colImageFuel");
            this.colImageFuel.ColumnEdit = this.repositoryItemPicturePitStopSelection;
            this.colImageFuel.FieldName = "colImageFuel";
            this.colImageFuel.Name = "colImageFuel";
            this.colImageFuel.RowIndex = 1;
            this.colImageFuel.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            // 
            // colFuel
            // 
            resources.ApplyResources(this.colFuel, "colFuel");
            this.colFuel.ColumnEdit = this.repositoryItemProgressBarFuel;
            this.colFuel.FieldName = "FuelPercent";
            this.colFuel.Name = "colFuel";
            this.colFuel.RowIndex = 1;
            // 
            // repositoryItemProgressBarFuel
            // 
            this.repositoryItemProgressBarFuel.EndColor = System.Drawing.Color.Empty;
            this.repositoryItemProgressBarFuel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.repositoryItemProgressBarFuel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemProgressBarFuel.Name = "repositoryItemProgressBarFuel";
            this.repositoryItemProgressBarFuel.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.repositoryItemProgressBarFuel.ShowTitle = true;
            this.repositoryItemProgressBarFuel.StartColor = System.Drawing.Color.Empty;
            this.repositoryItemProgressBarFuel.Step = 1;
            this.repositoryItemProgressBarFuel.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.repositoryItemProgressBarFuel_CustomDisplayText);
            // 
            // colImageTires
            // 
            resources.ApplyResources(this.colImageTires, "colImageTires");
            this.colImageTires.ColumnEdit = this.repositoryItemPicturePitStopSelection;
            this.colImageTires.FieldName = "colImageTires";
            this.colImageTires.Name = "colImageTires";
            this.colImageTires.RowIndex = 2;
            this.colImageTires.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            // 
            // colTires
            // 
            this.colTires.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colTires.AppearanceCell.ForeColor")));
            this.colTires.AppearanceCell.Options.UseForeColor = true;
            resources.ApplyResources(this.colTires, "colTires");
            this.colTires.ColumnEdit = this.repositoryItemProgressBarTires;
            this.colTires.FieldName = "TiresWearPercent";
            this.colTires.Name = "colTires";
            this.colTires.RowIndex = 2;
            // 
            // repositoryItemProgressBarTires
            // 
            this.repositoryItemProgressBarTires.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("repositoryItemProgressBarTires.Appearance.ForeColor")));
            this.repositoryItemProgressBarTires.EndColor = System.Drawing.Color.LightSeaGreen;
            this.repositoryItemProgressBarTires.Name = "repositoryItemProgressBarTires";
            this.repositoryItemProgressBarTires.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.repositoryItemProgressBarTires.ShowTitle = true;
            this.repositoryItemProgressBarTires.StartColor = System.Drawing.Color.Teal;
            this.repositoryItemProgressBarTires.Step = 1;
            this.repositoryItemProgressBarTires.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.repositoryItemProgressBarTires_CustomDisplayText);
            // 
            // colFiller
            // 
            resources.ApplyResources(this.colFiller, "colFiller");
            this.colFiller.Name = "colFiller";
            this.colFiller.RowIndex = 3;
            // 
            // gridBand1
            // 
            resources.ApplyResources(this.gridBand1, "gridBand1");
            this.gridBand1.Columns.Add(this.colLastLap);
            this.gridBand1.Columns.Add(this.colCurrentTires);
            this.gridBand1.Columns.Add(this.colImageState);
            this.gridBand1.Columns.Add(this.colPitStopSelectionImage);
            this.gridBand1.VisibleIndex = 2;
            // 
            // colLastLap
            // 
            this.colLastLap.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colLastLap.AppearanceCell.Font")));
            this.colLastLap.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colLastLap.AppearanceCell.ForeColor")));
            this.colLastLap.AppearanceCell.Options.UseFont = true;
            this.colLastLap.AppearanceCell.Options.UseForeColor = true;
            this.colLastLap.AppearanceCell.Options.UseTextOptions = true;
            this.colLastLap.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colLastLap, "colLastLap");
            this.colLastLap.FieldName = "LastLapForUIOrPitAction";
            this.colLastLap.Name = "colLastLap";
            this.colLastLap.RowCount = 2;
            // 
            // colCurrentTires
            // 
            resources.ApplyResources(this.colCurrentTires, "colCurrentTires");
            this.colCurrentTires.ColumnEdit = this.repositoryItemPicturePitStopSelection;
            this.colCurrentTires.FieldName = "colCurrentTires";
            this.colCurrentTires.Name = "colCurrentTires";
            this.colCurrentTires.RowCount = 4;
            this.colCurrentTires.RowIndex = 1;
            this.colCurrentTires.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            // 
            // colImageState
            // 
            resources.ApplyResources(this.colImageState, "colImageState");
            this.colImageState.ColumnEdit = this.repositoryItemImageStates;
            this.colImageState.FieldName = "StateImageIndex";
            this.colImageState.Name = "colImageState";
            this.colImageState.OptionsColumn.AllowEdit = false;
            this.colImageState.OptionsColumn.ReadOnly = true;
            this.colImageState.RowCount = 4;
            this.colImageState.RowIndex = 1;
            // 
            // repositoryItemImageStates
            // 
            this.repositoryItemImageStates.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemImageStates.Buttons"))))});
            this.repositoryItemImageStates.Name = "repositoryItemImageStates";
            // 
            // colPitStopSelectionImage
            // 
            this.colPitStopSelectionImage.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colPitStopSelectionImage.AppearanceCell.Font")));
            this.colPitStopSelectionImage.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colPitStopSelectionImage.AppearanceCell.ForeColor")));
            this.colPitStopSelectionImage.AppearanceCell.Options.UseFont = true;
            this.colPitStopSelectionImage.AppearanceCell.Options.UseForeColor = true;
            this.colPitStopSelectionImage.AppearanceCell.Options.UseTextOptions = true;
            this.colPitStopSelectionImage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colPitStopSelectionImage, "colPitStopSelectionImage");
            this.colPitStopSelectionImage.ColumnEdit = this.repositoryItemPicturePitStopSelection;
            this.colPitStopSelectionImage.FieldName = "colPitStopSelectionImage";
            this.colPitStopSelectionImage.Name = "colPitStopSelectionImage";
            this.colPitStopSelectionImage.OptionsColumn.AllowEdit = false;
            this.colPitStopSelectionImage.OptionsColumn.ReadOnly = true;
            this.colPitStopSelectionImage.RowCount = 4;
            this.colPitStopSelectionImage.RowIndex = 1;
            this.colPitStopSelectionImage.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            // 
            // bandCarImage
            // 
            resources.ApplyResources(this.bandCarImage, "bandCarImage");
            this.bandCarImage.Columns.Add(this.colCurrentCurves);
            this.bandCarImage.Columns.Add(this.colPitStopSelectionTitle);
            this.bandCarImage.Columns.Add(this.colImageCar);
            this.bandCarImage.VisibleIndex = 3;
            // 
            // colCurrentCurves
            // 
            this.colCurrentCurves.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colCurrentCurves.AppearanceCell.Font")));
            this.colCurrentCurves.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colCurrentCurves.AppearanceCell.ForeColor")));
            this.colCurrentCurves.AppearanceCell.Options.UseFont = true;
            this.colCurrentCurves.AppearanceCell.Options.UseForeColor = true;
            this.colCurrentCurves.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrentCurves.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            resources.ApplyResources(this.colCurrentCurves, "colCurrentCurves");
            this.colCurrentCurves.FieldName = "CurrentCurves";
            this.colCurrentCurves.Name = "colCurrentCurves";
            // 
            // colPitStopSelectionTitle
            // 
            this.colPitStopSelectionTitle.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colPitStopSelectionTitle.AppearanceCell.Font")));
            this.colPitStopSelectionTitle.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colPitStopSelectionTitle.AppearanceCell.ForeColor")));
            this.colPitStopSelectionTitle.AppearanceCell.Options.UseFont = true;
            this.colPitStopSelectionTitle.AppearanceCell.Options.UseForeColor = true;
            this.colPitStopSelectionTitle.AppearanceCell.Options.UseTextOptions = true;
            this.colPitStopSelectionTitle.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPitStopSelectionTitle.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            resources.ApplyResources(this.colPitStopSelectionTitle, "colPitStopSelectionTitle");
            this.colPitStopSelectionTitle.FieldName = "PitStop_CurrentSelectionTitle";
            this.colPitStopSelectionTitle.Name = "colPitStopSelectionTitle";
            this.colPitStopSelectionTitle.RowIndex = 1;
            // 
            // colImageCar
            // 
            this.colImageCar.AppearanceCell.BorderColor = ((System.Drawing.Color)(resources.GetObject("colImageCar.AppearanceCell.BorderColor")));
            this.colImageCar.AppearanceCell.Options.UseBorderColor = true;
            resources.ApplyResources(this.colImageCar, "colImageCar");
            this.colImageCar.ColumnEdit = this.repositoryItemPictureCar;
            this.colImageCar.FieldName = "CarImage";
            this.colImageCar.Name = "colImageCar";
            this.colImageCar.RowCount = 5;
            this.colImageCar.RowIndex = 1;
            // 
            // repositoryItemPictureCar
            // 
            this.repositoryItemPictureCar.Name = "repositoryItemPictureCar";
            this.repositoryItemPictureCar.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.repositoryItemPictureCar.ZoomAccelerationFactor = 1D;
            // 
            // colPitStopAction
            // 
            this.colPitStopAction.AppearanceCell.Font = ((System.Drawing.Font)(resources.GetObject("colPitStopAction.AppearanceCell.Font")));
            this.colPitStopAction.AppearanceCell.ForeColor = ((System.Drawing.Color)(resources.GetObject("colPitStopAction.AppearanceCell.ForeColor")));
            this.colPitStopAction.AppearanceCell.Options.UseFont = true;
            this.colPitStopAction.AppearanceCell.Options.UseForeColor = true;
            this.colPitStopAction.AppearanceCell.Options.UseTextOptions = true;
            this.colPitStopAction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPitStopAction.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            resources.ApplyResources(this.colPitStopAction, "colPitStopAction");
            this.colPitStopAction.FieldName = "PitStop_CurrentActionShowed";
            this.colPitStopAction.Name = "colPitStopAction";
            // 
            // repositoryItemImagePitStop
            // 
            this.repositoryItemImagePitStop.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemImagePitStop.Buttons"))))});
            this.repositoryItemImagePitStop.DropDownRows = 1;
            resources.ApplyResources(this.repositoryItemImagePitStop, "repositoryItemImagePitStop");
            this.repositoryItemImagePitStop.Name = "repositoryItemImagePitStop";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.ContextImage = ((System.Drawing.Image)(resources.GetObject("repositoryItemTextEdit1.ContextImage")));
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // stateImageList
            // 
            this.stateImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.stateImageList, "stateImageList");
            this.stateImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panelLeft
            // 
            this.panelLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelLeft.Controls.Add(this.panelWeatherAndTires);
            this.panelLeft.Controls.Add(this.panelButtons);
            this.panelLeft.Controls.Add(this.panelTitle);
            this.panelLeft.Controls.Add(this.panelControlFlag);
            this.panelLeft.Controls.Add(this.panelTests);
            resources.ApplyResources(this.panelLeft, "panelLeft");
            this.panelLeft.Name = "panelLeft";
            // 
            // panelWeatherAndTires
            // 
            this.panelWeatherAndTires.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelWeatherAndTires.Appearance.BackColor")));
            this.panelWeatherAndTires.Appearance.Options.UseBackColor = true;
            this.panelWeatherAndTires.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelWeatherAndTires.Controls.Add(this.panelWeahter);
            this.panelWeatherAndTires.Controls.Add(this.panelTires);
            resources.ApplyResources(this.panelWeatherAndTires, "panelWeatherAndTires");
            this.panelWeatherAndTires.Name = "panelWeatherAndTires";
            // 
            // panelWeahter
            // 
            this.panelWeahter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelWeahter.Controls.Add(this.panelCurrentWeather);
            this.panelWeahter.Controls.Add(this.panelForecast);
            resources.ApplyResources(this.panelWeahter, "panelWeahter");
            this.panelWeahter.Name = "panelWeahter";
            // 
            // panelCurrentWeather
            // 
            this.panelCurrentWeather.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelCurrentWeather.Appearance.BackColor")));
            this.panelCurrentWeather.Appearance.Options.UseBackColor = true;
            this.panelCurrentWeather.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCurrentWeather.Controls.Add(this.pbWeather);
            this.panelCurrentWeather.Controls.Add(this.lblTemp);
            resources.ApplyResources(this.panelCurrentWeather, "panelCurrentWeather");
            this.panelCurrentWeather.Name = "panelCurrentWeather";
            // 
            // pbWeather
            // 
            this.pbWeather.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.pbWeather, "pbWeather");
            this.pbWeather.EditValue = global::ESRM.Win.Images.SunnyRain1;
            this.pbWeather.Name = "pbWeather";
            this.pbWeather.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pbWeather.Properties.Appearance.BackColor")));
            this.pbWeather.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("pbWeather.Properties.Appearance.Font")));
            this.pbWeather.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("pbWeather.Properties.Appearance.ForeColor")));
            this.pbWeather.Properties.Appearance.Options.UseBackColor = true;
            this.pbWeather.Properties.Appearance.Options.UseFont = true;
            this.pbWeather.Properties.Appearance.Options.UseForeColor = true;
            this.pbWeather.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbWeather.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pbWeather.Properties.ZoomAccelerationFactor = 1D;
            // 
            // lblTemp
            // 
            this.lblTemp.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblTemp, "lblTemp");
            this.lblTemp.ForeColor = System.Drawing.Color.DarkKhaki;
            this.lblTemp.Name = "lblTemp";
            // 
            // panelForecast
            // 
            this.panelForecast.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelForecast.Appearance.BackColor")));
            this.panelForecast.Appearance.Options.UseBackColor = true;
            this.panelForecast.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelForecast.Controls.Add(this.pbNextWeather);
            this.panelForecast.Controls.Add(this.lblForecast);
            resources.ApplyResources(this.panelForecast, "panelForecast");
            this.panelForecast.Name = "panelForecast";
            // 
            // pbNextWeather
            // 
            this.pbNextWeather.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.pbNextWeather, "pbNextWeather");
            this.pbNextWeather.EditValue = global::ESRM.Win.Images.SunnyCloudy;
            this.pbNextWeather.Name = "pbNextWeather";
            this.pbNextWeather.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pbNextWeather.Properties.Appearance.BackColor")));
            this.pbNextWeather.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("pbNextWeather.Properties.Appearance.Font")));
            this.pbNextWeather.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("pbNextWeather.Properties.Appearance.ForeColor")));
            this.pbNextWeather.Properties.Appearance.Options.UseBackColor = true;
            this.pbNextWeather.Properties.Appearance.Options.UseFont = true;
            this.pbNextWeather.Properties.Appearance.Options.UseForeColor = true;
            this.pbNextWeather.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbNextWeather.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pbNextWeather.Properties.ZoomAccelerationFactor = 1D;
            // 
            // lblForecast
            // 
            resources.ApplyResources(this.lblForecast, "lblForecast");
            this.lblForecast.ForeColor = System.Drawing.Color.White;
            this.lblForecast.Name = "lblForecast";
            this.lblForecast.UseCompatibleTextRendering = true;
            // 
            // panelTires
            // 
            this.panelTires.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTires.Controls.Add(this.pbOptimalTires);
            this.panelTires.Controls.Add(this.panelTemperatures);
            resources.ApplyResources(this.panelTires, "panelTires");
            this.panelTires.Name = "panelTires";
            // 
            // pbOptimalTires
            // 
            this.pbOptimalTires.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.pbOptimalTires, "pbOptimalTires");
            this.pbOptimalTires.EditValue = global::ESRM.Win.Images.Soft;
            this.pbOptimalTires.Name = "pbOptimalTires";
            this.pbOptimalTires.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pbOptimalTires.Properties.Appearance.BackColor")));
            this.pbOptimalTires.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("pbOptimalTires.Properties.Appearance.Font")));
            this.pbOptimalTires.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("pbOptimalTires.Properties.Appearance.ForeColor")));
            this.pbOptimalTires.Properties.Appearance.Options.UseBackColor = true;
            this.pbOptimalTires.Properties.Appearance.Options.UseFont = true;
            this.pbOptimalTires.Properties.Appearance.Options.UseForeColor = true;
            this.pbOptimalTires.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbOptimalTires.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pbOptimalTires.Properties.ZoomAccelerationFactor = 1D;
            // 
            // panelTemperatures
            // 
            this.panelTemperatures.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelTemperatures.Appearance.BackColor")));
            this.panelTemperatures.Appearance.Options.UseBackColor = true;
            this.panelTemperatures.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTemperatures.Controls.Add(this.lblTrackTemperature);
            resources.ApplyResources(this.panelTemperatures, "panelTemperatures");
            this.panelTemperatures.Name = "panelTemperatures";
            // 
            // lblTrackTemperature
            // 
            resources.ApplyResources(this.lblTrackTemperature, "lblTrackTemperature");
            this.lblTrackTemperature.ForeColor = System.Drawing.Color.White;
            this.lblTrackTemperature.Name = "lblTrackTemperature";
            // 
            // panelButtons
            // 
            this.panelButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelButtons.Controls.Add(this.panelSeparateur2);
            this.panelButtons.Controls.Add(this.btnGreenFlag);
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.panelButtons.Name = "panelButtons";
            // 
            // panelSeparateur2
            // 
            this.panelSeparateur2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelSeparateur2.Controls.Add(this.pbStart);
            this.panelSeparateur2.Controls.Add(this.pbStop);
            resources.ApplyResources(this.panelSeparateur2, "panelSeparateur2");
            this.panelSeparateur2.Name = "panelSeparateur2";
            // 
            // pbStart
            // 
            this.pbStart.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.pbStart, "pbStart");
            this.pbStart.Name = "pbStart";
            this.pbStart.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pbStart.Properties.Appearance.BackColor")));
            this.pbStart.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("pbStart.Properties.Appearance.Font")));
            this.pbStart.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("pbStart.Properties.Appearance.ForeColor")));
            this.pbStart.Properties.Appearance.Options.UseBackColor = true;
            this.pbStart.Properties.Appearance.Options.UseFont = true;
            this.pbStart.Properties.Appearance.Options.UseForeColor = true;
            this.pbStart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbStart.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pbStart.Properties.ZoomAccelerationFactor = 1D;
            this.pbStart.Click += new System.EventHandler(this.StartRace_Click);
            // 
            // pbStop
            // 
            resources.ApplyResources(this.pbStop, "pbStop");
            this.pbStop.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbStop.EditValue = global::ESRM.Win.Images.Stop;
            this.pbStop.Name = "pbStop";
            this.pbStop.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pbStop.Properties.Appearance.BackColor")));
            this.pbStop.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("pbStop.Properties.Appearance.Font")));
            this.pbStop.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("pbStop.Properties.Appearance.ForeColor")));
            this.pbStop.Properties.Appearance.Options.UseBackColor = true;
            this.pbStop.Properties.Appearance.Options.UseFont = true;
            this.pbStop.Properties.Appearance.Options.UseForeColor = true;
            this.pbStop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbStop.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pbStop.Properties.ZoomAccelerationFactor = 1D;
            this.pbStop.Click += new System.EventHandler(this.StopRace_Click);
            // 
            // btnGreenFlag
            // 
            this.btnGreenFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnGreenFlag, "btnGreenFlag");
            this.btnGreenFlag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGreenFlag.ForeColor = System.Drawing.Color.White;
            this.btnGreenFlag.Name = "btnGreenFlag";
            this.btnGreenFlag.UseCompatibleTextRendering = true;
            this.btnGreenFlag.UseVisualStyleBackColor = false;
            // 
            // panelTitle
            // 
            this.panelTitle.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelTitle.Appearance.BackColor")));
            this.panelTitle.Appearance.Options.UseBackColor = true;
            this.panelTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTitle.Controls.Add(this.labelRaceTime);
            this.panelTitle.Controls.Add(this.labelLapsCount);
            resources.ApplyResources(this.panelTitle, "panelTitle");
            this.panelTitle.Name = "panelTitle";
            // 
            // labelRaceTime
            // 
            resources.ApplyResources(this.labelRaceTime, "labelRaceTime");
            this.labelRaceTime.ForeColor = System.Drawing.Color.White;
            this.labelRaceTime.Name = "labelRaceTime";
            this.labelRaceTime.Paint += new System.Windows.Forms.PaintEventHandler(this.labelRaceTime_Paint);
            // 
            // labelLapsCount
            // 
            resources.ApplyResources(this.labelLapsCount, "labelLapsCount");
            this.labelLapsCount.ForeColor = System.Drawing.Color.White;
            this.labelLapsCount.Name = "labelLapsCount";
            // 
            // panelControlFlag
            // 
            this.panelControlFlag.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlFlag.Controls.Add(this.pbFlag);
            resources.ApplyResources(this.panelControlFlag, "panelControlFlag");
            this.panelControlFlag.Name = "panelControlFlag";
            // 
            // pbFlag
            // 
            this.pbFlag.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.pbFlag, "pbFlag");
            this.pbFlag.Name = "pbFlag";
            this.pbFlag.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pbFlag.Properties.Appearance.BackColor")));
            this.pbFlag.Properties.Appearance.Options.UseBackColor = true;
            this.pbFlag.Properties.Appearance.Options.UseFont = true;
            this.pbFlag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbFlag.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pbFlag.Properties.ZoomAccelerationFactor = 1D;
            // 
            // panelTests
            // 
            this.panelTests.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTests.Controls.Add(this.simpleButton7);
            this.panelTests.Controls.Add(this.simpleButton6);
            this.panelTests.Controls.Add(this.simpleButton5);
            this.panelTests.Controls.Add(this.simpleButton1);
            this.panelTests.Controls.Add(this.simpleButton3);
            this.panelTests.Controls.Add(this.simpleButton2);
            this.panelTests.Controls.Add(this.simpleButton4);
            resources.ApplyResources(this.panelTests, "panelTests");
            this.panelTests.Name = "panelTests";
            // 
            // simpleButton7
            // 
            resources.ApplyResources(this.simpleButton7, "simpleButton7");
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // simpleButton6
            // 
            resources.ApplyResources(this.simpleButton6, "simpleButton6");
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // simpleButton5
            // 
            resources.ApplyResources(this.simpleButton5, "simpleButton5");
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton1
            // 
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton3
            // 
            resources.ApplyResources(this.simpleButton3, "simpleButton3");
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            resources.ApplyResources(this.simpleButton2, "simpleButton2");
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton4
            // 
            resources.ApplyResources(this.simpleButton4, "simpleButton4");
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // TiresImageList
            // 
            this.TiresImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.TiresImageList, "TiresImageList");
            this.TiresImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // WeatherImageList
            // 
            this.WeatherImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.WeatherImageList, "WeatherImageList");
            this.WeatherImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // headerPanel
            // 
            this.headerPanel.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("headerPanel.Appearance.BackColor")));
            this.headerPanel.Appearance.Options.UseBackColor = true;
            this.headerPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.headerPanel.Controls.Add(this.lblRaceInformation);
            resources.ApplyResources(this.headerPanel, "headerPanel");
            this.headerPanel.Name = "headerPanel";
            // 
            // lblRaceInformation
            // 
            resources.ApplyResources(this.lblRaceInformation, "lblRaceInformation");
            this.lblRaceInformation.ForeColor = System.Drawing.Color.White;
            this.lblRaceInformation.Name = "lblRaceInformation";
            // 
            // RacePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::ESRM.Win.Images.background;
            this.Controls.Add(this.raceGrid);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.headerPanel);
            this.Name = "RacePage";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RacePage_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.raceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classicRaceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditPilotName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPicturePilot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEditLapCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPicturePitStopSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBarCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBarFuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBarTires)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImagePitStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelWeatherAndTires)).EndInit();
            this.panelWeatherAndTires.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelWeahter)).EndInit();
            this.panelWeahter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelCurrentWeather)).EndInit();
            this.panelCurrentWeather.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWeather.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelForecast)).EndInit();
            this.panelForecast.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNextWeather.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTires)).EndInit();
            this.panelTires.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOptimalTires.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTemperatures)).EndInit();
            this.panelTemperatures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelButtons)).EndInit();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSeparateur2)).EndInit();
            this.panelSeparateur2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).EndInit();
            this.panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlFlag)).EndInit();
            this.panelControlFlag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTests)).EndInit();
            this.panelTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private Label labelLapsCount;
        private PanelControl panelLeft;
        private DevExpress.XtraEditors.PictureEdit pbFlag;
        private PictureEdit pbStop;
        private PictureEdit pbStart;
        private PanelControl panelTests;
        private PanelControl panelButtons;
        private PanelControl panelTitle;
        private PanelControl panelSeparateur2;
        private PanelControl panelControlFlag;
        private Label labelRaceTime;
        private ESRMButton btnGreenFlag;
        private SimpleButton simpleButton6;
        private SimpleButton simpleButton5;
        private SimpleButton simpleButton7;
        private ESRMGrid raceGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView classicRaceView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPilote;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImagePilote;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPicturePilot;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPosition;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImageState;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLapCount;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFuel;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBarFuel;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTires;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHealth;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLastLap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBestLap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImageCar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBarTires;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBarCar;
        private ImageList stateImageList;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageStates;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditLapCount;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colId;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFiller;
        private PanelControl panelWeatherAndTires;
        private ImageList TiresImageList;
        private ImageList WeatherImageList;
        private PictureEdit pbOptimalTires;
        private PanelControl panelWeahter;
        private PictureEdit pbWeather;
        private PictureEdit pbNextWeather;
        private PanelControl panelTires;
        private PanelControl panelForecast;
        private Label lblForecast;
        private PanelControl panelTemperatures;
        private Label lblTrackTemperature;
        private PanelControl panelCurrentWeather;
        private Label lblTemp;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPitStopAction;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPitStopSelectionTitle;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPitStopSelectionImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImagePitStop;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCurrentTires;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImageFuel;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPicturePitStopSelection;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImageHealth;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImageTires;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureCar;
        private PanelControl headerPanel;
        private Label lblRaceInformation;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEditPilotName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMandatoryLeft;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCurrentCurves;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandLaps;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand bandCarImage;
    }
}
