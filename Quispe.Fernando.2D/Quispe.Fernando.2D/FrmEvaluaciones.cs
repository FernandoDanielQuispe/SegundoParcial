using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;

namespace Quispe.Fernando._2D
{
    delegate void AnalizarAlumno(Alumno a);
    delegate void Evaluar(object o);

    public partial class FrmEvaluaciones : Form
    {
        private Evaluador evaluador;
        private Evaluacion evaluacion;
        private List<Alumno> alumnos;
        List<Alumno> evaluados; 
        
        const int TIEMPOEVALUACION = 8000;

        event Evaluar EvaluarProximo;
        event AnalizarAlumno TieneNotaFinal;

        private EvaluacionDAO evaluacionDAO; 

        private static SqlCommand comando; 
        private static SqlConnection conexion; 

        SqlConnection cn = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database = JardinUtn; Trusted_Connection = True;");


        /// <summary>
        /// formularios evaluaciones
        /// </summary>
        public FrmEvaluaciones()
        {
            InitializeComponent();

            evaluacion = new Evaluacion();

            alumnos = new List<Alumno>();
 

            evaluados = new List<Alumno>(); //agregadoo

            TieneNotaFinal += llevarEvaluados; 

            //EvaluarProximo += proximo;
        }

        /// <summary>
        /// ejecucion de evaluaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Evaluaciones_Load(object sender, EventArgs e)
        {
            this.alumnos = new List<Alumno>();           

            Conexion c = new Conexion();
            
            this.alumnos = c.cargarAlumnos();         

            this.evaluacion = new Evaluacion();

            this.evaluador = new Evaluador();

        }
           

        /// <summary>
        /// Manejador del evento asociado al evento InformaEstado
        /// </summary>
        /// <param name="sender">Paquete emisor del evento InformaException</param>
        /// <param name="e">Almacena informacion del evento</param>
        private void alumno_InformaEstado(object alumno, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Alumno.DelegadoEstado d = new Alumno.DelegadoEstado(alumno_InformaEstado);
                this.Invoke(d, new object[] { alumno, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        ///  Informa en caso de error al intentar conexión con la base de datos de SQL Server.
        /// </summary>
        /// <param name="alumno">Emisor del evento</param>
        /// <param name="ex">Excepcion capturada al intentar agregar el paquete a la base de datos</param>
        private void alumno_InformaExcepcion(object alumno, Exception ex)
        {
            MessageBox.Show("Error al intentar insertar el alumno con el nombre " +
                ((Alumno)alumno).ToString() + "en la base de datos de SQL Server\n" +
                ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Limpia los 3 ListBox y luego recorrerá la lista agregando cada uno de ellos en el listado que corresponda.
        /// </summary>
        private void ActualizarEstados()
        {
            lstAlumnosEnEspera.Items.Clear();
            lstAlumnosEvaluando.Items.Clear();
            lstAlumnosEvaluados.Items.Clear();

            foreach (Alumno alumno in this.alumnos)
            {
                switch (alumno.Estado)
                {
                    case Alumno.EEstado.EnEspera:
                        lstAlumnosEnEspera.Items.Add(alumno);
                        break;

                    case Alumno.EEstado.Evaluando:
                        lstAlumnosEvaluando.Items.Add(alumno);
                        break;

                    case Alumno.EEstado.Evaluado:
                        lstAlumnosEvaluados.Items.Add(alumno);
                        break;

                    default:
                        break;
                }
            }
            lstAlumnosEnEspera.Refresh();
            lstAlumnosEvaluando.Refresh();
            lstAlumnosEvaluados.Refresh();
        }             


        /// <summary>
        /// Llama al método FinEntregas a fin de cerrar todos los hilos abiertos
        /// </summary>
        /// <param name="sender">Emisor del evento</param>
        /// <param name="e">Almacena informacion del evento</param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {          
            evaluador.FinEntregas();
        }       

        /// <summary>
        /// lleva los evaluados
        /// </summary>
        /// <param name="a"></param>
        private void llevarEvaluados(Alumno a) 
        {
            evaluados.Add(a);
            refrescarlista();
        }

        /// <summary>
        /// refresca la lista
        /// </summary>
        private void refrescarlista() 
        {
            if (lstAlumnosEnEspera.InvokeRequired)
            {
                lstAlumnosEnEspera.BeginInvoke((MethodInvoker)delegate
                {
                    lstAlumnosEnEspera.DataSource = null;
                    lstAlumnosEnEspera.DataSource = evaluados;
                });
            }
            else
            {
                lstAlumnosEnEspera.DataSource = null;
                lstAlumnosEnEspera.DataSource = evaluados;
            }
        }


        /// <summary>
        /// muestra el formulario
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="txt"></param>
        void mostrarEnForm(string mensaje, TextBox txt)
        {
            if (txt.InvokeRequired)
            {
                txt.BeginInvoke((MethodInvoker)delegate
                {
                    txt.Text = mensaje;
                });
            }
            else
                txt.Text = mensaje;
        }

        /// <summary>
        /// inicia la evaluacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciarEvaluacion_Click(object sender, EventArgs e)
        {
            foreach (Alumno alumno in this.alumnos)
            {
                alumno.InformaEstado += alumno_InformaEstado;
                alumno.InformaExcepcion += alumno_InformaExcepcion;

                try
                {
                    this.evaluador += alumno;
                    ActualizarEstados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alumno repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }

        }

        private void lstAlumnoIngresado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblAlumno_Click(object sender, EventArgs e)
        {

        }
    }
}
