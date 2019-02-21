using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ESRI.ArcGIS.Controls;
using GenericTools;
using AnalysisTools;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;
using System.IO;
using ESRI.ArcGIS;


namespace MainProject
{
    public partial class MainForm : DevComponents.DotNetBar.OfficeForm
    {

        #region "Variables"

        private bool m_bLayoutCalled = false;
        private DateTime m_dt;

        private GenericTools.SynchronizerTools.ControlsSynchronizer m_controlsSynchronizer = null;
        private ESRI.ArcGIS.Controls.IMapControl3 m_mapControl = null;
        private ESRI.ArcGIS.Controls.IPageLayoutControl2 m_pageLayoutControl = null;
        private AxLicenseControl LicenseControl;
        private string m_documentFileName = string.Empty;


        // AnalysisTools.ToolbarMenuItems.ContextMenuClass.ContextMenuClass m_contextMenu = new AnalysisTools.ToolbarMenuItems.ContextMenuClass.ContextMenuClass();
        AnalysisTools.Report.Cmd_Report report = new AnalysisTools.Report.Cmd_Report();
        AnalysisTools.Identify.Identify_Tool identify = new AnalysisTools.Identify.Identify_Tool();
        AnalysisTools.SearchFeatures.Cmd_SearchFeatures searchFeatures = new AnalysisTools.SearchFeatures.Cmd_SearchFeatures();
        AnalysisTools.AboutForm.Cmd_AboutForm about = new AnalysisTools.AboutForm.Cmd_AboutForm();
        AnalysisTools.Graphics.RemoveGraphics removeGraphics = new AnalysisTools.Graphics.RemoveGraphics();
        AnalysisTools.Ruler.Tool_Ruler ruler = new AnalysisTools.Ruler.Tool_Ruler();
        AnalysisTools.MapTips.MapTips mapTips = new AnalysisTools.MapTips.MapTips();
        AnalysisTools.Area.Area area = new AnalysisTools.Area.Area();

        //Reports
        AnalysisTools.Reports.Immigration.Immigration immigration = new AnalysisTools.Reports.Immigration.Immigration();
        AnalysisTools.Reports.Fealiat.Fealiat faliat = new AnalysisTools.Reports.Fealiat.Fealiat();
        AnalysisTools.Reports.Jamiat.Jamiat jamiat = new AnalysisTools.Reports.Jamiat.Jamiat();
        AnalysisTools.Reports.Khanevar.Khanevar khanevar = new AnalysisTools.Reports.Khanevar.Khanevar();
        AnalysisTools.Reports.Maloliat.Maloliat maloliat = new AnalysisTools.Reports.Maloliat.Maloliat();
        AnalysisTools.Reports.Zanashoi.Zanashoi zanashoi = new AnalysisTools.Reports.Zanashoi.Zanashoi();
        AnalysisTools.Reports.Maskan.Maskan maskan = new AnalysisTools.Reports.Maskan.Maskan();
        AnalysisTools.Reports.Education.Education education = new AnalysisTools.Reports.Education.Education();

        #endregion

        #region "Form Event"

        public MainForm()
        {
            InitializeComponent();
            TOC_Panel.Font = new Font("Tahoma", 8f, FontStyle.Bold);

        }

        private void MainForm1_Load(object sender, EventArgs e)
        {
            try
            {
                m_mapControl = (IMapControl3)MapControl.Object;
                m_pageLayoutControl = (IPageLayoutControl2)PageLayoutControl.Object;

                //initialize the controls synchronization class
                m_controlsSynchronizer = new GenericTools.SynchronizerTools.ControlsSynchronizer(m_mapControl, m_pageLayoutControl);

                //bind the controls together (both point at the same map) and set the MapControl as the active control
                m_controlsSynchronizer.BindControls(true);

                m_controlsSynchronizer.AddFrameworkControl(TOCControl.Object);

                m_controlsSynchronizer.ActivateMap();
                panelLayoutView.Visible = false;
                panelDataView.Visible = true;

                if (File.Exists("MXD/LoadingDocument.mxd"))
                    m_mapControl.LoadMxFile("MXD/LoadingDocument.mxd");
            }
            catch
            {
                lblCoordinate.Text = "اشکال در بارگذاری نرم افزار";
            }

        }

