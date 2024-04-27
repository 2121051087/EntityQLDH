using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }
        #region Xu li UI
        private void txt_account_Click(object sender, EventArgs e)
        {
            txt_account.BackColor = Color.White;
            panel_account.BackColor = Color.White;
            panel_password.BackColor = SystemColors.Control;
            txt_password.BackColor = SystemColors.Control;

        }

        private void txt_password_Click(object sender, EventArgs e)
        {
            txt_password.BackColor = Color.White;
            panel_password.BackColor = Color.White;
            panel_account.BackColor = SystemColors.Control;
            txt_account.BackColor = SystemColors.Control;
        }
        private void pic_password_MouseUp(object sender, MouseEventArgs e)
        {
            txt_password.UseSystemPasswordChar = true;
        }

        private void pic_password_MouseDown(object sender, MouseEventArgs e)
        {
            txt_password.UseSystemPasswordChar = false;
        }
        #endregion
        // dieu huong form 
        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_SignUp form_SignUp = new Form_SignUp();
            form_SignUp.ShowDialog();

            this.Show();
            form_SignUp.FormClosed += (s, args) => this.Show();
        }

        private void btn_ForgetPassWord_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ForgetPassWord form_ForgetPassWord = new Form_ForgetPassWord();
            form_ForgetPassWord.ShowDialog();

            this.Show();
            form_ForgetPassWord.FormClosed += (s, args) => this.Show();
        }

        // -----------xu li login-----------------
       

        void checkTaiKhoan()
        {
          QLDH_Data db = new QLDH_Data();
            var user = db.TaiKhoans.Where(s => s.TenTaiKhoan == txt_account.Text && s.MatKhau == txt_password.Text).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form_Home form_Home = new Form_Home();
                form_Home.ShowDialog();
                this.Show();
                form_Home.FormClosed += (s, args) => this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
        }   

        private void btn_Login_Click(object sender, EventArgs e)
        {
          checkTaiKhoan();
        }

    }
}
