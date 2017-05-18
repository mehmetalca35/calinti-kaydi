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
    public partial class frmMarkaEkle : Form
    {
        public frmMarkaEkle()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source=vt.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand kontrol = new OleDbCommand("SELECT * FROM marka WHERE ADI='" + textBox1.Text + "'", baglan);
            baglan.Open();
            OleDbDataReader kontrol2 = kontrol.ExecuteReader();
            if (!kontrol2.Read())
            {
                OleDbCommand kaydet = new OleDbCommand("insert into marka values('"+textBox1.Text+"')", baglan);
            }
            else
            {
                MessageBox.Show("MARKA DAHA ÖNCE KAYITLI");
            }
            textBox1.Clear();
            baglan.Close();
        }
    }
}
