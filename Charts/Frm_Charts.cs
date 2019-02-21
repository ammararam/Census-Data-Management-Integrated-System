using ESRI.ArcGIS.esriSystem;
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
using ESRI.ArcGIS.Geodatabase;
using Telerik.Charting;
using ESRI.ArcGIS.DataSourcesGDB;
using Microsoft.CSharp;


namespace Analysis_GeneralTools.Charts
{
    public partial class Frm_Charts : DevComponents.DotNetBar.OfficeForm
    {
        private IHookHelper m_hookHelper = null;
        private IMap m_Map;
        private ArrayList m_ArrayLayers;
        private ArrayList m_ArrayFields;
        private ArrayList m_ArrayTables;
        //  private ArrayList m_ArrayFields_AxisY;

        public IHookHelper Set_HookHelper
        {
            set
            {
                m_hookHelper = value;
            }
        }

        public Frm_Charts()
        {
            InitializeComponent();
        }

        private void Frm_Charts_Load(object sender, EventArgs e)
        {
            microChartItem1.DataPoints = GetRandomDataPoints();
            microChartItem2.DataPoints = GetRandomDataPoints();
            microChartItem3.DataPoints = GetRandomDataPoints();
            microChartItem4.DataPoints = GetRandomDataPoints();
            microChartItem5.DataPoints = GetRandomDataPoints();
            microChartItem6.DataPoints = GetRandomDataPoints();
            microChartItem7.DataPoints = GetRandomDataPoints();
            microChartItem8.DataPoints = GetRandomDataPoints();

            if (m_hookHelper == null) return;
            m_Map = m_hookHelper.FocusMap;
            if (m_Map == null) return;

            radChart1.Series.Clear();
            radChart2.Series.Clear();

            cboGraphType.Items.Add("خطی");
            cboGraphType.Items.Add("ستونی");
            cboGraphType.Items.Add("سطحی");
            cboGraphType.Items.Add("پلاتی");
            cboGraphType.Items.Add("دایره ای");
            cboGraphType.SelectedIndex = 1;
            //LoopThroughLayersOfSpecificUID(m_Map, "{40A9E885-5533-11D0-98BE-00805F7CED21}");

            IWorkspaceFactory pWorkspaceFactory = new AccessWorkspaceFactoryClass();
            IWorkspace pWorkspace = (IWorkspace)pWorkspaceFactory.OpenFromFile(@"C:\Users\mgh\Desktop\Data\GDB_DneshgaheAzad.mdb", 0);
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(esriDatasetType.esriDTTable);
            IDataset pDataset = pEnumDataset.Next();
            m_ArrayTables = new ArrayList();

            while (pDataset != null)
            {
                if (pDataset is ITable)
                {
                    cboTables.Items.Add(pDataset.Name);
                    m_ArrayTables.Add(pDataset);
                }
                pDataset = pEnumDataset.Next();
            }
            if (cboTables.Items.Count > 1)
                cboTables.SelectedIndex = 1;

            cboFirstYear.Items.Add("90");
            cboFirstYear.Items.Add("91");
            cboFirstYear.SelectedIndex = 0;

            cboSecondYear.Items.Add("90");
            cboSecondYear.Items.Add("91");
            cboSecondYear.SelectedIndex = 0;

            cboCities1.Items.Add("مشهد");
            cboCities1.Items.Add("ورامین");
            cboCities1.SelectedIndex = 0;

            cboCities2.Items.Add("مشهد");
            cboCities2.Items.Add("ورامین");
            cboCities2.SelectedIndex = 1;

            cboSex.Items.Add("مرد");
            cboSex.Items.Add("زن");
            cboSex.SelectedIndex = 0;

            // Fill_CboMagtha();

            Fill_CboGroup();
        }


        //private void Fill_CboMagtha()
        //{
        //    //maingroup

        //    cboMaghta.Items.Add("کاردانی پیوسته");
        //    cboMaghta.Items.Add("کارشناسی");
        //    cboMaghta.Items.Add("دکتری تخصصی");
        //    cboMaghta.Items.Add("کاردانی");
        //    cboMaghta.Items.Add("کارشناسی ارشد ناپیوسته");
        //    cboMaghta.Items.Add("کارشناسی ناپیوسته");
        //    cboMaghta.SelectedIndex = 0;
        //}

        private void Fill_CboGroup()
        {

            cboGroup.Items.Add("پزشكي");
            cboGroup.Items.Add("علوم انساني");
            cboGroup.Items.Add("علوم پايه");
            cboGroup.Items.Add("فني مهندسي");
            cboGroup.Items.Add("كشاورزي");
            cboGroup.Items.Add("هنر");
            cboGroup.Items.Add("فني مهندسي");

            cboGroup.SelectedIndex = 0;
        }

