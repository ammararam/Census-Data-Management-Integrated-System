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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SystemUI;

namespace AnalysisTools.MapTips
{
    public partial class frm_MapTips : DevComponents.DotNetBar.OfficeForm
    {
        private IHookHelper m_hookHelper = null;
        private IMap Map;
        private IMapControl3 m_MapControl;
        private List<IField> m_Fields;
        private List<IFeatureLayer> m_Layers;
        private IActiveViewEvents_Event activeViewEvents;

        public IHookHelper Set_HookHelper
        {
            set
            {
                m_hookHelper = value;
            }

        }


        public frm_MapTips()
        {
            InitializeComponent();
        }

        private void frm_MapTips_Load(object sender, EventArgs e)
        {
            btnShowMapTip.Enabled = false;
            btnCleanMapTip.Enabled = false;
            cboFields.Enabled = false;
            Toolbar.Style = eDotNetBarStyle.Office2003;
            this.Height = 125;

            if (m_hookHelper == null) return;
            Map = m_hookHelper.FocusMap;
            if (Map == null) return;

            if (m_hookHelper.Hook is IMapControl3)
                m_MapControl = m_hookHelper.Hook as IMapControl3;
            if (m_MapControl == null) return;

            GetLayers();
            rbtnNormal.Checked = true;

            activeViewEvents = (IActiveViewEvents_Event)Map;
            activeViewEvents.ItemAdded += new IActiveViewEvents_ItemAddedEventHandler(activeViewEvents_ItemAdded);
            activeViewEvents.ItemDeleted += new IActiveViewEvents_ItemDeletedEventHandler(activeViewEvents_ItemDeleted);

        }

        void activeViewEvents_ItemDeleted(object Item)
        {
            if (Item is IFeatureLayer)
                GetLayers();
        }

        void activeViewEvents_ItemAdded(object Item)
        {
            if (Item is IFeatureLayer)
                GetLayers();
        }

        private void GetLayers()
        {
            int j = 0;
            cboLayers.Items.Clear();
            if (m_Layers == null)
                m_Layers = new List<IFeatureLayer>();
            else
                m_Layers.Clear();

            for (int i = 0; i <= Map.LayerCount - 1; i++)
            {
                if (Map.get_Layer(i) is IFeatureLayer)
                {
                    cboLayers.Items.Add(Map.get_Layer(i).Name);
                    m_Layers.Add((IFeatureLayer)Map.get_Layer(i));
                }
            }

            if (cboLayers.Items.Count >= 0)
            {
                cboLayers.SelectedIndex = 0;
                btnShowMapTip.Enabled = true;
                btnCleanMapTip.Enabled = true;
            }
            else
            {
                btnShowMapTip.Enabled = false;
                btnCleanMapTip.Enabled = false;
                cboFields.Items.Clear();
            }

        }

        private void ShowLayerTips()
        {
            if (m_Fields.Count == 0) return;
            m_MapControl.ShowMapTips = true;
            IFeatureLayer featureLayer = (IFeatureLayer)m_Layers[cboLayers.SelectedIndex];
            featureLayer.ShowTips = true;
            featureLayer.DisplayField = m_Fields[cboFields.SelectedIndex].Name;
        }

        private void cboFields_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (m_MapControl != null) m_MapControl.ShowMapTips = false;
            this.Close();
        }

        private void btnShowMapTip_Click(object sender, EventArgs e)
        {
            ShowLayerTips();
        }

        private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get IFeatureLayer interface
            IFeatureLayer featureLayer = (IFeatureLayer)Map.get_Layer(cboLayers.SelectedIndex);
            //Query interface for ILayerFields
            ILayerFields layerFields = (ILayerFields)featureLayer;

            int j = 0;
            cboFields.Items.Clear();
            cboFields.Enabled = true;

            if (m_Fields == null)
                m_Fields = new List<IField>();
            else
                m_Fields.Clear();

            //Loop through the fields
            for (int i = 0; i <= layerFields.FieldCount - 1; i++)
            {
                //Get IField interface
                IField field = layerFields.get_Field(i);
                //If the field is not the shape field
                if (IsValid(field))
                {
                    //Add field name to the control
                    cboFields.Items.Insert(j, field.AliasName);
                    m_Fields.Add(field);
                    //If the field name is the display field
                    if (field.Name == featureLayer.DisplayField)
                    {
                        //Select the field name in the control
                        cboFields.SelectedIndex = j;
                    }
                    j = j + 1;
                }
            }
        }

        private bool IsValid(IField field)
        {
            bool result = false;
            switch (field.Type)
            {
                case esriFieldType.esriFieldTypeBlob:
                    break;
                case esriFieldType.esriFieldTypeDate:
                    result = true;
                    break;
                case esriFieldType.esriFieldTypeDouble:
                    result = true;

                    break;
                case esriFieldType.esriFieldTypeGUID:
                    break;
                case esriFieldType.esriFieldTypeGeometry:
                    break;
                case esriFieldType.esriFieldTypeGlobalID:
                    break;
                case esriFieldType.esriFieldTypeInteger:
                    result = true;
                    break;
                case esriFieldType.esriFieldTypeOID:
                    result = true;
                    break;
                case esriFieldType.esriFieldTypeRaster:
                    break;
                case esriFieldType.esriFieldTypeSingle:
                    result = true;
                    break;
                case esriFieldType.esriFieldTypeSmallInteger:
                    result = true;
                    break;
                case esriFieldType.esriFieldTypeString:
                    result = true;
                    break;
                case esriFieldType.esriFieldTypeXML:
                    break;
                default:
                    break;
            }
            return result;
        }

        private void btnCleanMapTip_Click(object sender, EventArgs e)
        {
            ClearShowMapTip();
        }

        private void ClearShowMapTip()
        {
            IFeatureLayer featureLayer = (IFeatureLayer)Map.get_Layer(cboLayers.SelectedIndex);
            featureLayer.ShowTips = false;
            featureLayer.DisplayField = "";
        }

        private void rbtnTransparent_CheckedChanged(object sender, EventArgs e)
        {
            if (m_MapControl == null) return;
            if (rbtnTransparent.CheckState == CheckState.Checked)
                m_MapControl.TipStyle = esriTipStyle.esriTipStyleTransparent;
            else
                m_MapControl.TipStyle = esriTipStyle.esriTipStyleSolid;

        }

        private void rbtnNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (m_MapControl == null) return;
            if (rbtnTransparent.CheckState == CheckState.Unchecked)
                m_MapControl.TipStyle = esriTipStyle.esriTipStyleTransparent;
            else
                m_MapControl.TipStyle = esriTipStyle.esriTipStyleSolid;

        }

        private void frm_MapTips_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_MapControl.ShowMapTips = false;
            if (activeViewEvents != null)
            {
                activeViewEvents.ItemAdded -= activeViewEvents_ItemAdded;
                activeViewEvents.ItemDeleted -= activeViewEvents_ItemDeleted;
                activeViewEvents = null;
            }
        }
    }
}