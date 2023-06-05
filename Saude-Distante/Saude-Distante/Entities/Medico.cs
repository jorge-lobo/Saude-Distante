using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Medico : Profissional
    {
        //ATRIBUTOS

        public int IdMedico { get; set; }
        public string CedulaMedico { get; set; }
        public List<Medico> Medicos { get; set; } = new List<Medico>();

        //CONSTRUTORES

        public Medico()
        {

        }

        //construtor com herança de Profissional
        public Medico(PessoaTipo pessoaTipo, string nome, DateOnly dataNascimento, int nif, string email, Profissao profissao, double vencimento, string pass, int idMedico, string cedulaMedico)
           : base(pessoaTipo, nome, dataNascimento, nif, email, profissao, vencimento, pass)
        {
            IdMedico = idMedico;
            CedulaMedico = cedulaMedico;
        }
      
        //MÉTODOS
        public void AddMedico(Medico med)
        {
            Medicos.Add(med);
        }
        public void RemoveMedico(Medico med)
        {
            Medicos.Remove(med);
        }
    }
}
