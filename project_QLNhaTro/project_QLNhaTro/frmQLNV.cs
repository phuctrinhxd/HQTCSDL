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
using BusinessLayer;
using DTO;

namespace project_QLNhaTro
{
    public partial class frmQLNV : Form
    {
        BUS_TaiKhoan busTaiKhoan = new BUS_TaiKhoan();
        public frmQLNV()
        {
            InitializeComponent();
        }
        public void loadDachSachNV()
        {
            try
            {
                busTaiKhoan = new BUS_TaiKhoan();
                //load danh sách dịch vụ lên dgv
                this.dgvTaiKhoan.DataSource = busTaiKhoan.getTaiKhoan().Tables[0];
            }
            catch (SqlException error)  //bắt lỗi sql
            {
                MessageBox.Show("Không truy cập dữ liệu CTDV được!\rLỗi: " + error.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)    //bắt các lỗi khác
            {
                MessageBox.Show("Không truy cập dữ liệu CTDV được!\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int r = dgvTaiKhoan.CurrentCell.RowIndex;
            // lay row hien tai
            //chuyen gia tri len form
            tbxTenDangNhap.Text = dgvTaiKhoan.Rows[r].Cells[0].Value.ToString();
            tbxMatKhau.Text = dgvTaiKhoan.Rows[r].Cells[1].Value.ToString();
            tbxHoTen.Text = dgvTaiKhoan.Rows[r].Cells[2].Value.ToString();
            tbxSoDT.Text = dgvTaiKhoan.Rows[r].Cells[3].Value.ToString();
            tbxMaQuyen.Text = dgvTaiKhoan.Rows[r].Cells[4].Value.ToString();
        }
        private void frmQLNV_Load(object sender, EventArgs e)
        {
            loadDachSachNV();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            loadDachSachNV();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có muốn thêm nhân viên này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                if (tbxTenDangNhap.Text != "" && tbxMatKhau.Text != "" && tbxHoTen.Text != "" && tbxSoDT.Text != "" && tbxMaQuyen.Text != "")
                {
                    string error = "";
                    DTO_TaiKhoan tk = new DTO_TaiKhoan(tbxTenDangNhap.Text, tbxMatKhau.Text, tbxHoTen.Text, tbxSoDT.Text, tbxMaQuyen.Text);
                    try
                    {
                        //Thêm mới NV
                        if (busTaiKhoan.themtaikhoan(ref error, tk))
                        {   //nếu thêm thành công thì thông báo
                            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDachSachNV();//load lại DSNV
                            // xóa trắng textbox và reset datetimepicker
                            this.tbxTenDangNhap.ResetText();
                            this.tbxMatKhau.ResetText();
                            this.tbxHoTen.ResetText();
                            this.tbxSoDT.ResetText();
                            this.tbxMaQuyen.ResetText();
                        }
                        else
                        {
                            //Lỗi từ sqlserver
                            MessageBox.Show("Lỗi: " + error, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception er)//bắt các lỗi khác
                    {
                        MessageBox.Show("Thêm mới nhân viên vào dữ liệu không thành công.\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string error = "";
            DTO_TaiKhoan tk = new DTO_TaiKhoan(tbxTenDangNhap.Text, tbxMatKhau.Text, tbxHoTen.Text, tbxSoDT.Text, tbxMaQuyen.Text);
            //xác nhận có muốn sửa ko
            DialogResult tl = MessageBox.Show("Bạn có muốn sửa thông tin nhân viên này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                if (tbxTenDangNhap.Text != "" && tbxMatKhau.Text != "" && tbxHoTen.Text != "" && tbxSoDT.Text != "" && tbxMaQuyen.Text != "")
                {
                    try
                    {
                        //cập nhật dịch vụ
                        if (busTaiKhoan.suaTaiKhoan(ref error, tk))
                        {   //nếu thành công thì thông báo
                            MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDachSachNV();//load lại dữ liệu
                            // xóa trắng textbox
                            this.tbxTenDangNhap.ResetText();
                            this.tbxMatKhau.ResetText();
                            this.tbxHoTen.ResetText();
                            this.tbxSoDT.ResetText();
                            this.tbxMaQuyen.ResetText();
                        }
                        else
                        {
                            //lỗi từ sqlserver
                            MessageBox.Show("Lỗi: " + error, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception er)//các lỗi khác
                    {
                        MessageBox.Show("Sửa thông tin nhân viên không thành công!\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
            }
        }

        private void dgvTaiKhoan_Click(object sender, EventArgs e)
        {
            int r = dgvTaiKhoan.CurrentCell.RowIndex;
            //chuyen gia tri len form
            tbxTenDangNhap.Text = dgvTaiKhoan.Rows[r].Cells[0].Value.ToString();
            tbxMatKhau.Text = dgvTaiKhoan.Rows[r].Cells[1].Value.ToString();
            tbxHoTen.Text = dgvTaiKhoan.Rows[r].Cells[2].Value.ToString();
            tbxSoDT.Text = dgvTaiKhoan.Rows[r].Cells[3].Value.ToString();
            tbxMaQuyen.Text = dgvTaiKhoan.Rows[r].Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string error = "";
            //xác nhận có muốn xóa ko
            DialogResult tl = MessageBox.Show("Bạn có muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                if (tbxTenDangNhap.Text != "" && tbxMatKhau.Text != "" && tbxHoTen.Text != "" && tbxSoDT.Text != "" && tbxMaQuyen.Text != "")
                {
                    try
                    {
                        //cập nhật dịch vụ
                        if (busTaiKhoan.xoaTaiKhoan(ref error, tbxTenDangNhap.Text))
                        {   //nếu thành công thì thông báo
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDachSachNV();//load lại dữ liệu
                            // xóa trắng textbox
                            this.tbxTenDangNhap.ResetText();
                            this.tbxMatKhau.ResetText();
                            this.tbxHoTen.ResetText();
                            this.tbxSoDT.ResetText();
                            this.tbxMaQuyen.ResetText();
                        }
                        else
                        {
                            //lỗi từ sqlserver
                            MessageBox.Show("Lỗi: " + error, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception er)//các lỗi khác
                    {
                        MessageBox.Show("Sửa thông tin nhân viên không thành công!\rLỗi: " + er.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
