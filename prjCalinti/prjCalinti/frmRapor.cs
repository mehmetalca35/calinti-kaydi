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
    public partial class frmRapor : Form
    {
        public frmRapor()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ace.oledb.12.0;Data Source=vt.accdb");
        public static string tarih, sql;
        void guncelle()
        {
            OleDbDataAdapter oku = new OleDbDataAdapter("select * from marka",baglan);
            DataTable tablo = new DataTable();
            oku.Fill(tablo);
            dataGridView1.DataSource = tablo;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                comboBox1.Items.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmRapor2 goster = new frmRapor2();
            sql = "SELECT * FROM raporlananlar where EKLENMETARIHI = '"+dateTimePicker1.Value.ToShortDateString()+"%'";
            goster.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmRapor2 goster = new frmRapor2();
            sql = "SELECT * FROM raporlananlar where MARKA = '" + comboBox1.Text+ "'";
            goster.ShowDialog();
        }

        private void frmRapor_Load(object sender, EventArgs e)
        {
            guncelle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                frmRapor2 goster = new frmRapor2();
                sql = "SELECT * FROM raporlananlar where BULUNDU = 'EVET'"; 
                goster.ShowDialog();
        }
    }
}
