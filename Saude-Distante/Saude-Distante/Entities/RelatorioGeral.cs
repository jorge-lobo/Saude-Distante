using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class RelatorioGeral
    {
        //ATRIBUTOS
        public List<Consulta> Consultas { get; set; } = new List<Consulta>();

        //CONSTRUTORES

        public RelatorioGeral()
        {
            
        }

        //MÉTODOS
        public void AddConsulta(Consulta consulta)
        {
            Consultas.Add(consulta);
        }
        public void RemoveConsulta(Consulta consulta)
        {
            Consultas.Remove(consulta);
        }









    }
}
