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
    public partial class FRegistration : Form
    {
        ClassAdo classAdo = new ClassAdo();
        public FRegistration()
        {
            InitializeComponent();
        }

        public int Validation(GroupBox groupBox)
        {
            int cError = 0;

            foreach (Control cnt in groupBox.Controls)
            {
                TextBox tb = cnt as TextBox;
                if (tb != null)
                {
                    if (tb.Text == "")
                    {
                        tb.BackColor = Color.Red;
                        cError++;
                    }
                    else
                    {
                        tb.BackColor = Color.White;
                    }
                }

            }
            return cError;
        }


        private void FRegistration_Load(object sender, EventArgs e)
        {
            lblValidPassword.Text = "";
            btnRegistrate.Enabled = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtPassword.Text != txtPassword2.Text)
            {
                lblValidPassword.Text = "Пароли не совпадают!";
                btnRegistrate.Enabled = false;
            }
            else
            {
                lblValidPassword.Text = "Пароли совпадают!";
                btnRegistrate.Enabled = true;
            }
        }

        private void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword2.Text == "" || txtPassword.Text != txtPassword2.Text)
            {
                lblValidPassword.Text = "Пароли не совпадают!";
                btnRegistrate.Enabled = false;
            }
            else
            {
                lblValidPassword.Text = "Пароли совпадают!";
                btnRegistrate.Enabled = true;
            }
        }

        private void bRegistrate_Click(object sender, EventArgs e)
        {
            if (Validation(groupBox1) > 0)
            {
                MessageBox.Show("Заполните обязательные поля!");
            }
            else
            {
                string sql = $"SELECT * FROM Users WHERE login = '{txtLogin.Text}'";
                DataSet ds = classAdo.GetDataSet(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегистрирован!");
                }
                else
                {
                    SqlCommand cmd = classAdo.StProcExec("AddUser");

                    cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@passw", txtPassword.Text);
                    cmd.Parameters.Add("@id_user", SqlDbType.Int);

                    cmd.Parameters["@id_user"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    int userId = Convert.ToInt32(cmd.Parameters["@id_user"].Value);
                    MessageBox.Show($"Пользователь {txtLastName.Text} {txtFirstName.Text} id={userId.ToString()} успешно создан!");
                }
            }
        }
    }
}