        #region Random Data Creation
        private List<double> GetRandomDataPoints(bool allowNegative)
        {
            return GetRandomDataPoints(allowNegative, 12);
        }
        private List<double> GetRandomDataPoints(bool allowNegative, int pointsToCreate)
        {
            List<double> points = new List<double>();
            Random rnd = new Random((int)DateTime.Now.Ticks);
            Random rnd2 = new Random();

            for (int i = 0; i < pointsToCreate; i++)
            {
                points.Add(allowNegative ? ((rnd2.Next(50) > 25 ? 1 : -1) * rnd.Next(100)) : rnd.Next(100));
            }

            return points;
        }
        private List<double> GetRandomDataPoints()
        {
            return GetRandomDataPoints(true);
        }
        #endregion

        #region "Loop Through Layers of Specific UID"


        ///</remarks>
        public void LoopThroughLayersOfSpecificUID(IMap map, String layerCLSID)
        {
            if (map == null || layerCLSID == null)
            {
                return;
            }
            IUID uid = new UIDClass();
            uid.Value = layerCLSID; // Example: "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}" = IGeoFeatureLayer
            try
            {
                IEnumLayer enumLayer = map.get_Layers(((ESRI.ArcGIS.esriSystem.UID)(uid)), false); // Explicit Cast 
                enumLayer.Reset();
                ILayer layer = enumLayer.Next();
                cboTables.Items.Clear();

                if (m_ArrayLayers == null)
                    m_ArrayLayers = new ArrayList();
                else
                    m_ArrayLayers.Clear();

                while (!(layer == null))
                {
                    // TODO - Implement your code here...

                    if (layer is IFeatureLayer)
                    {
                        cboTables.Items.Add(layer.Name);
                        cboCities1.Items.Add(layer.Name);

                        m_ArrayLayers.Add(layer);

                    }


                    layer = enumLayer.Next();
                }
                if (cboTables.Items.Count > 0)
                    cboTables.SelectedIndex = 0;
                if (cboCities1.Items.Count > 0)
                    cboCities1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                //Windows.Forms.MessageBox.Show("No layers of type: " + uid.Value.ToString);
            }
        }
        #endregion


        //private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    IFeatureLayer pFLayer = (IFeatureLayer)m_ArrayLayers[cboTables.SelectedIndex];
        //    if (pFLayer == null) return;

        //    IFeatureClass pFClass = pFLayer.FeatureClass;
        //    IFields pFields = pFClass.Fields;

        //    if (m_ArrayFields == null)
        //    {
        //        m_ArrayFields = new ArrayList();
        //    }
        //    else
        //    {
        //        m_ArrayFields.Clear();
        //    }
        //    cboFirstYear.Items.Clear();
        //    cboSecondYear.Items.Clear();

        //    for (int i = 0; i <= pFields.FieldCount - 1; i++)
        //    {
        //        IField pField = pFields.get_Field(i);
        //        cboFirstYear.Items.Add(pField.AliasName);
        //        cboSecondYear.Items.Add(pField.AliasName);

        //        m_ArrayFields.Add(pField);
        //    }
        //    if (cboFirstYear.Items.Count > 0)
        //        cboFirstYear.SelectedIndex = 0;
        //    if (cboSecondYear.Items.Count > 0)
        //        cboSecondYear.SelectedIndex = 0;

        //}

        private void btnShowChart_Click(object sender, EventArgs e)
        {
            tabControl_First.SelectedTabIndex = 0;
            tabControl_Second.SelectedTabIndex = 0;

            ITable pTable = (ITable)m_ArrayTables[cboTables.SelectedIndex];
            if (pTable == null) return;
            Fill_Charts(pTable, radChart1, cboCities1.Text);

            Fill_Charts(pTable, radChart2, cboCities2.Text);

        }

