using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Saude_Distante.Entities
{
    internal class Motorista : Profissional
    {
        //ATRIBUTOS        
        public int IdMotorista { get; set; }
        public string NumCarta { get; set; }
        public string CartaMotorista { get; set; }
        public List<Motorista> Motoristas { get; set; } = new List<Motorista>();
        public List<Viatura> Viaturas { get; set; }

        //CONSTRUTORES
        public Motorista()
        {
            
        }

        //construtor com herança de Profissional
        public Motorista(PessoaTipo pessoaTipo, string nome, DateOnly dataNascimento, int nif, string email, Profissao profissao, double vencimento, string pass, int idMotorista, string numCarta, string cartaMotorista)
           : base(pessoaTipo, nome, dataNascimento, nif, email, profissao, vencimento, pass)
        {
            IdMotorista = idMotorista;
            NumCarta = numCarta;
            CartaMotorista = cartaMotorista;
        }
       
        //MÉTODOS
        public void AddMotorista(Motorista mot)
        {
            Motoristas.Add(mot);
        }
        public void RemoveMotorita(Motorista mot)
        {
            Motoristas.Remove(mot);
        }
        public void ReqViatura(Viatura reqViatura)
        {
            Viaturas.Add(reqViatura);
        }

        


    }
}
