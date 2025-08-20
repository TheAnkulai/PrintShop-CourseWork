using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintShop
{
    public partial class FEditAdditionalProduct : Form
    {
        ClassAdo classAdo = new ClassAdo();

        int AdditionalProductId = 0;
        string AdditionalProductName = "";
        decimal AdditionalProductPrice = 0;
        public FEditAdditionalProduct(int AdditionalProductId, string AdditionalProductName, decimal AdditionalProductPrice)
        {
            this.AdditionalProductId = AdditionalProductId;
            this.AdditionalProductName = AdditionalProductName;
            this.AdditionalProductPrice = AdditionalProductPrice;
            InitializeComponent();
        }

        private void FEditAdditionalProduct_Load(object sender, EventArgs e)
        {
            txtAdditioanlProductName.Text = this.AdditionalProductName;
            numAdditionalProductPrice.Value = this.AdditionalProductPrice;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            classAdo.StProcExec("EditAdditionalProduct");
            SqlCommand cmd = classAdo.StProcExec("EditAdditionalProduct");

            cmd.Parameters.AddWithValue("@addProductId", AdditionalProductId);
            cmd.Parameters.AddWithValue("@addProductName", txtAdditioanlProductName.Text);
            cmd.Parameters.AddWithValue("@addProductPrice", numAdditionalProductPrice.Value);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
