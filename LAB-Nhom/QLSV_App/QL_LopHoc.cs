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
    public partial class QL_LopHoc : Form
    {
        string connectionString = @"Data Source=LAPTOP-PCJITTQT\THEANH;Initial Catalog=QUANLYSINHVIEN;Integrated Security=True;";
        public QL_LopHoc()
        {
            InitializeComponent();
            CenterToScreen();
            lbEmployee.Text = "Nhân Viên : " +  LoginForm.user.ToUpper();
            LoadLop_NV(LoginForm.user);
        }

        public void LoadLop_NV(string tendn)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
              
                SqlCommand command = new SqlCommand("SP_LocLopTheoTenNV", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TENDN", tendn);

                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    
                    connection.Open();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            QLSV qLSV = new QLSV();
            qLSV.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_management_Click(object sender, EventArgs e)
        {
            manageClass mnClass = new manageClass();
            mnClass.ShowDialog();
            LoadLop_NV(LoginForm.user);
        }
    }
}
