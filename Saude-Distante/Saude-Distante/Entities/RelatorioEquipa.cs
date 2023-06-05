using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class RelatorioEquipa
    {
        //ATRIBUTOS
        public string Local { get; set; }
        public DateOnly DataDeslocacao { get; set; }
        public string Constituicao { get; set; }

        //CONSTRUTORES
        public RelatorioEquipa()
        {
            
        }

        public RelatorioEquipa(string local, DateOnly dataDeslocacao, string constituicao)
        {
            Local = local;
            DataDeslocacao = dataDeslocacao;
            Constituicao = constituicao;
        }

    }
}
