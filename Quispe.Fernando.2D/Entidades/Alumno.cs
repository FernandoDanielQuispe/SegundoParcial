using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno : IMostrar<Alumno>
    {
        /// <summary>
        /// delegados
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(object alumno, EventArgs e);
        public delegate void DelegadoException(object alumno, Exception ex);

       /// <summary>
       /// eventos
       /// </summary>
        public event DelegadoEstado InformaEstado;
        public event DelegadoException InformaExcepcion;

        /// <summary>
        /// Enumerado con los tipos de estado
        /// </summary>
        public enum EEstado
        {
            EnEspera,
            Evaluando,
            Evaluado
        }

        /// <summary>
        /// campos
        /// </summary>
        private int idAlumnos;
        private string nombre;
        private string apellido;
        private int edad;
        private int dni;
        private string direccion;
        private int responsable;
        private EEstado estado;
        float notaFinal;

        #region propiedades
        /// <summary>
        /// Obtiene y asigna nota final
        /// </summary>
        public float NotaFinal 
        {
            get
            { 
                return notaFinal; 
            }
            set
            {
                this.notaFinal = value;
            }
        }


        /// <summary>
        /// Obtiene y asigna idalumnos
        /// </summary>
        public int IdAlumnos
        {
            get
            {
                return this.idAlumnos;
            }
            set
            {
                this.idAlumnos = value;
            }
        }

        /// <summary>
        /// Obtiene y asigna nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        /// <summary>
        /// Obtiene y asigna apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }


        /// <summary>
        /// Obtiene y asigna edad
        /// </summary>
        public int Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                this.edad = value;
            }
        }


        /// <summary>
        /// Obtiene y asigna dni
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }


        /// <summary>
        /// Obtiene y asigna direccion
        /// </summary>
        public string Direccion
        {
            get
            {
                return this.direccion;
            }
            set
            {
                this.direccion = value;
            }
        }


        /// <summary>
        /// Obtiene y asigna el responsable
        /// </summary>
        public int Responsable
        {
            get
            {
                return this.responsable;
            }
            set
            {
                this.responsable = value;
            }
        }

        /// <summary>
        /// Obtiene y asigna el estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public Alumno()
        {
        }
        
        /// <summary>
        /// constructor del alumno
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="notaFinal"></param>
        public Alumno(string nombre, string apellido, float notaFinal)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NotaFinal = notaFinal;
        }
               
        /// <summary>
        /// para cuando dos alumnos sean iguales
        /// </summary>
        /// <param name="a1">alumno 1 a ser comparado</param>
        /// <param name="a2">alumno 2 a ser comparado</param>
        /// <returns>True en caso de ser iguales / False en caso de ser diferentes</returns>
        public static bool operator ==(Alumno a1, Alumno a2)
        {
            return a1.Apellido == a2.Apellido;
        }
 
        /// <summary>
        /// para cuando dos alumnos sean distintos
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a1, Alumno a2)
        {
            return !(a1 == a2);
        }

        /// <summary>
        /// muestra los datos
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Alumno> elemento)
        {
            StringBuilder sb = new StringBuilder();
            Alumno a = (Alumno)elemento;
            sb.AppendFormat("{0} {1} - Nota final: {2}", a.Nombre, a.Apellido, a.notaFinal.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// MockCicloDeVida hará que el alumno cambie de estado 
        /// </summary>
        public void MockCicloDeVida()
        {
            try
            {
                while ((int)this.Estado < 2)
                {
                    if (InformaEstado != null)
                    {
                        InformaEstado(this, null);
                    }
                    Thread.Sleep(8000); 

                    if ((int)this.Estado == 1)
                    {
                        int i = (int)this.Estado + 1;
                        this.Estado = (EEstado)i;
                        Evaluacion evaluacion = new Evaluador().Evaluar(this);
                        EvaluacionDAO.Insertar(evaluacion);
                        this.NotaFinal = evaluacion.NotaFinal;
                    }
                    else
                    {
                        int i = (int)this.Estado + 1;
                        this.Estado = (EEstado)i;
                    }
                }                   
            }
            catch (Exception ex)
            {
                InformaExcepcion(this, ex);
            }
        }

        /// <summary>
        /// Retorna la informacion del paquete
        /// </summary>
        /// <returns>Datos del paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
    }
}
