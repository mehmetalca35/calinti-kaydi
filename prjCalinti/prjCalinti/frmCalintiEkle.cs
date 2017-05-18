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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string marka, garanti;
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0; Data Source=vt.accdb");
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                textBox3.Enabled = true;
                marka = comboBox1.Text;
            }
            else
            {
                textBox3.Enabled = false;
                marka = "";
            }
        }//model seçimi

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {

            }
            else
            {
                e.Handled = true;
            }
        }//IMEI numarası sadece sayı girişi

        void markacek()//marka çekme
        {
            OleDbDataAdapter oku = new OleDbDataAdapter("select * from marka ORDER BY ADI", baglan);
            DataTable tablo = new DataTable();
            oku.Fill(tablo); 
            dataGridView2.DataSource = tablo;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            #region//marka çekme
            markacek();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
            }
            #endregion
        }
        void temizle()
        {
            textBox4.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            maskedTextBox1.Text = "";
        }//temizleme
        private void button1_Click(object sender, EventArgs e)//çalıntı ekleme butonu
        {
            if (textBox2.Text != "" && comboBox1.SelectedIndex != -1 && textBox3.Text != "" && comboBox2.SelectedIndex != -1 && textBox3.Text != "" && maskedTextBox1.Text != "")
            {
                OleDbCommand kontrol = new OleDbCommand("SELECT * FROM raporlananlar WHERE IMEINO='"+textBox2.Text+"'",baglan);
                baglan.Open();
                OleDbDataReader kontrol2 = kontrol.ExecuteReader();
                if (!kontrol2.Read())
                {
                    OleDbCommand kaydet = new OleDbCommand(
                    @"insert into raporlananlar(IMEINO,MARKA,MODEL,CALINMATARIHI,GARANTIDURUMU,URUNSAHIBI,ILETISIM,BULUNDU,EKLENMETARIHI) 
                VALUES('" + textBox2.Text + "','" + marka + "','" + textBox3.Text + "','" + dateTimePicker1.Value + "','" + garanti + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "','HAYIR','" + DateTime.Now + "')", baglan);
                    kaydet.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("IMEI DAHA ÖNCE KAYITLI");
                }
                baglan.Close();
            }
            else
            {
                MessageBox.Show("TÜM ALANLAR GİRİLMELİDİR");
            }
            temizle();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                garanti = comboBox2.Text;
            }
            else
            {
                garanti = "";
            }
        }//garanti durumu
    }
}
