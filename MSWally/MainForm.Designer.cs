namespace MSWally
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlWorld = new System.Windows.Forms.Panel();
            this.dgvWalls = new System.Windows.Forms.DataGridView();
            this.colStartX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartZOffs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndZOffs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmWallTableMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiWallModHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiWallModThickness = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiWallModStartZ = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiWallModEndZ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiWallSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMovie = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSceneSelector = new System.Windows.Forms.ComboBox();
            this.opdMoviescopeLoad = new System.Windows.Forms.OpenFileDialog();
            this.tbMovieName = new System.Windows.Forms.TextBox();
            this.pbLoadMovie = new System.Windows.Forms.Button();
            this.pbSaveMovie = new System.Windows.Forms.Button();
            this.pbSaveAs = new System.Windows.Forms.Button();
            this.cbCreateBackup = new System.Windows.Forms.CheckBox();
            this.sfdMoviescopeSave = new System.Windows.Forms.SaveFileDialog();
            this.pbSetup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSetSize = new System.Windows.Forms.Label();
            this.lblSceneCount = new System.Windows.Forms.Label();
            this.pbRestore = new System.Windows.Forms.Button();
            this.pbDeleteBackup = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCeilingHeight = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pbSetCeilingHeight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalls)).BeginInit();
            this.cmWallTableMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCeilingHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWorld
            // 
            this.pnlWorld.Location = new System.Drawing.Point(12, 120);
            this.pnlWorld.Name = "pnlWorld";
            this.pnlWorld.Size = new System.Drawing.Size(500, 500);
            this.pnlWorld.TabIndex = 0;
            this.pnlWorld.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlWorld_MouseClick);
            // 
            // dgvWalls
            // 
            this.dgvWalls.AllowUserToAddRows = false;
            this.dgvWalls.AllowUserToDeleteRows = false;
            this.dgvWalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWalls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStartX,
            this.colStartY,
            this.colEndX,
            this.colEndY,
            this.colHeight,
            this.colThickness,
            this.colStartZOffs,
            this.colEndZOffs,
            this.colLength,
            this.colDirection,
            this.colAngle});
            this.dgvWalls.ContextMenuStrip = this.cmWallTableMenu;
            this.dgvWalls.Location = new System.Drawing.Point(518, 120);
            this.dgvWalls.Name = "dgvWalls";
            this.dgvWalls.ReadOnly = true;
            this.dgvWalls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWalls.Size = new System.Drawing.Size(592, 435);
            this.dgvWalls.TabIndex = 1;
            this.dgvWalls.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvWalls_DataBindingComplete);
            this.dgvWalls.SelectionChanged += new System.EventHandler(this.dgvWalls_SelectionChanged);
            // 
            // colStartX
            // 
            this.colStartX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStartX.DataPropertyName = "StartX";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colStartX.DefaultCellStyle = dataGridViewCellStyle21;
            this.colStartX.HeaderText = "StartX";
            this.colStartX.Name = "colStartX";
            this.colStartX.ReadOnly = true;
            this.colStartX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStartX.Width = 42;
            // 
            // colStartY
            // 
            this.colStartY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStartY.DataPropertyName = "StartY";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colStartY.DefaultCellStyle = dataGridViewCellStyle22;
            this.colStartY.HeaderText = "StartY";
            this.colStartY.Name = "colStartY";
            this.colStartY.ReadOnly = true;
            this.colStartY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStartY.Width = 42;
            // 
            // colEndX
            // 
            this.colEndX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEndX.DataPropertyName = "EndX";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colEndX.DefaultCellStyle = dataGridViewCellStyle23;
            this.colEndX.HeaderText = "EndX";
            this.colEndX.Name = "colEndX";
            this.colEndX.ReadOnly = true;
            this.colEndX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEndX.Width = 39;
            // 
            // colEndY
            // 
            this.colEndY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEndY.DataPropertyName = "EndY";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colEndY.DefaultCellStyle = dataGridViewCellStyle24;
            this.colEndY.HeaderText = "EndY";
            this.colEndY.Name = "colEndY";
            this.colEndY.ReadOnly = true;
            this.colEndY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEndY.Width = 39;
            // 
            // colHeight
            // 
            this.colHeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colHeight.DataPropertyName = "Height";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colHeight.DefaultCellStyle = dataGridViewCellStyle25;
            this.colHeight.HeaderText = "Height";
            this.colHeight.Name = "colHeight";
            this.colHeight.ReadOnly = true;
            this.colHeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHeight.Width = 44;
            // 
            // colThickness
            // 
            this.colThickness.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colThickness.DataPropertyName = "Thickness";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colThickness.DefaultCellStyle = dataGridViewCellStyle26;
            this.colThickness.HeaderText = "Thickness";
            this.colThickness.Name = "colThickness";
            this.colThickness.ReadOnly = true;
            this.colThickness.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colThickness.Width = 62;
            // 
            // colStartZOffs
            // 
            this.colStartZOffs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStartZOffs.DataPropertyName = "StartZOffset";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "N1";
            dataGridViewCellStyle27.NullValue = null;
            this.colStartZOffs.DefaultCellStyle = dataGridViewCellStyle27;
            this.colStartZOffs.HeaderText = "Start ZOffs";
            this.colStartZOffs.Name = "colStartZOffs";
            this.colStartZOffs.ReadOnly = true;
            this.colStartZOffs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStartZOffs.Width = 64;
            // 
            // colEndZOffs
            // 
            this.colEndZOffs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEndZOffs.DataPropertyName = "EndZOffset";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle28.Format = "N1";
            dataGridViewCellStyle28.NullValue = null;
            this.colEndZOffs.DefaultCellStyle = dataGridViewCellStyle28;
            this.colEndZOffs.HeaderText = "End ZOffs";
            this.colEndZOffs.Name = "colEndZOffs";
            this.colEndZOffs.ReadOnly = true;
            this.colEndZOffs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colEndZOffs.Width = 61;
            // 
            // colLength
            // 
            this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLength.DataPropertyName = "Length";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Format = "N1";
            dataGridViewCellStyle29.NullValue = null;
            this.colLength.DefaultCellStyle = dataGridViewCellStyle29;
            this.colLength.HeaderText = "Length";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLength.Width = 46;
            // 
            // colDirection
            // 
            this.colDirection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDirection.DataPropertyName = "Direction";
            this.colDirection.HeaderText = "Direction";
            this.colDirection.Name = "colDirection";
            this.colDirection.ReadOnly = true;
            this.colDirection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDirection.Width = 55;
            // 
            // colAngle
            // 
            this.colAngle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAngle.DataPropertyName = "Argument";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "N1";
            dataGridViewCellStyle30.NullValue = null;
            this.colAngle.DefaultCellStyle = dataGridViewCellStyle30;
            this.colAngle.HeaderText = "Angle";
            this.colAngle.Name = "colAngle";
            this.colAngle.ReadOnly = true;
            this.colAngle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAngle.Width = 40;
            // 
            // cmWallTableMenu
            // 
            this.cmWallTableMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiWallModHeight,
            this.cmiWallModThickness,
            this.cmiWallModStartZ,
            this.cmiWallModEndZ,
            this.toolStripSeparator2,
            this.cmiWallSelectAll});
            this.cmWallTableMenu.Name = "cmWallTableMenu";
            this.cmWallTableMenu.Size = new System.Drawing.Size(268, 120);
            this.cmWallTableMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmWallTableMenu_Opening);
            // 
            // cmiWallModHeight
            // 
            this.cmiWallModHeight.Name = "cmiWallModHeight";
            this.cmiWallModHeight.Size = new System.Drawing.Size(267, 22);
            this.cmiWallModHeight.Text = "Selected Walls: Modify Height";
            this.cmiWallModHeight.Click += new System.EventHandler(this.cmiWallModHeight_Click);
            // 
            // cmiWallModThickness
            // 
            this.cmiWallModThickness.Name = "cmiWallModThickness";
            this.cmiWallModThickness.Size = new System.Drawing.Size(267, 22);
            this.cmiWallModThickness.Text = "Selected Walls: Modify Thickness";
            this.cmiWallModThickness.Click += new System.EventHandler(this.cmiWallModHeight_Click);
            // 
            // cmiWallModStartZ
            // 
            this.cmiWallModStartZ.Name = "cmiWallModStartZ";
            this.cmiWallModStartZ.Size = new System.Drawing.Size(267, 22);
            this.cmiWallModStartZ.Text = "Selected Walls: Modify Start Z-Offset";
            this.cmiWallModStartZ.Click += new System.EventHandler(this.cmiWallModHeight_Click);
            // 
            // cmiWallModEndZ
            // 
            this.cmiWallModEndZ.Name = "cmiWallModEndZ";
            this.cmiWallModEndZ.Size = new System.Drawing.Size(267, 22);
            this.cmiWallModEndZ.Text = "Selected Walls: Modify End Z-Offset";
            this.cmiWallModEndZ.Click += new System.EventHandler(this.cmiWallModHeight_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(264, 6);
            // 
            // cmiWallSelectAll
            // 
            this.cmiWallSelectAll.Name = "cmiWallSelectAll";
            this.cmiWallSelectAll.Size = new System.Drawing.Size(267, 22);
            this.cmiWallSelectAll.Text = "Select All Walls";
            this.cmiWallSelectAll.Click += new System.EventHandler(this.cmiWallSelectAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "World (Set):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(526, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Walls:";
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovie.Location = new System.Drawing.Point(12, 17);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(45, 13);
            this.lblMovie.TabIndex = 4;
            this.lblMovie.Text = "Movie:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Scene:";
            // 
            // cbSceneSelector
            // 
            this.cbSceneSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSceneSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSceneSelector.FormattingEnabled = true;
            this.cbSceneSelector.Location = new System.Drawing.Point(57, 45);
            this.cbSceneSelector.Name = "cbSceneSelector";
            this.cbSceneSelector.Size = new System.Drawing.Size(391, 21);
            this.cbSceneSelector.TabIndex = 6;
            this.cbSceneSelector.SelectedIndexChanged += new System.EventHandler(this.cbSceneSelector_SelectedIndexChanged);
            // 
            // opdMoviescopeLoad
            // 
            this.opdMoviescopeLoad.DefaultExt = "mscope";
            this.opdMoviescopeLoad.FileName = "openFileDialog1";
            this.opdMoviescopeLoad.Filter = "MS Movie Detail Description|*.mscope|Backup files|*.bak*|All files|*.*";
            // 
            // tbMovieName
            // 
            this.tbMovieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMovieName.Location = new System.Drawing.Point(57, 12);
            this.tbMovieName.Name = "tbMovieName";
            this.tbMovieName.ReadOnly = true;
            this.tbMovieName.Size = new System.Drawing.Size(487, 23);
            this.tbMovieName.TabIndex = 7;
            // 
            // pbLoadMovie
            // 
            this.pbLoadMovie.Location = new System.Drawing.Point(563, 12);
            this.pbLoadMovie.Name = "pbLoadMovie";
            this.pbLoadMovie.Size = new System.Drawing.Size(75, 23);
            this.pbLoadMovie.TabIndex = 8;
            this.pbLoadMovie.Text = "Load";
            this.pbLoadMovie.UseVisualStyleBackColor = true;
            this.pbLoadMovie.Click += new System.EventHandler(this.pbLoadMovie_Click);
            // 
            // pbSaveMovie
            // 
            this.pbSaveMovie.Location = new System.Drawing.Point(654, 12);
            this.pbSaveMovie.Name = "pbSaveMovie";
            this.pbSaveMovie.Size = new System.Drawing.Size(75, 23);
            this.pbSaveMovie.TabIndex = 9;
            this.pbSaveMovie.Text = "Save";
            this.pbSaveMovie.UseVisualStyleBackColor = true;
            this.pbSaveMovie.Click += new System.EventHandler(this.pbSaveMovie_Click);
            // 
            // pbSaveAs
            // 
            this.pbSaveAs.Location = new System.Drawing.Point(654, 45);
            this.pbSaveAs.Name = "pbSaveAs";
            this.pbSaveAs.Size = new System.Drawing.Size(75, 23);
            this.pbSaveAs.TabIndex = 10;
            this.pbSaveAs.Text = "Save As...";
            this.pbSaveAs.UseVisualStyleBackColor = true;
            this.pbSaveAs.Click += new System.EventHandler(this.pbSaveAs_Click);
            // 
            // cbCreateBackup
            // 
            this.cbCreateBackup.AutoSize = true;
            this.cbCreateBackup.Checked = true;
            this.cbCreateBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCreateBackup.Location = new System.Drawing.Point(752, 16);
            this.cbCreateBackup.Name = "cbCreateBackup";
            this.cbCreateBackup.Size = new System.Drawing.Size(96, 17);
            this.cbCreateBackup.TabIndex = 12;
            this.cbCreateBackup.Text = "Create backup";
            this.cbCreateBackup.UseVisualStyleBackColor = true;
            // 
            // sfdMoviescopeSave
            // 
            this.sfdMoviescopeSave.DefaultExt = "mscope";
            this.sfdMoviescopeSave.Filter = "MS Movie Detail Description|*.mscope|Backup files|*.bak*|All files|*.*";
            // 
            // pbSetup
            // 
            this.pbSetup.Image = ((System.Drawing.Image)(resources.GetObject("pbSetup.Image")));
            this.pbSetup.Location = new System.Drawing.Point(1069, 12);
            this.pbSetup.Name = "pbSetup";
            this.pbSetup.Size = new System.Drawing.Size(32, 32);
            this.pbSetup.TabIndex = 13;
            this.pbSetup.UseVisualStyleBackColor = true;
            this.pbSetup.Click += new System.EventHandler(this.pbSetup_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Set Size:";
            // 
            // lblSetSize
            // 
            this.lblSetSize.AutoSize = true;
            this.lblSetSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetSize.Location = new System.Drawing.Point(168, 104);
            this.lblSetSize.Name = "lblSetSize";
            this.lblSetSize.Size = new System.Drawing.Size(27, 13);
            this.lblSetSize.TabIndex = 15;
            this.lblSetSize.Text = "0x0";
            // 
            // lblSceneCount
            // 
            this.lblSceneCount.AutoSize = true;
            this.lblSceneCount.Location = new System.Drawing.Point(464, 50);
            this.lblSceneCount.Name = "lblSceneCount";
            this.lblSceneCount.Size = new System.Drawing.Size(51, 13);
            this.lblSceneCount.TabIndex = 16;
            this.lblSceneCount.Text = "(1 scene)";
            this.lblSceneCount.Visible = false;
            // 
            // pbRestore
            // 
            this.pbRestore.Enabled = false;
            this.pbRestore.Location = new System.Drawing.Point(854, 12);
            this.pbRestore.Name = "pbRestore";
            this.pbRestore.Size = new System.Drawing.Size(75, 23);
            this.pbRestore.TabIndex = 17;
            this.pbRestore.Text = "Restore";
            this.pbRestore.UseVisualStyleBackColor = true;
            this.pbRestore.Click += new System.EventHandler(this.pbRestore_Click);
            // 
            // pbDeleteBackup
            // 
            this.pbDeleteBackup.Enabled = false;
            this.pbDeleteBackup.Location = new System.Drawing.Point(854, 43);
            this.pbDeleteBackup.Name = "pbDeleteBackup";
            this.pbDeleteBackup.Size = new System.Drawing.Size(75, 23);
            this.pbDeleteBackup.TabIndex = 18;
            this.pbDeleteBackup.Text = "Del. Backup";
            this.pbDeleteBackup.UseVisualStyleBackColor = true;
            this.pbDeleteBackup.Click += new System.EventHandler(this.pbDeleteBackup_Click);
            // 
            // tbLog
            // 
            this.tbLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog.Location = new System.Drawing.Point(12, 626);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(1098, 117);
            this.tbLog.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(518, 585);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Set Ceiling Height:";
            // 
            // nudCeilingHeight
            // 
            this.nudCeilingHeight.DecimalPlaces = 1;
            this.nudCeilingHeight.Location = new System.Drawing.Point(637, 583);
            this.nudCeilingHeight.Name = "nudCeilingHeight";
            this.nudCeilingHeight.Size = new System.Drawing.Size(55, 20);
            this.nudCeilingHeight.TabIndex = 21;
            this.nudCeilingHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCeilingHeight.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(784, 580);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(326, 36);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "PLEASE NOTE that the ceiling height is set globally on a scene set basis, and it " +
    "should be set accordingly with wall height in the set";
            // 
            // pbSetCeilingHeight
            // 
            this.pbSetCeilingHeight.Location = new System.Drawing.Point(698, 580);
            this.pbSetCeilingHeight.Name = "pbSetCeilingHeight";
            this.pbSetCeilingHeight.Size = new System.Drawing.Size(75, 23);
            this.pbSetCeilingHeight.TabIndex = 23;
            this.pbSetCeilingHeight.Text = "Update";
            this.pbSetCeilingHeight.UseVisualStyleBackColor = true;
            this.pbSetCeilingHeight.Click += new System.EventHandler(this.pbSetCeilingHeight_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 742);
            this.Controls.Add(this.pbSetCeilingHeight);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.nudCeilingHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.pbDeleteBackup);
            this.Controls.Add(this.pbRestore);
            this.Controls.Add(this.lblSceneCount);
            this.Controls.Add(this.lblSetSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbSetup);
            this.Controls.Add(this.cbCreateBackup);
            this.Controls.Add(this.pbSaveAs);
            this.Controls.Add(this.pbSaveMovie);
            this.Controls.Add(this.pbLoadMovie);
            this.Controls.Add(this.tbMovieName);
            this.Controls.Add(this.cbSceneSelector);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMovie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvWalls);
            this.Controls.Add(this.pnlWorld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalls)).EndInit();
            this.cmWallTableMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCeilingHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlWorld;
        private System.Windows.Forms.DataGridView dgvWalls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSceneSelector;
        private System.Windows.Forms.OpenFileDialog opdMoviescopeLoad;
        private System.Windows.Forms.TextBox tbMovieName;
        private System.Windows.Forms.Button pbLoadMovie;
        private System.Windows.Forms.Button pbSaveMovie;
        private System.Windows.Forms.Button pbSaveAs;
        private System.Windows.Forms.ContextMenuStrip cmWallTableMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmiWallSelectAll;
        private System.Windows.Forms.CheckBox cbCreateBackup;
        private System.Windows.Forms.SaveFileDialog sfdMoviescopeSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThickness;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartZOffs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndZOffs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAngle;
        private System.Windows.Forms.ToolStripMenuItem cmiWallModHeight;
        private System.Windows.Forms.ToolStripMenuItem cmiWallModThickness;
        private System.Windows.Forms.ToolStripMenuItem cmiWallModStartZ;
        private System.Windows.Forms.ToolStripMenuItem cmiWallModEndZ;
        private System.Windows.Forms.Button pbSetup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSetSize;
        private System.Windows.Forms.Label lblSceneCount;
        private System.Windows.Forms.Button pbRestore;
        private System.Windows.Forms.Button pbDeleteBackup;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCeilingHeight;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button pbSetCeilingHeight;
    }
}

