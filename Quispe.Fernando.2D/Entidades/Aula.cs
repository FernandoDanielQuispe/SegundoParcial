using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aula
    {
        private int idAula;
        private string salita;       

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

        public string Salita
        {
            get
            {
                return this.salita;
            }
            set
            {
                this.salita = value;
            }
        }
    }
}
