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
    public partial class Form_Supplier : Form
    {
        public Form_Supplier()
        {
            InitializeComponent();
        }
        #region Xu ly UI
        private void txt_idNCC_Click(object sender, EventArgs e)
        {
            txt_idNCC.BackColor = Color.White;
            panel_idNCC.BackColor = Color.White;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_Phone.BackColor = SystemColors.Control;
            txt_Phone.BackColor = SystemColors.Control;
            panel_DiaChi.BackColor = SystemColors.Control;
            txt_DiaChi.BackColor = SystemColors.Control;
        }

        private void txt_Name_Click(object sender, EventArgs e)
        {
            txt_Name.BackColor = Color.White;
            panel_Name.BackColor = Color.White;
            panel_idNCC.BackColor = SystemColors.Control;
            txt_idNCC.BackColor = SystemColors.Control;
            panel_Phone.BackColor = SystemColors.Control;
            txt_Phone.BackColor = SystemColors.Control;
            panel_DiaChi.BackColor = SystemColors.Control;
            txt_DiaChi.BackColor = SystemColors.Control;

        }

        private void txt_Phone_Click(object sender, EventArgs e)
        {
            txt_Phone.BackColor = Color.White;
            panel_Phone.BackColor = Color.White;
            panel_idNCC.BackColor = SystemColors.Control;
            txt_idNCC.BackColor = SystemColors.Control;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_DiaChi.BackColor = SystemColors.Control;
            txt_DiaChi.BackColor = SystemColors.Control;
        }

        private void txt_DiaChi_Click(object sender, EventArgs e)
        {
            txt_DiaChi.BackColor = Color.White;
            panel_DiaChi.BackColor = Color.White;
            panel_idNCC.BackColor = SystemColors.Control;
            txt_idNCC.BackColor = SystemColors.Control;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_Phone.BackColor = SystemColors.Control;
            txt_Phone.BackColor = SystemColors.Control;

        }
        #endregion
        QLDH_Data db = new QLDH_Data();
        #region Method
        void loadDataNhaCungCap()
        {
            var result = from ncc in db.NhaCungCaps
                         select new
                         {
                             ID_NCC = ncc.idNCC,
                             Name = ncc.Name,
                             Phone = ncc.Phone,
                             DiaChi = ncc.DiaChi
                         };
            dataGridView1.DataSource = result.ToList();
        }
        void AddNCC()
        {
            NhaCungCap ncc = new NhaCungCap();
            ncc.idNCC = txt_idNCC.Text;
            ncc.Name = txt_Name.Text;
            ncc.Phone = txt_Phone.Text;
            ncc.DiaChi = txt_DiaChi.Text;
            db.NhaCungCaps.Add(ncc);
            db.SaveChanges();
            loadDataNhaCungCap();
        }
        void EditNCC()
        {
            string idNCC = txt_idNCC.Text;
            NhaCungCap ncc = db.NhaCungCaps.Where(s => s.idNCC == idNCC).Single();
            ncc.Name = txt_Name.Text;
            ncc.Phone = txt_Phone.Text;
            ncc.DiaChi = txt_DiaChi.Text;
            db.SaveChanges();
            loadDataNhaCungCap();
        }
        void DeleteNCC()
        {
            string idNCC = txt_idNCC.Text;
            NhaCungCap ncc = db.NhaCungCaps.Where(s => s.idNCC == idNCC).Single();
            db.NhaCungCaps.Remove(ncc);
            db.SaveChanges();
            loadDataNhaCungCap();
        }
        void ClearTextBox()
        {
            txt_idNCC.Text = "";
            txt_Name.Text = "";
            txt_Phone.Text = "";
            txt_DiaChi.Text = "";
        }

        #endregion
        private void Form_Supplier_Load(object sender, EventArgs e)
        {
            loadDataNhaCungCap();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void dataGridView1_Click(object sender, EventArgs e) // hien thi lai thong tin len textbox
        {
            txt_idNCC.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_Phone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_DiaChi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                AddNCC();
                MessageBox.Show("Thêm Nhà cung cấp thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                EditNCC();
                MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteNCC();
                MessageBox.Show("Xóa nhà cung cấp thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
