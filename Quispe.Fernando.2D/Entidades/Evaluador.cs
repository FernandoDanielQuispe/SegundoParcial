using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evaluador : IMostrar<List<Alumno>>
    {
        /// <summary>
        /// Campos
        /// </summary>
        private List<Thread> mockAlumnos;
        private List<Alumno> alumnos;
        private List<Docente> docentes;
        private List<Aula> aulas;
        private List<Evaluacion> evaluaciones;
        Random random;

        /// <summary>
        /// Obtiene y asigna alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// obtiene y asigna las evaluaciones
        /// </summary>
        public List<Evaluacion> Evaluaciones
        {
            get
            {
                return this.evaluaciones;
            }
            set
            {
                this.evaluaciones = value;
            }
        }

        /// <summary>
        /// carga los datos en la lista
        /// </summary>
        public Evaluador()
        {
            this.mockAlumnos = new List<Thread>();            
            this.evaluaciones = new List<Evaluacion>();

            Conexion c = new Conexion();
            this.docentes = c.cargarDocentes();
            this.aulas = c.cargarAulas();
            this.alumnos = c.cargarAlumnos();

            random = new Random();
        }

        /// <summary>
        /// evalua al alumno
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public Evaluacion Evaluar(Alumno alumno)
        {            
            int idDocenteRandom = random.Next(0, this.docentes.Count());
            int idAulaRandom = random.Next(0, this.aulas.Count());

            int nota1Ramdom = random.Next(0, 10);
            int nota2Ramdom = random.Next(0, 10);
            float notaFinal = (((float)nota1Ramdom + (float)nota2Ramdom) / 2);

            Evaluacion evaluacion = new Evaluacion(alumno.IdAlumnos, idDocenteRandom, idAulaRandom, nota1Ramdom, nota2Ramdom, notaFinal, "");

            this.evaluaciones.Add(evaluacion);
            return evaluacion;
        }

        /// <summary>
        /// ciclo de vida
        /// </summary>
        /// <param name="e"></param>
        /// <param name="a"></param>
        /// <returns>Correo mas el paquete agregado / Excepcion en caso de encontrarse cargado</returns>
        public static Evaluador operator +(Evaluador e, Alumno a)
        {     
            a.MockCicloDeVida();

            return e;
        }

        /// <summary>
        /// Muestra los datos de alumnos
        /// </summary>
        /// <param name="elementos">Lista de paquetes a ser mostrado</param>
        /// <returns>Datos de alumnos</returns>
        public string MostrarDatos(IMostrar<List<Alumno>> elementos)
        {            
            List<Alumno> ps = ((Evaluador)elementos).Alumnos;
            StringBuilder sb = new StringBuilder();

            foreach (Alumno a in ps)
            {               
                sb.AppendFormat("{0} {1} - Nota final: {2}\n", a.Nombre, a.Apellido, a.NotaFinal.ToString());
            }
            return sb.ToString();           
        }

        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockAlumnos)
            {
                if (hilo.IsAlive && hilo != null)
                {
                    hilo.Abort();
                }
            }
        }
    }
}
