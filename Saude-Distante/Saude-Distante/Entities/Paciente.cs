using Saude_Distante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Paciente : Pessoa
    {
        //ATRIBUTOS

        public int NumUtente { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public int ValorPad { get; set; }
        public int ValorPas { get; set; }
        public string Hta { get; set; }
        public int Colesterol { get; set; }
        public int Glicose { get; set; }


        //CONSTRUTORES 
        public Paciente() 
        {

        }

        //construtor com herança de Pessoa
        public Paciente(PessoaTipo pessoaTipo, string nome, DateOnly dataNascimento, int nif, string email, int numUtente, double altura, double peso, int valorPad, int valorPas, string hta, int colesterol, int glicose) 
            : base(pessoaTipo, nome, dataNascimento, nif, email)
        {
            NumUtente = numUtente;
            Altura = altura;
            Peso = peso;
            ValorPad = valorPad;
            ValorPas = valorPas;
            Hta = hta;
            Colesterol = colesterol;
            Glicose = glicose;
        }

        //MÉTODOS
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DADOS DO UTENTE:");
            sb.AppendLine("----------------");
            sb.AppendLine("Nome: " + Nome);
            sb.AppendLine("Número Utente: " + NumUtente);
            sb.AppendLine("Data Nascimento: " + DataNascimento);
            sb.AppendLine("NIF: " + Nif);
            sb.AppendLine("Email: " + Email);
            sb.Append("Altura: " + Altura);
            sb.AppendLine("m | Peso: " + Peso + "kg");
            sb.AppendLine("Valor Colesterol: " + Colesterol + "mg/dL");
            sb.AppendLine("Valor Glicose: " + Glicose + "mg/dL");
            sb.AppendLine("Valores PAD: " + ValorPad + "mmHg");
            sb.AppendLine("Valores PAS: " + ValorPas + "mmHg");
            sb.AppendLine("Hipertensão arterial: " + Hta);
            sb.AppendLine();
            sb.AppendLine("_____________________________________________");

            return sb.ToString();
        }
    }
}
