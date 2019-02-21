using ESRI.ArcGIS.esriSystem;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;

namespace AnalysisTools.GoogleMap
{
    /// <summary>
    /// Summary description for Cmd_GoogleMap.
    /// </summary>
    [Guid("33e03a35-48e1-4a41-9d44-ed7744cd2ead")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("AnalysisTools.GoogleMap.Cmd_GoogleMap")]
    public sealed class Cmd_GoogleMap : BaseCommand
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
        private IPoint pCenterPt;
        private string Url;
        private IActiveViewEvents_Event activeViewEvents;
        private WebBrowser WebBrowser_Map;
        private ESRI.ArcGIS.Carto.IActiveViewEvents_AfterDrawEventHandler m_ActiveViewEventsAfterDraw;
        private ITransformEvents_Event m_TransformEvents;
        private Boolean FirstUpdate;

        public Cmd_GoogleMap()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text
            base.m_caption = "";  //localizable text
            base.m_message = "";  //localizable text 
            base.m_toolTip = "";  //localizable text 
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
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

        }

        public WebBrowser Set_WebBrowser_Map
        {
            set { WebBrowser_Map = value; }
        }

        public override void OnClick()
        {
            try
            {

                IMap Map;

                if (m_hookHelper == null)
                    return;
                Map = m_hookHelper.FocusMap as IMap;
                if (Map == null)
                    return;


                m_TransformEvents = m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation as ITransformEvents_Event;
                m_TransformEvents.VisibleBoundsUpdated += new ITransformEvents_VisibleBoundsUpdatedEventHandler(m_TransformEvents_VisibleBoundsUpdated);

            }
            catch (Exception ex)
            {

            }
        }

        void m_TransformEvents_VisibleBoundsUpdated(IDisplayTransformation sender, bool sizeChanged)
        {
            Url = "";
            // MessageBox.Show(Url);
            GoogleMap();
            double Ax = 0;
            double Ay = 0;
            double Az = 0;
            double Bx = 0;
            double By = 0;
            double Bz = 0;
            Ax = Math.Truncate(pCenterPt.X);
            double Temp = pCenterPt.X - Ax;
            Temp = Temp * 60;
            Ay = Math.Truncate(Temp);
            Az = Temp - Ay;
            Bx = Math.Truncate(pCenterPt.Y);
            Temp = pCenterPt.Y - Bx;
            Temp = Temp * 60;
            By = Math.Truncate(Temp);
            Bz = (Temp - By);

            Ay += Az;
            By += Bz;
            Url = "http://maps.google.com/maps?q=" + Bx + "+" + By + "'+N,+" + Ax + "+" + Ay + "'+E&hl=en&geocode=+&t=h&z=12";

            WebBrowser_Map.Navigate(Url);
            return;
        E:
            return;
        }

        private void GoogleMap()
        {
            // ERROR: Not supported in C#: OnErrorStatement

            IActiveView pMapsActiveView;
            IEnvelope pEnvelope;
            ISpatialReference pEnvSpatRef;
            ISpatialReferenceInfo pSRI;
            IProjectedCoordinateSystem pPCS;

            pMapsActiveView = (IActiveView)m_hookHelper.FocusMap;
            pEnvelope = pMapsActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds;
            pCenterPt = new ESRI.ArcGIS.Geometry.Point();
            pEnvSpatRef = pEnvelope.SpatialReference;


            ISpatialReference pSpRef2;
            SpatialReferenceEnvironment pSpRFc;
            IGeographicCoordinateSystem pGCS;
            pSpRFc = new SpatialReferenceEnvironment();
            pGCS = pSpRFc.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            pSpRef2 = pGCS;
            pSpRef2.SetFalseOriginAndUnits(-180, -90, 1000000);

            pEnvelope.Project(pSpRef2);
            pCenterPt.PutCoords((pEnvelope.LowerLeft.X + pEnvelope.LowerRight.X) / 2, (pEnvelope.LowerLeft.Y + pEnvelope.UpperRight.Y) / 2);

            return;
        E:
            return;
        }

        public void Remove_EventHandler()
        {
            m_TransformEvents.VisibleBoundsUpdated -= new ITransformEvents_VisibleBoundsUpdatedEventHandler(m_TransformEvents_VisibleBoundsUpdated);
            m_TransformEvents = null;
        }


        #endregion
    }
}
