namespace AnalysisTools.MapTips
{
    partial class frm_MapTips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_MapTips));
            this.Toolbar = new DevComponents.DotNetBar.Bar();
            this.btnShowMapTip = new DevComponents.DotNetBar.ButtonItem();
            this.btnCleanMapTip = new DevComponents.DotNetBar.ButtonItem();
            this.btnClose = new DevComponents.DotNetBar.ButtonItem();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rbtnNormal = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtnTransparent = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cboFields = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLayers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Toolbar)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toolbar
            // 
            this.Toolbar.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.Toolbar.AccessibleName = "DotNetBar Bar";
            this.Toolbar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.Toolbar.AntiAlias = true;
            this.Toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Toolbar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Toolbar.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Office2003;
            this.Toolbar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnShowMapTip,
            this.btnCleanMapTip,
            this.btnClose});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(314, 25);
            this.Toolbar.Stretch = true;
            this.Toolbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.Toolbar.TabIndex = 8;
            this.Toolbar.TabStop = false;
            // 
            // btnShowMapTip
            // 
            this.btnShowMapTip.Image = global::AnalysisTools.Properties.Resources.HTMLPopUpTool16;
            this.btnShowMapTip.Name = "btnShowMapTip";
            this.btnShowMapTip.Text = "buttonItem1";
            this.btnShowMapTip.Click += new System.EventHandler(this.btnShowMapTip_Click);
            // 
            // btnCleanMapTip
            // 
            this.btnCleanMapTip.Image = global::AnalysisTools.Properties.Resources.edit_clear;
            this.btnCleanMapTip.Name = "btnCleanMapTip";
            this.btnCleanMapTip.Text = "buttonItem1";
            this.btnCleanMapTip.Click += new System.EventHandler(this.btnCleanMapTip_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::AnalysisTools.Properties.Resources.close1;
            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "buttonItem1";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Controls.Add(this.cboFields);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cboLayers);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupPanel1.Location = new System.Drawing.Point(0, 25);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(314, 119);
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
            this.groupPanel1.Style.TextShadowOffset = new System.Drawing.Point(10, 0);
            this.groupPanel1.Style.TextTrimming = DevComponents.DotNetBar.eStyleTextTrimming.Character;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 7;
            this.groupPanel1.Text = "انتخاب لایه و فیلد توصیفی";
            this.groupPanel1.TitleImage = global::AnalysisTools.Properties.Resources.Layers;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.rbtnNormal);
            this.groupPanel2.Controls.Add(this.rbtnTransparent);
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Location = new System.Drawing.Point(0, 55);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(308, 39);
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
            this.groupPanel2.TabIndex = 90;
            this.groupPanel2.Text = "نحوه نمایش";
            // 
            // rbtnNormal
            // 
            this.rbtnNormal.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnNormal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnNormal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnNormal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rbtnNormal.Location = new System.Drawing.Point(139, -1);
            this.rbtnNormal.Name = "rbtnNormal";
            this.rbtnNormal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtnNormal.Size = new System.Drawing.Size(91, 17);
            this.rbtnNormal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnNormal.TabIndex = 98;
            this.rbtnNormal.Text = "عادی";
            this.rbtnNormal.TextColor = System.Drawing.Color.Black;
            this.rbtnNormal.CheckedChanged += new System.EventHandler(this.rbtnNormal_CheckedChanged);
            // 
            // rbtnTransparent
            // 
            this.rbtnTransparent.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnTransparent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnTransparent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnTransparent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rbtnTransparent.Location = new System.Drawing.Point(10, -1);
            this.rbtnTransparent.Name = "rbtnTransparent";
            this.rbtnTransparent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtnTransparent.Size = new System.Drawing.Size(91, 17);
            this.rbtnTransparent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnTransparent.TabIndex = 97;
            this.rbtnTransparent.Text = "شفاف";
            this.rbtnTransparent.TextColor = System.Drawing.Color.Black;
            this.rbtnTransparent.CheckedChanged += new System.EventHandler(this.rbtnTransparent_CheckedChanged);
            // 
            // cboFields
            // 
            this.cboFields.DisplayMember = "Text";
            this.cboFields.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFields.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboFields.FormattingEnabled = true;
            this.cboFields.ItemHeight = 15;
            this.cboFields.Location = new System.Drawing.Point(9, 28);
            this.cboFields.Name = "cboFields";
            this.cboFields.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboFields.Size = new System.Drawing.Size(220, 21);
            this.cboFields.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboFields.TabIndex = 89;
            this.cboFields.SelectedIndexChanged += new System.EventHandler(this.cboFields_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(235, 32);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "فیلد توصیفی:";
            // 
            // cboLayers
            // 
            this.cboLayers.DisplayMember = "Text";
            this.cboLayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboLayers.FormattingEnabled = true;
            this.cboLayers.ItemHeight = 15;
            this.cboLayers.Location = new System.Drawing.Point(9, 1);
            this.cboLayers.Name = "cboLayers";
            this.cboLayers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboLayers.Size = new System.Drawing.Size(220, 21);
            this.cboLayers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboLayers.TabIndex = 1;
            this.cboLayers.SelectedIndexChanged += new System.EventHandler(this.cboLayer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(247, 6);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "لایه مکانی:";
            // 
            // frm_MapTips
            // 
            this.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ClientSize = new System.Drawing.Size(314, 144);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.Toolbar);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_MapTips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمایش فیلد توصیفی";
            this.TitleText = "نمایش فیلد توصیفی";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_MapTips_FormClosing);
            this.Load += new System.EventHandler(this.frm_MapTips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Toolbar)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cboLayers;
        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cboFields;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Bar Toolbar;
        private DevComponents.DotNetBar.ButtonItem btnShowMapTip;
        private DevComponents.DotNetBar.ButtonItem btnCleanMapTip;
        private DevComponents.DotNetBar.ButtonItem btnClose;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnNormal;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnTransparent;
    }
}