using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// metodo que las clases que implementen la Interfaz deberan sobreescribirlo
        /// </summary>
        /// <param name="elemento">el elemento debera ser especificado en el momento de la declaracion</param>
        /// <returns></returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
