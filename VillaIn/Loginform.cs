using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using VillaIn;

namespace VillaIn   
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string connectionString = "Data Source=LAPTOP-08ADTL81\\MAURAANINDITAK;Initial Catalog=Villain;Integrated Security=True;";
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

                        this.Hide(); // sembunyikan login
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi gagal: " + ex.Message);
                }
            }
        }
    }
}