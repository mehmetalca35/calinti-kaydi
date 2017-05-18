using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjCalinti
{
    public partial class frmRapor2 : Form
    {
        public frmRapor2()
        {
            InitializeComponent();
        }

        private void frmRapor2_Load(object sender, EventArgs e)
        {
            CrystalReport1 rapor = new CrystalReport1();
            oleDbDataAdapter1.SelectCommand.CommandText = frmRapor.sql;
            oleDbDataAdapter1.Fill(dataSet11.Tables["raporlananlar"]);
            rapor.SetDataSource(dataSet11.Tables["raporlananlar"]);
            crystalReportViewer1.ReportSource = rapor;
            if (rapor.Rows.Count > 0)
            {
                Opacity = 1;
            }
            else
            {
                MessageBox.Show("RAPOR BULUNAMADI");
                this.Close();
            }
        }
    }
}
