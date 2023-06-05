using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Viatura : Equipamento
    {
        //ATRIBUTOS

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public EstadoEquipamento EstadoViatura { get; set; }    //operacional ou a precisar de assistência
        public TipoViatura TipoViatura { get; set; }      //transporte de passageiros ou ambulante
        
        //CONSTRUTORES

        public Viatura()
        {

        }

        //construtor com herança de Equipamento
        public Viatura(int idEquipamento, TipoEquipamento tipoEquipamento, string marca, string modelo, string matricula, EstadoEquipamento estadoViatura, TipoViatura tipoViatura)
            : base(idEquipamento, tipoEquipamento)
        {
            Marca = marca;
            Modelo = modelo;
            Matricula = matricula;
            EstadoViatura = estadoViatura;
            TipoViatura = tipoViatura;
        }

        // MÉTODOS

        public override string ToString()
        {
            return "Viatura #" + IdEquipamento + ": " + Marca + " | " + Modelo + " | " + Matricula + " | Estado da viatura: " + EstadoViatura;
        }

        
       
    }
}
