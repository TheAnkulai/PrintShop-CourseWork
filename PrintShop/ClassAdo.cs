using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PrintShop
{
    internal class ClassAdo
    {
        public string connectionString;
        public SqlCommand cmd;

        public ClassAdo()
        {
            connectionString = "Data Source=DESKTOP-1OBU2SC\\SQLEXPRESS; Initial Catalog=printShopBd; Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
        }

        public DataSet GetDataSet(string sqlQuery)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Table");
            return ds;
        }

        public DataSet GetDataSetOfProc(string ProcedureName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(ProcedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcedureName;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Tables");
            return ds;
        }

        public DataSet GetDataSetOfProcWithParameters(string ProcedureName, string ParameterName, int ParameterValue)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(ProcedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcedureName;
            cmd.Parameters.AddWithValue(ParameterName, ParameterValue);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Tables");
            return ds;
        }

        public void DataGridBindOfProc(string StoredProcedureName, DataGridView dataGridView)
        {
            DataSet ds = GetDataSetOfProc(StoredProcedureName);
            dataGridView.DataSource = ds.Tables[0].DefaultView;
        }

        public void DataGridBindOfProcWithParameters(string ProcedureName, string ParameterName, int ParameterValue, DataGridView dgv)
        {
            DataSet ds = GetDataSetOfProcWithParameters(ProcedureName, ParameterName, ParameterValue);
            dgv.DataSource = ds.Tables[0].DefaultView;
        }
        public void DataGridBind (string sqlQuerry,  DataGridView dataGridView)
        {
            DataSet ds = GetDataSet(sqlQuerry);
            dataGridView.DataSource = ds.Tables[0].DefaultView;
        }

        public void ComboBoxBind(string StoredProcedureName, ComboBox comboBox, string displayMember, string valueMember)
        {
            DataSet ds = GetDataSetOfProc(StoredProcedureName);
            comboBox.DataSource = ds.Tables[0];
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.SelectedValue = ds.Tables[0].Rows[0][valueMember].ToString();
        }

        public SqlCommand StProcExec(string commandText)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = commandText;
            return cmd;
        }

        public void AddButton(DataGridView dgv, string dataPropertyName, string ButtonText)
        {
            DataGridViewButtonColumn ColumnButton = new DataGridViewButtonColumn();
            ColumnButton.UseColumnTextForButtonValue = true;
            ColumnButton.DataPropertyName = dataPropertyName;
            ColumnButton.Text = ButtonText;
            dgv.Columns.Add(ColumnButton);
        }
    }
}
