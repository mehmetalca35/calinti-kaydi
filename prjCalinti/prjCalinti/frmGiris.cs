using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace prjCalinti
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        int hak;
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source=vt.accdb");

        private void button1_Click(object sender, EventArgs e)
        {

            if (hak <= 2)
            {
                string kadi = textBox1.Text.Trim();
                string sifre = textBox2.Text.Trim();
                OleDbDataAdapter sorgula = new OleDbDataAdapter("SELECT * FROM kullanicilar where KADI='" + kadi + "' and SIFRE = '" + sifre + "'", baglan);
                DataTable tablo = new DataTable();
                sorgula.Fill(tablo);
                if (tablo.Rows.Count > 0)
                {
                    this.Hide();
                    frmMenu goster = new frmMenu();
                    goster.ShowDialog();
                }
                else
                {
                    hak++;
                    label1.Text = "Kalan Hakkınız : " + (3 - hak).ToString();
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
