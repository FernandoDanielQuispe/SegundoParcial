using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using Entidades;

namespace Quispe.Fernando._2D
{
    public class Conexion2
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;


        public Conexion2()
        {
            try
            {
                cn = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database = JardinUtn; Trusted_Connection = True;");
                cn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se conecto con la base de datos" + ex.ToString());
            }
        }


        public Queue<Alumno> cargarAlumnos()
        {
            Queue<Alumno> listaAlumnos = new Queue<Alumno>();
            try
            {
                da = new SqlDataAdapter("select * from Alumnos",cn);
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

                    listaAlumnos.Enqueue(alumno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar alumnos" +ex.ToString());
            }
            return listaAlumnos;
        }

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
                MessageBox.Show("No se pudo llenar docente" + ex.ToString());
            }
            return listaDocentes;
        }


        //agregado
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
                MessageBox.Show("No se pudo llenar aula" + ex.ToString());
            }
            return listaAulas;
        }



        //aun no usado
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
