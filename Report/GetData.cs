
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Geodatabase;

namespace AnalysisTools.Report
{
    public class GetData
    {

        private DataSet _FDataSet;
        private IFeatureClass _TableData;
        private List<int> indexes;
        private List<string> columnNames;

        public List<int> Indexes
        {
            get { return indexes; }
            set { indexes = value; }
        }
   
        public List<string> ColumnNames
        {
            get { return columnNames; }
            set { columnNames = value; }
        }


       

        public DataSet FDataSet
        {
            get { return _FDataSet; }
            set { _FDataSet = value; }
        }

        public GetData(IFeatureClass table)
        {
            _TableData = table;
        }

        public void CreateFeatureDataSet()
        {

            if (this._TableData == null) return;

            this._FDataSet = new DataSet();
            DataTable table = new DataTable();
            table.TableName = "TableData";
            this._FDataSet.Tables.Add(table);

            GetColumns(table);

            GetDataFromFeatureClass(table);

        }

        private void GetDataFromFeatureClass(DataTable table)
        {
            IFeatureCursor fCursor = this._TableData.Search(null, true);
            IFeature feature = fCursor.NextFeature();
            while (feature != null)
            {
                string[] values = new string[indexes.Count ];

                for (int i = 0; i < indexes.Count ; i++)
                {
                    object val = feature.get_Value(indexes[i]);
                    if (val == null)
                        values[i] = "-";
                    else
                        values[i] = feature.get_Value(indexes[i]).ToString();
                }
                table.Rows.Add(values);
                feature = fCursor.NextFeature();
            }
        }

        private void GetColumns(DataTable table)
        {
            for (int i = 0; i < columnNames.Count ; i++)
            {
             
                    DataColumn dataColumn = new DataColumn();
                    dataColumn.AllowDBNull = true;
                    dataColumn.DefaultValue = "-";
                    dataColumn.ColumnName = columnNames[i];
                    dataColumn.DataType = typeof(string);

                    table.Columns.Add(dataColumn);
            }
        }


    }
}
