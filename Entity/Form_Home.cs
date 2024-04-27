using Entity.Properties;
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
    public partial class Form_Home : Form
    {
        public Form_Home()
        {
            InitializeComponent();
         

        }
        #region Xu li UI 
        private bool check;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check)
            {
                panel1.Width += 10;
                if (panel1.Size == panel1.MaximumSize)
                {
                    pic_Menu.Left += 100;
                    timer1.Stop();
                    check = false;
                    pic_Menu.Image = Resources.ic_arrow;
                }
            }
            else
            {
                panel1.Width -= 10;
                if (panel1.Size == panel1.MinimumSize)
                {
                    pic_Menu.Left = 15;
                    timer1.Stop();
                    check = true;
                    pic_Menu.Image = Resources.ic_Menu;
                }
            }
        }

        private void pic_Menu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void ShowAboutInfo()
        {
            if (panel4.Visible == false)
            {
                panel4.Visible = true;
            }
            else
            {
                panel4.Visible = false;
            }
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            ShowAboutInfo();
        }
        #endregion


        // xử lí điều hướng form 
        private void btn_DonHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Order form_Order = new Form_Order();
            form_Order.ShowDialog();

            this.Show();
            form_Order.FormClosed += (s, args) => this.Show();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Customer form_Customer = new Form_Customer();
            form_Customer.ShowDialog();

            this.Show();
            form_Customer.FormClosed += (s, args) => this.Show();
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Product form_Product = new Form_Product();
            form_Product.ShowDialog();

            this.Show();
            form_Product.FormClosed += (s, args) => this.Show();
        }

        private void btn_NhaCungCap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Supplier form_Supplier = new Form_Supplier();
            form_Supplier.ShowDialog();

            this.Show();
            form_Supplier.FormClosed += (s, args) => this.Show();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login form_Login = new Form_Login();
            form_Login.ShowDialog();

            this.Show();
            form_Login.FormClosed += (s, args) => this.Show();

        }
    }
}
