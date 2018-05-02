using System.Windows.Forms;

namespace electronic_journal.Interfaces
{
    public interface IDataGridModes
    {
        void DataGridMode();
        void DataGridAligment(DataGridView dataGridView);
        void DataGridColumnsSize(DataGridView dataGridView);
        void DataGridReadOnly(DataGridView dataGridView);
        void DataGridAllowUserToAddRows(DataGridView dataGridView);
        void DataGridRowHeadersVisible(DataGridView dataGridView);
        void DataGridAllowUserToResize(DataGridView dataGridView);
    }
}
