using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Equipa
    {
        //ATRIBUTOS
        public int IdEquipa { get; set; }
        public string NomeColab { get; set; }
        public Profissao ProfissaoColab { get; set; }
        public double VencimentoColab { get; set; }
      
        //CONSTRUTORES

        public Equipa()
        {
            
        }

        public Equipa(int idEquipa)
        {
            IdEquipa = idEquipa;
        }

        public Equipa(int idEquipa, string nomeColab, Profissao profissaoColab, double vencimentoColab)
        {
            IdEquipa = idEquipa;
            NomeColab = nomeColab;
            ProfissaoColab = profissaoColab;
            VencimentoColab = vencimentoColab;
        }

        //MÉTODOS
        
        public void SumVencimentos()
        {
            Equipa equipa = new Equipa();
            equipa.SumVencimentos();
        }
     
    }
}
