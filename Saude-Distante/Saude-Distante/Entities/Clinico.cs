using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Clinico : Equipamento
    {
        //ATRIBUTOS

        public string NomeMaterial { get; set; }
        public int Quantidade { get; set; }
        public int QtdReq { get; set; }
        public EstadoEquipamento EstadoMaterial { get; set; }
        public List<Clinico> Clinicos { get; set; }
        public List<Clinico> ReqEquipClinicos { get; set; }

        private Clinico reqEquipClinico;


        //CONSTRUTORES

        public Clinico()
        {

        }

        //construtor com herança de Equipamento
        public Clinico(int idEquipamento, TipoEquipamento tipoEquipamento, string nomeMaterial, int quantidade, EstadoEquipamento estadoMaterial)
            : base(idEquipamento, tipoEquipamento)
        {
            NomeMaterial = nomeMaterial;
            Quantidade = quantidade;
            EstadoMaterial = estadoMaterial;
        }

        //MÉTODOS
        
        public void AddReqClin(Clinico cl, int qtd)
        {
            ReqEquipClinicos.Add(reqEquipClinico);
        }
        

    }
}
