using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
    }
}
