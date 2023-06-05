using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Profissional : Pessoa
    {
        //ATRIBUTOS

        public Profissao Profissao { get; set; }
        public double Vencimento { get; set; }
        public string Pass { get; set; }

        //CONSTRUTORES

        public Profissional()
        {
            
        }

        //construtor com herança de Pessoa
        public Profissional(PessoaTipo pessoaTipo, string nome, DateOnly dataNascimento, int nif, string email, Profissao profissao, double vencimento, string pass) 
            : base(pessoaTipo, nome, dataNascimento, nif, email)
        {
            Profissao = profissao;
            Vencimento = vencimento;
            Pass = pass;
        }


    }
}
