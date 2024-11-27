using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLSV_App
{
    public partial class QLSV : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu
        string connectstring = @"Data Source=LAPTOP-PCJITTQT\THEANH;Initial Catalog=QUANLYSINHVIEN;Integrated Security=True;";

        public QLSV()
        {
            InitializeComponent();
            CenterToScreen();
            LoadData();
            lbEmployee.Text = "Nhân Viên : " + LoginForm.user.ToUpper();
        }

        private void LoadData()
        {
            string username = LoginForm.user;
            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                SqlCommand command = new SqlCommand("SP_LOAD_SV", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TENDN", username);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dt);

                    // Thêm cột mới để hiển thị mã hóa dưới dạng chuỗi
                    dt.Columns.Add("MATKHAU_STR", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["MATKHAU"] != DBNull.Value)
                        {
                            byte[] byteArray = (byte[])row["MATKHAU"];
                            string hexString = BitConverter.ToString(byteArray).Replace("-", "");
                            row["MATKHAU_STR"] = hexString;
                        }
                        else
                        {
                            row["MATKHAU_STR"] = "N/A";
                        }
                    }

                    // Đặt DataSource cho DataGridView
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["MATKHAU"].Visible = false;
                    dataGridView1.Columns["MATKHAU_STR"].HeaderText = "Mã Hóa Mật Khẩu";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            this.Hide();
            QL_LopHoc qL_LopHoc = new QL_LopHoc();
            qL_LopHoc.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnScore_Click_1(object sender, EventArgs e)
        {
            DiemSV diemSV = new DiemSV();
            diemSV.Show();
            this.Hide();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string username = LoginForm.user.ToUpper();
                string malop = txtMaLop.Text.ToUpper();
                string masv = txtMaSV.Text.ToUpper();
                string tensv = txtHoTen.Text;
                DateTime ngaysinh;
                if (!DateTime.TryParse(txtNgaySinh.Text, out ngaysinh))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng ngày tháng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string dchi = txtDiaChi.Text;
                string tendnSV = txtUserSV.Text.ToUpper();
                string password = txtPassSV.Text;

                using (SqlConnection conn = new SqlConnection(connectstring))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_SINHVIEN", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MASV", masv);
                        cmd.Parameters.AddWithValue("@HOTEN", tensv);
                        cmd.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                        cmd.Parameters.AddWithValue("@DIACHI", dchi);
                        cmd.Parameters.AddWithValue("@MALOP", malop);
                        cmd.Parameters.AddWithValue("@TENDN_SV", tendnSV);
                        cmd.Parameters.AddWithValue("@PASS_SV", password);
                        cmd.Parameters.AddWithValue("@TENDN_NV", username);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string username = LoginForm.user.ToUpper();
                string malop = txtMaLop.Text.ToUpper();
                string masv = txtMaSV.Text.ToUpper();
                string tensv = txtHoTen.Text;
                DateTime ngaysinh;
                if (!DateTime.TryParse(txtNgaySinh.Text, out ngaysinh))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng ngày tháng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string dchi = txtDiaChi.Text;
                string tendnSV = txtUserSV.Text.ToUpper();
                string password = txtPassSV.Text;
                using (SqlConnection conn = new SqlConnection(connectstring))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_SINHVIEN", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MASV", masv);
                        cmd.Parameters.AddWithValue("@HOTEN", tensv);
                        cmd.Parameters.AddWithValue("@NGAYSINH", ngaysinh);
                        cmd.Parameters.AddWithValue("@DIACHI", dchi);
                        cmd.Parameters.AddWithValue("@MALOP", malop);
                        cmd.Parameters.AddWithValue("@TENDN_SV", tendnSV);
                        cmd.Parameters.AddWithValue("@PASS_SV", password);
                        cmd.Parameters.AddWithValue("@TENDN_NV", username);

                        try
                        {
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        // Phương thức xóa sinh viên
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (SqlConnection conn = new SqlConnection(connectstring))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DELETE_SINHVIEN", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MASV", txtMaSV.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@MALOP", txtMaLop.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@TENDN_NV", LoginForm.user.ToUpper());

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtNgaySinh.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                string.IsNullOrWhiteSpace(txtUserSV.Text) ||
                string.IsNullOrWhiteSpace(txtPassSV.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
