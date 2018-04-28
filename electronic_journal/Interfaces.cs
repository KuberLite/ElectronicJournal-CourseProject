using System.Data.SqlClient;

namespace electronic_journal
{
    public interface IDataGridModes
    {
        void DataGridMode();
        void DataGridAligment();
        void DataGridColumnsSize();
        void DataGridReadOnly();
        void DataGridAllowUserToAddRows();
        void DataGridRowHeadersVisible();
        void DataGridAllowUserToResize();
    }

    public interface IConnection
    {
        SqlConnection ConnectionSQL();
        SqlDataAdapter SqlDataAdapter(string query, SqlConnection sqlConnection);
    }
}