        private void Fill_Charts(ITable pTable, Telerik.WinControls.UI.RadChart pChart, string ChartTitle)
        {
            pChart.Series.Clear();              //adding the series items  
            //  pChart.ChartTitle.TextBlock.Text = ChartTitle;
            ChartSeries cs = new ChartSeries();

            if (ChartTitle == "مشهد")
            {
                cs.Items.Add(new ChartSeriesItem(90, "دکتری تخصصی"));
                cs.Items.Add(new ChartSeriesItem(200, "کاردانی"));
                cs.Items.Add(new ChartSeriesItem(107, "کاردانی پیوسته"));
                pChart.Series.Add(cs);
                cs = new ChartSeries();
                cs.Items.Add(new ChartSeriesItem(1767, "کارشناسی"));
                cs.Items.Add(new ChartSeriesItem(1155, "کارشناسی ارشد ناپیوسته"));
                cs.Items.Add(new ChartSeriesItem(337, "کارشناسی ناپیوسته"));
                pChart.Series.Add(cs);
            }
            else
            {
                cs.Items.Add(new ChartSeriesItem(150, "کاردانی"));
                cs.Items.Add(new ChartSeriesItem(600, "کاردانی پیوسته"));
                pChart.Series.Add(cs);
                cs = new ChartSeries();
                cs.Items.Add(new ChartSeriesItem(1259, "کارشناسی"));
                cs.Items.Add(new ChartSeriesItem(62, "کارشناسی ارشد ناپیوسته"));
                cs.Items.Add(new ChartSeriesItem(360, "کارشناسی ناپیوسته"));
                pChart.Series.Add(cs);

            }


            pChart.ForeColor = Color.White;

            ChartMarkedZone zone1 = new ChartMarkedZone();
            zone1.ValueStartY = 0;
            zone1.ValueEndY = 500;
            zone1.Appearance.FillStyle.MainColor = Color.PaleVioletRed;
            pChart.PlotArea.MarkedZones.Add(zone1);
            ChartMarkedZone zone2 = new ChartMarkedZone();
            zone2.ValueStartY = 500;
            zone2.ValueEndY = 1000;
            zone2.Appearance.FillStyle.MainColor = Color.LightYellow;
            pChart.PlotArea.MarkedZones.Add(zone2);
            ChartMarkedZone zone3 = new ChartMarkedZone();
            zone3.ValueStartY = 1000;
            zone3.ValueEndY = 1500;
            zone3.Appearance.FillStyle.MainColor = Color.LightGreen;
            pChart.PlotArea.MarkedZones.Add(zone3);
            pChart.Series[0].Appearance.TextAppearance.TextProperties.Font = new Font("Tahoma", 8, FontStyle.Bold);
            pChart.Series[0].Appearance.TextAppearance.TextProperties.Color = Color.Black;
            pChart.Series[1].Appearance.TextAppearance.TextProperties.Font = new Font("Tahoma", 8, FontStyle.Bold);
            pChart.Series[1].Appearance.TextAppearance.TextProperties.Color = Color.Black;
            // pChart.PlotArea.DataTable.Visible = true;
            // pChart.PlotArea.XAxis.Step = 2;
            pChart.ChartTitle.TextBlock.Text = ChartTitle;
            pChart.Skin = "Gradient";
            pChart.Update();
            pChart.Refresh();
            pChart.Save(@"C:\Users\mgh\Desktop\" + ChartTitle + ".jpg");
        }

        //private void Fill_Charts(ITable pTable, Telerik.WinControls.UI.RadChart pChart, string ChartTitle)
        //{
        //    pChart.Series.Clear();              //adding the series items  
        //    //  pChart.ChartTitle.TextBlock.Text = ChartTitle;
        //    ChartSeries cs = new ChartSeries();

        //    ICursor pCursor = pTable.Search(null, true);
        //    IRow pRow = pCursor.NextRow();

        //    int IndexFieldX;
        //    int IndexFieldY;
        //    int CodeCity;
        //    if (cboSex.SelectedIndex == 0)
        //        IndexFieldX = pTable.FindField("std_male");
        //    else
        //        IndexFieldX = pTable.FindField("std_female");

        //    IndexFieldY = pTable.FindField("maghta");
        //    if (IndexFieldX == -1 || IndexFieldY == -1) return;

        //    int sal = -1;
        //    if (ChartTitle == "مشهد")
        //    {
        //        CodeCity = 111;
        //        sal = int.Parse(cboFirstYear.Text);
        //    }
        //    else
        //    {
        //        CodeCity = 143;
        //        sal = int.Parse(cboSecondYear.Text);
        //    }
        //    int i = 1;
        //    int IndexCode = pTable.FindField("vcode");
        //    if (IndexCode == -1) return;

        //    int IndexFieldSal = pTable.FindField("Sal");
        //    int IndexFieldmaingroup = pTable.FindField("maingroup");
        //    while (pRow != null)
        //    {
        //        if ((int)pRow.get_Value(IndexCode) == CodeCity)
        //        {
        //            if ((int)pRow.get_Value(IndexFieldSal) == sal)
        //            {
        //                if ((string)pRow.get_Value(IndexFieldmaingroup) == cboGroup.Text)
        //                {
        //                    System.Object ValueX = pRow.get_Value(IndexFieldX);
        //                    System.Object ValueY = pRow.get_Value(IndexFieldY);

        //                    if (ValueX != null && ValueY != null)
        //                    {
        //                        //MessageBox.Show(ValueX.ToString());
        //                        //MessageBox.Show(ValueY.ToString());
        //                        cs.Items.Add(new ChartSeriesItem(Convert.ToDouble(ValueX), ValueY.ToString()));
        //                        i += 1;
        //                        if (i == 3)
        //                        {
        //                            pChart.Series.Add(cs);
        //                            cs = new ChartSeries();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        pRow = pCursor.NextRow();
        //    }
        //    pChart.Series.Add(cs);

        //    pChart.ForeColor = Color.White;

        //    ChartMarkedZone zone1 = new ChartMarkedZone();
        //    zone1.ValueStartY = 0;
        //    zone1.ValueEndY = 500;
        //    zone1.Appearance.FillStyle.MainColor = Color.PaleVioletRed;
        //    pChart.PlotArea.MarkedZones.Add(zone1);
        //    ChartMarkedZone zone2 = new ChartMarkedZone();
        //    zone2.ValueStartY = 500;
        //    zone2.ValueEndY = 1000;
        //    zone2.Appearance.FillStyle.MainColor = Color.LightYellow;
        //    pChart.PlotArea.MarkedZones.Add(zone2);
        //    ChartMarkedZone zone3 = new ChartMarkedZone();
        //    zone3.ValueStartY = 1000;
        //    zone3.ValueEndY = 1500;
        //    zone3.Appearance.FillStyle.MainColor = Color.LightGreen;
        //    pChart.PlotArea.MarkedZones.Add(zone3);
        //    pChart.Series[0].Appearance.TextAppearance.TextProperties.Font = new Font("Tahoma", 8, FontStyle.Bold);
        //    pChart.Series[0].Appearance.TextAppearance.TextProperties.Color = Color.Black;
        //    // pChart.PlotArea.DataTable.Visible = true;
        //    // pChart.PlotArea.XAxis.Step = 2;
        //    pChart.ChartTitle.TextBlock.Text = ChartTitle;
        //    pChart.Skin = "Gradient";
        //    pChart.Update();
        //    pChart.Refresh();
        //    pChart.Save(@"C:\Users\mgh\Desktop\" + ChartTitle + ".jpg");

        //}

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            tabControl_First.SelectedTabIndex = 1;
            tabControl_Second.SelectedTabIndex = 1;

            ITable pTable = (ITable)m_ArrayTables[cboTables.SelectedIndex];
            if (pTable == null) return;

            Fill_AttributeTable(pTable, dataGridViewX_First, cboCities1.Text);
            Fill_AttributeTable(pTable, dataGridViewX_Second, cboCities2.Text);

        }

