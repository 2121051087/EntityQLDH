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
    public partial class Form_Order : Form
    {
        public Form_Order()
        {
            InitializeComponent();
        }


        #region Xu ly UI
        private void txt_idDH_Click(object sender, EventArgs e)
        {
            txt_idDH.BackColor = Color.White;
            panel_idDH.BackColor = Color.White;
            panel_idKH.BackColor = SystemColors.Control;
            txt_idKH.BackColor = SystemColors.Control;
            panel_idSP.BackColor = SystemColors.Control;
            txt_idSP.BackColor = SystemColors.Control;
            panel_SoLuong.BackColor = SystemColors.Control;
            txt_SoLuong.BackColor = SystemColors.Control;
            panel_Gia.BackColor = SystemColors.Control;
            txt_Gia.BackColor = SystemColors.Control;
        }

        private void txt_idSP_Click(object sender, EventArgs e)
        {
            txt_idDH.BackColor = SystemColors.Control;
            panel_idDH.BackColor = SystemColors.Control;
            panel_idKH.BackColor = SystemColors.Control;
            txt_idKH.BackColor = SystemColors.Control;
            panel_idSP.BackColor = Color.White;
            txt_idSP.BackColor = Color.White;
            panel_SoLuong.BackColor = SystemColors.Control;
            txt_SoLuong.BackColor = SystemColors.Control;
            panel_Gia.BackColor = SystemColors.Control;
            txt_Gia.BackColor = SystemColors.Control;

        }

        private void txt_idKH_Click(object sender, EventArgs e)
        {
            txt_idDH.BackColor = SystemColors.Control;
            panel_idDH.BackColor = SystemColors.Control;
            panel_idKH.BackColor = Color.White;
            txt_idKH.BackColor = Color.White;
            panel_idSP.BackColor = SystemColors.Control;
            txt_idSP.BackColor = SystemColors.Control;
            panel_SoLuong.BackColor = SystemColors.Control;
            txt_SoLuong.BackColor = SystemColors.Control;
            panel_Gia.BackColor = SystemColors.Control;
            txt_Gia.BackColor = SystemColors.Control;
        }

        private void txt_SoLuong_Click(object sender, EventArgs e)
        {
            txt_idDH.BackColor = SystemColors.Control;
            panel_idDH.BackColor = SystemColors.Control;
            panel_idKH.BackColor = SystemColors.Control;
            txt_idKH.BackColor = SystemColors.Control;
            panel_idSP.BackColor = SystemColors.Control;
            txt_idSP.BackColor = SystemColors.Control;
            panel_SoLuong.BackColor = Color.White;
            txt_SoLuong.BackColor = Color.White;
            panel_Gia.BackColor = SystemColors.Control;
            txt_Gia.BackColor = SystemColors.Control;
        }

        private void txt_Gia_Click(object sender, EventArgs e)
        {

            txt_idDH.BackColor = SystemColors.Control;
            panel_idDH.BackColor = SystemColors.Control;
            panel_idKH.BackColor = SystemColors.Control;
            txt_idKH.BackColor = SystemColors.Control;
            panel_idSP.BackColor = SystemColors.Control;
            txt_idSP.BackColor = SystemColors.Control;
            panel_SoLuong.BackColor = SystemColors.Control;
            txt_SoLuong.BackColor = SystemColors.Control;
            panel_Gia.BackColor = Color.White;
            txt_Gia.BackColor = Color.White;
        }
        #endregion


        QLDH_Data db = new QLDH_Data();

        #region Method 
        void loadDataDonHang()
        {
            var result = from c in db.DonHangs
                         select new
                         {
                             idDH = c.idDH,
                             idSP = c.idSP,
                             idKH = c.idKH,
                             SoLuong = c.SoLuong,
                             Gia = c.Gia
                         };
            dataGridView1.DataSource = result.ToList();

        }
        void AddDonHang()
        {
            DonHang dh = new DonHang()
            {
                idDH = txt_idDH.Text,
                idKH = txt_idKH.Text,
                idSP = txt_idSP.Text,
                SoLuong = int.Parse(txt_SoLuong.Text),
                Gia = int.Parse(txt_Gia.Text)
            };
            db.DonHangs.Add(dh);
            db.SaveChanges();
            loadDataDonHang();
        }
        void UpdateDonHang()
        {
           
            if (!string.IsNullOrEmpty(txt_idDH.Text))
            {
           
                DonHang dh = db.DonHangs.SingleOrDefault(p => p.idDH == txt_idDH.Text);

               
                if (dh != null)
                {
                   
                    dh.idKH = txt_idKH.Text;
                    dh.idSP = txt_idSP.Text;

                    int soLuong, gia;
                    if (int.TryParse(txt_SoLuong.Text, out soLuong) && int.TryParse(txt_Gia.Text, out gia))
                    {
                        dh.SoLuong = soLuong;
                        dh.Gia = gia;

                      
                        db.SaveChanges();

                   
                        loadDataDonHang();
                    }
                    else
                    {
                        MessageBox.Show("Số lượng và giá phải là số nguyên");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng có ID này");
                }
            }
            else
            {
                MessageBox.Show("ID Đơn hàng không được để trống");
            }
        }

        void DeleteDonHang()
        {
            var id = txt_idDH.Text;
            DonHang dh = db.DonHangs.Where(p => p.idDH == id).SingleOrDefault();
            if (dh != null)
            {
                db.DonHangs.Remove(dh);
                db.SaveChanges();
                loadDataDonHang();
            }
        }
        void ClearTextBox()
        {
            txt_idDH.Text = ""; 
            txt_idKH.Text = "";
            txt_idSP.Text = "";
            txt_SoLuong.Text = "";
            txt_Gia.Text = "";

        }
        #endregion

        private void Form_Oder_Load(object sender, EventArgs e)
        {
            loadDataDonHang();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                AddDonHang();
                MessageBox.Show("Thêm đơn hàng thành công");
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
                UpdateDonHang();
                MessageBox.Show("Cập nhật đơn hàng thành công");
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
                DeleteDonHang();
                MessageBox.Show("Xóa đơn hàng thành công");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           txt_idDH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_idKH.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_idSP.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_SoLuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_Gia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }
    }
}
