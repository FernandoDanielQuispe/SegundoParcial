using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Quispe.Fernando._2D;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// Verifica que la lista de alumnos esté instanciada.
        /// </summary>
        [TestMethod]
        public void Verifica_Lista_Paquetes_Instanciada()
        {
            Evaluador evaluador;
            evaluador = new Evaluador();
            Assert.IsNotNull(evaluador.Alumnos);
        }    

    }
}