        private void Fill_AttributeTable(ITable pTable, DevComponents.DotNetBar.Controls.DataGridViewX dataGridView, string City)
        {

            ICursor pCursor = pTable.Search(null, true);
            IRow pRow = pCursor.NextRow();

            IFields pFields;
            IField pField;

            int IndexFieldX;
            int IndexFieldY;
            int CodeCity;
            if (cboSex.SelectedIndex == 0)
                IndexFieldX = pTable.FindField("std_male");
            else
                IndexFieldX = pTable.FindField("std_female");

            IndexFieldY = pTable.FindField("maghta");
            if (IndexFieldX == -1 || IndexFieldY == -1) return;

            int sal = -1;
            if (City == "مشهد")
            {
                CodeCity = 111;
                sal = int.Parse(cboFirstYear.Text);
            }
            else
            {
                CodeCity = 143;
                sal = int.Parse(cboSecondYear.Text);
            }
            int i = 1;
            int IndexCode = pTable.FindField("vcode");
            if (IndexCode == -1) return;

            int IndexFieldSal = pTable.FindField("Sal");
            int IndexFieldmaingroup = pTable.FindField("maingroup");
            dataGridView.Rows.Clear();

            object[] Vlaues = new object[6];
            int j = -1;
            pFields = pTable.Fields;

            while (pRow != null)
            {
                if ((int)pRow.get_Value(IndexCode) == CodeCity)
                {
                    if ((int)pRow.get_Value(IndexFieldSal) == sal)
                    {
                        if ((string)pRow.get_Value(IndexFieldmaingroup) == cboGroup.Text)
                        {
                            System.Object ValueX = pRow.get_Value(IndexFieldX);
                            System.Object ValueY = pRow.get_Value(IndexFieldY);

                            if (ValueX != null && ValueY != null)
                            {

                                for (int k = 0; k <= pTable.Fields.FieldCount - 1; k++)
                                {
                                    pField = pFields.get_Field(k);
                                    if (!(pField.Name == pTable.OIDFieldName) && !(pField.Name == "vcode"))
                                    {
                                        // MessageBox.Show(pRow.get_Value(k).ToString ());
                                        Vlaues[++j] = pRow.get_Value(k);
                                    }

                                }
                                dataGridView.Rows.Add(Vlaues);
                                j = -1;
                            }
                        }
                    }
                }
                pRow = pCursor.NextRow();
            }

        }


    }
}