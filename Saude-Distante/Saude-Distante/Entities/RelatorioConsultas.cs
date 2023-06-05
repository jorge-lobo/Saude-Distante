using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class RelatorioConsultas
    {
        //ATRIBUTOS
        public DateOnly Data { get; set; }
        public List<ValorHTA> ValoresHTA { get; set; } = new List<ValorHTA>();

        //CONSTRUTORES
        public RelatorioConsultas()
        {
            
        }

        public RelatorioConsultas(DateOnly data)
        {
            Data = data;
        }

        //MÉTODOS
        public void AddValor(ValorHTA valor)
        {
            ValoresHTA.Add(valor);
        }
        public void RemoveValor(ValorHTA valor)
        {
            ValoresHTA.Remove(valor);
        }
        


    }
}
