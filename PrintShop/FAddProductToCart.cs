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
    public partial class FAddProductToCart : Form
    {
        ClassAdo classAdo = new ClassAdo();
        private Cart cart;
        string ConnectionString = "Data Source=DESKTOP-1OBU2SC\\SQLEXPRESS; Initial Catalog=printShopBd; Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";

        int productId = 0, categoryId = 0;
        string productName = "", categoryName = "", character = "";
        decimal productPricePerEach = 0;



        public FAddProductToCart(Cart existingCart, int productId, int categoryId, string productName, string categoryName, string character, decimal productPricePerEach)
        {
            InitializeComponent();
            this.cart = existingCart;
            this.productId = productId;
            this.categoryId = categoryId;
            this.productName = productName;
            this.categoryName = categoryName;
            this.character = character;
            this.productPricePerEach = productPricePerEach;
        }


        private void FAddProductToCart_Load(object sender, EventArgs e)
        {
            txtProductName.Text = productName;
            txtCategory.Text = categoryName;
            txtProductPricePerEach.Text = productPricePerEach.ToString();
            cbAdditionalProduct.Text = "Нет";
            classAdo.ComboBoxBind("ViewAdditionalProducts", cbAdditionalProduct, "Название", "ID");
            classAdo.ComboBoxBind("ViewMaterials", cbMaterial, "materialName", "id_material");
            classAdo.ComboBoxBind("ViewColors", cbColor, "color", "id_color");
        }


        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                productId = productId,
                productName = txtProductName.Text,
                categoryId = categoryId,
                categoryName = txtCategory.Text,
                pricePerEach = Decimal.Parse(txtProductPricePerEach.Text),
                character = rtxtCharacter.Text
            };

            var material = new Material
            {
                materialId = (int)cbMaterial.SelectedValue,
                materialName = cbMaterial.Text,
                materialPrice = Decimal.Parse(txtMaterialPrice.Text)
            };

            var additional = new AdditionalProduct
            {
                additionalProductId = (int)cbAdditionalProduct.SelectedValue,
                additionalProductName = cbAdditionalProduct.Text,
                additionalProductPrice = Decimal.Parse(txtAdditionalProductPrice.Text)
            };

            int quantity = (int)numQuantity.Value;
            int colorId = (int)cbColor.SelectedValue;
            string colorName = cbColor.Text;

            cart.AddItem(product, quantity, colorId, colorName, additional, material);
            MessageBox.Show("Товар успешно добавлен в корзину!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateAdditionalProductPrice_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT AddProductPrice FROM AdditionalProducts WHERE addProductName = '{cbAdditionalProduct.Text}'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Table");
            txtAdditionalProductPrice.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void btnUpdateMaterialPrice_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT price FROM Materials WHERE materialName = '{cbMaterial.Text}'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Table");
            txtMaterialPrice.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            if (numQuantity.Value == 0)
            {
                MessageBox.Show("Выберите количество товара!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if ((cbAdditionalProduct.Text != "Нет" && txtAdditionalProductPrice.Text == "0") || txtAdditionalProductPrice.Text == "")
            {
                MessageBox.Show("Данные о цене за доп. услугу не соответствуют с данными из базы данных. Обновите цену доп. услуги (кнопка справа от поля выбора)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cbColor.Text == "")
            {
                MessageBox.Show("Выбери цвет печати!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            string sql = $"SELECT price FROM Materials WHERE materialName = '{cbMaterial.Text}'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Table");
            if (txtMaterialPrice.Text != ds.Tables[0].Rows[0][0].ToString())
            {
                MessageBox.Show("Данные о цене за материал не соответствуют данными из базы данных. Обновите цену материала (кнопка справа от поля выбора)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (numQuantity.Value > 0 && (cbAdditionalProduct.Text != "Нет" && txtAdditionalProductPrice.Text != "0") && txtMaterialPrice.Text == ds.Tables[0].Rows[0][0].ToString())
            {
                txtTotalPrice.Text = (numQuantity.Value * (Decimal.Parse(txtProductPricePerEach.Text) + Decimal.Parse(txtAdditionalProductPrice.Text) + Decimal.Parse(txtMaterialPrice.Text))).ToString();
            }
        }


    }
}
