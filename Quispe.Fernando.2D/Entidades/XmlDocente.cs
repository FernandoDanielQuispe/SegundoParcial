using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml;
using System.Data.SqlClient;

namespace Entidades
{
    public class XmlDocente
    {
        public void ProcesarXml()           
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adpter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            XmlReader xmlFile;            
            string query = null;
            string Nombre = null;
            string Apellido = null;
            int Edad = 0;
            string Dni = null;
            string Direccion = null;
            string Sexo = null;
            string Email = null;
            int i = 0;
           
            connetionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=JardinUtn;Trusted_Connection = True";
            connection = new SqlConnection(connetionString);
            
            query = @"SELECT COUNT(*) FROM Docentes";       
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
            {
                connetionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=JardinUtn;Trusted_Connection = True";
                connection = new SqlConnection(connetionString);

                xmlFile = XmlReader.Create("MisDocumentos/SegundoParcialUtn/JardinUtn/Docentes/Docentes.xml", new XmlReaderSettings());
                ds.ReadXml(xmlFile);
                    
                connection.Open();

                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    Nombre = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    Apellido = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    Edad = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[3]);
                    Sexo = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    Dni = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    Direccion = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                    Email = ds.Tables[0].Rows[i].ItemArray[7].ToString();

                    query = "INSERT INTO Docentes VALUES('" + Nombre + "','" + Apellido + "'," + Edad + ",'" + Sexo + "','" + Dni + "','" + Direccion + "','" + Email + "')";
                    command = new SqlCommand(query, connection);
                    adpter.InsertCommand = command;
                    adpter.InsertCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
            else
            {
                connection.Close();
            }            
        }
    }
}
