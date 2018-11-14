using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using System.Data.SqlClient;
using DTO;

namespace project_QLNhaTro
{
    public partial class frmDichVu : Form
    {
        BUS_DichVu busDichVu = new BUS_DichVu();
        public frmDichVu()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void loadDachSachDV()
        {
            try
            {
                busDichVu = new BUS_DichVu();
                //load danh sách dịch vụ lên dgv
                this.dgvDichVu.DataSource = busDichVu.getTaiKhoan().Tables[0];
            }
            catch (SqlException error)  //bắt lỗi sql
            {
                MessageBox.Show("Không truy cập dữ liệu CTDV được!\rLỗi: " + error.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)    //bắt các lỗi khác
            {
                MessageBox.Show("Không truy cập dữ liệu CTDV được!\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int r = dgvDichVu.CurrentCell.RowIndex;
            // lay row hien tai
            //chuyen gia tri len form
            tbxMaDV.Text = dgvDichVu.Rows[r].Cells[0].Value.ToString();
            tbxTenDV.Text = dgvDichVu.Rows[r].Cells[1].Value.ToString();
            tbxGiaDV.Text = dgvDichVu.Rows[r].Cells[2].Value.ToString();
        }
        private void frmDichVu_Load(object sender, EventArgs e)
        {
            loadDachSachDV();
        }

      

        private void dgvDichVu_Click(object sender, EventArgs e)
        {
            int r = dgvDichVu.CurrentCell.RowIndex;
            // lay row hien tai
            //chuyen gia tri len form
            tbxMaDV.Text = dgvDichVu.Rows[r].Cells[0].Value.ToString();
            tbxTenDV.Text = dgvDichVu.Rows[r].Cells[1].Value.ToString();
            tbxGiaDV.Text = dgvDichVu.Rows[r].Cells[2].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có muốn thêm dịch vụ này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                if (tbxMaDV.Text != "" && tbxTenDV.Text != "" && tbxGiaDV.Text !="")
                {
                    string error = "";
                    DTO_DichVu dv = new DTO_DichVu(tbxMaDV.Text, tbxTenDV.Text, decimal.Parse(this.tbxGiaDV.Text.ToString()));
                    try
                    {
                        //Thêm mới NV
                        if (busDichVu.themDichVu(ref error, dv))
                        {   //nếu thêm thành công thì thông báo
                            MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDachSachDV();//load lại DSNV
                            // xóa trắng textbox và reset datetimepicker
                           
                        }
                        else
                        {
                            //Lỗi từ sqlserver
                            MessageBox.Show("Lỗi: " + error, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception er)//bắt các lỗi khác
                    {
                        MessageBox.Show("Thêm mới dịch vụ vào dữ liệu không thành công.\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
            }
        }
    }
}
