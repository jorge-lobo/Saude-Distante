using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Equipamento
    {
        //ATRIBUTOS

        public int IdEquipamento { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }   //Viatura ou Clinico

        //CONSTRUTORES

        public Equipamento() 
        {

        }

        public Equipamento(int idEquipamento, TipoEquipamento tipoEquipamento)
        {
            IdEquipamento = idEquipamento;
            TipoEquipamento = tipoEquipamento;
        }

    }
}
