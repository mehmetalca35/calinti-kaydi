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
    public partial class frmCalintiSorgulama : Form
    {
        public frmCalintiSorgulama()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source=vt.accdb");

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        void temizle()
        {
            textBox4.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            maskedTextBox1.Text = "";
            label6.Text = "";
            label11.Text = "";
        }//temizleme
        private void button1_Click(object sender, EventArgs e)//RAPOR ID YE GÖRE ARA
        {
            if (textBox5.Text != "")
            {
                OleDbCommand kontrol = new OleDbCommand("SELECT * FROM raporlananlar WHERE RaporID = " + textBox5.Text + "", baglan);
                baglan.Open();
                OleDbDataReader kontrol2 = kontrol.ExecuteReader();
                if (kontrol2.Read())
                {
                    OleDbDataAdapter oku = new OleDbDataAdapter("SELECT * FROM raporlananlar WHERE RAPORID = " + textBox5.Text + "", baglan);
                    DataTable tablo = new DataTable();
                    oku.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
                    maskedTextBox1.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
                    comboBox1.Items.Add(dataGridView1.Rows[0].Cells[2].Value.ToString());
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                    comboBox2.SelectedIndex = comboBox2.FindString(dataGridView1.Rows[0].Cells[6].Value.ToString());
                    label6.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    label11.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    button2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("ARANAN KAYIT BULUNAMADI");
                    button2.Enabled = false;
                    temizle();
                }
                baglan.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)//IMEI NOYA GÖRE ARA
        {
            if (textBox6.Text != "")
            {
                OleDbCommand kontrol = new OleDbCommand("SELECT * FROM raporlananlar WHERE IMEINO ='" + textBox6.Text + "'", baglan);
                baglan.Open();
                OleDbDataReader kontrol2 = kontrol.ExecuteReader();
                if (kontrol2.Read())
                {
                    OleDbDataAdapter oku = new OleDbDataAdapter("SELECT * FROM raporlananlar WHERE IMEINO = '" + textBox6.Text + "'", baglan);
                    DataTable tablo = new DataTable();
                    oku.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
                    maskedTextBox1.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
                    comboBox1.Items.Add(dataGridView1.Rows[0].Cells[2].Value.ToString());
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                    comboBox2.SelectedIndex = comboBox2.FindString(dataGridView1.Rows[0].Cells[6].Value.ToString());
                    label6.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    label11.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    button2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("ARANAN KAYIT BULUNAMADI");
                    button2.Enabled = false;
                    temizle();
                }
                baglan.Close();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)//BULUNDU BUTONU
        {
            DialogResult sor = MessageBox.Show("BULUNDU KAYDINI GİRMEYE EMİNMİSİNİZ?", "ONAY", MessageBoxButtons.YesNo);
            OleDbDataAdapter oku = new OleDbDataAdapter("SELECT * FROM raporlananlar WHERE IMEINO = '" + textBox2.Text + "'", baglan);
            DataTable tablo = new DataTable();
            oku.Fill(tablo);
            dataGridView2.DataSource = tablo;
            if (sor == DialogResult.Yes && textBox1.Text != "")
            {
                if (dataGridView2.Rows[0].Cells[9].Value.ToString() != "EVET")
                {
                    OleDbCommand bulundu = new OleDbCommand("UPDATE raporlananlar set BULUNDU='EVET',BULUNMATARIHI='" + DateTime.Now + "' WHERE IMEINO='" + textBox2.Text + "'", baglan);
                    baglan.Open();
                    bulundu.ExecuteNonQuery();
                    baglan.Close();
                }
                else
                {
                    MessageBox.Show("KAYITLI IMEI NOLU TELEFON BULUNMUŞ");
                }
            }
        }

        private void frmCalintiSorgulama_Load(object sender, EventArgs e)
        {

        }
    }

}
