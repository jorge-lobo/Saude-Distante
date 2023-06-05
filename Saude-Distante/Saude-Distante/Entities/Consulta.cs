using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saude_Distante.Entities
{
    internal class Consulta
    {
        //ATRIBUTOS
        public int IdConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Local { get; set; }
        public Paciente Paciente { get; set; }

        //CONSTRUTORES

        public Consulta()
        {

        }

        public Consulta(int idConsulta, DateTime dataConsulta, string local, Paciente paciente)
        {
            IdConsulta = idConsulta;
            DataConsulta = dataConsulta;
            Local = local;
            Paciente = paciente;
        }

        //MÉTODOS

        //método para ler os dados da ficha de consulta
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Consulta #{IdConsulta}: ");
            sb.Append(DataConsulta.ToString("dd/MM/yyyy HH:mm") + " | ");
            sb.AppendLine("Localidade: " + Local);
            sb.AppendLine("DADOS DO PACIENTE:");
            sb.AppendLine("Nº de utente: " + Paciente.NumUtente);
            sb.AppendLine("Nome: " + Paciente.Nome);
            sb.AppendLine("Email: " + Paciente.Email);
            sb.Append("Altura: " + Paciente.Altura + "m | ");
            sb.AppendLine("Peso: " + Paciente.Peso + "kg");
            if (Paciente.ValorPad != 0)                                 //os valores de PAD, PAS e HTA só devem aparecer na ficha
            {                                                           //após o enfermeiro introduzir os valores
                sb.AppendLine("Valores PAD: " + Paciente.ValorPad + "mmHg");
                sb.AppendLine("Valores PAS: " + Paciente.ValorPas + "mmHg");
                sb.AppendLine("Hipertensão arterial: " + Paciente.Hta);
            }
            sb.AppendLine("__________________________________________________________________");

            return sb.ToString();

        }

    }
}
