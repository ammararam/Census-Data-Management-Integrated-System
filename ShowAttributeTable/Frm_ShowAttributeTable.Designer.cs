namespace Analysis_GeneralTools.ShowAttributeTable
{
    partial class Frm_ShowAttributeTable
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnZoomIn = new DevComponents.DotNetBar.ButtonItem();
            this.btnZoomOut = new DevComponents.DotNetBar.ButtonItem();
            this.btnfullExtent = new DevComponents.DotNetBar.ButtonItem();
            this.btnPan = new DevComponents.DotNetBar.ButtonItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.lstResult = new DevComponents.DotNetBar.Controls.ListViewEx();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(417, 297);
            this.splitContainer1.SplitterDistance = 29;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lstResult);
            this.splitContainer2.Size = new System.Drawing.Size(417, 264);
            this.splitContainer2.SplitterDistance = 235;
            this.splitContainer2.TabIndex = 0;
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Office2003;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnfullExtent,
            this.btnPan,
            this.btnSave,
            this.btnDelete});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(417, 25);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = global::Analysis_GeneralTools.Properties.Resources.ZoomIn;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Text = "buttonItem1";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = global::Analysis_GeneralTools.Properties.Resources.ZoomOut;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Text = "buttonItem1";
            // 
            // btnfullExtent
            // 
            this.btnfullExtent.Image = global::Analysis_GeneralTools.Properties.Resources.FullExtent1;
            this.btnfullExtent.Name = "btnfullExtent";
            this.btnfullExtent.Text = "buttonItem1";
            // 
            // btnPan
            // 
            this.btnPan.Image = global::Analysis_GeneralTools.Properties.Resources.Pan;
            this.btnPan.Name = "btnPan";
            this.btnPan.Text = "buttonItem1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Analysis_GeneralTools.Properties.Resources.SaveToolStripButton_Image;
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "buttonItem1";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Analysis_GeneralTools.Properties.Resources.delete21;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "buttonItem1";
            // 
            // lstResult
            // 
            // 
            // 
            // 
            this.lstResult.Border.Class = "ListViewBorder";
            this.lstResult.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lstResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResult.FullRowSelect = true;
            this.lstResult.GridLines = true;
            this.lstResult.Location = new System.Drawing.Point(0, 0);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(417, 235);
            this.lstResult.TabIndex = 3;
            this.lstResult.UseCompatibleStateImageBehavior = false;
            this.lstResult.View = System.Windows.Forms.View.Details;
            // 
            // Frm_ShowAttributeTable
            // 
            this.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ClientSize = new System.Drawing.Size(417, 297);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_ShowAttributeTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نمایش جدول اطلاعات توصیفی";
            this.Load += new System.EventHandler(this.Frm_ShowAttributeTable_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnZoomIn;
        private DevComponents.DotNetBar.ButtonItem btnZoomOut;
        private DevComponents.DotNetBar.ButtonItem btnfullExtent;
        private DevComponents.DotNetBar.ButtonItem btnPan;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.Controls.ListViewEx lstResult;
    }
}