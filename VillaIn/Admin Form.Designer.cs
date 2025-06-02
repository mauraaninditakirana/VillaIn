namespace VillaIn
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelInput = new System.Windows.Forms.Panel();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.radioVilla = new System.Windows.Forms.RadioButton();
            this.radioPengguna = new System.Windows.Forms.RadioButton();
            this.radioAdmin = new System.Windows.Forms.RadioButton();
            this.radioTransaksi = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(750, 200);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.radioPengguna);
            this.panelInput.Location = new System.Drawing.Point(20, 230);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(500, 500);
            this.panelInput.TabIndex = 1;

            // Tombol CRUD + Exit (horizontal layout)
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();

            int buttonTop = 470;
            int buttonLeft = 170;
            int buttonSpacing = 110;

            this.btnTambah.Location = new System.Drawing.Point(buttonLeft + (buttonSpacing * 0), buttonTop);
            this.btnUbah.Location = new System.Drawing.Point(buttonLeft + (buttonSpacing * 1), buttonTop);
            this.btnHapus.Location = new System.Drawing.Point(buttonLeft + (buttonSpacing * 2), buttonTop);
            this.btnReset.Location = new System.Drawing.Point(buttonLeft + (buttonSpacing * 3), buttonTop);
            this.btnExit.Location = new System.Drawing.Point(buttonLeft + (buttonSpacing * 4), buttonTop);

            this.btnTambah.Size = this.btnUbah.Size = this.btnHapus.Size = this.btnReset.Size = this.btnExit.Size = new System.Drawing.Size(100, 30);

            this.btnTambah.Text = "Tambah";
            this.btnUbah.Text = "Ubah";
            this.btnHapus.Text = "Hapus";
            this.btnReset.Text = "Reset";
            this.btnExit.Text = "Exit";

            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Tambahkan tombol ke form
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);

            // 
            // radioVilla
            // 
            this.radioVilla.Location = new System.Drawing.Point(20, 470);
            this.radioVilla.Name = "radioVilla";
            this.radioVilla.Size = new System.Drawing.Size(100, 20);
            this.radioVilla.TabIndex = 6;
            this.radioVilla.Text = "Villa";
            this.radioVilla.CheckedChanged += new System.EventHandler(this.radioVilla_CheckedChanged);
            // 
            // radioPengguna
            // 
            this.radioPengguna.Location = new System.Drawing.Point(88, 240);
            this.radioPengguna.Name = "radioPengguna";
            this.radioPengguna.Size = new System.Drawing.Size(100, 20);
            this.radioPengguna.TabIndex = 7;
            this.radioPengguna.Text = "Pengguna";
            this.radioPengguna.CheckedChanged += new System.EventHandler(this.radioPengguna_CheckedChanged);
            // 
            // radioAdmin
            // 
            this.radioAdmin.Location = new System.Drawing.Point(240, 470);
            this.radioAdmin.Name = "radioAdmin";
            this.radioAdmin.Size = new System.Drawing.Size(100, 20);
            this.radioAdmin.TabIndex = 8;
            this.radioAdmin.Text = "Admin";
            this.radioAdmin.CheckedChanged += new System.EventHandler(this.radioAdmin_CheckedChanged);
            // 
            // radioTransaksi
            // 
            this.radioTransaksi.Location = new System.Drawing.Point(350, 470);
            this.radioTransaksi.Name = "radioTransaksi";
            this.radioTransaksi.Size = new System.Drawing.Size(100, 20);
            this.radioTransaksi.TabIndex = 9;
            this.radioTransaksi.Text = "Transaksi";
            this.radioTransaksi.CheckedChanged += new System.EventHandler(this.radioTransaksi_CheckedChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.radioTransaksi);
            this.Controls.Add(this.radioAdmin);
            this.Controls.Add(this.radioVilla);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AdminForm";
            this.Text = "Admin Form";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelInput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton radioVilla;
        private System.Windows.Forms.RadioButton radioPengguna;
        private System.Windows.Forms.RadioButton radioAdmin;
        private System.Windows.Forms.RadioButton radioTransaksi;
    }
}