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
    public partial class PemilikVillaForm : Form
    {
        private string idPengguna;
        public PemilikVillaForm(string idPengguna)
        {
            InitializeComponent();
            this.idPengguna = idPengguna;
        }

        private void btnInsert1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-08ADTL81\\MAURAANINDITAK;Initial Catalog=Villain;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM transaksi WHERE id_pengguna = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", "PG001"); // ID bisa dari session/login
            }
    }
}
