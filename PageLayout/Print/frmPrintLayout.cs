using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;

namespace AnalysisTools.PageLayout.Print
{
    public partial class frmPrintLayout : DevComponents.DotNetBar.OfficeForm
    {
        private IHookHelper m_hookHelper = null;
        private IPageLayoutControl pageLayoutControl;
        public IHookHelper Set_HookHelper
        {
            get { return m_hookHelper; }
            set { m_hookHelper = value; }
        }

        public frmPrintLayout()
        {
            InitializeComponent();
        }

        private void frmPrintLayout_Load(object sender, EventArgs e)
        {
            pageLayoutControl = m_hookHelper.Hook as IPageLayoutControl;
            if (pageLayoutControl == null) return;

            //Add esriPageFormID constants to drop down
            cboPageSize.Items.Add("Letter - 8.5in x 11in.");
            cboPageSize.Items.Add("Legal - 8.5in x 14in.");
            cboPageSize.Items.Add("Tabloid - 11in x 17in.");
            cboPageSize.Items.Add("C - 17in x 22in.");
            cboPageSize.Items.Add("D - 22in x 34in.");
            cboPageSize.Items.Add("E - 34in x 44in.");
            cboPageSize.Items.Add("A5 - 148mm x 210mm.");
            cboPageSize.Items.Add("A4 - 210mm x 297mm.");
            cboPageSize.Items.Add("A3 - 297mm x 420mm.");
            cboPageSize.Items.Add("A2 - 420mm x 594mm.");
            cboPageSize.Items.Add("A1 - 594mm x 841mm.");
            cboPageSize.Items.Add("A0 - 841mm x 1189mm.");
            cboPageSize.Items.Add("Custom Page Size.");
            cboPageSize.Items.Add("Same as Printer Form.");
            cboPageSize.SelectedIndex = 7;

            //Add esriPageToPrinterMapping constants to drop down
            cboPageToPrinterMapping.Items.Add("0: Crop");
            cboPageToPrinterMapping.Items.Add("1: Scale");
            cboPageToPrinterMapping.Items.Add("2: Tile");
            cboPageToPrinterMapping.SelectedIndex = 1;
            optPortrait.Checked = true;
            EnableOrientation(false);

            //Display printer details
            UpdatePrintingDisplay();

            //Update page display
            cboPageSize.SelectedIndex = (int)pageLayoutControl.Page.FormID;
            cboPageToPrinterMapping.SelectedIndex = (int)pageLayoutControl.Page.PageToPrinterMapping;
            if (pageLayoutControl.Page.Orientation == 1)
            {
                optPortrait.Checked = true;
            }
            else
            {
                optLandscape.Checked = true;
            }

            //Update printer page display
            UpdatePrintPageDisplay();

        }

        private void UpdatePrintPageDisplay()
        {
            //Determine the number of pages
            short iPageCount = pageLayoutControl.get_PrinterPageCount(Convert.ToDouble(txbOverlap.Text));
            lblPageCount.Text = iPageCount.ToString();

            //Validate start and end pages
            int iPageStart = Convert.ToInt32(txbStartPage.Text);
            int iPageEnd = Convert.ToInt32(txbEndPage.Text);
            if ((iPageStart < 1) | (iPageStart > iPageCount))
            {
                txbStartPage.Text = "1";
            }
            if ((iPageEnd < 1) | (iPageEnd > iPageCount))
            {
                txbEndPage.Text = iPageCount.ToString();
            }
        }

        private void EnableOrientation(bool b)
        {
            optPortrait.Enabled = b;
            optLandscape.Enabled = b;
        }

  
        private void UpdatePrintingDisplay()
        {
            if (pageLayoutControl.Printer != null)
            {
                //Get IPrinter interface through the PageLayoutControl's printer
                IPrinter printer = pageLayoutControl.Printer;

                //Determine the orientation of the printer's paper
                if (printer.Paper.Orientation == 1)
                {
                    lblPrinterOrientation.Text = "عمودی";
                }
                else
                {
                    lblPrinterOrientation.Text = "افقی";
                }

                //Determine the printer name
                lblPrinterName.Text = printer.Paper.PrinterName;

                //Determine the printer's paper size
                double dWidth;
                double dheight;
                printer.Paper.QueryPaperSize(out dWidth, out dheight);
                lblPrinterSize.Text = dWidth.ToString("###.000") + " X " + dheight.ToString("###.000") + " Inches";
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (pageLayoutControl.Printer != null)
            {
                //Set mouse pointer
                pageLayoutControl.MousePointer = esriControlsMousePointer.esriPointerHourglass;

                //Get IPrinter interface through the PageLayoutControl's printer
                IPrinter printer = pageLayoutControl.Printer;

                //Determine whether printer paper's orientation needs changing
                if (printer.Paper.Orientation != pageLayoutControl.Page.Orientation)
                {
                    printer.Paper.Orientation = pageLayoutControl.Page.Orientation;
                    //Update the display
                    UpdatePrintingDisplay();
                }

                //Print the page range with the specified overlap
                pageLayoutControl.PrintPageLayout(Convert.ToInt16(txbStartPage.Text), Convert.ToInt16(txbEndPage.Text), Convert.ToDouble(txbOverlap.Text));

                //Set the mouse pointer
                pageLayoutControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }
        }

        private void txbOverlap_Leave(object sender, EventArgs e)
        {
            UpdatePrintPageDisplay();
        }

        private void cboPageToPrinterMapping_Click(object sender, EventArgs e)
        {
            //Set the printer to page mapping
            pageLayoutControl.Page.PageToPrinterMapping = (esriPageToPrinterMapping)cboPageToPrinterMapping.SelectedIndex;
            //Update printer page display
            UpdatePrintPageDisplay();
        }

    
        private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Orientation cannot change if the page size is set to 'Same as Printer'
            if (cboPageSize.SelectedIndex == 13)
                EnableOrientation(false);
            else
                EnableOrientation(true);
            //Set the page size
            pageLayoutControl.Page.FormID = (esriPageFormID)cboPageSize.SelectedIndex;
            //Update printer page display
            UpdatePrintPageDisplay();
        }

        private void optLandscape_CheckedChanged(object sender, EventArgs e)
        {
            if (optLandscape.Checked == true)
            {
                //Set the page orientation
                if (pageLayoutControl.Page.FormID != esriPageFormID.esriPageFormSameAsPrinter)
                {
                    pageLayoutControl.Page.Orientation = 2;
                }
                //Update printer page display
                UpdatePrintPageDisplay();
            }
        }

        private void optPortrait_CheckedChanged(object sender, EventArgs e)
        {
            if (optPortrait.Checked == true)
            {
                //Set the page orientation
                if (pageLayoutControl.Page.FormID != esriPageFormID.esriPageFormSameAsPrinter)
                {
                    pageLayoutControl.Page.Orientation = 1;
                }
                //Update printer page display
                UpdatePrintPageDisplay();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrintLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            pageLayoutControl = null;
        }
    }
}