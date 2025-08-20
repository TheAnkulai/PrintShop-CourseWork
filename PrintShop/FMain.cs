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
    public partial class FMain : Form
    {
        ClassAdo classAdo = new ClassAdo();
        public Cart cart = new Cart();
        int access_level = 0;
        int userId = 0;
        public FMain(int access_level, int userId)
        {
            InitializeComponent();
            this.access_level = access_level;
            this.userId = userId;
        }
        string ConnectionString = "Data Source=DESKTOP-1OBU2SC\\SQLEXPRESS; Initial Catalog=printShopBd; Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True; ApplicationIntent=ReadWrite; MultiSubnetFailover=False";
        private void FMainUser_Load(object sender, EventArgs e)
        {
            //Вкладки
            

            //Услуги
            classAdo.ComboBoxBind("ViewCategories", cbCategories, "categoryName", "id_category");
            classAdo.DataGridBindOfProc("ViewProducts", dgvProducts);
            classAdo.AddButton(dgvProducts, "dtnAddProductToCart", "Добавить в корзину");

            //Доп. услуги
            classAdo.DataGridBindOfProc("ViewAdditionalProducts", dgvAdditionalProducts);


            //Корзина
            dgvCart.Columns.Add("Product", "Товар");
            dgvCart.Columns.Add("Material", "Материал");
            dgvCart.Columns.Add("Addition", "Дополнительно");
            dgvCart.Columns.Add("Color", "Цвет");
            dgvCart.Columns.Add("Quantity", "Количество");
            dgvCart.Columns.Add("Total", "Сумма");
            classAdo.AddButton(dgvCart, "btnEditCartItem", "Изменить");
            classAdo.AddButton(dgvCart, "btnDeleteCartItem", "Удалить");

            //Заказы
            classAdo.ComboBoxBind("ViewProducts", cbProductNameFilter, "Название", "ID");
            classAdo.ComboBoxBind("ViewColors", cbColorFilter, "color", "id_color");
            classAdo.ComboBoxBind("ViewAdditionalProducts", cbAdditionalProductFilter, "Название", "ID");
            classAdo.ComboBoxBind("ViewMaterials", cbMaterialFilter, "materialName", "id_material");

            //обычный пользователь
            if (access_level == 3)
            {
                //Вкладки
                if (TabControl1.TabPages.Contains(tabClients)) TabControl1.TabPages.Remove(tabClients);
                if (TabControl1.TabPages.Contains(tabStaff)) TabControl1.TabPages.Remove(tabStaff);
                if (TabControl1.TabPages.Contains(tabReports)) TabControl1.TabPages.Remove(tabReports);
                
                //Услуги
                gbAddNewProduct.Visible = false;
                gbAddNewProduct.Enabled = false;

                //Доп. услгуи
                gbAddAdditionalProduct.Visible = false;
                gbAddAdditionalProduct.Enabled = false;
                btnAddAdditionalProduct.Enabled = false;
                btnAddAdditionalProduct.Visible = false;

                //Заказы
                classAdo.DataGridBindOfProcWithParameters("ViewUserOrders", "@id_user", userId, dgvOrders);
                chbFIOStaffFilter.Visible = false;
                chbFIOStaffFilter.Enabled = false;
                chbUserFIOFilter.Enabled = false;
                chbUserFIOFilter.Visible = false;
                cbStaffFilter.Enabled = false;
                cbStaffFilter.Visible = false;
                txtUserFIOFilter.Visible = false;
                txtUserFIOFilter.Enabled = false;
            }

            //администратор
            if (access_level == 1)
            {
                //Услуги

                classAdo.ComboBoxBind("viewCategories", cbCategoryAdd, "categoryName", "id_category");

                classAdo.AddButton(dgvProducts, "btnEditProduct", "Изменить");
                classAdo.AddButton(dgvProducts, "btnDeleteProduct", "Удалить");
                //Доп. услуги
                classAdo.AddButton(dgvAdditionalProducts, "btnEditAdditionalProduct", "Изменить");
                classAdo.AddButton(dgvAdditionalProducts, "btnDeleteAdditionalProduct", "Удалить");
                //Корзина

                //Заказы
                classAdo.DataGridBindOfProc("ViewOrders", dgvOrders);
                classAdo.ComboBoxBind("ViewStaffFIO", cbStaffFilter, "FIO", "id_staff");
                classAdo.AddButton(dgvOrders, "btnEditOrderPosition", "Изменить");
            }
        }

        //Вкладка Товары
        private void bSearch_Click(object sender, EventArgs e)
        {
            if (cbCategories.SelectedValue != null)
            {
                classAdo.DataGridBindOfProcWithParameters("ViewCategoryProducts", "@category_id", (int)cbCategories.SelectedValue, dgvProducts);
            }
            
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            classAdo.StProcExec("AddProducts");
            SqlCommand cmd = classAdo.StProcExec("AddProducts");
            if (txtProductNameAdd.Text != "" && numPricePerEachAdd.Value != 0)
            {
                cmd.Parameters.AddWithValue("@category_id", cbCategoryAdd.SelectedValue);
                cmd.Parameters.AddWithValue("@productName", txtProductNameAdd.Text);
                cmd.Parameters.AddWithValue("@PricePerEach", numPricePerEachAdd.Value);
                cmd.Parameters.AddWithValue("@character", rTxtAddCharacter.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Товар добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                classAdo.DataGridBindOfProc("ViewProducts", dgvProducts);
            }
            else
            {
                MessageBox.Show("Введите все данные!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonColumn clickedColumn = (DataGridViewButtonColumn)dgv.Columns[e.ColumnIndex];

                string property = clickedColumn.DataPropertyName;

                switch (property)
                {
                    case "dtnAddProductToCart":

                        int nRow = dgvProducts.CurrentRow.Index;
                        int productId = (int)dgvProducts.Rows[nRow].Cells["ID"].Value;


                        string sql = $"SELECT id_category FROM Category WHERE categoryName = '{dgvProducts["Категория", nRow].Value.ToString()}'";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionString);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "Table");
                        int categoryId = (int)ds.Tables[0].Rows[0][0];

                        string productName = dgvProducts["Название", nRow].Value.ToString();
                        string categoryName = dgvProducts["Категория", nRow].Value.ToString();
                        string character = dgvProducts["Описание", nRow].Value.ToString();

                        decimal productPricePerEach = (decimal)dgvProducts["Цена за ед.", nRow].Value;

                        FAddProductToCart fAddProductToCart = new FAddProductToCart(cart, productId, categoryId, productName, categoryName, character, productPricePerEach);
                        fAddProductToCart.ShowDialog();

                        break;
                    case "btnEditProduct":
                        int nRow1 = dgvProducts.CurrentRow.Index;
                        int editProductId = (int)dgvProducts.Rows[nRow1].Cells["ID"].Value;

                        string sql1 = $"SELECT id_category FROM Category WHERE categoryName = N'{dgvProducts.Rows[nRow1].Cells["Категория"].Value.ToString()}'";
                        SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, ConnectionString);
                        DataSet ds1 = new DataSet();
                        adapter1.Fill(ds1, "Table");
                        int editCategoryId = (int)ds1.Tables[0].Rows[0][0];

                        string editProductName = dgvProducts.Rows[nRow1].Cells["Название"].Value.ToString();
                        decimal editPricePerEach = (decimal)dgvProducts.Rows[nRow1].Cells["Цена за ед."].Value;
                        string editCharacter = dgvProducts["Описание", nRow1].Value.ToString();

                        FEditProducts fEditProducts = new FEditProducts(editProductId, editCategoryId, editProductName, editPricePerEach, editCharacter);
                        fEditProducts.ShowDialog();
                        classAdo.DataGridBindOfProc("ViewProducts", dgvProducts);

                        break;
                    case "btnDeleteProduct":
                        var result = MessageBox.Show("Вы действительно хотите удалить улсугу?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            nRow = dgvProducts.CurrentRow.Index;
                            productId = (int)dgvProducts.Rows[nRow].Cells["ID"].Value;


                            classAdo.StProcExec("DeleteProduct");
                            SqlCommand cmd = classAdo.StProcExec("DeleteProduct");

                            cmd.Parameters.AddWithValue("@id_product", productId);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Услуга успешно удалена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            classAdo.DataGridBindOfProc("ViewProducts", dgvProducts);
                        }
                        else
                        {
                            MessageBox.Show("Операция отменена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    default:
                        MessageBox.Show("Нет формы для этого действия.");
                        break;
                }
            }
        }

        private void btnResetProductFilter_Click(object sender, EventArgs e)
        {
            classAdo.DataGridBindOfProc("ViewProducts", dgvProducts);
        }

        //Вкладка  Доп. Услуги
        private void btnAddAdditionalProduct_Click(object sender, EventArgs e)
        {
            classAdo.StProcExec("AddAdditionalProducts");
            SqlCommand cmd = classAdo.StProcExec("AddAdditionalProducts");
            if (txtAddAdditionalProduct.Text != "")
            {
                cmd.Parameters.AddWithValue("@addProductName", txtAddAdditionalProduct.Text);
                cmd.Parameters.AddWithValue("@addProductPrice", numAddAdditionalProductPrice.Value);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Доп. услуга добавлена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                classAdo.DataGridBindOfProc("ViewAdditionalProducts", dgvAdditionalProducts);
            }
            else
            {
                MessageBox.Show("Введите название!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvAdditionalProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                this.Text = dgvProducts.CurrentRow.Index.ToString();
                DataGridViewButtonColumn clickedColumn = (DataGridViewButtonColumn)dgv.Columns[e.ColumnIndex];

                string property = clickedColumn.DataPropertyName;

                switch (property)
                {
                    case "btnEditAdditionalProduct":
                        int nRow = dgvAdditionalProducts.CurrentRow.Index;

                        int additionalProductId = (int)dgvAdditionalProducts["ID", nRow].Value;
                        string additionalProductName = dgvAdditionalProducts["Название", nRow].Value.ToString();
                        decimal additionalProductPrice = (decimal)dgvAdditionalProducts["Цена", nRow].Value;
                        FEditAdditionalProduct fEditAddProducts = new FEditAdditionalProduct(additionalProductId, additionalProductName, additionalProductPrice);
                        fEditAddProducts.ShowDialog();
                        classAdo.DataGridBindOfProc("ViewAdditionalProducts", dgvAdditionalProducts);
                        break;

                    case "btnDeleteAdditionalProduct":
                        var result = MessageBox.Show("Вы действительно хотите удалить доп. улсугу?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            int DeleteNRow = dgvAdditionalProducts.CurrentRow.Index;
                            int DeleteAdditionalProductId = (int)dgvAdditionalProducts.Rows[DeleteNRow].Cells["ID"].Value;


                            classAdo.StProcExec("DeleteAdditionalProduct");
                            SqlCommand cmd = classAdo.StProcExec("DeleteAdditionalProduct");

                            cmd.Parameters.AddWithValue("@id_addProduct", DeleteAdditionalProductId);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Доп. услуга успешно удалена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            classAdo.DataGridBindOfProc("ViewAdditionalProducts", dgvAdditionalProducts);
                        }
                        else
                        {
                            MessageBox.Show("Операция отменена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    default:
                        MessageBox.Show("Нет формы для этого действия.");
                        break;
                }
            }
        }


        //Вкладка Корзина

        private void btnUpdateCart_Click(object sender, EventArgs e)
        {
            cart.RefreshCart(dgvCart, cart);
            if (cart.Items.Count > 0) {
                btnSaveOrder.Enabled = true;
            }

            txtTotalCartPrice.Text = cart.GetTotal().ToString();
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonColumn clickedColumn = (DataGridViewButtonColumn)dgv.Columns[e.ColumnIndex];

                string property = clickedColumn.DataPropertyName;

                switch (property)
                {
                    case "btnEditCartItem":
                        int index = dgvCart.CurrentRow.Index;

                        if (dgvCart["Product", index].Value != null)
                        {
                            FEditCartItem fEditCartItem = new FEditCartItem(cart, index);
                            fEditCartItem.ShowDialog();
                        }
                        cart.RefreshCart(dgvCart, cart);
                        break;
                    case "btnDeleteCartItem":
                        int nRow = dgvCart.CurrentRow.Index;
                        if (dgvCart["Product", nRow].Value != null) {
                            cart.RemoveItem(nRow);
                            MessageBox.Show("Успешно удалено из корзины!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cart.RefreshCart(dgvCart, cart);
                        }
                        break;
                    default:
                        MessageBox.Show("Нет формы для этого действия.");
                        break;
                }
            }
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if(cart.Items.Count == 0)
            {
                MessageBox.Show("Добавьте в корзину хотя бы один товар!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                classAdo.StProcExec("AddOrder");
                SqlCommand cmd = classAdo.StProcExec("AddOrder");

                cmd.Parameters.AddWithValue("@id_user", userId);
                cmd.Parameters.AddWithValue("@orderDatestart", dateOrder.Value);
                cmd.Parameters.Add("@id_order", SqlDbType.Int);

                cmd.Parameters["@id_order"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                int orderId = Convert.ToInt32(cmd.Parameters["@id_order"].Value);

                foreach (var item in cart.Items)
                {
                    classAdo.StProcExec("AddOrderPosition");
                    cmd = classAdo.StProcExec("AddOrderPosition");

                    cmd.Parameters.AddWithValue("@id_order", orderId);
                    cmd.Parameters.AddWithValue("@id_product", item.Product.productId);
                    cmd.Parameters.AddWithValue("@quantity", item.quantity);
                    cmd.Parameters.AddWithValue("@id_color", item.colorId);
                    cmd.Parameters.AddWithValue("@positionPrice", item.TotalPrice);
                    cmd.Parameters.AddWithValue("@id_addProduct", item.AdditionalProduct.additionalProductId);
                    cmd.Parameters.AddWithValue("@id_material", item.Material.materialId);

                    cmd.ExecuteNonQuery();

                
                }
                MessageBox.Show("Заказ успешно оформлен! Количество позиций в заказе: " + cart.Items.Count, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (access_level == 1)
                {
                    classAdo.DataGridBindOfProc("ViewOrders", dgvOrders);
                }
                else if (access_level == 3)
                {
                    classAdo.DataGridBindOfProcWithParameters("ViewUserOrders", "@id_user", userId, dgvOrders);
                }
                cart.Items.Clear();
                cart.RefreshCart(dgvCart, cart);
            }


        }

        //Вкладка Заказы

        private void btnFindOrders_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("ViewFilteredOrders", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_user", userId);
            cmd.Parameters.AddWithValue("@accessLevel", access_level);
            cmd.Parameters.AddWithValue("@id_order", !chbOrderIdFilter.Checked ? (object)DBNull.Value : Convert.ToInt32(txtOrderIdFilter.Text));
            cmd.Parameters.AddWithValue("@productName", !chbProductNameFilter.Checked ? (object)DBNull.Value : cbProductNameFilter.Text);
            cmd.Parameters.AddWithValue("@id_color", !chbColorFilter.Checked ? (object)DBNull.Value : cbColorFilter.SelectedValue);
            cmd.Parameters.AddWithValue("@id_addProduct", !chbAdditionalProductFilter.Checked ? (object)DBNull.Value : cbAdditionalProductFilter.SelectedValue);
            cmd.Parameters.AddWithValue("@id_material", !chbMaterialFilter.Checked ? (object)DBNull.Value : cbMaterialFilter.SelectedValue);
            cmd.Parameters.AddWithValue("@quantity", !chbQuantityFilter.Checked ? (object)DBNull.Value : numQuantityFilter.Value);
            cmd.Parameters.AddWithValue("@orderDateFrom", !chbOrderDateFilter.Checked ? (object)DBNull.Value : dateOrderFromFilter.Value.Date);
            cmd.Parameters.AddWithValue("@orderDateTo", !chbOrderDateFilter.Checked ? (object)DBNull.Value : dateOrderToFilter.Value.Date);
            cmd.Parameters.AddWithValue("@maxPositionPrice", !chbMaxPositionPriceFilter.Checked ? (object)DBNull.Value : numMaxPositionPrice.Value);
            cmd.Parameters.AddWithValue("@status", !chbStatusFilter.Checked ? (object)DBNull.Value : cbStatusFilter.Text);
            if (access_level == 1)
            {
                cmd.Parameters.AddWithValue("@FIO", !chbUserFIOFilter.Checked ? (object)DBNull.Value : txtUserFIOFilter.Text);
                cmd.Parameters.AddWithValue("@id_staff", !chbFIOStaffFilter.Checked ? (object)DBNull.Value : cbStaffFilter.SelectedValue);
            }
            foreach (SqlParameter p in cmd.Parameters)
            {
                Console.WriteLine($"{p.ParameterName} = {p.Value}");
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            conn.Open();
            adapter.Fill(table);
            dgvOrders.DataSource = table;
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonColumn clickedColumn = (DataGridViewButtonColumn)dgv.Columns[e.ColumnIndex];

                string property = clickedColumn.DataPropertyName;

                switch (property)
                {
                    case "btnEditOrderPosition":
                        int nRow = dgvOrders.CurrentRow.Index;
                        int editOrderPositionId = (int)dgvOrders.Rows[nRow].Cells["id позиции"].Value;

                        string editOrderPositionUserFIO = dgvOrders.Rows[nRow].Cells["ФИО заказчика"].Value.ToString();
                        string editOrderPositionProductName = dgvOrders.Rows[nRow].Cells["Название товара"].Value.ToString();
                        string editOrderPositionColor = dgvOrders.Rows[nRow].Cells["Цветность"].Value.ToString();
                        string editOrderPositionAdditionalProductName = dgvOrders.Rows[nRow].Cells["Доп. услуга"].Value.ToString();
                        string editorderPositionMaterialName = dgvOrders.Rows[nRow].Cells["Материал"].Value.ToString();
                        string editOrderPositionQuantity = dgvOrders.Rows[nRow].Cells["Количество"].Value.ToString();
                        string editOrderPositionPrice = dgvOrders.Rows[nRow].Cells["Цена за позицию"].Value.ToString();
                        DateTime editOrderPositionDateStart = Convert.ToDateTime(dgvOrders.Rows[nRow].Cells["Дата заказа"].Value);
                        DateTime editOrderPositionDateEnd = Convert.ToDateTime(dgvOrders.Rows[nRow].Cells["Дата завершения заказа"].Value);
                        string editOrderPositionStaffFIO = dgvOrders.Rows[nRow].Cells["Исполнитель"].Value.ToString();


                        break;
                    default:
                        MessageBox.Show("Нет формы для этого действия.");
                        break;
                }
            }
        }
    }
}
