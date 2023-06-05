using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Medicacao
    {
        //ATRIBUTOS

        public string Descricao { get; set; }
        public string Prescricao { get; set; }
        public bool Activa { get; set; }

        //CONSTRUTORES

        public Medicacao()
        {
            
        }

        public Medicacao(string descricao, string prescricao, bool activa)
        {
            Descricao = descricao;
            Prescricao = prescricao;
            Activa = activa;
        }

    }

}
