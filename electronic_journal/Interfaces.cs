using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronic_journal
{
    public interface IDataGridModes
    {
        void DataGridMode();
        void DataGridAligment();
        void DataGridColumnsSize();
        void DataGridReadOnly();
        void DataGridAllowUserToAddRows();
    }

    public interface IConnection
    {
        SqlConnection ConnectionSQL();
        SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection);
    }
}
