using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrintShop
{
    public partial class FEditOrder : Form
    {
        ClassAdo classAdo = new ClassAdo();
        int OrderId;
        string OrderUserFIO, OrderTotalPrice,
               OrderStaffFIO, OrderStatus;
        DateTime OrderDateStart, OrderDateEnd;
        public FEditOrder(int orderId, string orderPositionUserFIO,  string orderTotalPrice, DateTime orderPositionDateStart, DateTime orderPositionDateEnd, string orderPositionStaffFIO, string orderPositionStatus)
        {
            InitializeComponent();
            this.OrderId = orderId;
            this.OrderUserFIO = orderPositionUserFIO;
            this.OrderTotalPrice = orderTotalPrice;
            this.OrderStaffFIO = orderPositionStaffFIO;
            this.OrderStatus = orderPositionStatus;
            this.OrderDateStart = orderPositionDateStart;
            this.OrderDateEnd = orderPositionDateEnd;
        }

        private void FEditOrderPosition_Load(object sender, EventArgs e)
        {
            txtOrderTotalPrice.Text = OrderTotalPrice;
            dateOrderStart.Value = OrderDateStart;
            dateOrderEnd.Value = OrderDateEnd;
            txtUserFIO.Text = OrderUserFIO;
            cbStaffFIO.Text = OrderStaffFIO;
            cbOrderStatus.Text = OrderStatus;

            classAdo.ComboBoxBind("ViewStaffFIO", cbStaffFIO, "FIO", "id_staff");
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            classAdo.StProcExec("UpdateOrder");
            SqlCommand cmd = classAdo.StProcExec("UpdateOrder");

            cmd.Parameters.AddWithValue("@orderId", OrderId);
            cmd.Parameters.AddWithValue("@orderDateEnd", dateOrderEnd.Value);
            cmd.Parameters.AddWithValue("@id_staff", cbStaffFIO.SelectedValue);
            cmd.Parameters.AddWithValue("@status", cbOrderStatus.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Изменения сохранены!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
