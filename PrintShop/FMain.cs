using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

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
            classAdo.ComboBoxBind("GetCategories", cbCategories, "categoryName", "id_category");
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
            

            //Состав Заказов
            classAdo.ComboBoxBind("ViewProducts", cbOrderCompositionProductNameFilter, "Название", "ID");
            classAdo.ComboBoxBind("GetColors", cbOrderCompositionColorFilter, "color", "id_color");
            classAdo.ComboBoxBind("ViewAdditionalProducts", cbOrderCompositionAdditionalProductFilter, "Название", "ID");
            classAdo.ComboBoxBind("GetMaterials", cbOrderCompositionMaterialFilter, "materialName", "id_material");

            //обычный пользователь
            if (access_level == 3)
            {
                //Вкладки
                if (TabControl1.TabPages.Contains(tabStaff)) TabControl1.TabPages.Remove(tabStaff);
                if (TabControl1.TabPages.Contains(tabReports)) TabControl1.TabPages.Remove(tabReports);
                if (TabControl1.TabPages.Contains(tabOrders)) TabControl1.TabPages.Remove(tabOrders);
                
                //Услуги
                gbAddNewProduct.Visible = false;
                gbAddNewProduct.Enabled = false;

                //Доп. услгуи
                gbAddAdditionalProduct.Visible = false;
                gbAddAdditionalProduct.Enabled = false;
                btnAddAdditionalProduct.Enabled = false;
                btnAddAdditionalProduct.Visible = false;

                //Состав Заказов
                classAdo.DataGridBindOfProcWithParameters("ViewUserOrders", "@id_user", userId, dgvOrderComposition);
                chbOrderCompositionUserFIOFilter.Enabled = false;
                chbOrderCompositionUserFIOFilter.Visible = false;
                txtOrderCompositionUserFIOFilter.Visible = false;
                txtOrderCompositionUserFIOFilter.Enabled = false;
            }

            //администратор
            if (access_level == 1)
            {
                //Услуги

                classAdo.ComboBoxBind("GetCategories", cbCategoryAdd, "categoryName", "id_category");

                classAdo.AddButton(dgvProducts, "btnEditProduct", "Изменить");
                classAdo.AddButton(dgvProducts, "btnDeleteProduct", "Удалить");
                //Доп. услуги
                classAdo.AddButton(dgvAdditionalProducts, "btnEditAdditionalProduct", "Изменить");
                classAdo.AddButton(dgvAdditionalProducts, "btnDeleteAdditionalProduct", "Удалить");
                //Корзина

                //Состав Заказов
                classAdo.DataGridBindOfProc("ViewOrders", dgvOrderComposition);

                //Заказы
                classAdo.ComboBoxBind("GetStaffFIO", cbOrderFilterStaffFIO, "FIO", "id_staff");
                classAdo.DataGridBindOfProc("ViewFilteredOrders", dgvOrders);
                classAdo.AddButton(dgvOrders, "btnEditOrder", "Изменить");

                //Сотрудники
                classAdo.ComboBoxBind("GetPositions", cbStaffPositionSearch,"positionName", "id_position");
                classAdo.DataGridBindOfProc("ViewStaff", dgvStaff);
                classAdo.ComboBoxBind("GetPositions", cbAddStaffPosition, "positionName", "id_position"); 
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
                    classAdo.DataGridBindOfProc("ViewOrders", dgvOrderComposition);
                }
                else if (access_level == 3)
                {
                    classAdo.DataGridBindOfProcWithParameters("ViewUserOrders", "@id_user", userId, dgvOrderComposition);
                }
                cart.Items.Clear();
                cart.RefreshCart(dgvCart, cart);
            }


        }

        //Вкладка Состав Заказов

        private void btnFindOrders_Click(object sender, EventArgs e)
        {
            FindFilteredOrderPositions();
        }

        

        private void FindFilteredOrderPositions()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("ViewFilteredOrderComposition", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_user", userId);
            cmd.Parameters.AddWithValue("@accessLevel", access_level);
            cmd.Parameters.AddWithValue("@id_order", !chbOrderCompositionFilterOrderId.Checked || txtOrderCompositionOrderIdFilter.Text == "" ? (object)DBNull.Value : Convert.ToInt32(txtOrderCompositionOrderIdFilter.Text));
            cmd.Parameters.AddWithValue("@productName", !chbOrderCompositionProductNameFilter.Checked || cbOrderCompositionProductNameFilter.SelectedValue == null ? (object)DBNull.Value : cbOrderCompositionProductNameFilter.Text);
            cmd.Parameters.AddWithValue("@id_color", !chbOrderCompositionColorFilter.Checked || cbOrderCompositionColorFilter.SelectedValue == null ? (object)DBNull.Value : cbOrderCompositionColorFilter.SelectedValue);
            cmd.Parameters.AddWithValue("@id_addProduct", !chbOrderCompositionAdditionalProductFilter.Checked || cbOrderCompositionAdditionalProductFilter.SelectedValue == null ? (object)DBNull.Value : cbOrderCompositionAdditionalProductFilter.SelectedValue);
            cmd.Parameters.AddWithValue("@id_material", !chbOrderCompositionMaterialFilter.Checked || cbOrderCompositionMaterialFilter.SelectedValue == null ? (object)DBNull.Value : cbOrderCompositionMaterialFilter.SelectedValue);
            cmd.Parameters.AddWithValue("@quantity", !chbOrderCompositionQuantityFilter.Checked || numOrderCompositionQuantityFilter.Value == 0 ? (object)DBNull.Value : numOrderCompositionQuantityFilter.Value);
            cmd.Parameters.AddWithValue("@orderDateFrom", !chbOrderCompositionDateFilter.Checked ? (object)DBNull.Value : dateOrderPositionFromFilter.Value.Date);
            cmd.Parameters.AddWithValue("@orderDateTo", !chbOrderCompositionDateFilter.Checked ? (object)DBNull.Value : dateOrderPositionToFilter.Value.Date);
            cmd.Parameters.AddWithValue("@maxPositionPrice", !chbOrderCompositionMaxPositionPriceFilter.Checked || numOrderCompositionMaxPositionPrice.Value == 0 ? (object)DBNull.Value : numOrderCompositionMaxPositionPrice.Value);
            cmd.Parameters.AddWithValue("@status", !chbOrderCompositionStatusFilter.Checked || cbOrderCompositionStatusFilter.Text  == "" ? (object)DBNull.Value : cbOrderCompositionStatusFilter.Text);
            if (access_level == 1)
            {
                cmd.Parameters.AddWithValue("@FIO", !chbOrderCompositionUserFIOFilter.Checked || txtOrderCompositionUserFIOFilter.Text == "" ? (object)DBNull.Value : txtOrderCompositionUserFIOFilter.Text);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            conn.Open();
            adapter.Fill(table);
            dgvOrderComposition.DataSource = table;
        }

        private void btnResetOrderCompositionFilters_Click(object sender, EventArgs e)
        {
            chbOrderCompositionAdditionalProductFilter.Checked = false;
            chbOrderCompositionColorFilter.Checked = false;
            chbOrderCompositionDateFilter.Checked = false;
            chbOrderCompositionFilterOrderId.Checked = false;
            chbOrderCompositionMaterialFilter.Checked = false;
            chbOrderCompositionMaxPositionPriceFilter.Checked = false;
            chbOrderCompositionProductNameFilter.Checked = false;
            chbOrderCompositionQuantityFilter.Checked = false;
            chbOrderCompositionStatusFilter.Checked = false;
            chbOrderCompositionUserFIOFilter.Checked = false;

            txtOrderCompositionOrderIdFilter.Text = string.Empty;
            txtOrderCompositionUserFIOFilter.Text = string.Empty;

            numOrderCompositionMaxPositionPrice.Value = 0;
            numOrderCompositionQuantityFilter.Value = 0;

            cbOrderCompositionAdditionalProductFilter.Text = string.Empty;
            cbOrderCompositionColorFilter.Text = string.Empty;
            cbOrderCompositionMaterialFilter.Text = string.Empty;
            cbOrderCompositionProductNameFilter.Text = string.Empty;
            cbOrderCompositionStatusFilter.Text = string.Empty;
        }

        //Вкладка Заказы
        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonColumn clickedColumn = (DataGridViewButtonColumn)dgv.Columns[e.ColumnIndex];

                string property = clickedColumn.DataPropertyName;

                switch (property)
                {
                    case "btnEditOrder":
                        int nRow = dgvOrders.CurrentRow.Index;
                        int editOrderId = (int)dgvOrders.Rows[nRow].Cells["id заказа"].Value;
                        string editOrderUserFIO = dgvOrders.Rows[nRow].Cells["ФИО заказчика"].Value.ToString();
                        string editOrderTotalPrice = dgvOrders.Rows[nRow].Cells["Цена заказа"].Value.ToString();
                        DateTime editOrderDateStart = Convert.ToDateTime(dgvOrders.Rows[nRow].Cells["Дата заказа"].Value);
                        DateTime editOrderDateEnd = dgvOrders.Rows[nRow].Cells["Дата завершения заказа"].Value == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dgvOrders.Rows[nRow].Cells["Дата завершения заказа"].Value);
                        string editOrderStaffFIO = dgvOrders.Rows[nRow].Cells["Исполнитель"].Value.ToString();
                        string editOrderStatus = dgvOrders.Rows[nRow].Cells["Статус"].Value.ToString();

                        FEditOrder fEditOrderPosition = new FEditOrder(editOrderId, editOrderUserFIO, editOrderTotalPrice,
                            editOrderDateStart, editOrderDateEnd,
                            editOrderStaffFIO, editOrderStatus);
                        fEditOrderPosition.ShowDialog();
                        FindFilteredOrders();

                        break;
                    default:
                        MessageBox.Show("Нет формы для этого действия.");
                        break;
                }
            }
        }

        private void FindFilteredOrders()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("ViewFilteredOrders", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_order", !chbOrderFilterOrderId.Checked || txtOrderFilterOrderId.Text == "" ? (object)DBNull.Value : Convert.ToInt32(txtOrderFilterOrderId.Text));
            cmd.Parameters.AddWithValue("@id_staff", !chbOrderFilterStaffFIO.Checked || cbOrderFilterStaffFIO.SelectedValue == null ? (object)DBNull.Value : cbOrderFilterStaffFIO.SelectedValue);
            cmd.Parameters.AddWithValue("@orderDateFrom", !chbOrderFilterDate.Checked ? (object)DBNull.Value : dateOrderFrom.Value.Date);
            cmd.Parameters.AddWithValue("@orderDateTo", !chbOrderFilterDate.Checked ? (object)DBNull.Value : dateOrderTo.Value.Date);
            cmd.Parameters.AddWithValue("@maxTotalPrice", !chbOrderFilterMaxPrice.Checked ? (object)DBNull.Value : numOrderFilterMaxPrice.Value);
            cmd.Parameters.AddWithValue("@status", !chbOrderFilterStatus.Checked || cbOrderFilterStatus.Text == "" ? (object)DBNull.Value : cbOrderFilterStatus.Text);
            cmd.Parameters.AddWithValue("@FIO", !chbOrderFilterUserFIO.Checked || txtOrderFilterUserFIO.Text == "" ? (object)DBNull.Value : txtOrderFilterUserFIO.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            conn.Open();
            adapter.Fill(table);
            dgvOrders.DataSource = table;
        }
        private void btnSearchFilteredOrders_Click(object sender, EventArgs e)
        {
            FindFilteredOrders();
        }

        private void btnResetOrderFilters_Click(object sender, EventArgs e)
        {
            chbOrderFilterDate.Checked = false;
            chbOrderFilterMaxPrice.Checked = false;
            chbOrderFilterStatus.Checked = false;
            chbOrderFilterOrderId.Checked = false;
            chbOrderFilterStaffFIO.Checked = false;
            chbOrderFilterUserFIO.Checked = false;

            txtOrderFilterOrderId.Text = "";
            txtOrderFilterUserFIO.Text = "";
            cbOrderFilterStaffFIO.Text = "";
            cbOrderFilterStatus.Text = "";
            numOrderFilterMaxPrice.Value = 0;
            FindFilteredOrders();
        }

        private void txtFilterOrderId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Вкладка Сотрудники
        private void btnStaffSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("ViewStaff", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_position", cbStaffPositionSearch.Text != "" ? cbStaffPositionSearch.SelectedValue : (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@staffFIO", txtStaffFIOSearch.Text != "" ? txtStaffFIOSearch.Text : (object)DBNull.Value);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            conn.Open();
            adapter.Fill(table);
            dgvStaff.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtStaffFIOSearch.Text = "";
            cbStaffPositionSearch.Text = "";
            classAdo.DataGridBindOfProc("ViewStaff", dgvStaff);
        }

        private void btnAddNewStaff_Click(object sender, EventArgs e)
        {
            classAdo.StProcExec("AddStaff");
            SqlCommand cmd = classAdo.StProcExec("AddStaff");

            cmd.Parameters.AddWithValue("@lastName", txtAddStaffLastNane.Text);
            cmd.Parameters.AddWithValue("@firstName", txtAddStaffFirstName.Text);
            cmd.Parameters.AddWithValue("@id_position", cbAddStaffPosition.SelectedValue);

            SqlParameter ReturnValue = new SqlParameter();
            ReturnValue.Direction = ParameterDirection.ReturnValue;
            ReturnValue.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(ReturnValue);

            cmd.ExecuteNonQuery();

            int result = (int)ReturnValue.Value;

            if (result == 0) MessageBox.Show("Новый сотрудник успешно добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (result == -1) MessageBox.Show("Такой сотрудник уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            classAdo.DataGridBindOfProc("ViewStaff", dgvStaff);
        }

        private void rbReportProducts_CheckedChanged(object sender, EventArgs e)
        {
            LoadChart("RatingProducts", "Товар");
        }

        private void rbReportCategory_CheckedChanged(object sender, EventArgs e)
        {
            LoadChart("RatingCategories", "Категория");
        }

        private void rbReportMaterials_CheckedChanged(object sender, EventArgs e)
        {
            LoadChart("RatingMaterials", "Материал");
        }

        private void rbReportStaff_CheckedChanged(object sender, EventArgs e)
        {
            LoadChart("RatingStaff", "Сотрудник");
        }

        private void LoadChart(string procedureName, string columnName)
        {
            classAdo.StProcExec(procedureName);
            SqlCommand cmd = classAdo.StProcExec(procedureName);
            cmd.Parameters.Add("@dateFrom", SqlDbType.Date);
            cmd.Parameters.Add("@dateTo", SqlDbType.Date);

            cmd.Parameters["@dateFrom"].Value = dateReportFrom.Value;
            cmd.Parameters["@dateTo"].Value = dateReportTo.Value;


            SqlDataAdapter reportAdapter = new SqlDataAdapter();
            reportAdapter.SelectCommand = cmd;
            DataSet dsReport = new DataSet();
            reportAdapter.Fill(dsReport, "Report");
            dgvReport.DataSource = dsReport.Tables[0].DefaultView;

            chartReport.Series.Clear();
            chartReport.Titles.Clear();
            chartReport.ChartAreas.Clear();

            Series series = new Series("diagram")
            {
                XValueMember = columnName,
                YValueMembers = "Кол-во",
                ChartType = SeriesChartType.Column

            };

            chartReport.ChartAreas.Add(new ChartArea("MainArea"));
            chartReport.Series.Add(series);
            chartReport.DataSource = dsReport;
            chartReport.DataBind();

            decimal sumPrice = 0;
            int sumCount = 0;

            for (int i = 0; i < dgvReport.RowCount - 1; i++)
            {
                sumCount += int.Parse(dgvReport[dgvReport.ColumnCount - 2, i].Value.ToString());
                sumPrice += decimal.Parse(dgvReport[dgvReport.ColumnCount - 1, i].Value.ToString());
            }

            int lastRow = dgvReport.RowCount - 1;
            dgvReport[dgvReport.ColumnCount - 3, lastRow].Value = "Итого: ";
            dgvReport[dgvReport.ColumnCount - 2, lastRow].Value = sumCount.ToString();
            dgvReport[dgvReport.ColumnCount - 1, lastRow].Value = sumPrice.ToString();
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            string title = "";
            if (rbReportProducts.Checked)
            {
                title = "Рейтинг Товаров ";
            }
            if (rbReportCategory.Checked)
            {
                title = "Рейтинг категорий";
            }
            if (rbReportMaterials.Checked)
            {
                title = "Рейтинг материалов";
            }
            if (rbReportStaff.Checked)
            {
                title = "Рейтинг сотрудников";
            }
            title += $" за период с {dateReportFrom.Value.ToShortDateString()} по {dateReportTo.Value.ToShortDateString()}";

            Excel.Application Excelapp = new Excel.Application();
            Excel.Workbook Excelworkbook;
            Excel.Worksheet Excelworksheet;
            Excel.Range ExcelCells;

            Excelworkbook = Excelapp.Workbooks.Add(System.Reflection.Missing.Value);
            Excelworksheet = (Excel.Worksheet)Excelworkbook.Worksheets.get_Item(1);
            Excelapp.Cells[1, 1] = title;

            for (int i = 0; i < dgvReport.ColumnCount - 1; i++)
            {
                Excelapp.Cells[2, i + 1] = dgvReport.Columns[i].HeaderCell.Value;
            }
            for (int i = 0; i < dgvReport.Rows.Count; i++)
            {
                for (int j = 0; j < dgvReport.ColumnCount; j++)
                {
                    Excelapp.Cells[i + 3, j + 1] = dgvReport[j, i].Value;
                }
            }

            int istr = dgvReport.Rows.Count + 1;

            ExcelCells = Excelapp.Range[Excelworksheet.Columns[2], Excelworksheet.Cells[istr, dgvReport.ColumnCount]];
            ExcelCells.EntireColumn.AutoFit();
            ExcelCells = Excelapp.Range[Excelworksheet.Columns[1], Excelworksheet.Columns[dgvReport.ColumnCount - 1]];
            ExcelCells.HorizontalAlignment = Excel.Constants.xlLeft;
            ExcelCells = Excelapp.Range[Excelworksheet.Cells[2, 1], Excelworksheet.Cells[istr + 1, dgvReport.ColumnCount]];
            ExcelCells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            ExcelCells.Borders.Weight = Excel.XlBorderWeight.xlThin;
            Excelapp.Visible = true;
            Excelapp.UserControl = true;

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)Excelworksheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(5, 180, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            int col = dgvReport.ColumnCount - 2;
            string liter = "";

            switch (col)
            {
                case 1:
                    liter = "B";
                    break;
                case 2:
                    liter = "C";
                    break;
                case 3:
                    liter = "D";
                    break;
                case 4:
                    liter = "E";
                    break;
                case 5:
                    liter = "F";
                    break;
                case 6:
                    liter = "G";
                    break;
                case 7:
                    liter = "H";
                    break;
                case 8:
                    liter = "I";
                    break;
                case 9:
                    liter = "J";
                    break;
                case 10:
                    liter = "K";
                    break;
                default:
                    break;
            }

            chartRange = Excelworksheet.get_Range(liter + "3", liter + (istr).ToString());

            chartPage.SetSourceData(chartRange, Type.Missing);
            chartPage.ChartType = Excel.XlChartType.xl3DColumn;

            chartPage.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowPercent, true, true, true, false, false, false, true);
        }
    }
}
