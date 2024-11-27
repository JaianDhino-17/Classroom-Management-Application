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
    public partial class DiemSV : Form
    {
        string connectstring = @"Data Source=LAPTOP-PCJITTQT\THEANH;Initial Catalog=QUANLYSINHVIEN;Integrated Security=True;";

        public DiemSV()
        {
            InitializeComponent();
            CenterToScreen();
            lbEmployee.Text = "Nhân Viên : " + LoginForm.user.ToUpper();
            LoadData();
        }

        private void LoadData()
        {
            string tendn = LoginForm.user.ToUpper();
            string matkhau = LoginForm.passwordNV;

            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                using (SqlCommand cmd = new SqlCommand("SP_SEL_PUBLIC_DIEM", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TENDN", tendn);
                    cmd.Parameters.AddWithValue("@MK", matkhau);

                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnScore_Click(object sender, EventArgs e)
        {

        }

        private void btnClass_Click(object sender, EventArgs e)
        {  
                this.Hide();
                QL_LopHoc qL_LopHoc = new QL_LopHoc();
                qL_LopHoc.ShowDialog();  
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            QLSV qLSV = new QLSV();
            qLSV.ShowDialog();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string masv = txtMSSV.Text.ToUpper();
            string maHP = txtMaHP.Text.ToUpper();
            float diemThi = float.Parse(txtDiem.Text);
            string tendnNV = LoginForm.user.ToUpper();
            string passNV = LoginForm.passwordNV;

            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                using (SqlCommand cmd = new SqlCommand("SP_INS_PUBLIC_DIEM", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MASV", masv);
                    cmd.Parameters.AddWithValue("@MAHP", maHP);
                    cmd.Parameters.AddWithValue("@DIEMTHI", diemThi.ToString()); 
                    cmd.Parameters.AddWithValue("@TENDN", tendnNV);
                    cmd.Parameters.AddWithValue("@MATKHAU", passNV); 

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Nhập điểm thành công!");
                        LoadData(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string masv = txtMSSV.Text.ToUpper();
            string maHP = txtMaHP.Text.ToUpper();
            float diemThi = float.Parse(txtDiem.Text);
            string tendnNV = LoginForm.user.ToUpper();
            string passNV = LoginForm.passwordNV;


            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UPDATE_BANGDIEM", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MASV", masv);
                    cmd.Parameters.AddWithValue("@MAHP", maHP);
                    cmd.Parameters.AddWithValue("@DIEMTHI", diemThi.ToString());
                    cmd.Parameters.AddWithValue("@TENDN", tendnNV);
                    cmd.Parameters.AddWithValue("@MATKHAU", passNV); 

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật điểm thành công!");
                        LoadData(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
