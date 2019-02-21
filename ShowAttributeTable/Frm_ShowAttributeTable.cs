using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace Analysis_GeneralTools.ShowAttributeTable
{
    public partial class Frm_ShowAttributeTable : DevComponents.DotNetBar.OfficeForm
    {
        private IHookHelper m_hookHelper = null;
        private IMap Map;

        public IHookHelper Set_HookHelper
        {
            set
            {
                m_hookHelper = value;
            }

        }

        public Frm_ShowAttributeTable()
        {
            InitializeComponent();
        }

        private void Frm_ShowAttributeTable_Load(object sender, EventArgs e)
        {
            if (m_hookHelper == null) return;
            Map = m_hookHelper.FocusMap;
            if (Map == null) return;

        }
    }
}