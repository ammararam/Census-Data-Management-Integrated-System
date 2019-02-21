using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
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


namespace AnalysisTools.Area
{
    /// <summary>
    /// Summary description for Area.
    /// </summary>
    [Guid("1db2acf7-d183-40aa-8a6f-76ae77144b85")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("AnalysisTools.Area.Area")]
    public sealed class Area : BaseTool
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

        public Area()
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
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;

            // TODO:  Add Area.OnCreate implementation
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add Area.OnClick implementation
        }

        private ESRI.ArcGIS.Geometry.IPoint clickedPoint;
        private IMap Map;
        private IActiveView activeView;

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            try
            {
                if (m_hookHelper == null) return;
                IFeature featureFinded = null;
                if (Button == 1)
                {
                    Map = m_hookHelper.FocusMap;
                    if (Map == null) return;
                    activeView = (IActiveView)Map;

                    clickedPoint = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                    IEnvelope envelope = Envelope_Search(activeView);
                    for (int i = 0; i < Map.LayerCount - 1; i++)
                    {
                        ILayer layer = Map.get_Layer(i);
                        if (layer is IFeatureLayer)
                        {
                            IGeoFeatureLayer geoFeatureLayer = (IGeoFeatureLayer)layer;
                            if (geoFeatureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                            {
                                featureFinded = GetFirstFeatureFromPointSearchInGeoFeatureLayer(envelope, geoFeatureLayer, activeView);
                                if (featureFinded != null) break;
                            }
                        }
                    }
                    if (featureFinded != null)
                    {
                        IFeatureClass featureClass = (IFeatureClass)featureFinded.Class;
                        int indexAreaField = featureClass.FindField(featureClass.AreaField.Name);
                        AddTextElement((double)featureFinded.get_Value(indexAreaField) , activeView );
                    }
                }
            }
            catch
            {

            }

        }

        private void AddTextElement(double area, IActiveView pACview)
        {
            ITextElement pTextElement = new TextElementClass();
            pTextElement.Text = (Math.Round(area * 0.000001, 2)).ToString() + " km";

            ITextSymbol pTextSymbol = new TextSymbolClass();
            //IRgbColor pRGB = new RgbColorClass();
            //pRGB.Green = 255;
            //pTextSymbol.Color = pRGB;

            ISimpleTextSymbol pSTextSymbol = (ISimpleTextSymbol)pTextSymbol;
            pSTextSymbol.XOffset = 5;
            pSTextSymbol.YOffset = 5;


            pTextElement.Symbol = pTextSymbol;

            IElement pElement = (IElement)pTextElement;
            pElement.Geometry = clickedPoint;

            IGraphicsContainer pGContainer = (IGraphicsContainer)pACview;
            pGContainer.AddElement(pElement, 0);

            pACview.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }


        private IEnvelope Envelope_Search(IActiveView activeView)
        {

            IArea Area;
            IEnvelope pEnvelope;
            IRubberBand rubberEnv;
            IGeometry geom;


            rubberEnv = new RubberEnvelopeClass();
            geom = rubberEnv.TrackNew(activeView.ScreenDisplay, null);

            geom.SpatialReference = Map.SpatialReference;
            pEnvelope = geom.Envelope;

            Area = (IArea)pEnvelope;

            if (pEnvelope.IsEmpty || Area.Area == 0)
            {
                pEnvelope = new EnvelopeClass();

                ////////////////////////////////////////////////////////////////////////////////////////
                ESRI.ArcGIS.esriSystem.tagRECT RECT = new tagRECT();
                RECT.bottom = 0;
                RECT.left = 0;
                RECT.right = 5;
                RECT.top = 5;

                IDisplayTransformation dispTrans = activeView.ScreenDisplay.DisplayTransformation;
                dispTrans.TransformRect(pEnvelope, RECT, 4);
                pEnvelope.CenterAt(clickedPoint);
            }
            return pEnvelope;
        }
        public IFeature GetFirstFeatureFromPointSearchInGeoFeatureLayer(IEnvelope envelope, IGeoFeatureLayer geoFeatureLayer, IActiveView activeView)
        {
            if (geoFeatureLayer == null || activeView == null)
            {
                return null;
            }

            IMap map = activeView.FocusMap;


            IFeatureClass featureClass = geoFeatureLayer.FeatureClass;
            System.String shapeFieldName = featureClass.ShapeFieldName;

            // Create a new spatial filter and use the new envelope as the geometry    
            ISpatialFilter spatialFilter = new SpatialFilterClass();
            spatialFilter.Geometry = envelope;
            spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelEnvelopeIntersects;
            spatialFilter.set_OutputSpatialReference(shapeFieldName, map.SpatialReference);
            spatialFilter.GeometryField = shapeFieldName;

            // Do the search
            IFeatureCursor featureCursor = featureClass.Search(spatialFilter, false);

            // Get the first feature
            IFeature feature = featureCursor.NextFeature();
            if (!(feature == null))
            {
                return feature;
            }
            else
            {
                return null;
            }
        }


        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add Area.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add Area.OnMouseUp implementation
        }
        #endregion
    }
}
