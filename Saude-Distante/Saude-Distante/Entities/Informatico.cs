using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Informatico : Equipamento
    {
        //ATRIBUTOS

        public string Designacao { get; set; }
        public string Marca { get; set; }
        public EstadoEquipamento EstadoEquipamento { get; set; }

        //CONSTRUTORES

        public Informatico()
        {

        }

        //construtor com herança de Equipamento
        public Informatico(int idEquipamento, TipoEquipamento tipoEquipamento, string designacao, string marca, EstadoEquipamento estadoEquipamento)
            : base(idEquipamento, tipoEquipamento)
        {
            Designacao = designacao;
            Marca = marca;
            EstadoEquipamento = estadoEquipamento;
        }








    }
}
