using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Entidades
{
    public static class GuardarString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool returnAux = false;
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(archivo, true);
                sw.WriteLine(texto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir / cerrar el archivo de texto\n" + ex.Message, ex);
            }
            finally
            {
                if (!(sw is null))
                {
                    sw.Close();
                    returnAux = true;
                }
            }

            return returnAux;
        }
    }
}
