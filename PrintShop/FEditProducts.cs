using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrintShop
{
    public partial class FEditProducts : Form
    {
        ClassAdo classAdo = new ClassAdo();

        int productId = 0, categoryId = 0;
        string productName = "", character = "";
        decimal pricePerEach = 0;
        public FEditProducts(int productId, int categoryId, string productName, decimal pricePerEach, string character)
        {
            this.productId = productId;
            this.categoryId = categoryId;
            this.productName = productName;
            this.pricePerEach = pricePerEach;
            this.character = character;

            InitializeComponent();
        }

        private void FEditProducts_Load(object sender, EventArgs e)
        {
            classAdo.ComboBoxBind("ViewCategories", cbCategory, "categoryName", "id_category");

            txtProductName.Text = this.productName;
            cbCategory.SelectedValue = this.categoryId;
            numPricePerEach.Value = this.pricePerEach;
            rTxtCharacter.Text = this.character;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            classAdo.StProcExec("EditProduct");
            SqlCommand cmd = classAdo.StProcExec("EditProduct");

            cmd.Parameters.AddWithValue("@productId", productId);
            cmd.Parameters.AddWithValue("@categoryId", cbCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@PricePerEach", numPricePerEach.Value);
            cmd.Parameters.AddWithValue("@character", rTxtCharacter.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Изменения сохранены!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
