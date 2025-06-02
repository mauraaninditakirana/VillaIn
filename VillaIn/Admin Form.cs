using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace VillaIn
{
    public partial class AdminForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-08ADTL81\\MAURAANINDITAK;Initial Catalog=Villain;Integrated Security=True;";
        private string currentEntity = "Villa"; // Default table
        private string idPengguna;

        private TextBox IdAPVK = new TextBox();
        private TextBox NmAPV = new TextBox();
        private TextBox EmAPV = new TextBox();
        private TextBox NtVPA = new TextBox();
        private TextBox AlmPA = new TextBox();
        private TextBox LokV = new TextBox();
        private TextBox StsV = new TextBox();

        public AdminForm(string idPengguna)
        {
            InitializeComponent();
            this.idPengguna = idPengguna;
            dataGridView1.CellClick += dataGridView1_CellClick;
            SetupDynamicUI();
            LoadData();
        }

        private void SetupDynamicUI()
        {
            panelInput.Controls.Clear();

            int startX = 20;
            int startY = 20;
            int labelWidth = 100;
            int textboxWidth = 200;
            int spacingY = 40;

            // Label dan nama TextBox
            string[] labels = { "ID", "Nama", "Email", "Telp", "Alamat", "Lokasi", "Status" };
            TextBox[] textboxes = { IdAPVK, NmAPV, EmAPV, NtVPA, AlmPA, LokV, StsV };

            for (int i = 0; i < labels.Length; i++)
            {
                Label lbl = new Label
                {
                    Text = labels[i],
                    Location = new Point(startX, startY + (i * spacingY)),
                    Size = new Size(labelWidth, 25)
                };

                TextBox txt = textboxes[i];
                txt.Name = "txt" + labels[i];
                txt.Location = new Point(startX + labelWidth + 10, startY + (i * spacingY));
                txt.Size = new Size(textboxWidth, 25);

                panelInput.Controls.Add(lbl);
                panelInput.Controls.Add(txt);
            }


            // Tombol Aksi
            int buttonStartX = startX + labelWidth + textboxWidth + 40;
            int buttonStartY = startY;

            Button[] buttons = { btnTambah, btnUbah, btnHapus, btnReset };
            string[] buttonTexts = { "Tambah", "Ubah", "Hapus", "Reset" };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = buttonTexts[i];
                buttons[i].Size = new Size(100, 30);
                buttons[i].Location = new Point(buttonStartX, buttonStartY + (i * 40));
                panelInput.Controls.Add(buttons[i]);
            }

            // Radio Button
            int radioY = startY + labels.Length * spacingY + 10;
            RadioButton[] radios = { radioVilla, radioPengguna, radioAdmin, radioTransaksi };

            int radioX = startX;
            foreach (var radio in radios)
            {
                radio.Location = new Point(radioX, radioY);
                panelInput.Controls.Add(radio);
                radioX += 120; // jarak antar radio button
            }

            // Tinggikan panel agar muat semua
            panelInput.Size = new Size(700, radioY + 50);
        }



        private void AddInputField(string label, int top)
        {
            Label lbl = new Label
            {
                Text = label,
                Location = new Point(10, top),
                Size = new Size(100, 25)
            };

            TextBox txt = new TextBox
            {
                Name = "txt" + label,
                Location = new Point(120, top),
                Size = new Size(200, 25)
            };

            panelInput.Controls.Add(lbl);
            panelInput.Controls.Add(txt);
        }

        private string GetInput(string name)
        {
            var ctrl = panelInput.Controls["txt" + name] as TextBox;
            return ctrl?.Text.Trim() ?? "";
        }

        private void SetInput(string name, string value)
        {
            var ctrl = panelInput.Controls["txt" + name] as TextBox;
            if (ctrl != null) ctrl.Text = value;
        }

        private void ClearInputs()
        {
            foreach (Control ctrl in panelInput.Controls)
            {
                if (ctrl is TextBox txt) txt.Clear();
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = currentEntity switch
                {
                    "Villa" => "SELECT * FROM Villa",
                    "Pengguna" => "SELECT * FROM Pengguna",
                    "Admin" => "SELECT * FROM SuperAdmin",
                    _ => "SELECT * FROM Villa"
                };
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string id = GetInput("ID");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd = GetInsertCommand(conn, transaction);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Data berhasil ditambahkan!");
                    LoadData();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Gagal menambahkan: " + ex.Message);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            string id = GetInput("ID");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd = GetUpdateCommand(conn, transaction);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Data berhasil diubah!");
                    LoadData();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Gagal mengubah: " + ex.Message);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            string id = GetInput("ID");
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Pilih data yang ingin dihapus!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string query = currentEntity switch
                    {
                        "Villa" => "DELETE FROM Villa WHERE id_villa=@id",
                        "Pengguna" => "DELETE FROM Pengguna WHERE id_pengguna=@id",
                        "Admin" => "DELETE FROM SuperAdmin WHERE id_superadmin=@id",
                        _ => ""
                    };
                    SqlCommand cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Data berhasil dihapus!");
                    LoadData();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Gagal menghapus: " + ex.Message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private SqlCommand GetInsertCommand(SqlConnection conn, SqlTransaction transaction)
        {
            string id = GetInput("ID");
            string nama = GetInput("Nama");

            if (currentEntity == "Villa")
            {
                return new SqlCommand("INSERT INTO Villa VALUES (@id, @nama, @lokasi, @status)", conn, transaction)
                {
                    Parameters = {
                        new SqlParameter("@id", id),
                        new SqlParameter("@nama", nama),
                        new SqlParameter("@lokasi", GetInput("Lokasi")),
                        new SqlParameter("@status", GetInput("Status"))
                    }
                };
            }
            else if (currentEntity == "Pengguna")
            {
                return new SqlCommand("INSERT INTO Pengguna VALUES (@id, @nama, @email, @telp, @alamat)", conn, transaction)
                {
                    Parameters = {
                        new SqlParameter("@id", id),
                        new SqlParameter("@nama", nama),
                        new SqlParameter("@email", GetInput("Email")),
                        new SqlParameter("@telp", GetInput("Telp")),
                        new SqlParameter("@alamat", GetInput("Alamat"))
                    }
                };
            }
            else // Admin
            {
                return new SqlCommand("INSERT INTO SuperAdmin VALUES (@id, @nama, @email, @telp)", conn, transaction)
                {
                    Parameters = {
                        new SqlParameter("@id", id),
                        new SqlParameter("@nama", nama),
                        new SqlParameter("@email", GetInput("Email")),
                        new SqlParameter("@telp", GetInput("Telp"))
                    }
                };
            }
        }

        private SqlCommand GetUpdateCommand(SqlConnection conn, SqlTransaction transaction)
        {
            string id = GetInput("ID");
            string nama = GetInput("Nama");

            if (currentEntity == "Villa")
            {
                return new SqlCommand("UPDATE Villa SET nama_villa=@nama, lokasi_villa=@lokasi, status_villa=@status WHERE id_villa=@id", conn, transaction)
                {
                    Parameters = {
                        new SqlParameter("@id", id),
                        new SqlParameter("@nama", nama),
                        new SqlParameter("@lokasi", GetInput("Lokasi")),
                        new SqlParameter("@status", GetInput("Status"))
                    }
                };
            }
            else if (currentEntity == "Pengguna")
            {
                return new SqlCommand("UPDATE Pengguna SET nama_pengguna=@nama, email_pengguna=@email, notelp_pengguna=@telp, alamat_rumah=@alamat WHERE id_pengguna=@id", conn, transaction)
                {
                    Parameters = {
                        new SqlParameter("@id", id),
                        new SqlParameter("@nama", nama),
                        new SqlParameter("@email", GetInput("Email")),
                        new SqlParameter("@telp", GetInput("Telp")),
                        new SqlParameter("@alamat", GetInput("Alamat"))
                    }
                };
            }
            else // Admin
            {
                return new SqlCommand("UPDATE SuperAdmin SET nama_admin=@nama, email_admin=@email, telp_admin=@telp WHERE id_superadmin=@id", conn, transaction)
                {
                    Parameters = {
                        new SqlParameter("@id", id),
                        new SqlParameter("@nama", nama),
                        new SqlParameter("@email", GetInput("Email")),
                        new SqlParameter("@telp", GetInput("Telp"))
                    }
                };
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                SetInput("ID", row.Cells[0].Value?.ToString() ?? "");
                SetInput("Nama", row.Cells[1].Value?.ToString() ?? "");

                if (currentEntity == "Villa")
                {
                    SetInput("Lokasi", row.Cells[2].Value?.ToString() ?? "");
                    SetInput("Status", row.Cells[3].Value?.ToString() ?? "");
                }
                else if (currentEntity == "Pengguna")
                {
                    SetInput("Email", row.Cells[2].Value?.ToString() ?? "");
                    SetInput("Telp", row.Cells[3].Value?.ToString() ?? "");
                    SetInput("Alamat", row.Cells[4].Value?.ToString() ?? "");
                }
                else if (currentEntity == "Admin")
                {
                    SetInput("Email", row.Cells[2].Value?.ToString() ?? "");
                    SetInput("Telp", row.Cells[3].Value?.ToString() ?? "");
                }
            }
        }


        private void radioVilla_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVilla.Checked)
            {
                currentEntity = "Villa";
                LoadData();
            }
        }

        private void radioPengguna_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPengguna.Checked)
            {
                currentEntity = "Pengguna";
                LoadData();
            }
        }

        private void radioAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAdmin.Checked)
            {
                currentEntity = "Admin";
                LoadData();
            }
        }

        private void radioTransaksi_CheckedChanged(object sender, EventArgs e)
        {
            // Saat radio Transaksi dipilih
            currentEntity = "Transaksi";
            SetupDynamicUI();
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Membersihkan semua inputan
            ClearTextboxes();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Saat form pertama kali dibuka
            SetupDynamicUI();
            LoadData();
        }

        private void ClearTextboxes()
        {
            foreach (Control ctrl in panelInput.Controls)
            {
                if (ctrl is TextBox textbox)
                {
                    textbox.Clear();
                }
                else if (ctrl is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
                else if (ctrl is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }
            }
        }


    }
}