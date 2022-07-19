namespace ESRM.Win.Views
{
    partial class DlgPacerLapInfos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControlOriginalsInfos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblCountInfos = new System.Windows.Forms.Label();
            this.btnExportXLS = new ESRM.Win.ESRMButton();
            this.edtMinValue = new System.Windows.Forms.TextBox();
            this.btnClearBegin = new ESRM.Win.ESRMButton();
            this.btnClearEnd = new ESRM.Win.ESRMButton();
            this.btnStartMaxLast = new ESRM.Win.ESRMButton();
            this.edtLastCountTh = new System.Windows.Forms.TextBox();
            this.btnStartAvgLast = new ESRM.Win.ESRMButton();
            this.btnGenerateFirstLapInfos = new ESRM.Win.ESRMButton();
            this.gridControlUpdatedInfos = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlFistLapInfos = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtStartPower = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestPacer = new ESRM.Win.ESRMButton();
            this.btnOK = new ESRM.Win.ESRMButton();
            this.btnCancel = new ESRM.Win.ESRMButton();
            this.btnTestYF = new ESRM.Win.ESRMButton();
            this.btnTestGF = new ESRM.Win.ESRMButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOriginalsInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUpdatedInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFistLapInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlOriginalsInfos
            // 
            this.gridControlOriginalsInfos.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControlOriginalsInfos.Location = new System.Drawing.Point(0, 0);
            this.gridControlOriginalsInfos.MainView = this.gridView1;
            this.gridControlOriginalsInfos.Name = "gridControlOriginalsInfos";
            this.gridControlOriginalsInfos.Size = new System.Drawing.Size(193, 688);
            this.gridControlOriginalsInfos.TabIndex = 0;
            this.gridControlOriginalsInfos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControlOriginalsInfos;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "value";
            this.gridColumn2.FieldName = "ThrotthleValue";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Braking?";
            this.gridColumn3.FieldName = "Braking";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // lblCountInfos
            // 
            this.lblCountInfos.AutoSize = true;
            this.lblCountInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountInfos.Location = new System.Drawing.Point(593, 6);
            this.lblCountInfos.Name = "lblCountInfos";
            this.lblCountInfos.Size = new System.Drawing.Size(51, 20);
            this.lblCountInfos.TabIndex = 7;
            this.lblCountInfos.Text = "label1";
            // 
            // btnExportXLS
            // 
            this.btnExportXLS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnExportXLS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnExportXLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportXLS.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportXLS.ForeColor = System.Drawing.Color.White;
            this.btnExportXLS.Location = new System.Drawing.Point(652, 6);
            this.btnExportXLS.Name = "btnExportXLS";
            this.btnExportXLS.Size = new System.Drawing.Size(261, 47);
            this.btnExportXLS.TabIndex = 8;
            this.btnExportXLS.Text = "XLS";
            this.btnExportXLS.UseCompatibleTextRendering = true;
            this.btnExportXLS.UseVisualStyleBackColor = false;
            this.btnExportXLS.Click += new System.EventHandler(this.btnExportXLS_Click);
            // 
            // edtMinValue
            // 
            this.edtMinValue.Location = new System.Drawing.Point(799, 124);
            this.edtMinValue.Margin = new System.Windows.Forms.Padding(2);
            this.edtMinValue.Name = "edtMinValue";
            this.edtMinValue.Size = new System.Drawing.Size(68, 20);
            this.edtMinValue.TabIndex = 9;
            this.edtMinValue.Text = "0";
            // 
            // btnClearBegin
            // 
            this.btnClearBegin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnClearBegin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnClearBegin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearBegin.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBegin.ForeColor = System.Drawing.Color.White;
            this.btnClearBegin.Location = new System.Drawing.Point(652, 74);
            this.btnClearBegin.Name = "btnClearBegin";
            this.btnClearBegin.Size = new System.Drawing.Size(261, 47);
            this.btnClearBegin.TabIndex = 10;
            this.btnClearBegin.Text = "Clear Start";
            this.btnClearBegin.UseCompatibleTextRendering = true;
            this.btnClearBegin.UseVisualStyleBackColor = false;
            this.btnClearBegin.Click += new System.EventHandler(this.btnClearBegin_Click);
            // 
            // btnClearEnd
            // 
            this.btnClearEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnClearEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnClearEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearEnd.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearEnd.ForeColor = System.Drawing.Color.White;
            this.btnClearEnd.Location = new System.Drawing.Point(652, 147);
            this.btnClearEnd.Name = "btnClearEnd";
            this.btnClearEnd.Size = new System.Drawing.Size(261, 47);
            this.btnClearEnd.TabIndex = 11;
            this.btnClearEnd.Text = "Clear End";
            this.btnClearEnd.UseCompatibleTextRendering = true;
            this.btnClearEnd.UseVisualStyleBackColor = false;
            this.btnClearEnd.Click += new System.EventHandler(this.btnClearEnd_Click);
            // 
            // btnStartMaxLast
            // 
            this.btnStartMaxLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnStartMaxLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnStartMaxLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMaxLast.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMaxLast.ForeColor = System.Drawing.Color.White;
            this.btnStartMaxLast.Location = new System.Drawing.Point(12, 23);
            this.btnStartMaxLast.Name = "btnStartMaxLast";
            this.btnStartMaxLast.Size = new System.Drawing.Size(261, 47);
            this.btnStartMaxLast.TabIndex = 12;
            this.btnStartMaxLast.Text = "Set Start Power (Max of last)";
            this.btnStartMaxLast.UseCompatibleTextRendering = true;
            this.btnStartMaxLast.UseVisualStyleBackColor = false;
            this.btnStartMaxLast.Click += new System.EventHandler(this.btnStartMaxLast_Click);
            // 
            // edtLastCountTh
            // 
            this.edtLastCountTh.Location = new System.Drawing.Point(200, 76);
            this.edtLastCountTh.Margin = new System.Windows.Forms.Padding(2);
            this.edtLastCountTh.Name = "edtLastCountTh";
            this.edtLastCountTh.Size = new System.Drawing.Size(68, 20);
            this.edtLastCountTh.TabIndex = 13;
            this.edtLastCountTh.Text = "20";
            // 
            // btnStartAvgLast
            // 
            this.btnStartAvgLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnStartAvgLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnStartAvgLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartAvgLast.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartAvgLast.ForeColor = System.Drawing.Color.White;
            this.btnStartAvgLast.Location = new System.Drawing.Point(12, 101);
            this.btnStartAvgLast.Name = "btnStartAvgLast";
            this.btnStartAvgLast.Size = new System.Drawing.Size(261, 47);
            this.btnStartAvgLast.TabIndex = 14;
            this.btnStartAvgLast.Text = "Set Start Power (Avg of last)";
            this.btnStartAvgLast.UseCompatibleTextRendering = true;
            this.btnStartAvgLast.UseVisualStyleBackColor = false;
            this.btnStartAvgLast.Click += new System.EventHandler(this.btnStartAvgLast_Click);
            // 
            // btnGenerateFirstLapInfos
            // 
            this.btnGenerateFirstLapInfos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGenerateFirstLapInfos.Enabled = false;
            this.btnGenerateFirstLapInfos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGenerateFirstLapInfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateFirstLapInfos.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateFirstLapInfos.ForeColor = System.Drawing.Color.White;
            this.btnGenerateFirstLapInfos.Location = new System.Drawing.Point(650, 415);
            this.btnGenerateFirstLapInfos.Name = "btnGenerateFirstLapInfos";
            this.btnGenerateFirstLapInfos.Size = new System.Drawing.Size(261, 47);
            this.btnGenerateFirstLapInfos.TabIndex = 15;
            this.btnGenerateFirstLapInfos.Text = "Générer infos de premier tour";
            this.btnGenerateFirstLapInfos.UseCompatibleTextRendering = true;
            this.btnGenerateFirstLapInfos.UseVisualStyleBackColor = false;
            this.btnGenerateFirstLapInfos.Click += new System.EventHandler(this.btnGenerateFirstLapInfos_Click);
            // 
            // gridControlUpdatedInfos
            // 
            this.gridControlUpdatedInfos.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControlUpdatedInfos.Location = new System.Drawing.Point(193, 0);
            this.gridControlUpdatedInfos.MainView = this.gridView2;
            this.gridControlUpdatedInfos.Name = "gridControlUpdatedInfos";
            this.gridControlUpdatedInfos.Size = new System.Drawing.Size(197, 688);
            this.gridControlUpdatedInfos.TabIndex = 16;
            this.gridControlUpdatedInfos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4});
            this.gridView2.GridControl = this.gridControlUpdatedInfos;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "value";
            this.gridColumn1.FieldName = "ThrotthleValue";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Braking?";
            this.gridColumn4.FieldName = "Braking";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridControlFistLapInfos
            // 
            this.gridControlFistLapInfos.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControlFistLapInfos.Location = new System.Drawing.Point(390, 0);
            this.gridControlFistLapInfos.MainView = this.gridView3;
            this.gridControlFistLapInfos.Name = "gridControlFistLapInfos";
            this.gridControlFistLapInfos.Size = new System.Drawing.Size(197, 688);
            this.gridControlFistLapInfos.TabIndex = 17;
            this.gridControlFistLapInfos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6});
            this.gridView3.GridControl = this.gridControlFistLapInfos;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowFooter = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "value";
            this.gridColumn5.FieldName = "ThrotthleValue";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Braking?";
            this.gridColumn6.FieldName = "Braking";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // edtStartPower
            // 
            this.edtStartPower.Location = new System.Drawing.Point(200, 163);
            this.edtStartPower.Margin = new System.Windows.Forms.Padding(2);
            this.edtStartPower.Name = "edtStartPower";
            this.edtStartPower.Size = new System.Drawing.Size(68, 20);
            this.edtStartPower.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStartMaxLast);
            this.groupBox1.Controls.Add(this.edtStartPower);
            this.groupBox1.Controls.Add(this.edtLastCountTh);
            this.groupBox1.Controls.Add(this.btnStartAvgLast);
            this.groupBox1.Location = new System.Drawing.Point(638, 205);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(282, 194);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start Power";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Last Count Row use";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Start Power";
            // 
            // btnTestPacer
            // 
            this.btnTestPacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTestPacer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTestPacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestPacer.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestPacer.ForeColor = System.Drawing.Color.White;
            this.btnTestPacer.Location = new System.Drawing.Point(650, 487);
            this.btnTestPacer.Name = "btnTestPacer";
            this.btnTestPacer.Size = new System.Drawing.Size(261, 47);
            this.btnTestPacer.TabIndex = 21;
            this.btnTestPacer.Text = "Test Pacer";
            this.btnTestPacer.UseCompatibleTextRendering = true;
            this.btnTestPacer.UseVisualStyleBackColor = false;
            this.btnTestPacer.Click += new System.EventHandler(this.btnTestPacer_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(652, 630);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(126, 47);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseCompatibleTextRendering = true;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(790, 629);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 47);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnTestYF
            // 
            this.btnTestYF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTestYF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTestYF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestYF.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestYF.ForeColor = System.Drawing.Color.White;
            this.btnTestYF.Location = new System.Drawing.Point(652, 555);
            this.btnTestYF.Name = "btnTestYF";
            this.btnTestYF.Size = new System.Drawing.Size(126, 47);
            this.btnTestYF.TabIndex = 22;
            this.btnTestYF.Text = "Test Yellow F.";
            this.btnTestYF.UseCompatibleTextRendering = true;
            this.btnTestYF.UseVisualStyleBackColor = false;
            this.btnTestYF.Click += new System.EventHandler(this.btnTestYF_Click);
            // 
            // btnTestGF
            // 
            this.btnTestGF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTestGF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTestGF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestGF.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestGF.ForeColor = System.Drawing.Color.White;
            this.btnTestGF.Location = new System.Drawing.Point(790, 555);
            this.btnTestGF.Name = "btnTestGF";
            this.btnTestGF.Size = new System.Drawing.Size(121, 47);
            this.btnTestGF.TabIndex = 23;
            this.btnTestGF.Text = "Test Green F.";
            this.btnTestGF.UseCompatibleTextRendering = true;
            this.btnTestGF.UseVisualStyleBackColor = false;
            this.btnTestGF.Click += new System.EventHandler(this.btnTestGF_Click);
            // 
            // DlgPacerLapInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 688);
            this.Controls.Add(this.btnTestGF);
            this.Controls.Add(this.btnTestYF);
            this.Controls.Add(this.btnTestPacer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridControlFistLapInfos);
            this.Controls.Add(this.gridControlUpdatedInfos);
            this.Controls.Add(this.btnGenerateFirstLapInfos);
            this.Controls.Add(this.btnClearEnd);
            this.Controls.Add(this.btnClearBegin);
            this.Controls.Add(this.edtMinValue);
            this.Controls.Add(this.btnExportXLS);
            this.Controls.Add(this.lblCountInfos);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gridControlOriginalsInfos);
            this.Name = "DlgPacerLapInfos";
            this.Text = "OK";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOriginalsInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUpdatedInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFistLapInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlOriginalsInfos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Label lblCountInfos;
        private ESRMButton btnExportXLS;
        private System.Windows.Forms.TextBox edtMinValue;
        private ESRMButton btnClearBegin;
        private ESRMButton btnClearEnd;
        private ESRMButton btnStartMaxLast;
        private System.Windows.Forms.TextBox edtLastCountTh;
        private ESRMButton btnStartAvgLast;
        private ESRMButton btnGenerateFirstLapInfos;
        private DevExpress.XtraGrid.GridControl gridControlUpdatedInfos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.GridControl gridControlFistLapInfos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.TextBox edtStartPower;
        private System.Windows.Forms.GroupBox groupBox1;
        private ESRMButton btnTestPacer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ESRMButton btnOK;
        private ESRMButton btnCancel;
        private ESRMButton btnTestYF;
        private ESRMButton btnTestGF;
    }
}