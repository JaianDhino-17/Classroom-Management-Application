using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLSV_App
{
    public partial class LoginForm : Form
    {
        string connectstring = @"Data Source=LAPTOP-PCJITTQT\THEANH;Initial Catalog=QUANLYSINHVIEN;Integrated Security=True;";

        public LoginForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public static string user;
        public static string passwordNV;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.ToUpper();
            string password = txtPassword.Text;
            user = username;
            passwordNV = password;

            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SP_LOGIN_NV", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TENDN", username);
                    cmd.Parameters.AddWithValue("@MK", password);

                    // Thêm tham số để lấy giá trị trả về
                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        // Lấy giá trị trả về từ thủ tục
                        int result = (int)returnValue.Value;

                        if (result == 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            QL_LopHoc qL_LopHoc = new QL_LopHoc();
                            qL_LopHoc.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




        private void btnEsc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
