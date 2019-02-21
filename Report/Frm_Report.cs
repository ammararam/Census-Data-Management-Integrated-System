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
using System.Collections;
using Microsoft.Reporting.WinForms;
using FastReport;
using FastReport.Utils;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;

namespace AnalysisTools.Report
{
    public partial class Frm_Report : DevComponents.DotNetBar.OfficeForm
    {
        private IHookHelper m_hookHelper = null;
        private DataSet FDataSet;
        private List<ILayer> layers;
        // private List<IField> fields;
        private FastReport.Report FReport;
        private FastReport.Style StyleRowsEven;
        private IMap map;
        private IFeatureClass selectedFClass;
        private List<int> indexes;
        private List<string> columnNames;
        private Color colorHeader;
        private Color backgroundColor;

        public IHookHelper Set_HookHelper
        {
            set
            {
                m_hookHelper = value;
            }

        }


        public Frm_Report()
        {
            InitializeComponent();
        }

        private void Frm_Report_Load(object sender, EventArgs e)
        {
            if (m_hookHelper == null) return;
            map = m_hookHelper.FocusMap;
            if (map == null) return;

            FReport = new FastReport.Report();
            FReport.Preview = PreviewReport;

            GetLayers(map);

            DefaultCustomization();

        }

        public void GetLayers(IMap map)
        {
            if (map == null)
            {
                return;
            }
            IUID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11D0-98BE-00805F7CED21}"; // Example: "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}" = IGeoFeatureLayer
            try
            {
                IEnumLayer enumLayer = map.get_Layers(((ESRI.ArcGIS.esriSystem.UID)(uid)), false); // Explicit Cast 
                enumLayer.Reset();
                ILayer layer = enumLayer.Next();

                cboLayers.Items.Clear();
                layers = new List<ILayer>();

                while (!(layer == null))
                {
                    // TODO - Implement your code here...
                    cboLayers.Items.Add(layer.Name);
                    layers.Add(layer);

                    layer = enumLayer.Next();
                }
                if (cboLayers.Items.Count > 0)
                    cboLayers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                //Windows.Forms.MessageBox.Show("No layers of type: " + uid.Value.ToString);
            }
        }

        private void BtnShowReport_Click(object sender, EventArgs e)
        {
            GetFDataset();

            if (FDataSet == null)
                return;

            if (!CreateReport())
                return;
            if (!System.IO.File.Exists(Application.StartupPath + "\\Report\\Report_TableResult.frx"))
                return;
            FReport.Preview = PreviewReport;
            FReport.Load(Application.StartupPath + "\\Report\\Report_TableResult.frx");
            FReport.RegisterData(FDataSet);
            FReport.Prepare();
            FReport.Show();
        }

        private void GetFDataset()
        {
            GetSelectedNodes();
            GetData dt = new GetData(selectedFClass);
            dt.ColumnNames = columnNames;
            dt.Indexes = indexes;
            dt.CreateFeatureDataSet();
            FDataSet = dt.FDataSet;
        }

        private void GetSelectedNodes()
        {
            columnNames = new List<string>();
            indexes = new List<int>();

            for (int i = 0; i < TreeViewReport.Nodes.Count; i++)
            {
                TreeNode node = TreeViewReport.Nodes[i];
                if (node != null && node.Checked)
                {
                    columnNames.Add(node.Text);
                    indexes.Add((int)node.Tag);
                }
            }
        }


        private bool CreateReport()
        {
            bool functionReturnValue = false;
            // ERROR: Not supported in C#: OnErrorStatement


            functionReturnValue = false;

            // create report instance
            FastReport.Report MainReport = new FastReport.Report();
            FastReport.Report StyleReport = default(FastReport.Report);

            // register the dataset
            MainReport.RegisterData(this.FDataSet);

            MainReport.GetDataSource("TableData").Enabled = true;
            if (StyleRowsEven == null)
            {
                if (System.IO.File.Exists(Application.StartupPath + "\\Report\\Pattern.frx"))
                {
                    StyleReport = new FastReport.Report();
                    StyleReport.Load(Application.StartupPath + "\\Report\\Pattern.frx");
                    StyleRowsEven = StyleReport.Styles[0];
                    if (StyleRowsEven != null)
                        MainReport.Styles.Add(StyleRowsEven);
                }
            }

            ReportPage page = new ReportPage();
            page.Width = 33 * Units.Centimeters;

            MainReport.Pages.Add(page);

            page.CreateUniqueName();

            DataBand dataBand = new DataBand();
            page.Bands.Add(dataBand);
            dataBand.CreateUniqueName();
            dataBand.DataSource = MainReport.GetDataSource("TableData");
            dataBand.Height = (Units.Centimeters * 0.5f);

            if (StyleRowsEven != null)
            {
                MainReport.Styles.Add(StyleRowsEven);
                if (!ChkWithoutColorTextReport.Checked)
                {
                    dataBand.EvenStyle = StyleRowsEven.Name;
                }
                else
                {
                    dataBand.EvenStyle = "";
                }

            }

            page.ReportTitle = new ReportTitleBand();
            page.ReportTitle.Height = (Units.Centimeters * 4f);
            page.ReportTitle.CreateUniqueName();

            if (ChkWithoutColorHeader.CheckState == CheckState.Checked)
            {
                colorHeader = Color.Transparent;
                backgroundColor = Color.Transparent;
            }

            HeaderAllReport(page,  cboLayers .SelectedItem .ToString ());
            double higthHeader = double.Parse(txtWidthHeader.Text);
            double higthBody = double.Parse(txtWidthBody.Text);
            double WidthReport = 19;
            double widthColumn = (double)19 / columnNames.Count;

            for (int i = 0; i < columnNames.Count; i++)
            {

                WidthReport -= (widthColumn - 0.005);
                if (WidthReport < 0) break;

                TextObject titleText = new TextObject();
                titleText.Parent = page.ReportTitle;
                titleText.CreateUniqueName();
                titleText.Bounds = new RectangleF(Convert.ToSingle((Units.Centimeters * WidthReport)), (Units.Centimeters * 3f), (Units.Centimeters * (float)widthColumn), (Units.Centimeters * (float)higthHeader));
                titleText.Font = FontDialog_Topic.Font;
                titleText.Text = columnNames[i];
                titleText.VertAlign = VertAlign.Center;
                titleText.HorzAlign = HorzAlign.Center;
                titleText.Fill = new LinearGradientFill(backgroundColor, colorHeader, 90, Convert .ToSingle ( higthHeader ), 1f);
                titleText.RightToLeft = true;


                TextObject ReportText = new TextObject();
                ReportText.Parent = dataBand;
                ReportText.CreateUniqueName();
                ReportText.Bounds = new RectangleF(Convert.ToSingle((Units.Centimeters * WidthReport)), 0f, (Units.Centimeters * (float)widthColumn), (Units.Centimeters * (float)higthBody));
                ReportText.Text = "[TableData." + FDataSet.Tables[0].Columns[i].ColumnName + "]";
                ReportText.Font = FontDialog_TextReport.Font;
                ReportText.HorzAlign = HorzAlign.Center;
                ReportText.VertAlign = VertAlign.Center;
                ReportText.RightToLeft = true;

               // ReportText.Border.Lines = BorderLines.All;
                //ReportText.Border.BottomLine.Color = Color.Black;
                //ReportText.Border.BottomLine.Width = 0.5f;
                //ReportText.Border.TopLine .Color = Color.Black;
                //ReportText.Border.TopLine.Width = 0.5f;
            }

            if (WidthReport < 19)
            {
                TextObject RemaintitleText = new TextObject();
                RemaintitleText.Parent = page.ReportTitle;
                RemaintitleText.CreateUniqueName();
                RemaintitleText.Bounds = new RectangleF(0.0f, (Units.Centimeters * 3f), Convert.ToSingle((Units.Centimeters * WidthReport)), (Units.Centimeters * (float)higthHeader));
                RemaintitleText.Text = "";
                RemaintitleText.VertAlign = VertAlign.Center;
                RemaintitleText.HorzAlign = HorzAlign.Center;
                RemaintitleText.Fill = new LinearGradientFill(backgroundColor, colorHeader, 90, Convert.ToSingle(higthHeader), 1f);
            }

            MainReport.Save(Application.StartupPath + "\\Report\\Report_TableResult.frx");
            MainReport.Dispose();

            functionReturnValue = true;
            return functionReturnValue;
        Err:
            return functionReturnValue;

        }


        private void HeaderAllReport(ReportPage Page, string FeaturesName)
        {
            // create title text
            TextObject titleText = new TextObject();
            titleText.Parent = Page.ReportTitle;
            titleText.CreateUniqueName();
            titleText.Bounds = new RectangleF((Units.Centimeters * 5f), 0f, (Units.Centimeters * 10f), (Units.Centimeters * 1f));
            titleText.Font = FontDialog_Topic.Font;
            titleText.Text = "بسمه تعالی";
            titleText.HorzAlign = HorzAlign.Center;
            titleText.VertAlign = VertAlign.Center;

            // create title text
            TextObject InputDateText = new TextObject();
            InputDateText.Parent = Page.ReportTitle;
            InputDateText.CreateUniqueName();
            InputDateText.Bounds = new RectangleF((Units.Centimeters * 0f), 0f, (Units.Centimeters * 2.4f), (Units.Centimeters * 1f));
            InputDateText.Font = FontDialog_Topic.Font;
            InputDateText.Text = dateTimeReport.SelectedDateInStringPersian;
            InputDateText.HorzAlign = HorzAlign.Left;
            InputDateText.VertAlign = VertAlign.Center;

            TextObject DateText = new TextObject();
            DateText.Parent = Page.ReportTitle;
            DateText.CreateUniqueName();
            DateText.Bounds = new RectangleF((Units.Centimeters * 2.4f), 0f, (Units.Centimeters * 2f), (Units.Centimeters * 1f));
            DateText.Font = FontDialog_Topic.Font;
            DateText.Text = ": " + "تاریخ";
            DateText.HorzAlign = HorzAlign.Left;
            DateText.VertAlign = VertAlign.Center;

            PictureObject PictureTitle = new PictureObject();
            PictureTitle.Parent = Page.ReportTitle;
            PictureTitle.CreateUniqueName();
            if (System.IO.File.Exists(Properties.Settings.Default.SettingLogoPath + Properties.Settings.Default.SettingLogoExtension))
                PictureTitle.Image = Image.FromFile(Properties.Settings.Default.SettingLogoPath + Properties.Settings.Default.SettingLogoExtension);

            PictureTitle.Bounds = new RectangleF((Units.Centimeters * 15f), 0f, (Units.Centimeters * 10f), (Units.Centimeters * 1f));
            PictureTitle.Width = (Units.Centimeters * 2.75f);
            PictureTitle.Height = (Units.Centimeters * 2.25f);

            // create two title text objects
            TextObject titleText1 = new TextObject();
            titleText1.Parent = Page.ReportTitle;
            titleText1.CreateUniqueName();
            titleText1.Bounds = new RectangleF((Units.Centimeters * 5f), (Units.Centimeters * 1f), (Units.Centimeters * 10f), (Units.Centimeters * 1f));
            titleText1.Font = FontDialog_Topic.Font;
            titleText1.Text = "وزارت نیرو";
            titleText1.HorzAlign = HorzAlign.Center;

            // create two title text objects
            TextObject InputNumberText1 = new TextObject();
            InputNumberText1.Parent = Page.ReportTitle;
            InputNumberText1.CreateUniqueName();
            InputNumberText1.Bounds = new RectangleF(0.0f, (Units.Centimeters * 1f), (Units.Centimeters * 2.4f), (Units.Centimeters * 1f));
            InputNumberText1.Font = FontDialog_Topic.Font;
            InputNumberText1.Text = string.IsNullOrWhiteSpace(txtNumber.Text) ? "-" : txtNumber.Text;
            InputNumberText1.HorzAlign = HorzAlign.Left;

            // create two title text objects
            TextObject NumberText1 = new TextObject();
            NumberText1.Parent = Page.ReportTitle;
            NumberText1.CreateUniqueName();
            NumberText1.Bounds = new RectangleF((Units.Centimeters * 2.4f), (Units.Centimeters * 1f), (Units.Centimeters * 2f), (Units.Centimeters * 1f));
            NumberText1.Font = FontDialog_Topic.Font;
            NumberText1.Text = ": " + "شماره";
            NumberText1.HorzAlign = HorzAlign.Left;

            TextObject titleText2 = new TextObject();
            titleText2.Parent = Page.ReportTitle;
            titleText2.CreateUniqueName();
            titleText2.Bounds = new RectangleF((Units.Centimeters * 5f), (Units.Centimeters * 1.5f), (Units.Centimeters * 10f), (Units.Centimeters * 1f));
            titleText2.Font = FontDialog_Topic.Font;
            titleText2.Text = "اداره کل محیط زیست استان هرمزگان";
            titleText2.HorzAlign = HorzAlign.Center;

            TextObject titleText3 = new TextObject();
            titleText3.Parent = Page.ReportTitle;
            titleText3.CreateUniqueName();
            titleText3.Bounds = new RectangleF((Units.Centimeters * 5f), (Units.Centimeters * 2f), (Units.Centimeters * 10f), (Units.Centimeters * 1f));
            titleText3.Font = FontDialog_Topic.Font;
            titleText3.Text = FeaturesName + " گزارش اطلاعات توصیفی عوارض لایه ";
            titleText3.HorzAlign = HorzAlign.Center;

        }

        private void cboLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFeatureLayer selectedLayer = (IFeatureLayer)layers[cboLayers.SelectedIndex];
            selectedFClass = selectedLayer.FeatureClass;

            TreeViewReport.Nodes.Clear();

            for (int i = 0; i < selectedFClass.Fields.FieldCount; i++)
            {
                IField field = selectedFClass.Fields.get_Field(i);
                if (IsValidField(field))
                {
                    TreeNode node = new TreeNode(field.AliasName);
                    node.Tag = i;
                    TreeViewReport.Nodes.Add(node);
                }
            }
        }


        private bool IsValidField(IField field)
        {
            bool valid = false;
            switch (field.Type)
            {
                case esriFieldType.esriFieldTypeBlob:
                    break;
                case esriFieldType.esriFieldTypeDate:
                    valid = true;
                    break;
                case esriFieldType.esriFieldTypeDouble:
                    valid = true;
                    break;
                case esriFieldType.esriFieldTypeGUID:
                    break;
                case esriFieldType.esriFieldTypeGeometry:
                    break;
                case esriFieldType.esriFieldTypeGlobalID:
                    break;
                case esriFieldType.esriFieldTypeInteger:
                    valid = true;
                    break;
                case esriFieldType.esriFieldTypeOID:
                    valid = true;
                    break;
                case esriFieldType.esriFieldTypeRaster:
                    break;
                case esriFieldType.esriFieldTypeSingle:
                    valid = true;
                    break;
                case esriFieldType.esriFieldTypeSmallInteger:
                    valid = true;
                    break;
                case esriFieldType.esriFieldTypeString:
                    valid = true;
                    break;
                case esriFieldType.esriFieldTypeXML:
                    break;
                default:
                    break;
            }
            return valid;
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < TreeViewReport.Nodes.Count; i++)
            {
                TreeViewReport.Nodes[i].Checked = ChkSelectAll.Checked;
            }
        }

        private void BtnFontHeaderReport_Click(object sender, EventArgs e)
        {
            FontDialog_Topic.ShowDialog();
        }

        private void ColorHeaderReport_SelectedColorChanged(object sender, EventArgs e)
        {
            colorHeader = ColorHeaderReport.SelectedColor;
        }

        private void BtnDefultStyleReport_Click(object sender, EventArgs e)
        {
            DefaultCustomization();
        }

        private void DefaultCustomization()
        {
            ColorHeaderReport.SelectedColor = Color.LightSkyBlue;

            FontDialog_Topic.Font = new Font("Tahoma", 9.0f, FontStyle.Regular);
            FontDialog_TextReport.Font = new Font("Tahoma", 9.0f, FontStyle.Regular);
            ChkWithoutColorHeader.Checked = false;
           // ChkSelectAll.Checked = true;
            ChkWithoutColorTextReport.Checked = false;
            txtWidthBody.Text = Convert.ToString(0.5);
            txtWidthHeader.Text = Convert.ToString(1);
            Properties.Settings.Default.SettingLogoPath = String.Concat(Application.StartupPath, @"\Images\Logo");
            Properties.Settings.Default.SettingLogoExtension = ".jpg";
        }

        private void BtnFontTextReport_Click(object sender, EventArgs e)
        {
            FontDialog_TextReport.ShowDialog();
        }





    }
}