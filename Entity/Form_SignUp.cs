using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity
{
    public partial class Form_SignUp : Form
    {
        public Form_SignUp()
        {
            InitializeComponent();
            radioButton_agree.CheckedChanged += radioButton_agree_CheckedChanged;

            btn_SignUp.Enabled = false;
            btn_SignUp.BackColor = SystemColors.Control;
        }
        #region Xu ly UI
        private void txt_UserName_Click(object sender, EventArgs e)
        {
            txt_UserName.BackColor = Color.White;
            panel_userName.BackColor = Color.White;
            panel_password.BackColor = SystemColors.Control;
            txt_password.BackColor = SystemColors.Control;
            panel_reEnter.BackColor = SystemColors.Control;
            txt_Re_Enter_Password.BackColor = SystemColors.Control;
            panel_Email.BackColor = SystemColors.Control;
            txt_Email.BackColor = SystemColors.Control;
        }

        private void txt_password_Click(object sender, EventArgs e)
        {
            txt_UserName.BackColor = SystemColors.Control;
            panel_userName.BackColor = SystemColors.Control;
            panel_password.BackColor = Color.White;
            txt_password.BackColor = Color.White;
            panel_reEnter.BackColor = SystemColors.Control;
            txt_Re_Enter_Password.BackColor = SystemColors.Control;
            panel_Email.BackColor = SystemColors.Control;
            txt_Email.BackColor = SystemColors.Control;
        }

        private void txt_Re_Enter_Password_Click(object sender, EventArgs e)
        {
            txt_UserName.BackColor = SystemColors.Control;
            panel_userName.BackColor = SystemColors.Control;
            panel_password.BackColor = SystemColors.Control;
            txt_password.BackColor = SystemColors.Control;
            panel_reEnter.BackColor = Color.White;
            txt_Re_Enter_Password.BackColor = Color.White;
            panel_Email.BackColor = SystemColors.Control;
            txt_Email.BackColor = SystemColors.Control;
        }

        private void txt_Email_Click(object sender, EventArgs e)
        {
            txt_UserName.BackColor = SystemColors.Control;
            panel_userName.BackColor = SystemColors.Control;
            panel_password.BackColor = SystemColors.Control;
            txt_password.BackColor = SystemColors.Control;
            panel_reEnter.BackColor = SystemColors.Control;
            txt_Re_Enter_Password.BackColor = SystemColors.Control;
            panel_Email.BackColor = Color.White;
            txt_Email.BackColor = Color.White;
        }
      

        private void radioButton_agree_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_agree.Checked)
            {
                btn_SignUp.Enabled = true;
                btn_SignUp.BackColor = Color.FromArgb(33, 121, 184);
            }
            else
            {
                btn_SignUp.Enabled = false;
                btn_SignUp.BackColor = Color.Black;
            }
        }
        #endregion


        QLDH_Data db = new QLDH_Data();



        #region Xu ly logic 
        public bool checkAccount(string ac)// check mat khau va tai khoan 
        {
            return Regex.IsMatch(ac, @"^[a-zA-Z0-9]{6,24}$");
        }
        public bool checkEmail(string email)// check email
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9]{3,20}@gmail.com(.vn|)$");
        }
        void AddAccount()
        {
            TaiKhoan tk = new TaiKhoan() {
            TenTaiKhoan = txt_UserName.Text,
            MatKhau = txt_password.Text,
            Email = txt_Email.Text,
                     };
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
            

        }
    

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            QLDH_Data db = new QLDH_Data();

            if (txt_UserName.Text == "" || txt_password.Text == "" || txt_Re_Enter_Password.Text == "" || txt_Email.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
           //if(!checkAccount(txt_UserName.Text)) { MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 kí tự , với các  ký tự chữ và số , chữc hoa và chữ thường "); return; }
            if(!checkAccount(txt_password.Text)) { MessageBox.Show("Vui lòng nhập mật khẩu dài 6-24 kí tự , với các  ký tự chữ và số , chữc hoa và chữ thường "); return; }
            if(txt_password.Text != txt_Re_Enter_Password.Text) { MessageBox.Show("Mật khẩu không trùng khớp !"); return; }
            
                if ((!db.TaiKhoans.Any(em => em.Email == txt_Email.Text)))
                {

                    if ((!db.TaiKhoans.Any(tk => tk.TenTaiKhoan == txt_UserName.Text)))
                    {
                        AddAccount();
                        MessageBox.Show("Đăng ký thành công");
                        this.Hide();
                        Form_Login form_Login = new Form_Login();
                        form_Login.ShowDialog();
                        this.Show();
                        form_Login.FormClosed += (s, args) => this.Show();
                    }
                    else
                    {
                        MessageBox.Show("tên tài khoản đã tồn tại , vui lòng  đăng kí tên khác ");
                    }
                }
                else
                {
                    MessageBox.Show("Email đã được đăng kí , vui lòng  đăng kí email khác ");
                }
            }
             
        }
        #endregion
}

