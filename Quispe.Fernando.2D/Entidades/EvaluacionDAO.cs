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
    public class EvaluacionDAO
    {
        /// <summary>
        /// Campos
        /// </summary>
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Inicializa la conexion a SQL Server
        /// </summary>
        static EvaluacionDAO()
        {
            try
            {
                EvaluacionDAO.conexion = new SqlConnection(@"Server = localhost\SQLEXPRESS; Database = JardinUtn; Trusted_Connection = True;");
                EvaluacionDAO.comando = new SqlCommand();
                EvaluacionDAO.comando.CommandType = System.Data.CommandType.Text;
                EvaluacionDAO.comando.Connection = EvaluacionDAO.conexion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ejecuta un comando para guardar los datos de un paquete en la base de datos de SQL Server
        /// </summary>
        /// <param name="e">evaluacion a ser guardada</param>
        /// <returns>True si se inserto en paquete / Excpetion en caso de producirse un error</returns>
        public static bool Insertar(Evaluacion e)
        {
            bool returnAux = false;

            try
            {
                string comando = String.Format("insert into dbo.Evaluaciones" +
                    "(idAlumno, idDocente, idAula, Nota_1, Nota_2, NotaFinal, Observaciones ) values (" +
                    "{0}, {1}, {2}, {3}, {4}, {5}, '')",
                    e.IdAlumno, e.IdDocente, e.IdAula, e.Nota_1, e.Nota_2,  e.NotaFinal.ToString().Replace(',','.')
                    );

                EvaluacionDAO.comando.CommandText = comando;
                EvaluacionDAO.conexion.Open();
                EvaluacionDAO.comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                EvaluacionDAO.conexion.Close();
                returnAux = true;
            }
            return returnAux;
        }
    }
}
