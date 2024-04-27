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
    public partial class Form_Customer : Form
    {
        public Form_Customer()
        {
            InitializeComponent();
           
        }
        #region Xu ly UI
        private void txt_idKH_Click(object sender, EventArgs e)
        {

            txt_idKH.BackColor = Color.White;
            panel_idKH.BackColor = Color.White;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_NgaySinh.BackColor = SystemColors.Control;
            txt_NgaySinh.BackColor = SystemColors.Control;
            panel_Phone.BackColor = SystemColors.Control;
            txt_Phone.BackColor = SystemColors.Control;

        }

        private void txt_Name_Click(object sender, EventArgs e)
        {
            txt_idKH.BackColor = SystemColors.Control;
            panel_idKH.BackColor = SystemColors.Control;
            panel_Name.BackColor = Color.White;
            txt_Name.BackColor = Color.White;
            panel_NgaySinh.BackColor = SystemColors.Control;
            txt_NgaySinh.BackColor = SystemColors.Control;
            panel_Phone.BackColor = SystemColors.Control;
            txt_Phone.BackColor = SystemColors.Control;
        }

        private void txt_NgaySinh_Click(object sender, EventArgs e)
        {
            txt_idKH.BackColor = SystemColors.Control;
            panel_idKH.BackColor = SystemColors.Control;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_NgaySinh.BackColor = Color.White;
            txt_NgaySinh.BackColor = Color.White;
            panel_Phone.BackColor = SystemColors.Control;
            txt_Phone.BackColor = SystemColors.Control;
        }

        private void txt_Phone_Click(object sender, EventArgs e)
        {
            txt_idKH.BackColor = SystemColors.Control;
            panel_idKH.BackColor = SystemColors.Control;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_NgaySinh.BackColor = SystemColors.Control;
            txt_NgaySinh.BackColor = SystemColors.Control;
            panel_Phone.BackColor = Color.White;
            txt_Phone.BackColor = Color.White;
        }
       
       
        #endregion

        QLDH_Data db = new QLDH_Data();

        #region method
        void loadDataKhachHang()
        {   
          
            var result = from c in db.KhachHangs
                         select new
                         {
                             c.idKH,
                             c.Name,
                             c.NgaySinh,
                             c.Phone,
                            
                            
                         };
            dataGridView2.DataSource = result.ToList();
        }

        void AddKhachHang()
        {
            KhachHang kh = new KhachHang() { 
                idKH = txt_idKH.Text,
                Name = txt_Name.Text,
                NgaySinh = txt_NgaySinh.Text,
                Phone = txt_Phone.Text,
            };
            db.KhachHangs.Add(kh);
            db.SaveChanges();
            loadDataKhachHang();
              
            
        }
        void DeleteKhachHang()
        {
            var id = txt_idKH.Text;
            KhachHang kh = db.KhachHangs.Where(p => p.idKH == id).SingleOrDefault();
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
            loadDataKhachHang();
        }
        void UpdateKhachHang()
        {
            var id = txt_idKH.Text;
            KhachHang kh = db.KhachHangs.Where(p => p.idKH == id).SingleOrDefault();
            kh.Name = txt_Name.Text;
            kh.NgaySinh = txt_NgaySinh.Text;
            kh.Phone = txt_Phone.Text;
            db.SaveChanges();
            loadDataKhachHang();
           
        }
        void ClearTextBox()
        {
            txt_idKH.Text = "";
            txt_Name.Text = "";
            txt_NgaySinh.Text = "";
            txt_Phone.Text = "";
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDataKhachHang();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
          try
            {
                AddKhachHang();
                MessageBox.Show("Thêm khách hàng mới thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm khách hàng mới" + ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
           try
            {
                UpdateKhachHang();
                MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật thông tin khách hàng"+ ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteKhachHang();
                MessageBox.Show("Xóa khách hàng thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa khách hàng" + ex.Message);
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e) // hien thi lai thong tin len textbox
        {
            txt_idKH.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txt_Name.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txt_NgaySinh.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_Phone.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
