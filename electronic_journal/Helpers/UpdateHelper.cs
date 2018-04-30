using electronic_journal.Singleton;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronic_journal.Helpers {
    public class UpdateHelper<TCell> {
        private List<TCell> values;
        private Database database;
        private string tableName;
        private string valueCellName;
        private string idCellName;

        public UpdateHelper(string tableName, string idCellName, string valueCellName) {
            Reset();
            database = Database.GetInstance();
            this.tableName = tableName;
            this.valueCellName = valueCellName;
            this.idCellName = idCellName;
        }

        public void AddValue(TCell value)
        {
            TCell item = values.FirstOrDefault(i => i.Equals(value));
            if (item == null)
            {
                values.Add(value);
            }
        }

        public List<TCell> GetValues()
        {
            return values;
        }

        public void Reset()
        {
            values = new List<TCell>();
        }

        public List<string> GetCellsIds()
        {
            List<string> keys = new List<string>();
            foreach (var value in values)
            {
                string id = GetCellId(value);
                keys.Add(id);
            }
            return keys;
        }

        private string GetCellId(TCell value)
        {
            DataSet resultSet = new DataSet();
            string query = GenerateSelectIdQuery(value);
            database.ExequteQuery(query).Fill(resultSet);
            return resultSet.Tables[0].Rows[0][idCellName].ToString();
        }

        private string GenerateSelectIdQuery(TCell value)
        {
            return "select [" + idCellName + "] " 
                + "from [" + tableName + "] "
                + "where [" + valueCellName + "] "
                + "= '" + value.ToString() + "'";
        }
    }
}
