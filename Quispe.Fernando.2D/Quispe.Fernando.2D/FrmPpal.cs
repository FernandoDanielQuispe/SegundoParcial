using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.Threading;
using Entidades;

namespace Quispe.Fernando._2D
{
    public partial class FrmPpal : Form
    {

        int cont = 0;
        int conta = 0;

        public FrmPpal()
        {
            InitializeComponent();
        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {
            XmlDocente xml = new XmlDocente();
            xml.ProcesarXml();

        }

        private void evaluacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEvaluaciones evaluaciones = new FrmEvaluaciones();
            evaluaciones.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }    

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cont < 20)
            {
                cont = cont + 1;
                lblReloj.Text = cont.ToString();                
            }           
            else
            {               
                timer1.Enabled = false;
                timer2.Enabled = true;                
                conta = 0;
                MessageBoxTemporal.Show("COMIENZO DEL RECREO DE 5 SEGUNDOS!!!", "Jardin de Infantes - Los Pichoncitos", 5, true);
            }      
        }       

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (conta < 5)
            {
                conta = conta + 1;
                lblReloj.Text = conta.ToString();
            }
            else
            {                
                timer1.Enabled = true;
                timer2.Enabled = false;                
                cont = 0;
                MessageBoxTemporal.Show("FINALIZACION DEL RECREO!!!", "Jardin de Infantes - Los Pichoncitos", 3, true);
            }
        }

        private void pictureBoxInicial_Click(object sender, EventArgs e)
        {

        }
    }
}
