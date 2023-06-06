using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Doenca
    {
        //  ATRIBUTOS

        public string NomeDoenca { get; set; }
        public DateOnly DataDiagnostico { get; set; }
        

        // CONSTRUTORES

        public Doenca()
        {

        }

        public Doenca(string nomeDoenca, DateOnly dataDiagnostico)
        {
            NomeDoenca = nomeDoenca;
            DataDiagnostico = dataDiagnostico;
            
        }

    }
}
