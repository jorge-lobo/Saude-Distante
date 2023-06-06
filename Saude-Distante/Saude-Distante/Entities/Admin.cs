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
        public List<Administrativo> Administrativos { get; set; } = new List<Administrativo>();
        public List<Enfermeiro> Enfermeiros { get; set; } = new List<Enfermeiro>();
        public List<Medico> Medicos { get; set; } = new List<Medico>();
        public List<Motorista> Motoristas { get; set; } = new List<Motorista>();

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

        public void AddAdministrativo(Administrativo adm)
        {
            Administrativos.Add(adm);
        }
        
        public void AddEnfermeiro(Enfermeiro enf)
        {
            Enfermeiros.Add(enf);
        }
        
        public void AddMedico(Medico med)
        {
            Medicos.Add(med);
        }
       
        public void AddMotorista(Motorista mot)
        {
            Motoristas.Add(mot);
        }
        
    }



}
