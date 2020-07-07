using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Entidades
{
    public class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;


        public Conexion()
        {
            try
            {
                cn = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database = JardinUtn; Trusted_Connection = True;");
                cn.Open();
            }
            catch (Exception ex)
            {
                throw ex;              
            }
        }

        /// <summary>
        /// lista que tiene los alumnos
        /// </summary>
        /// <returns></returns>
        public List<Alumno> cargarAlumnos()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();
            try
            {
                da = new SqlDataAdapter("select * from Alumnos", cn);
                dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Alumno alumno = new Alumno();
                    alumno.IdAlumnos = Convert.ToInt32(dt.Rows[i]["idAlumnos"]);
                    alumno.Nombre = dt.Rows[i]["Nombre"].ToString();
                    alumno.Apellido = dt.Rows[i]["Apellido"].ToString();
                    alumno.Edad = Convert.ToInt32(dt.Rows[i]["Edad"]);
                    alumno.Dni = Convert.ToInt32(dt.Rows[i]["Dni"]);
                    alumno.Direccion = dt.Rows[i]["Direccion"].ToString();
                    alumno.Responsable = Convert.ToInt32(dt.Rows[i]["Responsable"]);
                    listaAlumnos.Add(alumno);                   
                }
            }
            catch (Exception ex)
            {
                throw ex;               
            }
            return listaAlumnos;
        }

        /// <summary>
        /// lista de docentes
        /// </summary>
        /// <returns></returns>
        public List<Docente> cargarDocentes()
        {
            List<Docente> listaDocentes = new List<Docente>();

            try
            {
                da = new SqlDataAdapter("select * from Docentes", cn);
                dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Docente docente = new Docente();
                    docente.IdDocente = Convert.ToInt32(dt.Rows[i]["idDocente"]);
                    docente.Nombre = dt.Rows[i]["Nombre"].ToString();
                    docente.Apellido = dt.Rows[i]["Apellido"].ToString();
                    docente.Edad = Convert.ToInt32(dt.Rows[i]["Edad"]);
                    docente.Sexo = dt.Rows[i]["Sexo"].ToString();
                    docente.Dni = Convert.ToInt32(dt.Rows[i]["Dni"]);
                    docente.Direccion = dt.Rows[i]["Direccion"].ToString();
                    docente.Email = dt.Rows[i]["Email"].ToString();

                    listaDocentes.Add(docente);
                }
            }
            catch (Exception ex)
            {
                throw ex;             
            }
            return listaDocentes;
        }

     
        /// <summary>
        /// lista de las aulas
        /// </summary>
        /// <returns></returns>
        public List<Aula> cargarAulas()
        {
            List<Aula> listaAulas = new List<Aula>();

            try
            {
                da = new SqlDataAdapter("select * from Aulas", cn);
                dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Aula aula = new Aula();
                    aula.IdAula = Convert.ToInt32(dt.Rows[i]["idAula"]);
                    aula.Salita = dt.Rows[i]["Salita"].ToString();

                    listaAulas.Add(aula);
                }
            }
            catch (Exception ex)
            {
                throw ex;                
            }
            return listaAulas;
        }

        /// <summary>
        /// inserta los datos
        /// </summary>
        /// <param name="idAlumnos"></param>
        /// <param name="idDocente"></param>
        /// <param name="idAula"></param>
        /// <param name="nota_1"></param>
        /// <param name="nota_2"></param>
        /// <param name="notaFinal"></param>
        /// <param name="observaciones"></param>
        /// <returns></returns>
        public string insertar(int idAlumnos, int idDocente, int idAula, int nota_1, int nota_2, float notaFinal, string observaciones)
        {
            string salida = "Se inserto";
            try
            {
                cmd = new SqlCommand("insertar into Evaluaciones(idAlumnos, idDocente, idAula, nota_1, nota_2, notaFinal, observaciones) values (" + idAlumnos + ", " + idDocente + ", " + idAula + ", " + nota_1 + ", " + nota_2 + ", '" + notaFinal + "', '" + observaciones + "')");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se conecto " + ex.ToString();
            }
            return salida;
        }
    }
}
