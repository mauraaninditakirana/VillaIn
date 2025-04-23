using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
