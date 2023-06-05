using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Admin
    {
        //ATRIBUTOS
        public int IdAdmin { get; set; }
        public string NomeAdmin { get; set; }
        public string Email { get; set; }
        protected string Pass { get; set; }
        public List<Equipa> Equipas { get; set; }

        //CONSTRUTORES
        public Admin()
        {

        }

        public Admin(int idAdmin, string nomeAdmin, string email, string pass)
        {
            IdAdmin = idAdmin;
            NomeAdmin = nomeAdmin;
            Email = email;
            Pass = pass;
        }

        //MÉTODOS
        public void AddEquipa(Equipa equipa)
        {
            Equipas.Add(equipa);
        }
        public void RemoveEquipa(Equipa equipa)
        {
            Equipas.Remove(equipa);
        }


    }



}
