using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrintShop
{
    public partial class FEditCartItem : Form
    {
        ClassAdo classAdo = new ClassAdo();
        private Cart cart;
        string ConnectionString = "Data Source=DESKTOP-1OBU2SC\\SQLEXPRESS; Initial Catalog=printShopBd; Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
        int index = 0;

        public FEditCartItem(Cart existingCart, int index)
        {
            InitializeComponent();
            this.cart = existingCart;
            this.index = index;
        }

        private void FEditCartItem_Load(object sender, EventArgs e)
        {
            classAdo.ComboBoxBind("ViewAdditionalProducts", cbAdditionalProduct, "Название", "ID");
            classAdo.ComboBoxBind("GetMaterials", cbMaterial, "materialName", "id_material");
            classAdo.ComboBoxBind("GetColors", cbColor, "color", "id_color");

            txtProductName.Text = cart.Items[index].Product.productName;
            txtCategory.Text = cart.Items[index].Product.categoryName;
            rtxtCharacter.Text = cart.Items[index].Product.character;
            numProductPricePerEach.Value = cart.Items[index].Product.pricePerEach;
            numQuantity.Value = cart.Items[index].quantity;
            cbAdditionalProduct.Text = cart.Items[index].AdditionalProduct.additionalProductName;
            numAdditionalProductPrice.Value = cart.Items[index].AdditionalProduct.additionalProductPrice;
            cbColor.Text = cart.Items[index].colorName;
            cbMaterial.Text = cart.Items[index].Material.materialName;
            numMaterialPrice.Value = cart.Items[index].Material.materialPrice;
            txtTotalPrice.Text = cart.Items[index].TotalPrice.ToString();
        }

        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            txtTotalPrice.Text = (numQuantity.Value * (numProductPricePerEach.Value + numAdditionalProductPrice.Value + numMaterialPrice.Value)).ToString();
        }

        private void btnUpdateAdditionalProductPrice_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT AddProductPrice FROM AdditionalProducts WHERE addProductName = '{cbAdditionalProduct.Text}'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Table");
            numAdditionalProductPrice.Value = (decimal)ds.Tables[0].Rows[0][0];
        }

        private void btnUpdateMaterialPrice_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT price FROM Materials WHERE materialName = '{cbMaterial.Text}'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Table");
            numMaterialPrice.Value = (decimal)ds.Tables[0].Rows[0][0];
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            cart.Items[index].quantity = (int)numQuantity.Value;
            cart.Items[index].AdditionalProduct.additionalProductId = (int)cbAdditionalProduct.SelectedValue;
            cart.Items[index].AdditionalProduct.additionalProductName = cbAdditionalProduct.Text;
            cart.Items[index].AdditionalProduct.additionalProductPrice = (int)numAdditionalProductPrice.Value;
            cart.Items[index].colorName = cbColor.Text;
            cart.Items[index].colorId = (int)cbColor.SelectedValue;
            cart.Items[index].Material.materialId = (int)cbMaterial.SelectedValue;
            cart.Items[index].Material.materialName = cbMaterial.Text;
            cart.Items[index].Material.materialPrice = (int)numMaterialPrice.Value;
            MessageBox.Show("Изменения сохранены!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