        private void MainForm_Layout(object sender, LayoutEventArgs e)
        {
            if (m_bLayoutCalled == false)
            {
                m_bLayoutCalled = true;
                m_dt = DateTime.Now;
                this.Activate();
            }
        }

        [STAThread]
        static void Main()
        {
            if (!RuntimeManager.Bind(ProductCode.Engine))
            {
                if (!RuntimeManager.Bind(ProductCode.Desktop))
                {
                    MessageBox.Show("Unable to bind to ArcGIS runtime. Application will be shut down.");
                    return;
                }
            }


            Application.Run(new MainForm());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MapControl = null;
            PageLayoutControl = null;
            TOCControl = null;
        }

        #endregion

        #region "MapControl PageLayoutControl Events"

        private void MapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            lblCoordinate.Text = String.Format("{0}     {1}  {2}", e.mapX.ToString("#######.###"), e.mapY.ToString("#######.###"), MapControl.MapUnits.ToString().Substring(4));
            lblSpatialReference.Text = "WGS_1984_UTM_Zone_40N";
        }

        //private void MapControl_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        //{
        //    //if there is no MapDocument, disable the Save menu and clear the statusbar
        //  //  m_documentFileName = MapControl.DocumentFilename.Trim ();
        //    MessageBox.Show(m_documentFileName);

        //    if (m_documentFileName == string.Empty)
        //    {
        //        BtnSaveMXD.Enabled = false;
        //        BtnSaveMXD_MainMenu.Enabled  = false;
        //        lblCoordinate.Text = string.Empty;
        //    }
        //    else
        //    {
        //        //enable the Save menu and write the doc name to the statusbar
        //        BtnSaveMXD.Enabled = true;
        //        BtnSaveMXD_MainMenu.Enabled  =  true;
        //        lblCoordinate.Text = Path.GetFileName(m_documentFileName);
        //    }
        //}

