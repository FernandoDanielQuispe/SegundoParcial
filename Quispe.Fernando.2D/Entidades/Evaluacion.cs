using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evaluacion : IMostrar<Evaluacion>
    {
        private int idAlumno;
        private int idDocente;
        private int idAula;
        private int nota_1;
        private int nota_2;
        private float notaFinal;
        private string observaciones;


        #region Propiedades       
        public int IdAlumno
        {
            get
            {
                return this.idAlumno;
            }
            set
            {
                this.idAlumno = value;
            }
        }


        public int IdDocente
        {
            get
            {
                return this.idDocente;
            }
            set
            {
                this.idDocente = value;
            }
        }

        public int IdAula
        {
            get
            {
                return this.idAula;
            }
            set
            {
                this.idAula = value;
            }
        }

        public int Nota_1
        {
            get
            {
                return this.nota_1;
            }
            set
            {
                this.nota_1 = value;
            }
        }

        public int Nota_2
        {
            get
            {
                return this.nota_2;
            }
            set
            {
                this.nota_2 = value;
            }
        }

        public float NotaFinal
        {
            get
            {
                return this.notaFinal;
            }
            set
            {
                this.notaFinal = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return this.observaciones;
            }
            set
            {
                this.observaciones = value;
            }
        }
        #endregion

        /// <summary>
        /// constrcutor de la clase
        /// </summary>
        public Evaluacion()
        { 
        }

        /// <summary>
        /// constructor con los datos
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <param name="idDocente"></param>
        /// <param name="idAula"></param>
        /// <param name="nota_1"></param>
        /// <param name="nota_2"></param>
        /// <param name="notaFinal"></param>
        /// <param name="observaciones"></param>
        public Evaluacion(int idAlumno, int idDocente, int idAula, int nota_1, int nota_2, float notaFinal, string observaciones)
        {
            this.IdAlumno = idAlumno;
            this.IdDocente = idDocente;
            this.IdAula = idAula;
            this.Nota_1 = nota_1;
            this.Nota_2 = nota_2;
            this.NotaFinal = notaFinal;
            this.Observaciones = observaciones;
        }
      

        /// <summary>
        /// muestra los datos
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Evaluacion> elemento)
        {
            StringBuilder sb = new StringBuilder();
            Evaluacion e = (Evaluacion)elemento;
            sb.AppendFormat("Alumno {0} Nota 1: {1} Nota 2: {2} Nota final: ", e.idAlumno, e.nota_1, e.nota_2, e.notaFinal);
            return sb.ToString();
        }
    }
}
