using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Enfermeiro : Profissional
    {
        public int IdEnfermeiro { get; set; }
        public string CedulaEnfermeiro { get; set; }
        public List<Enfermeiro> Enfermeiros { get; set; } = new List<Enfermeiro>();
        public List<Clinico> ReqEquipClinicos { get; set; }


        //CONSTRUTORES

        public Enfermeiro()
        {

        }

        //construtor com herança de Profissional
        public Enfermeiro(PessoaTipo pessoaTipo, string nome, DateOnly dataNascimento, int nif, string email, Profissao profissao, double vencimento, string pass, int idEnfermeiro, string cedulaEnfermeiro)
           : base(pessoaTipo, nome, dataNascimento, nif, email, profissao, vencimento, pass)
        {
            IdEnfermeiro = idEnfermeiro;
            CedulaEnfermeiro = cedulaEnfermeiro;
        }
       
        //MÉTODOS
        public void AddEnfermeiro(Enfermeiro enf)
        {
            Enfermeiros.Add(enf);
        }
        public void RemoveEnfermeiro(Enfermeiro enf)
        {
            Enfermeiros.Remove(enf);
        }


        
    }
}
