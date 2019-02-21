using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace AnalysisTools.SpatilSearch
{
    /// <summary>
    /// Summary description for Tool_SpatialSearch.
    /// </summary>
    [Guid("0463f1ad-b6fd-412d-b899-9e83a1d3e090")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("AnalysisTools.SpatilSearch.Tool_SpatialSearch")]
    public sealed class Tool_SpatialSearch : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(regKey);

        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper;
        private Frm_SpatialSearch Form;
        private IMap m_Map;

        public Tool_SpatialSearch()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text 
            base.m_caption = "";  //localizable text 
            base.m_message = "";  //localizable text
            base.m_toolTip = "";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            if ((hook != null))
            {
                m_hookHelper.Hook = hook;
            }

            if (m_hookHelper.ActiveView == null)
                m_hookHelper = null;

            if (m_hookHelper == null)
            {
                base.m_enabled = false;
            }
            else
            {
                base.m_enabled = true;
            }
            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            IWin32Window pWin = null;

            if (m_hookHelper == null) return;
            m_Map = m_hookHelper.FocusMap;
            if (m_Map == null) return;

            if (Form == null || Form.IsDisposed)
            {
                Form = new Frm_SpatialSearch();
            }
            if (!Form.Visible)
            {
                Form.Set_HookHelper = m_hookHelper;
                Form.Show(pWin);
            }

        }

        public void Hide_Form()
        {
            if (Form != null)
            {
                Form.Close();
                Form = null;
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            try
            {

                Form.ribbonBar1.Text = "";
                Form.Set_Pointclicked = null;
                RemoveGraphics();
                IActiveView pACView = (IActiveView)m_Map;
                bool ShowGraphics = (Form.rbtClickedPoint.CheckState == CheckState.Checked);


                if (ShowGraphics)
                {
                    IPoint pPointclicked = pACView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                    IRgbColor pRGB_Point = CreateRGBColor(255, 0, 0);

                    AddGraphicToMap(m_Map, pPointclicked, pRGB_Point, pRGB_Point);
                    Form.Set_Pointclicked = pPointclicked;
                    pACView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                }

            }
            catch
            {
                IGraphicsContainer pGraphicsContainer = (IGraphicsContainer)m_Map;
                IActiveView pACView = (IActiveView)m_Map;
                pGraphicsContainer.DeleteAllElements();
                Form.ribbonBar1.Text = "";
                Form.Set_Pointclicked = null;
                pACView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }

        }

        private void RemoveGraphics()
        {
            IGraphicsContainer pGraphicsContainer = m_Map as IGraphicsContainer;
            pGraphicsContainer.DeleteAllElements();

            IActiveView pACV = (IActiveView)m_Map;
            pACV.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }

        private IRgbColor CreateRGBColor(int red, int blue, int green)
        {
            if (red < 0 || red > 255) return null;
            if (blue < 0 || blue > 255) return null;
            if (green < 0 || green > 255) return null;

            IRgbColor pRGBColor = new RgbColorClass();
            pRGBColor.Red = red;
            pRGBColor.Green = green;
            pRGBColor.Blue = blue;

            return pRGBColor;

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
                simpleMarkerSymbol.Size = 7;
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
                simpleLineSymbol.Width = 3;

                ILineElement lineElement = new LineElementClass();
                lineElement.Symbol = simpleLineSymbol;
                element = (IElement)lineElement; // Explicit Cast
            }
            else if ((geometry.GeometryType) == esriGeometryType.esriGeometryPolygon)
            {
                // Polygon elements
                ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
                simpleFillSymbol.Color = rgbColor;
                simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSForwardDiagonal;
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

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add Tool_SpatialSearch.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add Tool_SpatialSearch.OnMouseUp implementation
        }
        #endregion
    }
}
