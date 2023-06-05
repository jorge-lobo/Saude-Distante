using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Administrativo : Profissional
    {
        //ATRIBUTOS
        public int IdAdministrativo { get; set; }
        public List<Administrativo> Administrativos { get; set; } = new List<Administrativo>();

        //CONSTRUTORES

        public Administrativo()
        {

        }

        //construtor com herança de Profissional        
        public Administrativo(PessoaTipo pessoaTipo, string nome, DateOnly dataNascimento, int nif, string email, Profissao profissao, double vencimento, string pass, int idAdministrativo) 
            : base(pessoaTipo, nome, dataNascimento, nif, email, profissao, vencimento, pass)
        {
            IdAdministrativo = idAdministrativo;
        }

        //MÉTODOS
        public void AddAdministrativo(Administrativo adm)
        {
            Administrativos.Add(adm);
        }
        public void RemoveAdministrativo(Administrativo adm)
        {
            Administrativos.Remove(adm);
        }

        public double Filter(Equipa eqp, int idEquipa)
        {
            if (eqp.IdEquipa == idEquipa)
            {
                return eqp.VencimentoColab;
            }
            else
                return 0;

        }

    }
}
