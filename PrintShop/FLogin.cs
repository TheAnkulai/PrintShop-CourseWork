using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PrintShop
{
    public partial class FLogin : Form
    {
        ClassAdo classAdo = new ClassAdo();
        public FLogin()
        {
            InitializeComponent();
        }


        private void label3_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FRegistration fRegistration = new FRegistration();
            fRegistration.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtLogin.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Заполните обязательные поля!");
            }
            else
            {

                classAdo.StProcExec("GetUsersByLoginAndPassw");
                SqlCommand cmd = classAdo.StProcExec("GetUsersByLoginAndPassw");
                cmd.Parameters.AddWithValue("@userName", txtLogin.Text);
                cmd.Parameters.AddWithValue("@passw", txtPassword.Text);

                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Table");

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Неверное имя пользователся или пароль!");
                }
                else
                {
                    int userId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    string FIO = ds.Tables[0].Rows[0][1] + " " + ds.Tables[0].Rows[0][2];
                    int access_level = int.Parse(ds.Tables[0].Rows[0][7].ToString());
                    MessageBox.Show($"{FIO}, добро пожаловать в систему!");

                    FMain fMain = new FMain(access_level, userId);

                    fMain.lblUser.Text = $"{FIO} ID = {userId.ToString()}";

                    fMain.ShowDialog();
                    txtLogin.Text = "";
                    txtPassword.Text = "";
                }
            }
        }
    }
}
