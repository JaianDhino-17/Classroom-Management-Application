using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLSV_App
{
    public partial class manageClass : Form
    {
        private string connectstring = @"Data Source=LAPTOP-PCJITTQT\THEANH;Initial Catalog=QUANLYSINHVIEN;Integrated Security=True;";

        public manageClass()
        {
            InitializeComponent();
            CenterToScreen();
        }

       

        private void btn_insertClass_Click(object sender, EventArgs e)
        {
            string malop = txt_ClassID.Text; 
            string tenlop =txt_ClassName.Text; 
            string manv = txt_employeeID.Text; 

            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_INSERT_LOP", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MALOP", malop);
                    cmd.Parameters.AddWithValue("@TENLOP", tenlop);
                    cmd.Parameters.AddWithValue("@MANV", manv);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_updateClass_Click(object sender, EventArgs e)
        {
            string malop = txt_ClassID.Text;
            string tenlop = txt_ClassName.Text;
            string manv = txt_employeeID.Text;

            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_UPDATE_LOP", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MALOP", malop);
                    cmd.Parameters.AddWithValue("@TENLOP", tenlop);
                    cmd.Parameters.AddWithValue("@MANV", manv);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_deleteClass_Click(object sender, EventArgs e)
        {
                string malop = txt_ClassID.Text;

            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_DELETE_LOP", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MALOP", malop);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
