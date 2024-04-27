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
    public partial class Form_Product : Form
    {
        public Form_Product()
        {
            InitializeComponent();
        }
        #region Xu ly UI
        private void txt_idSP_Click(object sender, EventArgs e)
        {
            txt_idSP.BackColor = Color.White;
            panel_idSP.BackColor = Color.White;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_MoTa.BackColor = SystemColors.Control;
            txt_Mota.BackColor = SystemColors.Control;
            panel_Gia.BackColor = SystemColors.Control;
            txt_Gia.BackColor = SystemColors.Control;
            panel_idNCC.BackColor = SystemColors.Control;
            txt_idNCC.BackColor = SystemColors.Control;

        }

        private void txt_idNCC_Click(object sender, EventArgs e)
        {
            txt_idSP.BackColor = SystemColors.Control;
            panel_idSP.BackColor = SystemColors.Control;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_MoTa.BackColor = SystemColors.Control;
            txt_Mota.BackColor = SystemColors.Control;
            panel_Gia.BackColor = SystemColors.Control;
            txt_Gia.BackColor = SystemColors.Control;
            panel_idNCC.BackColor = Color.White;
            txt_idNCC.BackColor = Color.White;
        }

        private void txt_Name_Click(object sender, EventArgs e)
        {
            txt_idSP.BackColor = SystemColors.Control;
            panel_idSP.BackColor = SystemColors.Control;
            panel_Name.BackColor = Color.White;
            txt_Name.BackColor = Color.White;
            panel_MoTa.BackColor = SystemColors.Control;
            txt_Mota.BackColor = SystemColors.Control;
            panel_Gia.BackColor = SystemColors.Control;
            txt_Gia.BackColor = SystemColors.Control;
            panel_idNCC.BackColor = SystemColors.Control;
            txt_idNCC.BackColor = SystemColors.Control;
        }

        private void txt_Mota_Click(object sender, EventArgs e)
        {
            txt_idSP.BackColor = SystemColors.Control;
            panel_idSP.BackColor = SystemColors.Control;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_MoTa.BackColor = Color.White;
            txt_Mota.BackColor = Color.White;
            panel_Gia.BackColor = SystemColors.Control;
            txt_Gia.BackColor = SystemColors.Control;
            panel_idNCC.BackColor = SystemColors.Control;
            txt_idNCC.BackColor = SystemColors.Control;

        }

        private void txt_Gia_Click(object sender, EventArgs e)
        {
            txt_idSP.BackColor = SystemColors.Control;
            panel_idSP.BackColor = SystemColors.Control;
            panel_Name.BackColor = SystemColors.Control;
            txt_Name.BackColor = SystemColors.Control;
            panel_MoTa.BackColor = SystemColors.Control;
            txt_Mota.BackColor = SystemColors.Control;
            panel_Gia.BackColor = Color.White;
            txt_Gia.BackColor = Color.White;
            panel_idNCC.BackColor = SystemColors.Control;
            txt_idNCC.BackColor = SystemColors.Control;
        }
        #endregion
        QLDH_Data db = new QLDH_Data();

        #region Method 
        void loadDataSanPham()
        {
            var data = db.SanPhams.Select(s => new
            {
                idSP = s.idSP,
                idNCC = s.idNCC,
                Name = s.Name,
                Mota = s.Mota,
                Gia = s.Gia
            });
            dataGridView1.DataSource = data.ToList();
        }

        void AddSanPham()
        {
            SanPham sp = new SanPham();
            sp.idSP = txt_idSP.Text;
            sp.idNCC = txt_idNCC.Text;
            sp.Name = txt_Name.Text;
            sp.Mota = txt_Mota.Text;
            sp.Gia =  int.Parse(txt_Gia.Text);
            db.SanPhams.Add(sp);
            db.SaveChanges();
            loadDataSanPham();
        }
        void UpdateSanPham()
        {
            SanPham sp = db.SanPhams.Where(s => s.idSP == txt_idSP.Text).FirstOrDefault();
            sp.idNCC = txt_idNCC.Text;
            sp.Name = txt_Name.Text;
            sp.Mota = txt_Mota.Text;
            sp.Gia = int.Parse(txt_Gia.Text);
            db.SaveChanges();
            loadDataSanPham();
        }
        void DeleteSanPham()
        {
            SanPham sp = db.SanPhams.Where(s => s.idSP == txt_idSP.Text).FirstOrDefault();
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            loadDataSanPham();
        }
        void ClearTextBox()
        {
            txt_idSP.Text = "";
            txt_idNCC.Text = "";
            txt_Name.Text = "";
            txt_Mota.Text = "";
            txt_Gia.Text = "";
        }
        #endregion

        private void btn_Them_Click(object sender, EventArgs e)
        {
           try
            {
                AddSanPham();
                MessageBox.Show("Thêm sản phẩm thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSanPham();
                MessageBox.Show("Cập nhật sản phẩm thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteSanPham();
                MessageBox.Show("Xóa sản phẩm thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_Product_Load(object sender, EventArgs e)
        {
           loadDataSanPham();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txt_idSP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_idNCC.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_Mota.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_Gia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
