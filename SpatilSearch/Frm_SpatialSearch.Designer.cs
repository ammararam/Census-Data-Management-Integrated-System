namespace AnalysisTools.SpatilSearch
{
    partial class Frm_SpatialSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SpatialSearch));
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lstFeatures = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.doubleInput = new DevComponents.Editors.DoubleInput();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rbtSelectedFeature = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtClickedPoint = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkShowGraphics = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cboLayers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ContextMenu_LstResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FlashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnSelectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FullExtentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbonBar1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.ContextMenu_LstResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.groupPanel2);
            this.ribbonBar1.Controls.Add(this.groupPanel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.ForeColor = System.Drawing.Color.White;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(359, 310);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.lstFeatures);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Location = new System.Drawing.Point(3, 163);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(353, 129);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "عوارض یافت شده";
            this.groupPanel2.TitleImage = global::AnalysisTools.Properties.Resources.Find;
            // 
            // lstFeatures
            // 
            // 
            // 
            // 
            this.lstFeatures.Border.Class = "ListViewBorder";
            this.lstFeatures.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lstFeatures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFeatures.FullRowSelect = true;
            this.lstFeatures.GridLines = true;
            this.lstFeatures.Location = new System.Drawing.Point(0, 0);
            this.lstFeatures.Name = "lstFeatures";
            this.lstFeatures.Size = new System.Drawing.Size(347, 107);
            this.lstFeatures.SmallImageList = this.imageList1;
            this.lstFeatures.TabIndex = 3;
            this.lstFeatures.UseCompatibleStateImageBehavior = false;
            this.lstFeatures.View = System.Windows.Forms.View.Details;
            this.lstFeatures.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstFeatures_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "لایه";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "شناسه عارضه";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 113;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "فاصله";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 124;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Layer_LYR_File32.png");
            this.imageList1.Images.SetKeyName(1, "LayerGroup32.png");
            this.imageList1.Images.SetKeyName(2, "LayerPoint32.png");
            this.imageList1.Images.SetKeyName(3, "LayerRasterOptimized32.png");
            this.imageList1.Images.SetKeyName(4, "pencil-ruler.png");
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.doubleInput);
            this.groupPanel1.Controls.Add(this.pictureBox1);
            this.groupPanel1.Controls.Add(this.groupPanel3);
            this.groupPanel1.Controls.Add(this.chkShowGraphics);
            this.groupPanel1.Controls.Add(this.cboLayers);
            this.groupPanel1.Controls.Add(this.btnClose);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Location = new System.Drawing.Point(3, 16);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(353, 145);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "پارامترهای ورودی";
            // 
            // doubleInput
            // 
            // 
            // 
            // 
            this.doubleInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput.Increment = 1D;
            this.doubleInput.Location = new System.Drawing.Point(161, 70);
            this.doubleInput.MinValue = 0D;
            this.doubleInput.Name = "doubleInput";
            this.doubleInput.ShowUpDown = true;
            this.doubleInput.Size = new System.Drawing.Size(97, 21);
            this.doubleInput.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AnalysisTools.Properties.Resources.LayerBasemap16;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.rbtSelectedFeature);
            this.groupPanel3.Controls.Add(this.rbtClickedPoint);
            this.groupPanel3.DrawTitleBox = false;
            this.groupPanel3.Location = new System.Drawing.Point(0, 25);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(347, 41);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 12;
            this.groupPanel3.Text = "انتخاب محل مبدا";
            // 
            // rbtSelectedFeature
            // 
            this.rbtSelectedFeature.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtSelectedFeature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtSelectedFeature.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtSelectedFeature.Location = new System.Drawing.Point(40, -1);
            this.rbtSelectedFeature.Name = "rbtSelectedFeature";
            this.rbtSelectedFeature.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtSelectedFeature.Size = new System.Drawing.Size(112, 16);
            this.rbtSelectedFeature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtSelectedFeature.TabIndex = 13;
            this.rbtSelectedFeature.Text = "عارضه انتخاب شده";
            this.rbtSelectedFeature.CheckedChanged += new System.EventHandler(this.rbtSelectedFeature_CheckedChanged);
            // 
            // rbtClickedPoint
            // 
            this.rbtClickedPoint.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtClickedPoint.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtClickedPoint.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtClickedPoint.Location = new System.Drawing.Point(158, -1);
            this.rbtClickedPoint.Name = "rbtClickedPoint";
            this.rbtClickedPoint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtClickedPoint.Size = new System.Drawing.Size(97, 16);
            this.rbtClickedPoint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtClickedPoint.TabIndex = 12;
            this.rbtClickedPoint.Text = "محل کلیک موس";
         
            // 
            // chkShowGraphics
            // 
            this.chkShowGraphics.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkShowGraphics.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkShowGraphics.Location = new System.Drawing.Point(29, 74);
            this.chkShowGraphics.Name = "chkShowGraphics";
            this.chkShowGraphics.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkShowGraphics.Size = new System.Drawing.Size(126, 14);
            this.chkShowGraphics.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkShowGraphics.TabIndex = 11;
            this.chkShowGraphics.Text = "نمایش گرافیکی عوارض";
            // 
            // cboLayers
            // 
            this.cboLayers.DisplayMember = "Text";
            this.cboLayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayers.FormattingEnabled = true;
            this.cboLayers.ItemHeight = 15;
            this.cboLayers.Location = new System.Drawing.Point(26, 1);
            this.cboLayers.Name = "cboLayers";
            this.cboLayers.Size = new System.Drawing.Size(232, 21);
            this.cboLayers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboLayers.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Image = global::AnalysisTools.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(59, 99);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 21);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "بستن";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Image = global::AnalysisTools.Properties.Resources.Find;
            this.btnSearch.Location = new System.Drawing.Point(197, 99);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 21);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(264, 74);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "فاصله مورد نظر:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(268, 4);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "لیست لایه ها:";
            // 
            // ContextMenu_LstResult
            // 
            this.ContextMenu_LstResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ContextMenu_LstResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FlashToolStripMenuItem,
            this.toolStripSeparator1,
            this.SelectToolStripMenuItem,
            this.UnSelectToolStripMenuItem1,
            this.toolStripSeparator2,
            this.ZoomToolStripMenuItem1,
            this.FullExtentToolStripMenuItem1});
            this.ContextMenu_LstResult.Name = "ContextMenu_TreeFeatures";
            this.ContextMenu_LstResult.Size = new System.Drawing.Size(133, 126);
            // 
            // FlashToolStripMenuItem
            // 
            this.FlashToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlashToolStripMenuItem.Image = global::AnalysisTools.Properties.Resources.RouteEventsUI_4057;
            this.FlashToolStripMenuItem.Name = "FlashToolStripMenuItem";
            this.FlashToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.FlashToolStripMenuItem.Text = "فلش";
            this.FlashToolStripMenuItem.Click += new System.EventHandler(this.FlashToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // SelectToolStripMenuItem
            // 
            this.SelectToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectToolStripMenuItem.Image = global::AnalysisTools.Properties.Resources.SelectFeature;
            this.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem";
            this.SelectToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.SelectToolStripMenuItem.Text = "انتخاب";
            this.SelectToolStripMenuItem.Click += new System.EventHandler(this.SelectToolStripMenuItem_Click);
            // 
            // UnSelectToolStripMenuItem1
            // 
            this.UnSelectToolStripMenuItem1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnSelectToolStripMenuItem1.Image = global::AnalysisTools.Properties.Resources.ClearSelection;
            this.UnSelectToolStripMenuItem1.Name = "UnSelectToolStripMenuItem1";
            this.UnSelectToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.UnSelectToolStripMenuItem1.Text = "حذف انتخاب";
            this.UnSelectToolStripMenuItem1.Click += new System.EventHandler(this.UnSelectToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            // 
            // ZoomToolStripMenuItem1
            // 
            this.ZoomToolStripMenuItem1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomToolStripMenuItem1.Image = global::AnalysisTools.Properties.Resources.ZoomIn;
            this.ZoomToolStripMenuItem1.Name = "ZoomToolStripMenuItem1";
            this.ZoomToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.ZoomToolStripMenuItem1.Text = "بزرگنمایی";
            this.ZoomToolStripMenuItem1.Click += new System.EventHandler(this.ZoomToolStripMenuItem1_Click);
            // 
            // FullExtentToolStripMenuItem1
            // 
            this.FullExtentToolStripMenuItem1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullExtentToolStripMenuItem1.Image = global::AnalysisTools.Properties.Resources.FullExtent;
            this.FullExtentToolStripMenuItem1.Name = "FullExtentToolStripMenuItem1";
            this.FullExtentToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.FullExtentToolStripMenuItem1.Text = "محدوده اولیه";
            this.FullExtentToolStripMenuItem1.Click += new System.EventHandler(this.FullExtentToolStripMenuItem1_Click);
            // 
            // Frm_SpatialSearch
            // 
            this.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ClientSize = new System.Drawing.Size(359, 310);
            this.Controls.Add(this.ribbonBar1);
            this.EnableGlass = false;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Frm_SpatialSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_SpatialSearch";
            this.TitleText = "جستجوی مکانی";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_SpatialSearch_FormClosing);
            this.Load += new System.EventHandler(this.Frm_SpatialSearch_Load);
            this.ribbonBar1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.ContextMenu_LstResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ListViewEx lstFeatures;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkShowGraphics;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboLayers;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.Editors.DoubleInput doubleInput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtSelectedFeature;
        public DevComponents.DotNetBar.Controls.CheckBoxX rbtClickedPoint;
        public DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private System.Windows.Forms.ContextMenuStrip ContextMenu_LstResult;
        private System.Windows.Forms.ToolStripMenuItem FlashToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnSelectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ZoomToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem FullExtentToolStripMenuItem1;
    }
}