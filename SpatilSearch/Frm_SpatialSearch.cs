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
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace AnalysisTools.SpatilSearch
{
    public partial class Frm_SpatialSearch : DevComponents.DotNetBar.OfficeForm
    {

        private IHookHelper m_hookHelper = null;
        private IMap m_Map;
        private ArrayList m_ArrayListLayers;
        private IPoint pPointclicked;
        private ArrayList m_ArrayListFeatures;
        private ListViewItem item;

        public IHookHelper Set_HookHelper
        {
            set
            {
                m_hookHelper = value;
            }

        }

        public IPoint Set_Pointclicked
        {
            set
            {
                pPointclicked = value;
            }
        }

        public Frm_SpatialSearch()
        {
            InitializeComponent();
        }

        private void Frm_SpatialSearch_Load(object sender, EventArgs e)
        {
            if (m_hookHelper == null) return;
            m_Map = (IMap)m_hookHelper.FocusMap;
            if (m_Map == null) return;

            rbtClickedPoint.Checked = true;
            chkShowGraphics.Checked = true;
            lstFeatures.Columns[0].ImageIndex = 1;
            lstFeatures.Columns[2].ImageIndex = 4;

            LoopThroughLayersOfSpecificUID(m_Map, "{40A9E885-5533-11D0-98BE-00805F7CED21}");

        }


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
                m_ArrayListLayers = new ArrayList();
                cboLayers.Items.Clear();
                while (!(layer == null))
                {
                    IFeatureLayer pFLayer = layer as IFeatureLayer;

                    cboLayers.Items.Add(pFLayer.Name);
                    m_ArrayListLayers.Add(pFLayer);

                    layer = enumLayer.Next();
                }

                if (cboLayers.Items.Count > 0)
                    cboLayers.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                ribbonBar1.Text = "";
                IGraphicsContainer pGraphicsContainer = m_Map as IGraphicsContainer;
                pGraphicsContainer.DeleteAllElements();

                IFeature pFeature = null;
                ITopologicalOperator pTopoOpe = null;

                if (m_ArrayListFeatures == null)
                    m_ArrayListFeatures = new ArrayList();
                else
                    m_ArrayListFeatures.Clear();
                lstFeatures.Items.Clear();

                if (rbtClickedPoint.CheckState == CheckState.Checked)
                {
                    if (pPointclicked == null)
                    {
                        ribbonBar1.Text = "لطفا ابتدا بر روی نقشه کلیک نمایید";
                        return;
                    }

                    pTopoOpe = pPointclicked as ITopologicalOperator;

                }
                else
                {
                    pFeature = Find_FirstFeature();
                    if (pFeature == null)
                    {
                        ribbonBar1.Text = "لطفاً ابتدا یک عارضه را انتخاب نمایید";
                        return;
                    }
                    pTopoOpe = pFeature.ShapeCopy as ITopologicalOperator;
                }

                if (pTopoOpe == null) return;

                double Radius = doubleInput.Value;

                IGeometry pGeoBuffer = pTopoOpe.Buffer(Radius);
                if (pGeoBuffer == null) return;

                if (pFeature == null)
                    Find_FeatureInBuffer(pGeoBuffer, null, pPointclicked);
                else
                    Find_FeatureInBuffer(pGeoBuffer, pFeature, null);

                pPointclicked = null;
                IActiveView pACV = (IActiveView)m_Map;
                pACV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            catch
            {
                ribbonBar1.Text = "اشکال در یافتن عوارض";
            }

        }


        private IFeature Find_FirstFeature()
        {
            if (m_Map == null) return null;
            IEnumFeature pEnumFeature = (IEnumFeature)m_Map.FeatureSelection;
            IFeature pFeature = null;
            pFeature = pEnumFeature.Next();

            while (pFeature != null)
            {
                if (pFeature.ShapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                    break;
                pFeature = pEnumFeature.Next();
            }

            return pFeature;
        }

        private void Find_FeatureInBuffer(IGeometry pBuffer, IFeature pFeatureFirst = null, IPoint pPoint = null)
        {
            IFeatureLayer pFLayer = (IFeatureLayer)m_ArrayListLayers[cboLayers.SelectedIndex];
            IFeatureClass pFClass = pFLayer.FeatureClass;
            double Distance;
            bool ShowGraphics;
            IGeometry pGeometry;

            ShowGraphics = chkShowGraphics.Checked;
            ISpatialFilter pSFilter = new SpatialFilter();
            pSFilter.Geometry = pBuffer;
            pSFilter.GeometryField = pFClass.ShapeFieldName;
            pSFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;

            IFeatureCursor pFCursor = pFClass.Search(pSFilter, true);
            IFeature pFeature = pFCursor.NextFeature();

            IRgbColor prgb = new RgbColor();
            prgb.Red  = 255;

            if (pFeatureFirst != null)
                pGeometry = pFeatureFirst.ShapeCopy;
            else
                pGeometry = pPoint;

            IProximityOperator pProximityOperator = pGeometry as IProximityOperator;
            if (pProximityOperator == null) return;

            while (pFeature != null)
            {
                try
                {
                    if (pFeatureFirst != null)
                    {
                        if (pFeature.OID == pFeatureFirst.OID)
                        {

                            pFeature = pFCursor.NextFeature();
                            continue;
                        }
                    }

                    Distance = pProximityOperator.ReturnDistance(pFeature.ShapeCopy);
                    Distance = Math.Round(Distance, 3);

                    ListViewItem pItem = new ListViewItem(pFLayer.Name);
                    pItem.SubItems.Add(pFeature.OID.ToString());
                    pItem.SubItems.Add(Distance.ToString());
                    lstFeatures.Items.Add(pItem);
                    m_ArrayListFeatures.Add(pFeature);
                    if (ShowGraphics)
                        AddGraphicToMap(m_Map, pFeature.ShapeCopy, prgb, prgb);

                    pFeature = pFCursor.NextFeature();
                }
                catch
                {
                    pFeature = pFCursor.NextFeature();
                }
            }

           
        }


        public void AddGraphicToMap(IMap map, IGeometry geometry, IRgbColor rgbColor, IRgbColor outlineRgbColor)
        {
            IGraphicsContainer graphicsContainer = (IGraphicsContainer)map; // Explicit Cast
            IElement element = null;
            if ((geometry.GeometryType) == esriGeometryType.esriGeometryPoint)
            {
                // Marker symbols
                ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                simpleMarkerSymbol.Color = rgbColor;
                simpleMarkerSymbol.Outline = true;
                simpleMarkerSymbol.OutlineColor = outlineRgbColor;
                simpleMarkerSymbol.Size = 5;
                simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;

                IMarkerElement markerElement = new MarkerElementClass();
                markerElement.Symbol = simpleMarkerSymbol;
                element = (IElement)markerElement; // Explicit Cast
            }
            else if ((geometry.GeometryType) == esriGeometryType.esriGeometryPolyline)
            {
                //  Line elements
                ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
                simpleLineSymbol.Color = rgbColor;
                simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
                simpleLineSymbol.Width = 5;

                ILineElement lineElement = new LineElementClass();
                lineElement.Symbol = simpleLineSymbol;
                element = (IElement)lineElement; // Explicit Cast
            }
            else if ((geometry.GeometryType) == esriGeometryType.esriGeometryPolygon)
            {
                // Polygon elements
                ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
                simpleFillSymbol.Color = rgbColor;
                simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                IFillShapeElement fillShapeElement = new PolygonElementClass();
                fillShapeElement.Symbol = simpleFillSymbol;
                element = (IElement)fillShapeElement; // Explicit Cast
            }
            if (!(element == null))
            {
                element.Geometry = geometry;
                graphicsContainer.AddElement(element, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RemoveGraphics();
            this.Close();
        }

        private void RemoveGraphics()
        {
            IFeatureLayer pFLayer = (IFeatureLayer)m_ArrayListLayers[cboLayers.SelectedIndex];
            IGraphicsContainer pGraphicsContainer = m_Map as IGraphicsContainer;
            pGraphicsContainer.DeleteAllElements();
            m_Map.ClearSelection();
            IActiveView pACV = (IActiveView)m_Map;

            pACV.Refresh();

        }

        private void Frm_SpatialSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveGraphics();
        }

        #region ContextMenu

        private void lstFeatures_MouseDown(object sender, MouseEventArgs e)
        {
            item = lstFeatures.GetItemAt(e.X, e.Y);
            if ((item != null))
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    lstFeatures.ContextMenuStrip = ContextMenu_LstResult;
                }
            }
            else
            {
                lstFeatures.ContextMenuStrip = null;
            }
        }

        private void FlashToolStripMenuItem_Click(object sender, EventArgs e)
        {

            IFeature pFeature = (IFeature)m_ArrayListFeatures[item.Index];

            IActiveView ActiveView = (IActiveView)m_Map;
            if (pFeature == null) return;

            IRgbColor pRGB = new RgbColorClass();
            pRGB.Green = 255;

            FlashGeometry(pFeature.ShapeCopy, pRGB, (IDisplay)ActiveView.ScreenDisplay, 200);

        }

        public void FlashGeometry(IGeometry geometry, IRgbColor color, IDisplay display, System.Int32 delay)
        {
            if (geometry == null || color == null || display == null)
            {
                return;
            }

            display.StartDrawing(display.hDC, (System.Int16)esriScreenCache.esriNoScreenCache); // Explicit Cast


            switch (geometry.GeometryType)
            {
                case esriGeometryType.esriGeometryPolygon:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
                        simpleFillSymbol.Color = color;
                        ISymbol symbol = simpleFillSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input polygon geometry.
                        display.SetSymbol(symbol);
                        display.DrawPolygon(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawPolygon(geometry);
                        break;
                    }

                case esriGeometryType.esriGeometryPolyline:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
                        simpleLineSymbol.Width = 4;
                        simpleLineSymbol.Color = color;
                        ISymbol symbol = simpleLineSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input polyline geometry.
                        display.SetSymbol(symbol);
                        display.DrawPolyline(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawPolyline(geometry);
                        break;
                    }

                case esriGeometryType.esriGeometryPoint:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                        simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                        simpleMarkerSymbol.Size = 12;
                        simpleMarkerSymbol.Color = color;
                        ISymbol symbol = simpleMarkerSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input point geometry.
                        display.SetSymbol(symbol);
                        display.DrawPoint(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawPoint(geometry);
                        break;
                    }

                case esriGeometryType.esriGeometryMultipoint:
                    {
                        //Set the flash geometry's symbol.
                        ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
                        simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                        simpleMarkerSymbol.Size = 12;
                        simpleMarkerSymbol.Color = color;
                        ISymbol symbol = simpleMarkerSymbol as ISymbol; // Dynamic Cast
                        symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

                        //Flash the input multipoint geometry.
                        display.SetSymbol(symbol);
                        display.DrawMultipoint(geometry);
                        System.Threading.Thread.Sleep(delay);
                        display.DrawMultipoint(geometry);
                        break;
                    }
            }
            display.FinishDrawing();
        }

        private void SelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (item == null) return;
            IFeature pF = (IFeature)m_ArrayListFeatures[item.Index];
            ILayer Layer = (ILayer)m_ArrayListLayers[item.Index];

            IActiveView ActiveView = (IActiveView)m_Map;
            if (pF == null || Layer == null) return;
            m_Map.SelectFeature(Layer, pF);
            ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        private void UnSelectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (item == null) return;
            IFeature pFeature = (IFeature)m_ArrayListFeatures[item.Index];
            ILayer Layer = (ILayer)m_ArrayListLayers[item.Index];

            IActiveView ActiveView = (IActiveView)m_Map;
            if (Layer == null || pFeature == null) return;

            IFeatureSelection FSelection = (IFeatureSelection)Layer;
            ISelectionSet SSet = FSelection.SelectionSet;
            //  Dim pSelectionEvents As ISelectionEvents
            SSet.RemoveList(1, pFeature.OID);
            //  pSelectionEvents = Map 
            FSelection.SelectionChanged();
            ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            // pSelectionEvents.SelectionChanged()
        }

        private void ZoomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (item == null) return;
            IFeature pF = (IFeature)m_ArrayListFeatures[item.Index];
            ILayer Layer = (ILayer)m_ArrayListLayers[item.Index];

            IEnvelope pEnvelope;
            IActiveView ActiveView = (IActiveView)m_Map;
            if (Layer == null || pF == null) return;
            if (pF.Shape.GeometryType != ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint)
            {
                pEnvelope = pF.Extent;
                pEnvelope.Expand(1.5, 1.5, true);
            }

            else
            {

                pEnvelope = new EnvelopeClass();

                ESRI.ArcGIS.esriSystem.tagRECT RECT = new tagRECT();

                IDisplayTransformation dispTrans = ActiveView.ScreenDisplay.DisplayTransformation;
                dispTrans.TransformRect(pEnvelope, RECT, 4);
                pEnvelope.Width = ActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.Width / 10;
                pEnvelope.Height = ActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.Height / 10;

                pEnvelope.CenterAt(pF.ShapeCopy as IPoint);
                pEnvelope.SpatialReference = m_Map.SpatialReference;

            }
            ActiveView.Extent = pEnvelope;
            ActiveView.Refresh();
        }

        private void FullExtentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IActiveView ActiveView = (IActiveView)m_Map;
            ActiveView.Extent = ActiveView.FullExtent;
            ActiveView.Refresh();
        }

        #endregion

        private void rbtSelectedFeature_CheckedChanged(object sender, EventArgs e)
        {
            RemoveGraphics();
        }



    }
}