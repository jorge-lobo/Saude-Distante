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
        public string Posologia { get; set; }
        public char Activa { get; set; }

        //CONSTRUTORES

        public Medicacao()
        {
            
        }

        public Medicacao(string descricao, string posologia, char activa)
        {
            Descricao = descricao;
            Posologia = posologia;
            Activa = activa;
        }

    }

}