        private void PageLayoutControl_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            lblCoordinate.Text = string.Format("{0} {1} {2}", e.pageX.ToString("###.##"), e.pageY.ToString("###.##"), PageLayoutControl.Page.Units.ToString().Substring(4));
        }

        private void TOCControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            //make sure that the user right clicked
            if (1 != e.button)
                return;

            m_SelectedTOCLayer = null;

            //use HitTest in order to test whether the user has selected a featureLayer
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null; ILayer layer = null;
            object other = null; object index = null;

            //do the HitTest
            TOCControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

            //Determine what kind of item has been clicked on
            if (null == layer || !(layer is ILayer))
                return;
            m_SelectedTOCLayer = layer;

            ////set the featurelayer as the custom property of the MapControl
            //MapControl.CustomProperty = layer;

            ////popup a context menu with a 'Properties' command
            //m_contextMenu.PopupMenu(e.x, e.y, TOCControl.hWnd);
        }

        #endregion

        #region"General Tools"

        private void btnNewDocument_Click(object sender, EventArgs e)
        {
            //ask the user whether he'd like to save the current doc
            DialogResult res = MessageBox.Show("Would you like to save the current document?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                GenericTools.GISGenericTools.SaveAs_NSMap(MapControl);
            }

            ShowDataMapView();

            //create a new Map instance
            IMap map = new MapClass();
            map.Name = "Map";
            //replace the shared map with the new Map instance
            m_controlsSynchronizer.ReplaceMap(map);

            m_documentFileName = string.Empty;
        }

        private void BOpenMXD_Click(object sender, EventArgs e)
        {
            MapControl.MousePointer = esriControlsMousePointer.esriPointerHourglass;

            ShowDataMapView();

            //launch the OpenMapDoc command
            GenericTools.SynchronizerTools.OpenNewMapDocument openMapDoc = new GenericTools.SynchronizerTools.OpenNewMapDocument(m_controlsSynchronizer);
            openMapDoc.OnCreate(m_controlsSynchronizer.MapControl.Object);
            openMapDoc.OnClick();

            m_documentFileName = openMapDoc.DocumentFileName;

            MapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
        }

        private void ShowPageLayoutView()
        {
            m_controlsSynchronizer.ActivatePageLayout();

            panelDataView.Visible = false;
            panelLayoutView.Visible = true;
        }

        private void ShowDataMapView()
        {
            m_controlsSynchronizer.ActivateMap();

            panelLayoutView.Visible = false;
            panelDataView.Visible = true;
        }

        private void BtnAddData_Click(object sender, EventArgs e)
        {
            GISGenericTools.AddData_NSMap(MapControl);
        }

        private void BtnSaveMXD_Click(object sender, EventArgs e)
        {
            //make sure that the current MapDoc is valid first
            if (m_documentFileName != string.Empty && m_mapControl.CheckMxFile(m_documentFileName))
            {
                //create a new instance of a MapDocument class
                IMapDocument mapDoc = new MapDocumentClass();
                //Open the current document into the MapDocument
                mapDoc.Open(m_documentFileName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_documentFileName))
                {
                    MessageBox.Show("سند فقط خواندنی است");
                    mapDoc.Close();
                    return;
                }

                //Replace the map with the one of the PageLayout
                mapDoc.ReplaceContents((IMxdContents)m_pageLayoutControl.PageLayout);

                //save the document
                mapDoc.Save(mapDoc.UsesRelativePaths, false);
                mapDoc.Close();
            }
        }

        private void BtnSaveAsMXD_Click(object sender, EventArgs e)
        {
            ControlsSaveAsDocCommand pCommand = new ESRI.ArcGIS.Controls.ControlsSaveAsDocCommand();
            pCommand.OnCreate(MapControl.Object);
            pCommand.OnClick();
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            if (panelDataView.Visible)
                GISNavaigationTools.ZoomIn_NSMap(MapControl, null);
            else
                GISNavaigationTools.ZoomIn_NSMap(null, PageLayoutControl);
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            if (panelDataView.Visible)
                GISNavaigationTools.ZoomOut_NSMap(MapControl, null);
            else
                GISNavaigationTools.ZoomOut_NSMap(null, PageLayoutControl);
        }

        private void BtnZoomInFeatures_Click(object sender, EventArgs e)
        {
            GISNavaigationTools.ZoomToSelected_NSMap(MapControl);
        }

        private void BtnPan_Click(object sender, EventArgs e)
        {
            if (panelDataView.Visible)
                GISNavaigationTools.Pan_NSMap(MapControl, null);
            else
                GISNavaigationTools.Pan_NSMap(null, PageLayoutControl);
        }


        private void BtnFullExtent_Click(object sender, EventArgs e)
        {
            GISNavaigationTools.FullExtent_NSMap(MapControl);
        }

        private void BtnPerviousZoom_Click(object sender, EventArgs e)
        {
            GISNavaigationTools.LastExtentExtent_NSMap(MapControl);
        }

        private void BtnNextZoomIn_Click(object sender, EventArgs e)
        {
            GISNavaigationTools.ForwardExtent_NSMap(MapControl);
        }

        private void BtnFixZoomOut_Click(object sender, EventArgs e)
        {
            GISNavaigationTools.ZoomOutFixed_NSMap(MapControl);
        }

        private void BtnFixZoomIn_Click(object sender, EventArgs e)
        {
            GISNavaigationTools.ZoomInFixed_NSMap(MapControl);
        }

        private void BtnSelectFeatures_Click(object sender, EventArgs e)
        {
            GISSelectionTools.SelectFeaturesTool_NSMap(MapControl, null);
            if (panelDataView.Visible)
                GISSelectionTools.SelectFeaturesTool_NSMap(MapControl, null);
            else
                GISSelectionTools.SelectFeaturesTool_NSMap(null, PageLayoutControl);
        }

        private void BtnUnSelect_Click(object sender, EventArgs e)
        {
            GISSelectionTools.ClearSelectionCommand_NSMap(MapControl);
        }

        private void BtnSelectAllFeatuers_Click(object sender, EventArgs e)
        {
            GISSelectionTools.SelectAllCommand_NSMap(MapControl);
        }

        private void BtnInversSelection_Click(object sender, EventArgs e)
        {
            GISSelectionTools.SwitchSelectionCommand_NSMap(MapControl);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnDataView_Click(object sender, EventArgs e)
        {
            ShowDataMapView();
        }

        private void btnLayoutView_Click(object sender, EventArgs e)
        {
            ShowPageLayoutView();
        }

        private void btnRefreshMap_Click(object sender, EventArgs e)
        {
            GenericTools.GISGenericTools.MapRefreshView_NSMap(MapControl);
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            btnIdentify.Checked = !btnIdentify.Checked;
            if (btnIdentify.Checked)
            {
                identify.OnCreate(MapControl.Object);
                identify.OnClick();
                MapControl.CurrentTool = (ESRI.ArcGIS.SystemUI.ITool)identify;
            }
            else
            {
                if (identify != null)
                {
                    MapControl.CurrentTool = null;
                    identify.Hide_FormIdentify();
                }
            }
        }

        private void btnMapTip_Click(object sender, EventArgs e)
        {
            btnMapTip.Checked = !btnMapTip.Checked;
            if (btnMapTip.Checked)
            {
                mapTips.OnCreate(MapControl.Object);
                mapTips.OnClick();
                //MapControl.CurrentTool = (ESRI.ArcGIS.SystemUI.ITool)mapTips;
                this.MapControl.TipStyle = ESRI.ArcGIS.SystemUI.esriTipStyle.esriTipStyleTransparent;
            }
            else
            {
                if (report != null)
                {
                    MapControl.CurrentTool = null;
                    mapTips.Hide_Form();
                }
            }
        }

        private void btnSearchFeatures_Click(object sender, EventArgs e)
        {
            btnSearchFeatures.Checked = !btnSearchFeatures.Checked;
            if (btnSearchFeatures.Checked)
            {
                searchFeatures.OnCreate(MapControl.Object);
                searchFeatures.OnClick();
            }
            else
            {
                if (searchFeatures != null)
                    searchFeatures.Hide_FormSearch();
            }
        }

        private void btnLineGraphics_Click(object sender, EventArgs e)
        {
            GISGraphicTools.NewLineTool_NSMap(MapControl);
        }

        private void btnMarkerGraphics_Click(object sender, EventArgs e)
        {
            GISGraphicTools.NewMarkerTool_NSMap(MapControl);
        }

        private void btnPolygonGraphics_Click(object sender, EventArgs e)
        {
            GISGraphicTools.NewPolygonTool_NSMap(MapControl);
        }

        private void btnSelectGraphics_Click(object sender, EventArgs e)
        {
            GISGraphicTools.SelectTool_NSMap(MapControl);
        }

        private void btnDeleteGraphics_Click(object sender, EventArgs e)
        {
            removeGraphics.Map = MapControl.Map;
            removeGraphics.RemoveAllGraphuics();
        }

        private void btnLengthPath_Click(object sender, EventArgs e)
        {
            btnLengthPath.Checked = !btnLengthPath.Checked;
            if (btnLengthPath.Checked)
            {
                ruler.OnCreate(MapControl.Object);
                ruler.OnClick();
                MapControl.CurrentTool = (ESRI.ArcGIS.SystemUI.ITool)ruler;
            }
            else
            {
                if (report != null)
                {
                    MapControl.CurrentTool = null;
                    ruler.Hide_Form();
                }
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            btnArea.Checked = !btnArea.Checked;
            if (btnArea.Checked)
            {
                area.OnCreate(MapControl.Object);
                area.OnClick();
                MapControl.CurrentTool = (ESRI.ArcGIS.SystemUI.ITool)area;
            }
            else
            {
                if (area != null)
                {
                    MapControl.CurrentTool = null;
                }
            }
        }

        #endregion

        #region "Main Menu"
        private void btnAboutSoftware_Click(object sender, EventArgs e)
        {
            about.OnCreate(MapControl.Object);
            about.OnClick();
        }

        #endregion

        #region "ToolbarTOC"

        private ILayer m_SelectedTOCLayer;

        AnalysisTools.ToolbarTOCItems.LoadLayerFile.LoadLayerFile loadLayer = new AnalysisTools.ToolbarTOCItems.LoadLayerFile.LoadLayerFile();
        AnalysisTools.ToolbarTOCItems.DeleteLayer.DeleteLayer deleteLayer = new AnalysisTools.ToolbarTOCItems.DeleteLayer.DeleteLayer();
        AnalysisTools.ToolbarTOCItems.ShowAttributeTable.AttributeTable attributeTable = new AnalysisTools.ToolbarTOCItems.ShowAttributeTable.AttributeTable();
        AnalysisTools.ToolbarTOCItems.ZoomToLayer.ZoomToLayer zoomToLayer = new AnalysisTools.ToolbarTOCItems.ZoomToLayer.ZoomToLayer();
        AnalysisTools.ToolbarTOCItems.SaveLayerFile.SaveLayerFile saveLayerFile = new AnalysisTools.ToolbarTOCItems.SaveLayerFile.SaveLayerFile();
        AnalysisTools.ToolbarTOCItems.SelectAll.SelectAllFeatures selectAllFeatures = new AnalysisTools.ToolbarTOCItems.SelectAll.SelectAllFeatures();
        AnalysisTools.ToolbarTOCItems.LayerPropertise.LayerPropertise layerPropertise = new AnalysisTools.ToolbarTOCItems.LayerPropertise.LayerPropertise();

        private void btnToolbarTOC_AddLayer_Click(object sender, EventArgs e)
        {
            loadLayer.OnCreate(MapControl.Object);
            loadLayer.OnClick();
        }

        private void btnToolbarTOC_RemoveLayer_Click(object sender, EventArgs e)
        {
            if (m_SelectedTOCLayer == null) return;

            deleteLayer.OnCreate(MapControl.Object);
            deleteLayer.SelectedLayer = m_SelectedTOCLayer;
            deleteLayer.OnClick();
        }

        private void btnToolbarTOC_AttributeTable_Click(object sender, EventArgs e)
        {
            if ((m_SelectedTOCLayer == null) || !(m_SelectedTOCLayer is IFeatureLayer)) return;

            btnToolbarTOC_AttributeTable.Checked = !btnToolbarTOC_AttributeTable.Checked;
            if (btnToolbarTOC_AttributeTable.Checked)
            {
                attributeTable.OnCreate(MapControl.Object);
                attributeTable.SelectedLayer = m_SelectedTOCLayer;
                attributeTable.OnClick();
            }
            else
            {
                if (attributeTable != null)
                {
                    attributeTable.Hide_Form();
                }
            }

        }

        private void btnToolbarTOC_ZoomToLayer_Click(object sender, EventArgs e)
        {
            if (m_SelectedTOCLayer == null) return;

            zoomToLayer.OnCreate(MapControl.Object);
            zoomToLayer.SelectedLayer = m_SelectedTOCLayer;
            zoomToLayer.OnClick();
        }

        private void btnToolbarTOC_SaveAsLayer_Click(object sender, EventArgs e)
        {
            if (m_SelectedTOCLayer == null) return;

            saveLayerFile.OnCreate(MapControl.Object);
            saveLayerFile.SelectedLayer = m_SelectedTOCLayer;
            saveLayerFile.OnClick();
        }

        private void btnToolbarTOC_SelectAllFeatureLayer_Click(object sender, EventArgs e)
        {
            if (m_SelectedTOCLayer == null || !(m_SelectedTOCLayer is IFeatureLayer)) return;

            selectAllFeatures.OnCreate(MapControl.Object);
            selectAllFeatures.SelectedLayer = m_SelectedTOCLayer;
            selectAllFeatures.OnClick();
        }

        private void btnToolbarTOC_LayerPropertise_Click(object sender, EventArgs e)
        {
            if (m_SelectedTOCLayer == null) return;

            layerPropertise.OnCreate(MapControl.Object);
            layerPropertise.SelectedLayer = m_SelectedTOCLayer;
            layerPropertise.OnClick();
        }

        #endregion


        private void btnImmigration_Click(object sender, EventArgs e)
        {
            if (MapControl.Map.LayerCount == 0)
                return;

            btnImmigration.Checked = !btnImmigration.Checked;
            if (btnImmigration.Checked)
            {
                immigration.OnCreate(MapControl.Object);
                immigration.OnClick();
            }
            else
            {
                if (immigration != null)
                {
                    MapControl.CurrentTool = null;
                    immigration.Hide_FormImmigration();
                }
            }
        }

        private void btnFaliat_Click(object sender, EventArgs e)
        {
            if (MapControl.Map.LayerCount == 0)
                return;

            btnFaliat.Checked = !btnFaliat.Checked;
            if (btnFaliat.Checked)
            {
                faliat.OnCreate(MapControl.Object);
                faliat.OnClick();
            }
            else
            {
                if (faliat != null)
                {
                    MapControl.CurrentTool = null;
                    faliat.Hide_Form();
                }
            }
        }

        private void btnJamiat_Click(object sender, EventArgs e)
        {
            if (MapControl.Map.LayerCount == 0)
                return;

            btnJamiat.Checked = !btnJamiat.Checked;
            if (btnJamiat.Checked)
            {
                jamiat.OnCreate(MapControl.Object);
                jamiat.OnClick();
            }
            else
            {
                if (jamiat != null)
                {
                    MapControl.CurrentTool = null;
                    jamiat.Hide_Form();
                }
            }
        }

        private void btnKhanevar_Click(object sender, EventArgs e)
        {
            if (MapControl.Map.LayerCount == 0)
                return;

            btnKhanevar.Checked = !btnKhanevar.Checked;
            if (btnKhanevar.Checked)
            {
                khanevar.OnCreate(MapControl.Object);
                khanevar.OnClick();
            }
            else
            {
                if (khanevar != null)
                {
                    MapControl.CurrentTool = null;
                    khanevar.Hide_Form();
                }
            }
        }

        private void btnMaloliat_Click(object sender, EventArgs e)
        {
            if (MapControl.Map.LayerCount == 0)
                return;

            btnMaloliat.Checked = !btnMaloliat.Checked;
            if (btnMaloliat.Checked)
            {
                maloliat.OnCreate(MapControl.Object);
                maloliat.OnClick();
            }
            else
            {
                if (maloliat != null)
                {
                    MapControl.CurrentTool = null;
                    maloliat.Hide_Form();
                }
            }
        }

        private void btnZanashoi_Click(object sender, EventArgs e)
        {
            if (MapControl.Map.LayerCount == 0)
                return;

            btnZanashoi.Checked = !btnZanashoi.Checked;
            if (btnZanashoi.Checked)
            {
                zanashoi.OnCreate(MapControl.Object);
                zanashoi.OnClick();
            }
            else
            {
                if (zanashoi != null)
                {
                    MapControl.CurrentTool = null;
                    zanashoi.Hide_Form();
                }
            }
        }

        private void btnMaskan_Click(object sender, EventArgs e)
        {
            if (MapControl.Map.LayerCount == 0) 
                return;

            btnMaskan.Checked = !btnMaskan.Checked;
            if (btnMaskan.Checked)
            {
                maskan.OnCreate(MapControl.Object);
                maskan.OnClick();
            }
            else
            {
                if (maskan != null)
                {
                    MapControl.CurrentTool = null;
                    maskan.Hide_Form();
                }
            }
        }

        private void btnTahsilat_Click(object sender, EventArgs e)
        {
            if (MapControl.Map.LayerCount == 0)
                return;

            btnTahsilat.Checked = !btnTahsilat.Checked;
            if (btnTahsilat.Checked)
            {
                education.OnCreate(MapControl.Object);
                education.OnClick();
            }
            else
            {
                if (education != null)
                {
                    MapControl.CurrentTool = null;
                    education.Hide_frmEducation();
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            about.OnCreate(MapControl.Object);
            about.OnClick();
        }



    }
}