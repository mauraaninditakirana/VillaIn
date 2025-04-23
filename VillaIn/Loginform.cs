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
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string connectionString = "Data Source=MSI\\RM_FAKHRI_W;Initial Catalog=Villain;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT id_pengguna, role FROM LoginUser WHERE username = @username AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string idPengguna = reader["id_pengguna"].ToString();
                        string role = reader["role"].ToString();

                        MessageBox.Show("Login berhasil sebagai: " + role); // debug

                        if (role == "admin")
                        {
                            AdminForm admin = new AdminForm(idPengguna);
                            admin.Show();
                        }
                        else if (role == "pemilik")
                        {
                            PemilikVillaForm pemilik = new PemilikVillaForm(idPengguna);
                            pemilik.Show();
                        }

                    }
                }
}
