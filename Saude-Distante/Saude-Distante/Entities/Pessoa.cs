using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Pessoa
    {
        //ATRIBUTOS

        public PessoaTipo PessoaTipo { get; set; }  //Profissional ou Paciente
        public string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public int Nif { get; set; }
        public string Email { get; set; }

        // CONSTRUTORES
        public Pessoa() 
        {

        }

        public Pessoa(PessoaTipo pessoaTipo, string nome, DateOnly dataNascimento, int nif, string email)
        {
            PessoaTipo = pessoaTipo;
            Nome = nome;
            DataNascimento = dataNascimento;
            Nif = nif;
            Email = email;
        }


        //MÉTODOS
        

    }
}
