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

namespace VillaIn
{
    public partial class Admin_Form : Form
    {
        private string idPengguna;
        public Admin_Form(string idPengguna)
        {
            InitializeComponent();
            this.idPengguna = idPengguna;
        }

        private void Admin_Form_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-08ADTL81\\MAURAANINDITAK;Initial Catalog=Villain";
                 using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Pengguna";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
