using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using Saude_Distante.Entities;
using Saude_Distante.Entities.Enums;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics.CodeAnalysis;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Default;  //código que permite ler o símbolo do €
        CultureInfo CI = CultureInfo.InvariantCulture;      //atalho para substituir o CultureInfo.InvariantCulture

        //____________________________________________________________________________________________________________________

        // LISTAS:

        //criação da lista de viaturas
        List<Viatura> viaturas = new List<Viatura>();
        Viatura viatura1 = new Viatura(1, TipoEquipamento.Viatura, "Seat", "Leon", "42-TF-03", EstadoEquipamento.Disponível, TipoViatura.Ligeiro);
        Viatura viatura2 = new Viatura(2, TipoEquipamento.Viatura, "Renault", "Megane", "75-LX-41", EstadoEquipamento.Indisponível, TipoViatura.Ligeiro);
        Viatura viatura3 = new Viatura(3, TipoEquipamento.Viatura, "Volkswagen", "Crafter", "13-XP-66", EstadoEquipamento.Disponível, TipoViatura.Ambulante);
        Viatura viatura4 = new Viatura(4, TipoEquipamento.Viatura, "Toyota", "Proace", "70-ZZ-25", EstadoEquipamento.Disponível, TipoViatura.Ambulante);

        //inserir as viaturas na lista de Viaturas
        viaturas.Add(viatura1);
        viaturas.Add(viatura2);
        viaturas.Add(viatura3);
        viaturas.Add(viatura4);

        //criação da lista de requisição de viaturas
        List<Viatura> reqViaturas = new List<Viatura>();
        Viatura reqViatura1 = new Viatura(2, TipoEquipamento.Viatura, "Renault", "Megane", "75-LX-41", EstadoEquipamento.Indisponível, TipoViatura.Ligeiro);

        //inserir a viatura na lista de requisição de viaturas
        reqViaturas.Add(reqViatura1);

        //criação da lista de equipamentos informáticos
        List<Informatico> informaticos = new List<Informatico>();
        Informatico informatico1 = new Informatico(1, TipoEquipamento.Informático, "Computador", "LENOVO Ideapad 3", EstadoEquipamento.Disponível);
        Informatico informatico2 = new Informatico(2, TipoEquipamento.Informático, "Computador", "ASUS Vivobook", EstadoEquipamento.Disponível);
        Informatico informatico3 = new Informatico(3, TipoEquipamento.Informático, "Computador", "HP 15s", EstadoEquipamento.Indisponível);
        Informatico informatico4 = new Informatico(4, TipoEquipamento.Informático, "Computador", "ACER Aspire", EstadoEquipamento.Disponível);

        //inserir os equipamentos na lista de equipamentos Informaticos
        informaticos.Add(informatico1);
        informaticos.Add(informatico2);
        informaticos.Add(informatico3);
        informaticos.Add(informatico4);

        //criação da lista de requisição de equipamentos informáticos
        List<Informatico> reqEquipInformaticos = new List<Informatico>();
        Informatico reqEquipInformatico1 = new Informatico(3, TipoEquipamento.Informático, "Computador", "HP 15s", EstadoEquipamento.Indisponível);

        //inserir a viatura na lista de requisição de equipamento informático
        reqEquipInformaticos.Add(reqEquipInformatico1);

        //criação da lista de equipamentos clínicos
        List<Clinico> clinicos = new List<Clinico>();
        Clinico clinico1 = new Clinico(1, TipoEquipamento.Clínico, "Estetoscópio", 15, EstadoEquipamento.Disponível);
        Clinico clinico2 = new Clinico(2, TipoEquipamento.Clínico, "Esfigmomanómetro", 15, EstadoEquipamento.Disponível);
        Clinico clinico3 = new Clinico(3, TipoEquipamento.Clínico, "Tiras Aval. Colesterol", 50, EstadoEquipamento.Disponível);
        Clinico clinico4 = new Clinico(4, TipoEquipamento.Clínico, "Tiras Aval. Glicose", 50, EstadoEquipamento.Disponível);

        //inserir os equipamentos na lista de equipamentos Informaticos
        clinicos.Add(clinico1);
        clinicos.Add(clinico2);
        clinicos.Add(clinico3);
        clinicos.Add(clinico4);

        //criação da lista de requisição de equipamentos clínicos
        List<Clinico> reqEquipClinicos = new List<Clinico>();
        Clinico reqEquipClinico1 = new Clinico(1, TipoEquipamento.Clínico, "Estetoscópio", 15, EstadoEquipamento.Disponível);
        Clinico reqEquipClinico2 = new Clinico(2, TipoEquipamento.Clínico, "Esfigmomanómetro", 15, EstadoEquipamento.Disponível);
        Clinico reqEquipClinico3 = new Clinico(3, TipoEquipamento.Clínico, "Tiras Aval. Colesterol", 50, EstadoEquipamento.Disponível);
        Clinico reqEquipClinico4 = new Clinico(4, TipoEquipamento.Clínico, "Tiras Aval. Glicose", 50, EstadoEquipamento.Disponível);

        //inserir a viatura na lista de requisição de equipamento clínico
        /* reqEquipClinicos.Add(reqEquipClinico1);
         reqEquipClinicos.Add(reqEquipClinico2);
         reqEquipClinicos.Add(reqEquipClinico3);
         reqEquipClinicos.Add(reqEquipClinico4);
        */

        //criação de lista de pacientes
        List<Paciente> pacientes = new List<Paciente>();
        Paciente paciente1 = new Paciente(PessoaTipo.Paciente, "Vera Lemos", new DateOnly(1965, 02, 15), 125366912, "vera-lemos@gmail.com", 120231303, 1.62, 52, 101, 163, "HTA Grau II", 192, 82);
        Paciente paciente2 = new Paciente(PessoaTipo.Paciente, "Luís Alves", new DateOnly(1986, 12, 03), 235666546, "luis.alves@gmail.com", 196454330, 1.88, 109, 123, 186, "HTA Grau III", 248, 133);
        Paciente paciente3 = new Paciente(PessoaTipo.Paciente, "Carla Mota", new DateOnly(1973, 06, 12), 156315465, "carlamota@gmail.com", 153300145, 1.74, 60, 86, 134, "Normal-Alta (1)", 194, 87);
        Paciente paciente4 = new Paciente(PessoaTipo.Paciente, "Rafael Torres", new DateOnly(1985, 03, 25), 164686660, "rafatorres@gmail.com", 456876766, 1.92, 88, 92, 150, "HTA Grau I", 220, 120);
        Paciente paciente5 = new Paciente(PessoaTipo.Paciente, "Maria Lima", new DateOnly(1996, 05, 09), 255654662, "malima@gmail.com", 232646464, 1.58, 49, 75, 110, "Óptima", 180, 90);
        Paciente paciente6 = new Paciente(PessoaTipo.Paciente, "César Antunes", new DateOnly(1943, 08, 29), 112564688, "tunescesar@gmail.com", 123563333, 1.69, 69, 87, 135, "Normal-Alta (1)", 205, 95);
        Paciente paciente7 = new Paciente(PessoaTipo.Paciente, "Carlota Gomes", new DateOnly(1985, 12, 15), 135466695, "carlota.gomes@gmail.com", 546113351, 1.72, 58, 82, 122, "Normal", 186, 89);
        Paciente paciente8 = new Paciente(PessoaTipo.Paciente, "Júlio Seixas", new DateOnly(1978, 10, 23), 564646460, "jules.xas@gmail.com", 135646334, 1.78, 70, 94, 150, "HTA Grau I", 203, 105);
        Paciente paciente9 = new Paciente(PessoaTipo.Paciente, "Teresa Ramos", new DateOnly(1985, 04, 01), 156315465, "teresinharamos@gmail.com", 135666320, 1.54, 47, 75, 110, "Óptima", 190, 86);
        Paciente paciente10 = new Paciente(PessoaTipo.Paciente, "Vasco Lopes", new DateOnly(1963, 02, 25), 126864663, "vascolopes@gmail.com", 146461133, 1.82, 75, 120, 190, "HTA Grau III", 232, 160);
        Paciente paciente11 = new Paciente(PessoaTipo.Paciente, "Mafalda Teles", new DateOnly(1966, 10, 07), 213576876, "teles.mafalda@gmail.com", 654132323, 1.63, 56, 87, 145, "Hipertensão Sistólica Isolada (2)", 203, 65);
        Paciente paciente12 = new Paciente(PessoaTipo.Paciente, "Óscar Pacheco", new DateOnly(1953, 02, 22), 135468333, "o_scar@gmail.com", 465433310, 1.84, 77, 103, 165, "HTA Grau II", 206, 97);

        //inserir os paceintes na lista
        pacientes.Add(paciente1);
        pacientes.Add(paciente2);
        pacientes.Add(paciente3);
        pacientes.Add(paciente4);
        pacientes.Add(paciente5);
        pacientes.Add(paciente6);
        pacientes.Add(paciente7);
        pacientes.Add(paciente8);
        pacientes.Add(paciente9);
        pacientes.Add(paciente10);
        pacientes.Add(paciente11);
        pacientes.Add(paciente12);

        //criação da lista de consultas
        List<Consulta> consultas = new List<Consulta>();

        Consulta consulta1 = new Consulta(1, new DateTime(2023, 06, 01, 10, 23, 24), "Famalicão", new Paciente(PessoaTipo.Paciente, "Vera Lemos", new DateOnly(1965, 02, 15), 125366912, "vera-lemos@gmail.com", 120231303, 1.62, 52, 101, 163, "HTA Grau II", 192, 82));
        Consulta consulta2 = new Consulta(2, new DateTime(2023, 06, 01, 15, 01, 56), "Braga", new Paciente(PessoaTipo.Paciente, "Luís Alves", new DateOnly(1986, 12, 03), 235666546, "luis.alves@gmail.com", 196454330, 1.88, 109, 123, 186, "HTA Grau III", 248, 133));
        Consulta consulta3 = new Consulta(3, new DateTime(2023, 06, 02, 09, 42, 33), "Fafe", new Paciente(PessoaTipo.Paciente, "Carla Mota", new DateOnly(1973, 06, 12), 156315465, "carlamota@gmail.com", 153300145, 1.74, 60, 86, 134, "Normal-Alta (1)", 194, 87));
        Consulta consulta4 = new Consulta(4, new DateTime(2023, 06, 02, 11, 09, 03), "Guimarães", new Paciente(PessoaTipo.Paciente, "Rafael Torres", new DateOnly(1985, 03, 25), 164686660, "rafatorres@gmail.com", 456876766, 1.92, 88, 92, 150, "HTA Grau I", 220, 120));
        Consulta consulta5 = new Consulta(5, new DateTime(2023, 06, 05, 14, 05, 32), "Famalicão", new Paciente(PessoaTipo.Paciente, "Maria Lima", new DateOnly(1996, 05, 09), 255654662, "malima@gmail.com", 232646464, 1.58, 49, 75, 110, "Óptima", 180, 90));
        Consulta consulta6 = new Consulta(6, new DateTime(2023, 06, 06, 09, 58, 02), "Fafe", new Paciente(PessoaTipo.Paciente, "César Antunes", new DateOnly(1943, 08, 29), 112564688, "tunescesar@gmail.com", 123563333, 1.69, 69, 87, 135, "Normal-Alta (1)", 205, 95));
        Consulta consulta7 = new Consulta(7, new DateTime(2023, 06, 06, 11, 11, 41), "Braga", new Paciente(PessoaTipo.Paciente, "Carlota Gomes", new DateOnly(1985, 12, 15), 135466695, "carlota.gomes@gmail.com", 546113351, 1.72, 58, 82, 122, "Normal", 186, 89));
        Consulta consulta8 = new Consulta(8, new DateTime(2023, 06, 07, 10, 05, 02), "Fafe", new Paciente(PessoaTipo.Paciente, "Júlio Seixas", new DateOnly(1978, 10, 23), 564646460, "jules.xas@gmail.com", 135646334, 1.78, 70, 94, 150, "HTA Grau I", 203, 105));
        Consulta consulta9 = new Consulta(9, new DateTime(2023, 06, 09, 09, 34, 57), "Guimarães", new Paciente(PessoaTipo.Paciente, "Teresa Ramos", new DateOnly(1985, 04, 01), 156315465, "teresinharamos@gmail.com", 135666320, 1.54, 47, 75, 110, "Óptima", 190, 86));
        Consulta consulta10 = new Consulta(10, new DateTime(2023, 06, 09, 11, 46, 10), "Braga", new Paciente(PessoaTipo.Paciente, "Vasco Lopes", new DateOnly(1963, 02, 25), 126864663, "vascolopes@gmail.com", 146461133, 1.82, 75, 120, 190, "HTA Grau III", 232, 160));
        Consulta consulta11 = new Consulta(11, new DateTime(2023, 06, 09, 16, 42, 01), "Guimarães", new Paciente(PessoaTipo.Paciente, "Mafalda Teles", new DateOnly(1966, 10, 07), 213576876, "teles.mafalda@gmail.com", 654132323, 1.63, 56, 87, 145, "Hipertensão Sistólica Isolada (2)", 203, 65));
        Consulta consulta12 = new Consulta(12, new DateTime(2023, 06, 12, 11, 05, 06), "Famalicão", new Paciente(PessoaTipo.Paciente, "Óscar Pacheco", new DateOnly(1953, 02, 22), 135468333, "o_scar@gmail.com", 465433310, 1.84, 77, 103, 165, "HTA Grau II", 206, 97));

        //inserir as consultas na lista de consultas
        consultas.Add(consulta1);
        consultas.Add(consulta2);
        consultas.Add(consulta3);
        consultas.Add(consulta4);
        consultas.Add(consulta5);
        consultas.Add(consulta6);
        consultas.Add(consulta7);
        consultas.Add(consulta8);
        consultas.Add(consulta9);
        consultas.Add(consulta10);
        consultas.Add(consulta11);
        consultas.Add(consulta12);

        string local = "Braga";     //variável default para o local. Este é alterado quando da designação da equipa

        //_____________________________________________________________________________________________________________

        // INTERVENIENTES:
        // criar admin
        Admin admin = new Admin(1, "Raúl Vale", "raul.vale_admin@smd.pt", "rvale123");

        // criar administrativo e adicionar à lista de administrativos
        List<Administrativo> administrativos = new List<Administrativo>();
        Administrativo administrativo1 = new Administrativo(PessoaTipo.Colaborador, "Inês Lima", new DateOnly(1988, 10, 15), 256312810, "ines.lima_adm@smd.pt", Profissao.Administrativo, 1100, "ilima123", 1);
        Administrativo administrativo2 = new Administrativo(PessoaTipo.Colaborador, "Tomás Machado", new DateOnly(1970, 01, 30), 175236001, "tomas.machado_adm@smd.pt", Profissao.Administrativo, 1800, "tmachado123", 2);
        Administrativo administrativo3 = new Administrativo(PessoaTipo.Colaborador, "Sofia Sá", new DateOnly(1996, 04, 02), 288632012, "sofia.sa_adm@smd.pt", Profissao.Administrativo, 1000, "ssa123", 3);
        Administrativo administrativo4 = new Administrativo(PessoaTipo.Colaborador, "Igor Lemos", new DateOnly(1984, 08, 03), 212056832, "igor.lemos_adm@smd.pt", Profissao.Administrativo, 1400, "ilemos123", 4);

        administrativos.Add(administrativo1);
        administrativos.Add(administrativo2);
        administrativos.Add(administrativo3);
        administrativos.Add(administrativo4);

        // criar enfermeiro e adicionar à lista de enfermeiros
        List<Enfermeiro> enfermeiros = new List<Enfermeiro>();
        Enfermeiro enfermeiro1 = new Enfermeiro(PessoaTipo.Colaborador, "Ivo Pires", new DateOnly(1989, 12, 22), 225339740, "ivo.pires_enf@smd.pt", Profissao.Enfermeiro, 1650, "ipires123", 1, "E45623");
        Enfermeiro enfermeiro2 = new Enfermeiro(PessoaTipo.Colaborador, "Mara Costa", new DateOnly(1975, 07, 01), 19852343, "mara.costa_enf@smd.pt", Profissao.Enfermeiro, 2000, "mcosta123", 2, "E38221");
        Enfermeiro enfermeiro3 = new Enfermeiro(PessoaTipo.Colaborador, "Joel Fonseca", new DateOnly(1999, 02, 13), 298343533, "joel.fonseca_enf@smd.pt", Profissao.Enfermeiro, 1400, "jfonseca123", 3, "E49123");
        Enfermeiro enfermeiro4 = new Enfermeiro(PessoaTipo.Colaborador, "Ana Fino", new DateOnly(1986, 07, 26), 213548437, "ana.fino_enf@smd.pt", Profissao.Enfermeiro, 1700, "afino123", 4, "E42031");

        enfermeiros.Add(enfermeiro1);
        enfermeiros.Add(enfermeiro2);
        enfermeiros.Add(enfermeiro3);
        enfermeiros.Add(enfermeiro4);

        // criar médico e adicionar à lista de médicos
        List<Medico> medicos = new List<Medico>();
        Medico medico1 = new Medico(PessoaTipo.Colaborador, "Lara Dias", new DateOnly(1982, 09, 08), 209011324, "lara.dias_med@smd.pt", Profissao.Médico, 4000, "ldias123", 1, "M35468");
        Medico medico2 = new Medico(PessoaTipo.Colaborador, "Vasco Sousa", new DateOnly(1976, 03, 31), 197532088, "vasco.sousa_med@smd.pt", Profissao.Médico, 4500, "vsousa123", 2, "M30193");
        Medico medico3 = new Medico(PessoaTipo.Colaborador, "Renata Setas", new DateOnly(1994, 06, 18), 265378611, "renata.setas_med@smd.pt", Profissao.Médico, 3800, "ldias123", 3, "M38465");
        Medico medico4 = new Medico(PessoaTipo.Colaborador, "Miguel Castro", new DateOnly(1980, 04, 21), 206634510, "miguel.castro_med@smd.pt", Profissao.Médico, 4200, "mcastro123", 4, "M33821");

        medicos.Add(medico1);
        medicos.Add(medico2);
        medicos.Add(medico3);
        medicos.Add(medico4);

        // criar motoristas e adicionar à lista de motoristas
        List<Motorista> motoristas = new List<Motorista>();
        Motorista motorista1 = new Motorista(PessoaTipo.Colaborador, "Tiago Faria", new DateOnly(1985, 11, 02), 206354786, "tiago.faria_mot@smd.pt", Profissao.Motorista, 950, "tfaria123", 1, "BR-653890", "BR-789411");
        Motorista motorista2 = new Motorista(PessoaTipo.Colaborador, "Cátia Gomes", new DateOnly(1992, 03, 14), 296453188, "catia.gomes_mot@smd.pt", Profissao.Motorista, 800, "cgomes123", 2, "P-465422", "P-489330");
        Motorista motorista3 = new Motorista(PessoaTipo.Colaborador, "Pedro Almeida", new DateOnly(1994, 01, 26), 235866221, "pedro.almeida_mot@smd.pt", Profissao.Motorista, 850, "palmeida123", 3, "VC-431321", "VC-541210");
        Motorista motorista4 = new Motorista(PessoaTipo.Colaborador, "Dora Miranda", new DateOnly(1973, 05, 11), 198725563, "dora.miranda_mot@smd.pt", Profissao.Motorista, 1000, "dmiranda123", 4, "L-784531", "L-7966523");

        motoristas.Add(motorista1);
        motoristas.Add(motorista2);
        motoristas.Add(motorista3);
        motoristas.Add(motorista4);

        // criar equipa e adicionar à lista de equipas
        List<Equipa> equipas = new List<Equipa>();
        //colaboradores equipa #1:
        Equipa equipa1 = new Equipa(1, "Igor Lemos", Profissao.Administrativo, 1400);
        Equipa equipa2 = new Equipa(1, "Ana Fino", Profissao.Enfermeiro, 1700);
        Equipa equipa3 = new Equipa(1, "Renata Setas", Profissao.Médico, 3500);
        Equipa equipa4 = new Equipa(1, "Pedro Almeida", Profissao.Motorista, 850);
        //colaboradores equipa #2:
        Equipa equipa5 = new Equipa(2, "Sofia Sá", Profissao.Administrativo, 1000);
        Equipa equipa6 = new Equipa(2, "Joel Fonseca", Profissao.Enfermeiro, 1400);
        Equipa equipa7 = new Equipa(2, "Miguel Castro", Profissao.Médico, 4200);
        Equipa equipa8 = new Equipa(2, "Dora Miranda", Profissao.Motorista, 1000);

        equipas.Add(equipa1);
        equipas.Add(equipa2);
        equipas.Add(equipa3);
        equipas.Add(equipa4);
        equipas.Add(equipa5);
        equipas.Add(equipa6);
        equipas.Add(equipa7);
        equipas.Add(equipa8);

        //_____________________________________________________________________________________________________________

        do          //início do loop da aplicação. sempre que se fizer logout a aplicação recomeça deste ponto
        {
            Console.BackgroundColor = ConsoleColor.White;       // altera o fundo para branco
            Console.ForegroundColor = ConsoleColor.Black;       // altera as letras para preto

            //título da aplicação
            Console.WriteLine("____________________________SAÚDE MENOS DISTANTE_________________________________________");
            Console.WriteLine();
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;       // retorna o fundo para preto
            Console.ForegroundColor = ConsoleColor.White;       // retorna as letras para branco

            //LOGIN
            Console.WriteLine("LOGIN");
            Console.WriteLine("-----");
            Console.Write("Email: ");
            string? email = Console.ReadLine();      //essencial para encaminhar cada profissional para a sua área
            Console.Write("Password: ");
            string? pass = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("______________________________________________________________________________________________");
            Console.WriteLine("______________________________________________________________________________________________");
            Console.WriteLine();

            //_________________________________________________________________________________________________________________

            //Secção do ADMIN - a parte final do email encaminha para a secção de admin (_admin@smd.pt)
            if (email.Contains("_admin@smd.pt"))
            {
                Console.WriteLine($"Olá {admin.NomeAdmin}!");
                Console.WriteLine("Bem-vindo à página de Administrador");
                Console.WriteLine();
                Console.WriteLine();

                int op;     //variante tem que estar fora do sistema do/while para ser reconhecido na pergunta como para para o loop
                            //Menu ADMIN:
                do
                {
                    Console.WriteLine("1 - Colaboradores | 2 - Equipas | 3 - Relatórios | 0 - Logout");
                    Console.Write("Seleccione uma opção: ");
                    op = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    int col;
                    //Sub-menu Colaboradores:
                    if (op == 1)
                    {
                        Console.WriteLine("COLABORADORES:");
                        Console.WriteLine("--------------");
                        //Sub-Menu -> Colaboradores
                        Console.WriteLine("1 - Criar Colaborador | 2 - Consultar Colaborador | 3 - Eliminar Colaborador");
                        Console.Write("Seleccione uma opção: ");
                        col = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        //Sub-secção - Criar colaborador
                        if (col == 1)
                        {
                            int cr_col;
                            Console.WriteLine("CRIAR COLABORADOR:");
                            Console.WriteLine("------------------");
                            // é necessário escolher primeiro a profissão, pois cada um tem os seus atributos
                            Console.WriteLine("1 - Administrativo | 2 - Enfermeiro | 3 - Médico | 4 - Motorista");
                            Console.Write("Seleccione a profissão: ");
                            cr_col = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //criar administrativo
                            if (cr_col == 1)
                            {
                                //formulário de criação de administrativo
                                Console.WriteLine("NOVO ADMINISTRATIVO - DADOS A INTRODUZIR:");
                                Console.WriteLine("-----------------------------------------");
                                int last_adm = administrativos.Count;
                                int idAdministrativo = last_adm + 1;
                                Console.Write("Primeiro nome: ");
                                string? pNome = Console.ReadLine();
                                Console.Write("Apelido: ");
                                string? uNome = Console.ReadLine();
                                string nome = pNome + " " + uNome;  //concatenar o primeiro nome com o apelido
                                Console.Write("Data de nascimento (dd/MM/aaaa): ");
                                DateOnly dataNascimento = DateOnly.Parse(Console.ReadLine());

                                //atribuição automática do email ao colaborador
                                //concatenar primeiro nome com o apelido e a extenção de email
                                //depois é necessário colocar a string em minúsculas
                                email = (pNome + "." + uNome + "_adm@smd.pt").ToLower();

                                //atribuição automática de password
                                //concatenar a primeira letra do primeiro nome com o apelido, com um "." no meio,
                                //finalizando com 123, tudo em minúsculas
                                pass = (pNome?.Substring(0, 1) + uNome + 123).ToLower();

                                // método para substituir os caracteres especiais por caracteres universais
                                char[] str = ReplaceSpecials(ref email);
                                str = ReplaceSpecials(ref pass);

                                Console.Write("NIF: ");
                                int nif = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Vencimento: ");
                                double vencimento = Convert.ToDouble(Console.ReadLine(), CI);
                                Console.WriteLine();

                                //valores de atributos já pré-definidos referentes a esta profissão
                                Profissao profissao = Profissao.Administrativo;
                                PessoaTipo pessoaTipo = PessoaTipo.Colaborador;

                                //adicionar o colaborador criado à tabela de administrativos
                                Administrativo adm = new Administrativo(pessoaTipo, nome, dataNascimento, nif, email, profissao, vencimento, pass, idAdministrativo);
                                adm.AddAdministrativo(adm);

                                //mensagem a confirmar a criação da ficha do administrativo e impressão dos dados introduzidos
                                Console.WriteLine("Colaborador criado com sucesso:");
                                Console.WriteLine($" {adm.IdAdministrativo}: {adm.Nome} | {adm.DataNascimento} | {adm.Email} | {adm.Pass} | {adm.Nif} | {adm.Vencimento.ToString("F2", CI)}€");
                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                            }

                            //criar enfermeiro
                            else if (cr_col == 2)
                            {
                                //formulário de criação de enfermeiro
                                Console.WriteLine("NOVO ENFERMEIRO - DADOS A INTRODUZIR:");
                                Console.WriteLine("-------------------------------------");
                                int last_enf = enfermeiros.Count;
                                int idEnfermeiro = last_enf + 1;
                                Console.Write("Primeiro nome: ");
                                string? pNome = Console.ReadLine();
                                Console.Write("Apelido: ");
                                string? uNome = Console.ReadLine();
                                string nome = pNome + " " + uNome;  //concatenar o primeiro nome com o apelido
                                Console.Write("Data de nascimento (dd/MM/aaaa): ");
                                DateOnly dataNascimento = DateOnly.Parse(Console.ReadLine());

                                //atribuição automática do email ao colaborador
                                //concatenar primeiro nome com o apelido e a extenção de email
                                //depois é necessário colocar a string em minúsculas
                                email = (pNome + "." + uNome + "_enf@smd.pt").ToLower();

                                //atribuição automática de password
                                //concatenar a primeira letra do primeiro nome com o apelido, com um "." no meio,
                                //finalizando com 123, tudo em minúsculas
                                pass = (pNome?.Substring(0, 1) + uNome + 123).ToLower();

                                // método para substituir os caracteres especiais por caracteres universais
                                char[] str = ReplaceSpecials(ref email);
                                str = ReplaceSpecials(ref pass);

                                Console.Write("NIF: ");
                                int nif = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Vencimento: ");
                                double vencimento = Convert.ToDouble(Console.ReadLine(), CI);
                                Console.Write("Cédula de enfermeiro: ");
                                string? cedulaEnfermeiro = Console.ReadLine();
                                Console.WriteLine();

                                //valores de atributos já pré-definidos referentes a esta profissão
                                Profissao profissao = Profissao.Enfermeiro;
                                PessoaTipo pessoaTipo = PessoaTipo.Colaborador;

                                //adicionar o colaborador criado à tabela de enfermeiros
                                Enfermeiro enf = new Enfermeiro(pessoaTipo, nome, dataNascimento, nif, email, profissao, vencimento, pass, idEnfermeiro, cedulaEnfermeiro);
                                enf.AddEnfermeiro(enf);

                                //mensagem a confirmar a criação da ficha do enfermeiro e impressão dos dados introduzidos
                                Console.WriteLine("Colaborador criado com sucesso:");
                                Console.WriteLine($" {enf.IdEnfermeiro}: {enf.Nome} | {enf.CedulaEnfermeiro} | {enf.DataNascimento} | {enf.Email} | {enf.Pass} | {enf.Nif} | {enf.Vencimento.ToString("F2", CI)}€");
                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                            }

                            //criar médico
                            else if (cr_col == 3)
                            {
                                //formulário de criação de médico
                                Console.WriteLine("NOVO MÉDICO - DADOS A INTRODUZIR:");
                                Console.WriteLine("---------------------------------");
                                int last_med = medicos.Count;
                                int idMedico = last_med + 1;
                                Console.Write("Primeiro nome: ");
                                string? pNome = Console.ReadLine();
                                Console.Write("Apelido: ");
                                string? uNome = Console.ReadLine();
                                string nome = pNome + " " + uNome;  //concatenar o primeiro nome com o apelido
                                Console.Write("Data de nascimento (dd/MM/aaaa): ");
                                DateOnly dataNascimento = DateOnly.Parse(Console.ReadLine());

                                //atribuição automática do email ao colaborador
                                //concatenar primeiro nome com o apelido e a extenção de email
                                //depois é necessário colocar a string em minúsculas
                                email = (pNome + "." + uNome + "_med@smd.pt").ToLower();

                                //atribuição automática de password
                                //concatenar a primeira letra do primeiro nome com o apelido, com um "." no meio,
                                //finalizando com 123, tudo em minúsculas
                                pass = (pNome?.Substring(0, 1) + uNome + 123).ToLower();

                                // método para substituir os caracteres especiais por caracteres universais
                                char[] str = ReplaceSpecials(ref email);
                                str = ReplaceSpecials(ref pass);

                                Console.Write("NIF: ");
                                int nif = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Vencimento: ");
                                double vencimento = Convert.ToDouble(Console.ReadLine(), CI);
                                Console.Write("Cédula de médico: ");
                                string? cedulaMedico = Console.ReadLine();
                                Console.WriteLine();

                                //valores de atributos já pré-definidos referentes a esta profissão
                                Profissao profissao = Profissao.Médico;
                                PessoaTipo pessoaTipo = PessoaTipo.Colaborador;

                                //adicionar o colaborador criado à tabela de médicos
                                Medico med = new Medico(pessoaTipo, nome, dataNascimento, nif, email, profissao, vencimento, pass, idMedico, cedulaMedico);
                                med.AddMedico(med);

                                //mensagem a confirmar a criação da ficha do médico e impressão dos dados introduzidos
                                Console.WriteLine("Colaborador criado com sucesso:");
                                Console.WriteLine($" {med.IdMedico}: {med.Nome} | {med.CedulaMedico} | {med.DataNascimento} | {med.Email} | {med.Pass} | {med.Nif} | {med.Vencimento.ToString("F2", CI)}€");
                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                            }

                            //criar motorista
                            else if (cr_col == 4)
                            {
                                //formulário de criação de motorista
                                Console.WriteLine("NOVO MOTORISTA - DADOS A INTRODUZIR:");
                                Console.WriteLine("------------------------------------");
                                int last_mot = motoristas.Count;
                                int idMotorista = last_mot + 1;
                                Console.Write("Primeiro nome: ");
                                string? pNome = Console.ReadLine();
                                Console.Write("Apelido: ");
                                string? uNome = Console.ReadLine();
                                string nome = pNome + " " + uNome;  //concatenar o primeiro nome com o apelido
                                Console.Write("Data de nascimento (dd/MM/aaaa): ");
                                DateOnly dataNascimento = DateOnly.Parse(Console.ReadLine());

                                //atribuição automática do email ao colaborador
                                //concatenar primeiro nome com o apelido e a extenção de email
                                //depois é necessário colocar a string em minúsculas
                                email = (pNome + "." + uNome + "_mot@smd.pt").ToLower();

                                //atribuição automática de password
                                //concatenar a primeira letra do primeiro nome com o apelido, com um "." no meio,
                                //finalizando com 123, tudo em minúsculas
                                pass = (pNome?.Substring(0, 1) + uNome + 123).ToLower();

                                // método para substituir os caracteres especiais por caracteres universais
                                char[] str = ReplaceSpecials(ref email);
                                str = ReplaceSpecials(ref pass);

                                Console.Write("NIF: ");
                                int nif = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Vencimento: ");
                                double vencimento = Convert.ToDouble(Console.ReadLine(), CI);
                                Console.Write("Carta de condução: ");
                                string? numCarta = Console.ReadLine();
                                Console.Write("Carta de motorista: ");
                                string? cartaMotorista = Console.ReadLine();
                                Console.WriteLine();

                                //valores de atributos já pré-definidos referentes a esta profissão
                                Profissao profissao = Profissao.Motorista;
                                PessoaTipo pessoaTipo = PessoaTipo.Colaborador;

                                //adicionar o colaborador criado à tabela de médicos
                                Motorista mot = new Motorista(pessoaTipo, nome, dataNascimento, nif, email, profissao, vencimento, pass, idMotorista, numCarta, cartaMotorista);
                                mot.AddMotorista(mot);

                                //mensagem a confirmar a criação da ficha do motorista e impressão dos dados introduzidos
                                Console.WriteLine("Colaborador criado com sucesso:");
                                Console.WriteLine($" {mot.IdMotorista}: {mot.Nome} | {mot.NumCarta} | {mot.CartaMotorista} | {mot.DataNascimento} | {mot.Email} | {mot.Pass} | {mot.Nif} | {mot.Vencimento.ToString("F2", CI)}€");
                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                            }

                            else
                            {
                                Console.Write("Valor inserido não foi reconhecido no sistema." +
                                        "\nPor favor insira outro valor: ");
                                Console.WriteLine();
                            }
                        }

                        //Sub-secção - Consultar colaborador
                        else if (col == 2)
                        {
                            int cons_col;
                            Console.WriteLine("CONSULTAR COLABORADOR:");
                            Console.WriteLine("----------------------");
                            // é necessário escolher primeiro a profissão, pois cada um tem os seus atributos
                            Console.WriteLine("1 - Administrativo | 2 - Enfermeiro | 3 - Médico | 4 - Motorista");
                            Console.Write("Seleccione a profissão: ");
                            cons_col = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            if (cons_col == 1)
                            {
                                Console.WriteLine("Lista Administrativos:");
                                Console.WriteLine("----------------------");
                                // para consultar lista administrativos
                                foreach (Administrativo adm in administrativos)
                                {
                                    Console.WriteLine($" {adm.IdAdministrativo}: {adm.Nome} | {adm.DataNascimento} | {adm.Email} | {adm.Pass} | {adm.Nif} | {adm.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                            }

                            else if (cons_col == 2)
                            {
                                Console.WriteLine("Lista Enfermeiros:");
                                Console.WriteLine("------------------");
                                // para consultar lista enfermeiros
                                foreach (Enfermeiro enf in enfermeiros)
                                {
                                    Console.WriteLine($" {enf.IdEnfermeiro}: {enf.Nome} | {enf.CedulaEnfermeiro} | {enf.DataNascimento} | {enf.Email} | {enf.Pass} | {enf.Nif} | {enf.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                            }

                            else if (cons_col == 3)
                            {
                                Console.WriteLine("Lista Médicos:");
                                Console.WriteLine("--------------");
                                // para consultar lista médicos
                                foreach (Medico med in medicos)
                                {
                                    Console.WriteLine($" {med.IdMedico}: {med.Nome} | {med.CedulaMedico} | {med.DataNascimento} | {med.Email} | {med.Pass} | {med.Nif} | {med.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                            }

                            else if (cons_col == 4)
                            {
                                Console.WriteLine("Lista Motoristas:");
                                Console.WriteLine("-----------------");
                                // para consultar lista motoristas
                                foreach (Motorista mot in motoristas)
                                {
                                    Console.WriteLine($" {mot.IdMotorista}: {mot.Nome} | {mot.NumCarta} | {mot.CartaMotorista} | {mot.DataNascimento} | {mot.Email} | {mot.Pass} | {mot.Nif} | {mot.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                            }

                            else
                            {
                                Console.Write("Valor inserido não foi reconhecido no sistema." +
                                        "\nPor favor insira outro valor: ");
                                Console.WriteLine();
                            }

                        }

                        //Sub-secção - Eliminar colaborador
                        else if (col == 3)
                        {
                            int del_col;
                            Console.WriteLine("ELIMINAR COLABORADOR:");
                            Console.WriteLine("---------------------");
                            // é necessário escolher primeiro a profissão, pois cada um tem os seus atributos
                            Console.WriteLine("1 - Administrativo | 2 - Enfermeiro | 3 - Médico | 4 - Motorista");
                            Console.Write("Seleccione a profissão: ");
                            del_col = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //eliminar administrativo
                            if (del_col == 1)
                            {
                                Console.WriteLine("Lista Administrativos:");
                                Console.WriteLine("----------------------");
                                // para consultar lista administrativos
                                foreach (Administrativo adm in administrativos)
                                {
                                    Console.WriteLine($" {adm.IdAdministrativo}: {adm.Nome} | {adm.DataNascimento} | {adm.Email} | {adm.Pass} | {adm.Nif} | {adm.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();

                                Console.Write("Indique o Id do colaborador a eliminar: ");
                                int del_id = Convert.ToInt32(Console.ReadLine());

                                int index = del_id - 1;
                                //como o index de listas começa com o valor 0, é necessário esta fórmula para igualar o index ao ID
                                administrativos.RemoveAt(index);

                                Console.WriteLine("Lista Administrativos actualizada:");
                                Console.WriteLine("----------------------------------");
                                foreach (Administrativo adm in administrativos)
                                {
                                    Console.WriteLine($" {adm.IdAdministrativo}: {adm.Nome} | {adm.DataNascimento} | {adm.Email} | {adm.Pass} | {adm.Nif} | {adm.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                            }

                            //eliminar enfermeiro
                            else if (del_col == 2)
                            {
                                Console.WriteLine("Lista Enfermeiros:");
                                Console.WriteLine("------------------");
                                // para consultar lista enfermeiros
                                foreach (Enfermeiro enf in enfermeiros)
                                {
                                    Console.WriteLine($" {enf.IdEnfermeiro}: {enf.Nome} | {enf.CedulaEnfermeiro} | {enf.DataNascimento} | {enf.Email} | {enf.Pass} | {enf.Nif} | {enf.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();

                                Console.Write("Indique o Id do colaborador a eliminar: ");
                                int del_id = Convert.ToInt32(Console.ReadLine());

                                int index = del_id - 1;
                                //como o index de listas começa com o valor 0, é necessário esta fórmula para igualar o index ao ID
                                enfermeiros.RemoveAt(index);

                                Console.WriteLine("Lista Enfermeiros actualizada:");
                                Console.WriteLine("------------------------------");
                                foreach (Enfermeiro enf in enfermeiros)
                                {
                                    Console.WriteLine($" {enf.IdEnfermeiro}: {enf.Nome} | {enf.CedulaEnfermeiro} | {enf.DataNascimento} | {enf.Email} | {enf.Pass} | {enf.Nif} | {enf.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                            }

                            //eliminar médico
                            else if (del_col == 3)
                            {
                                Console.WriteLine("Lista Médicos:");
                                Console.WriteLine("--------------");
                                // para consultar lista médicos
                                foreach (Medico med in medicos)
                                {
                                    Console.WriteLine($" {med.IdMedico}: {med.Nome} | {med.CedulaMedico} | {med.DataNascimento} | {med.Email} | {med.Pass} | {med.Nif} | {med.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();

                                Console.Write("Indique o Id do colaborador a eliminar: ");
                                int del_id = Convert.ToInt32(Console.ReadLine());

                                int index = del_id - 1;
                                //como o index de listas começa com o valor 0, é necessário esta fórmula para igualar o index ao ID
                                medicos.RemoveAt(index);

                                Console.WriteLine("Lista Médicos actualizada:");
                                Console.WriteLine("--------------------------");
                                foreach (Medico med in medicos)
                                {
                                    Console.WriteLine($" {med.IdMedico}: {med.Nome} | {med.CedulaMedico} | {med.DataNascimento} | {med.Email} | {med.Pass} | {med.Nif} | {med.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                            }

                            //eliminar motorista
                            else if (del_col == 4)
                            {
                                Console.WriteLine("Lista Motoristas:");
                                Console.WriteLine("-----------------");
                                // para consultar lista motoristas
                                foreach (Motorista mot in motoristas)
                                {
                                    Console.WriteLine($" {mot.IdMotorista}: {mot.Nome} | {mot.NumCarta} | {mot.CartaMotorista} | {mot.DataNascimento} | {mot.Email} | {mot.Pass} | {mot.Nif} | {mot.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();

                                Console.Write("Indique o Id do colaborador a eliminar: ");
                                int del_id = Convert.ToInt32(Console.ReadLine());

                                int index = del_id - 1;
                                //como o index de listas começa com o valor 0, é necessário esta fórmula para igualar o index ao ID
                                motoristas.RemoveAt(index);

                                Console.WriteLine("Lista Motoristas actualizada:");
                                Console.WriteLine("-----------------------------");
                                foreach (Motorista mot in motoristas)
                                {
                                    Console.WriteLine($" {mot.IdMotorista}: {mot.Nome} | {mot.NumCarta} | {mot.CartaMotorista} | {mot.DataNascimento} | {mot.Email} | {mot.Pass} | {mot.Nif} | {mot.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                            }

                            else
                            {
                                Console.Write("Valor inserido não foi reconhecido no sistema." +
                                        "\nPor favor insira outro valor: ");
                                Console.WriteLine();
                            }
                        }
                    }

                    //Sub-Menu Equipas:
                    else if (op == 2)
                    {
                        int eq;
                        Console.WriteLine("EQUIPAS:");
                        Console.WriteLine("--------");
                        //Sub-Menu -> Equipas
                        Console.WriteLine("1 - Criar Equipa | 2 - Consultar Equipas | 3 - Designar Equipa | 4 - Eliminar Equipa");
                        Console.Write("Seleccione uma opção: ");
                        eq = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        //Sub-secção - Criar equipa
                        if (eq == 1)
                        {
                            for (int i = 1; i <= 1; i++)
                            {
                                //formulário de criação de equipa
                                Console.WriteLine("CRIAR EQUIPA - DADOS A INTRODUZIR:");
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine();

                                //obter o ID da última eqipa para incrementar automaticamente o ID na criação de nova equipa
                                int lastEqp = equipas.Count;
                                int idEquipa;
                                //se for a 1ª equipa a ser criada, este é o cálculo a efectuar
                                if (lastEqp == 0)
                                {
                                    idEquipa = lastEqp + 1;
                                }
                                //depois da 1ª equipa, é necessário alterar o cálculo,
                                //uma vez que cada colaborador assume um índex único.
                                //neste caso toma-se como referência o ID da última equipa
                                else
                                {
                                    var lastItem = equipas.Last();
                                    idEquipa = lastItem.IdEquipa + 1;
                                }

                                //1º vai-se seleccionar o administrativo
                                Console.WriteLine("SELECCIONAR O ADMINISTRATIVO:");
                                Console.WriteLine("-----------------------------");

                                // apresentar a lista administrativos para se poder escolher pelo ID
                                foreach (Administrativo adm in administrativos)
                                {
                                    Console.WriteLine($" {adm.IdAdministrativo}: {adm.Nome} | {adm.DataNascimento} | {adm.Email} | {adm.Pass} | {adm.Nif} | {adm.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                                Console.Write("Indique o ID do administrativo: ");
                                int id_adm = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                Administrativo? eq_adm = administrativos.Find(administrativo => administrativo.IdAdministrativo.Equals(id_adm));

                                //é seleccionado o colaborador e atribui-se a variável eq_adm e assim buscam-se os seus atributos
                                //para depois poderem ser copiados para uma nova variável a ser introduzida na equipa criada

                                string nomeColab = eq_adm.Nome;
                                Profissao profissaoColab = eq_adm.Profissao;
                                double vencimentoColab = eq_adm.Vencimento;

                                Equipa equipa = new Equipa(idEquipa, nomeColab, profissaoColab, vencimentoColab);
                                equipas.Add(equipa);
                                // administrativo está inserido na equipa

                                //depois selecciona-se o enfermeiro
                                Console.WriteLine("SELECCIONAR O ENFERMEIRO:");
                                Console.WriteLine("-------------------------");

                                // apresentar a lista enfermeiros para se poder escolher pelo ID
                                foreach (Enfermeiro enf in enfermeiros)
                                {
                                    Console.WriteLine($" {enf.IdEnfermeiro}: {enf.Nome} | {enf.DataNascimento} | {enf.Email} | {enf.Pass} | {enf.Nif} | {enf.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                                Console.Write("Indique o ID do enfermeiro: ");
                                int id_enf = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                Enfermeiro? eq_enf = enfermeiros.Find(enfermeiro => enfermeiro.IdEnfermeiro.Equals(id_enf));

                                //é seleccionado o colaborador e atribui-se a variável eq_enf e assim buscam-se os seus atributos
                                //para depois poderem ser copiados para uma nova variável a ser introduzida na equipa criada

                                nomeColab = eq_enf.Nome;
                                profissaoColab = eq_enf.Profissao;
                                vencimentoColab = eq_enf.Vencimento;

                                equipa = new Equipa(idEquipa, nomeColab, profissaoColab, vencimentoColab);
                                equipas.Add(equipa);
                                // enfermeiro está inserido na equipa

                                //depois selecciona-se o médico
                                Console.WriteLine("SELECCIONAR O MÉDICO:");
                                Console.WriteLine("---------------------");

                                // apresentar a lista médicos para se poder escolher pelo ID
                                foreach (Medico med in medicos)
                                {
                                    Console.WriteLine($" {med.IdMedico}: {med.Nome} | {med.DataNascimento} | {med.Email} | {med.Pass} | {med.Nif} | {med.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                                Console.Write("Indique o ID do médico: ");
                                int id_med = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                Medico? eq_med = medicos.Find(medico => medico.IdMedico.Equals(id_med));

                                //é seleccionado o colaborador e atribui-se a variável eq_med e assim buscam-se os seus atributos
                                //para depois poderem ser copiados para uma nova variável a ser introduzida na equipa criada

                                nomeColab = eq_med.Nome;
                                profissaoColab = eq_med.Profissao;
                                vencimentoColab = eq_med.Vencimento;

                                equipa = new Equipa(idEquipa, nomeColab, profissaoColab, vencimentoColab);
                                equipas.Add(equipa);
                                // médico está inserido na equipa

                                //por fim selecciona-se o motorista
                                Console.WriteLine("SELECCIONAR O MOTORISTA:");
                                Console.WriteLine("------------------------");

                                // apresentar a lista motorista para se poder escolher pelo ID
                                foreach (Motorista mot in motoristas)
                                {
                                    Console.WriteLine($" {mot.IdMotorista}: {mot.Nome} | {mot.DataNascimento} | {mot.Email} | {mot.Pass} | {mot.Nif} | {mot.Vencimento.ToString("F2", CI)}€");
                                }
                                Console.WriteLine();
                                Console.Write("Indique o ID do motorista: ");
                                int id_mot = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                Motorista? eq_mot = motoristas.Find(motorista => motorista.IdMotorista.Equals(id_mot));

                                //é seleccionado o colaborador e atribui-se a variável eq_mot e assim buscam-se os seus atributos
                                //para depois poderem ser copiados para uma nova variável a ser introduzida na equipa criada

                                nomeColab = eq_mot.Nome;
                                profissaoColab = eq_mot.Profissao;
                                vencimentoColab = eq_mot.Vencimento;

                                equipa = new Equipa(idEquipa, nomeColab, profissaoColab, vencimentoColab);
                                equipas.Add(equipa);
                                // motorista está inserido na equipa

                                //no final apresenta-se a lista actualizada
                                Console.WriteLine("Constituição da equipa:");
                                Console.WriteLine("-----------------------");

                                Console.WriteLine($"{eq_adm.Profissao}: {eq_adm.Nome} | {eq_adm.Vencimento.ToString("F2", CI)}€");
                                Console.WriteLine($"{eq_enf.Profissao}: {eq_enf.Nome} | {eq_enf.Vencimento.ToString("F2", CI)}€");
                                Console.WriteLine($"{eq_med.Profissao}: {eq_med.Nome} | {eq_med.Vencimento.ToString("F2", CI)}€");
                                Console.WriteLine($"{eq_mot.Profissao}: {eq_mot.Nome} | {eq_mot.Vencimento.ToString("F2", CI)}€");

                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                                Console.WriteLine();
                                // a equipa está completa e guardada. o formulário termina e volta ao menu do admin
                            }
                        }

                        //Sub-secção - Consultar equipas
                        else if (eq == 2)
                        {
                            Console.WriteLine();
                            Console.WriteLine("CONSTITUIÇÃO DAS EQUIPAS:");
                            Console.WriteLine("-------------------------");
                            foreach (Equipa eqp in equipas)
                            {
                                Console.WriteLine($"#{eqp.IdEquipa} | {eqp.ProfissaoColab}: {eqp.NomeColab} | {eqp.VencimentoColab.ToString("F2", CI)}€");
                            }

                            Console.WriteLine();
                            Console.WriteLine("______________________________________________________________________________________________");
                            Console.WriteLine();
                        }

                        //Sub-secção - Destacar equipa
                        else if (eq == 3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("DESIGNAR EQUIPA:");
                            Console.WriteLine("----------------");

                            Console.WriteLine();
                            Console.Write("Indicar o concelho: ");
                            local = Console.ReadLine();
                            Console.Write("Indicar a data (dd/MM/aaaa): ");
                            DateTime dataConsulta = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine();

                            //apresentação da lista de equipas para permitir a selecção
                            foreach (Equipa eqp in equipas)
                            {
                                Console.WriteLine($"#{eqp.IdEquipa} | {eqp.ProfissaoColab}: {eqp.NomeColab} | {eqp.VencimentoColab.ToString("F2", CI)}€");
                            }

                            Console.WriteLine();
                            Console.Write("Seleccione o ID da equipa: ");
                            int idEqpSelect = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine();

                            Console.WriteLine("RESUMO:");
                            Console.WriteLine("-------");
                            Console.WriteLine("Data: " + dataConsulta.ToString("dd/MM/yyyy") + " | Concelho: " + local);
                            Console.WriteLine();

                            Console.WriteLine("EQUIPA DESIGNADA:");
                            Console.WriteLine();

                            foreach (Equipa eqp in equipas)
                            {
                                if (eqp.IdEquipa.Equals(idEqpSelect))  //apresentar apenas os colaboradores com o idEquipa selecionado
                                {
                                    Console.WriteLine($"{eqp.ProfissaoColab}: {eqp.NomeColab}");
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine("______________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();

                            // mensagem automática a ser enviada para os colaboradores seleccionados
                            Console.WriteLine("EMAIL");
                            Console.WriteLine("-----");
                            Console.WriteLine();
                            Console.WriteLine("Caixa de Entrada:");
                            Console.WriteLine();
                            Console.WriteLine($"Caro colega," +
                                $"\nServe o presente email para comunicar que foi inserido na Equipa #{idEqpSelect}," +
                                $" para se apresentar em {local}, no dia {dataConsulta.ToString("dd/MM/yyyy")}." +
                                $"\n\nCONSTITUIÇÃO DA EQUIPA #{idEqpSelect}:");
                            foreach (Equipa eqp in equipas)
                            {
                                if (eqp.IdEquipa.Equals(idEqpSelect))  //apresentar apenas os colaboradores com o idEquipa selecionado
                                {
                                    Console.WriteLine($"{eqp.ProfissaoColab}: {eqp.NomeColab}");
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("______________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine();

                            // mensagem para os utentes
                            Console.WriteLine($"Caro utente," +
                                $"\nServe o presente email para comunicar que no dia {dataConsulta.ToString("dd/MM/yyyy")} " +
                                $"se encontrará uma equipa em {local} durante todo dia." +
                                $"\nO objectivo é realizar consultas com o intuito de registar informação de saúde das pessoas " +
                                $"e avaliar o risco cardiovascular na população.");

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("______________________________________________________________________________________________");
                            Console.WriteLine();

                        }


                        //Sub-secção - Eliminar equipa      
                        else if (eq == 4)
                        {
                            int del_eqp;
                            Console.WriteLine("ELIMINAR EQUIPA:");
                            Console.WriteLine("----------------");

                            foreach (Equipa eqp in equipas)
                            {
                                Console.WriteLine($"#{eqp.IdEquipa} | {eqp.ProfissaoColab}: {eqp.NomeColab} | {eqp.VencimentoColab.ToString("F2", CI)}€");
                            }

                            Console.WriteLine();
                            Console.Write("Seleccione o ID da equipa a eliminar: ");
                            del_eqp = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //cada equipa tem 4 elementos, logo não podemos eliminar pelo índex. Então optamos pelo IdEquipa seleccionado
                            equipas.RemoveAll(eqp => eqp.IdEquipa.Equals(del_eqp));

                            Console.WriteLine("ACTUALIZAÇÃO DA CONSTITUIÇÃO DAS EQUIPAS:");
                            Console.WriteLine("-----------------------------------------");
                            foreach (Equipa eqp in equipas)
                            {
                                Console.WriteLine($"#{eqp.IdEquipa} | {eqp.ProfissaoColab}: {eqp.NomeColab} | {eqp.VencimentoColab.ToString("F2", CI)}€");
                            }
                            Console.WriteLine();

                        }

                    }

                    else if (op == 3)
                    {
                        int rel;
                        Console.WriteLine("RELATÓRIOS:");
                        Console.WriteLine("-----------");
                        //Sub-Menu -> Relatórios
                        Console.WriteLine("1 - Consultas Efectuadas | 2 - Relatório Geral | 3 - Vencimentos | 4 - Equipamentos");
                        Console.Write("Seleccione uma opção: ");
                        rel = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        //Relatório Consultas Efectuadas
                        if (rel == 1)
                        {
                            ///////////////////////////////////////////////////////////////////////
                            Console.WriteLine("Relatórios de consultas:");
                            Console.WriteLine("------------------------");

                            Console.WriteLine("1 - Total de consultas | 2 - Consultas por concelho | 3 - Consultas por semana | 4 - Consultas por dia");
                            Console.Write("Seleccione uma opção: ");
                            //string rel_cons = int.TryParse(Console.ReadLine());
                            //Console.WriteLine();

                            //if (rel_cons == 1)
                            {

                            }









                        }


                        //Relatório Geral
                        else if (rel == 2)
                        {
                            //////////////////////////////////////////////////////////////////////////
                        }



                        //Relatório de vencimentos
                        else if (rel == 3)
                        {
                            Console.WriteLine("RELATÓRIO DE VENCIMENTOS");
                            Console.WriteLine("------------------------");
                            Console.WriteLine();

                            foreach (Equipa eqp in equipas)
                            {
                                Console.WriteLine($"#{eqp.IdEquipa} | {eqp.ProfissaoColab}: {eqp.NomeColab}");
                            }

                            Console.WriteLine();
                            Console.Write("Indique o ID da equipa: ");
                            int idEqpSelect = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.WriteLine($"Relatório da equipa #{idEqpSelect}");
                            Console.WriteLine("-----------------------------------");

                            foreach (Equipa eqp in equipas)
                            {
                                if (eqp.IdEquipa.Equals(idEqpSelect))  //apresentar apenas os colaboradores com o idEquipa selecionado
                                {
                                    Console.WriteLine($"{eqp.ProfissaoColab}: {eqp.NomeColab} | {eqp.VencimentoColab.ToString("F2", CI)}€");
                                }
                            }

                            //somatório dos vencimentos dos colaboradores da equipa seleccionada.
                            //aplicado um filtro para seleccionar apenas os valores desta equipa
                            double sumVencimento = equipas.Sum(eqp => Filtro(eqp, idEqpSelect));
                            Console.WriteLine("-------------------------------------------");

                            Console.WriteLine($"Total: {sumVencimento.ToString("F2", CI)}€");

                            Console.WriteLine();
                            Console.WriteLine("______________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine();
                        }

                        //Relatório Equipamentos
                        else if (rel == 4)
                        {
                            Console.WriteLine("RELATÓRIO DE EQUIPAMENTOS");
                            Console.WriteLine("------------------------");
                            Console.WriteLine();

                            Console.WriteLine("1 - Viaturas | 2 - Equipamentos Informáticos | 3 - Equipamentos Clínicos");
                            Console.WriteLine();
                            Console.Write("Indique o número da lista a consultar: ");
                            int l = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //Sub-secção viaturas requisitadas
                            if (l == 1)
                            {
                                Console.WriteLine("Lista de viaturas requisitadas");
                                Console.WriteLine();

                                foreach (Viatura reqViatura in reqViaturas)
                                {
                                    Console.WriteLine($"Viatura {reqViatura.IdEquipamento}: {reqViatura.Marca} | {reqViatura.Modelo} | {reqViatura.Matricula} | {reqViatura.TipoViatura}");
                                }

                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                                Console.WriteLine();
                                Console.WriteLine();

                            }

                            //Sub-secção equipamentos informáticos requisitados
                            else if (l == 2)
                            {
                                Console.WriteLine("Lista de equipamentos informáticos requisitados");
                                Console.WriteLine();

                                foreach (Informatico reqEquipInf in reqEquipInformaticos)
                                {
                                    Console.WriteLine($"Equipamento {reqEquipInf.IdEquipamento}: {reqEquipInf.Designacao} | {reqEquipInf.Marca}");
                                }

                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                                Console.WriteLine();
                                Console.WriteLine();

                            }

                            //Sub-secção equipamentos clínicos requisitados
                            else if (l == 3)
                            {
                                Console.WriteLine("Lista de equipamentos clínicos requisitados");
                                Console.WriteLine();

                                foreach (Clinico reqEquipClin in reqEquipClinicos)
                                {
                                    Console.WriteLine($"Equipamento {reqEquipClin.IdEquipamento}: {reqEquipClin.NomeMaterial} | Quantidade: {reqEquipClin.QtdReq}");
                                }

                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                                Console.WriteLine();
                                Console.WriteLine();

                            }

                        }

                    }

                    //LOGOUT
                    else if (op == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();

                    }

                    //mensagem de erro - valor errado
                    else
                    {
                        Console.Write("Valor inserido não foi reconhecido no sistema." +
                                "\nPor favor insira outro valor: ");
                        Console.WriteLine();
                    }

                }
                while (op != 0);
            }
            //_________________________________________________________________________________________________________________

            //Secção do ADMINISTRATIVO - a parte final do email encaminha para a secção de administrativo (_adm@smd.pt)
            else if (email.Contains("_adm@smd.pt"))
            {
                Administrativo? adm1 = administrativos.Find(administrativo => administrativo.Email.Equals(email));

                Console.WriteLine($"Olá {adm1?.Nome}!");
                Console.WriteLine("Bem-vindo à página de Administrativo");
                Console.WriteLine();
                Console.WriteLine();

                int op;     //variante tem que estar fora do sistema do/while para ser reconhecido na pergunta como para para o loop
                int logout = 0;

                //Menu ADMINISTRATIVO:
                do
                {
                    Console.WriteLine("1 - Criar Consulta | 2 - Equipamento | 3 - Criar Relatório Vencimento | 0 - Logout");
                    Console.Write("Seleccione uma opção: ");
                    op = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    switch (op)
                    {
                        //logouot
                        case 0:
                            logout = 0;
                            break;

                        //criar consulta
                        case 1:
                            //abertura da ficha de consulta
                            Console.WriteLine("FORMULÁRIO DE CONSULTA:");
                            Console.WriteLine("-----------------------");

                            //obter o ID da última consulta para incrementar automaticamente o ID na criação de nova consulta
                            int lastCons = consultas.Count;
                            int idConsulta = lastCons + 1;

                            DateTime dataConsulta = DateTime.Now;

                            Console.WriteLine("Dados do paciente:");
                            Console.Write("Nome: ");
                            string? nomeUtente = Console.ReadLine();
                            Console.Write("Data de nascimento (dd/MM/aaaa): ");
                            DateOnly dataNascimento = DateOnly.Parse(Console.ReadLine());
                            Console.Write("Número de utente: ");
                            int numUtente = Convert.ToInt32(Console.ReadLine());
                            Console.Write("NIF: ");
                            int nif = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Altura: ");
                            double altura =Convert.ToDouble(Console.ReadLine(), CI);
                            Console.Write("Peso: ");
                            double peso = Convert.ToDouble(Console.ReadLine(), CI);
                            Console.Write("Email: ");
                            string? emailUtente = Console.ReadLine();
                            Console.WriteLine();
                            Console.WriteLine("_________________");
                            Console.WriteLine("Fim do formulário");
                            Console.WriteLine();
                            Console.WriteLine();

                            //constante: Paciente
                            PessoaTipo pessoaTipo = PessoaTipo.Paciente;
                            //como ainda não foi feito o levantamento clínico,
                            //os dados clínicos inicialmente têm valor = 0
                            int valorPad = 0;
                            int valorPas = 0;
                            string? hta = null;
                            int colesterol = 0;
                            int glicose = 0;

                            // adicionar consulta à lista de consultas
                            Consulta cons = new Consulta(idConsulta, dataConsulta, local, new Paciente(pessoaTipo, nomeUtente, dataNascimento, nif, emailUtente, numUtente, altura, peso, valorPad, valorPas, hta, colesterol, glicose));
                            consultas.Add(cons);

                            //apresentação da ficha de consulta criada
                            Console.WriteLine("FICHA DE CONSULTA:");
                            Console.WriteLine("------------------");
                            Console.WriteLine(cons);

                            break;

                        //equipamentos
                        case 2:
                            Console.WriteLine("1 - Requisitar Equipamento | 2 - Actualizar Estado Equipamento");
                            Console.Write("Seleccione uma opção: ");
                            int c2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //Sub-menu Requisitar Equipamento:
                            if (c2 == 1)
                            {
                                Console.WriteLine("REQUISIÇÃO DE EQUIPAMENTO");
                                Console.WriteLine("-------------------------");
                                Console.WriteLine();
                                //apresenta os equipamentos presentes na lista de equipamentos informáticos
                                foreach (Informatico informatico in informaticos)
                                {
                                    Console.WriteLine($"Equipamento {informatico.IdEquipamento}: {informatico.Designacao} | {informatico.Marca} | Estado do equipamento: {informatico.EstadoEquipamento}");
                                }
                                Console.WriteLine();

                                //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                int last = informaticos.Count;

                                Console.Write("Seleccione o ID do equipamento a requisitar: ");
                                int id_ei = Convert.ToInt32(Console.ReadLine());

                                //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                while (id_ei > last || id_ei < 1)
                                {
                                    Console.WriteLine();
                                    Console.Write("Valor inserido não foi reconhecido no sistema." +
                                        "\nPor favor insira outro valor: ");
                                    id_ei = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                }

                                Console.WriteLine();
                                Informatico? i1 = informaticos.Find(informatico => informatico.IdEquipamento.Equals(id_ei));

                                //adiciona o equipamento seleccionado à lista de requisições de equipamentos informáticos
                                reqEquipInformaticos.Add(i1);

                                //actualização automática do estado da viatura para Indisponível
                                if (i1 != null)
                                {
                                    i1.EstadoEquipamento = EstadoEquipamento.Indisponível;
                                }

                                //apresentação da lista de requisição de equipamentos informaticos actualizada
                                Console.WriteLine("Lista de requisição de equipamentos actualizada:");
                                Console.WriteLine("------------------------------------------------");
                                foreach (Informatico reqEquipInf in reqEquipInformaticos)
                                {
                                    Console.WriteLine($"Equipamento {reqEquipInf.IdEquipamento}: {reqEquipInf.Designacao} | {reqEquipInf.Marca}");
                                }

                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                                Console.WriteLine();
                                Console.WriteLine();
                            }

                            //actualização do estado equipamentos informáticos
                            else if (c2 == 2)
                            {
                                Console.WriteLine("ACTUALIZAÇÃO DE ESTADO DE EQUIPAMENTOS");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine();
                                //apresenta os equipamentos presentes na lista de equipamentos informáticos
                                foreach (Informatico informatico in informaticos)
                                {
                                    Console.WriteLine($"Equipamento {informatico.IdEquipamento}: {informatico.Designacao} | {informatico.Marca} | Estado do equipamento: {informatico.EstadoEquipamento}");
                                }
                                Console.WriteLine();

                                //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                int last = informaticos.Count;

                                Console.Write("Seleccione o ID da viatura a actualizar: ");
                                int id_ei = Convert.ToInt32(Console.ReadLine());

                                //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                while (id_ei > last || id_ei < 1)
                                {
                                    Console.WriteLine();
                                    Console.Write("Valor inserido não foi reconhecido no sistema." +
                                        "\nPor favor insira outro valor: ");
                                    id_ei = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                }

                                Console.WriteLine();
                                Informatico? i1 = informaticos.Find(informatico => informatico.IdEquipamento.Equals(id_ei));

                                //actualização automática do estado do equipamento para Disponível
                                if (i1 != null)
                                {
                                    i1.EstadoEquipamento = EstadoEquipamento.Disponível;
                                }

                                //apresentação da lista de equipamentos informáticos actualizada
                                Console.WriteLine("Lista de equipamentos informáticos actualizada:");
                                Console.WriteLine("-----------------------------------------------");
                                foreach (Informatico informatico in informaticos)
                                {
                                    Console.WriteLine($"Equipamento {informatico.IdEquipamento}: {informatico.Designacao} | {informatico.Marca} | Estado do equipamento: {informatico.EstadoEquipamento}");
                                }
                                Console.WriteLine();

                                Console.WriteLine();
                                Console.WriteLine("______________________________________________________________________________________________");
                                Console.WriteLine();
                                Console.WriteLine();
                            }

                            break;

                        //relatório vencimento
                        case 3:

                            Console.WriteLine("RELATÓRIO DE VENCIMENTOS");
                            Console.WriteLine("------------------------");
                            Console.WriteLine();

                            foreach (Equipa eqp in equipas)
                            {
                                Console.WriteLine($"#{eqp.IdEquipa} | {eqp.ProfissaoColab}: {eqp.NomeColab}");
                            }

                            Console.WriteLine();
                            Console.Write("Indique o ID da equipa: ");
                            int idEqpSelect = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            foreach (Equipa eqp in equipas)
                            {
                                if (eqp.IdEquipa.Equals(idEqpSelect))  //apresentar apenas os colaboradores com o idEquipa selecionado
                                {
                                    Console.WriteLine($"{eqp.ProfissaoColab}: {eqp.NomeColab} | {eqp.VencimentoColab.ToString("F2", CI)}€");
                                }
                            }

                            //somatório dos vencimentos dos colaboradores da equipa seleccionada.
                            //aplicado um filtro para seleccionar apenas os valores desta equipa
                            double sumVencimento = equipas.Sum(eqp => Filtro(eqp, idEqpSelect));
                            Console.WriteLine("-------------------------------------------");

                            Console.WriteLine($"Total: {sumVencimento.ToString("F2", CI)}€");

                            Console.WriteLine();
                            Console.WriteLine("______________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine();

                            break;

                        default:
                            Console.Write("Valor inserido não foi reconhecido no sistema");
                            Console.WriteLine();
                            break;
                    }
                }
                while (op != 0);
            }

            //Secção do ENFERMEIRO - a parte final do email encaminha para a secção de enfermeiro (_enf@smd.pt)
            else if (email.Contains("_enf@smd.pt"))
            {
                Enfermeiro? enf1 = enfermeiros.Find(enfermeiro => enfermeiro.Email.Equals(email));

                Console.WriteLine($"Olá {enf1?.Nome}!");
                Console.WriteLine("Bem-vindo à página de Enfermeiro");
                Console.WriteLine();
                Console.WriteLine();

                int op;     //variante tem que estar fora do sistema do/while para ser reconhecido na pergunta como para para o loop
                int logout = 0;

                //Menu ENFERMEIRO:
                do
                {
                    Console.WriteLine("1 - Consulta | 2 - Equipamento | 0 - Logout");
                    Console.Write("Seleccione uma opção: ");
                    op = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    switch (op)
                    {
                        //logouot
                        case 0:
                            logout = 0;
                            break;

                        //consulta
                        case 1:
                            Console.WriteLine("1 - Consultar historial do paciente | 2 - Introduzir valores pressão arterial");
                            Console.Write("Seleccione uma opção: ");
                            int c1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //Sub-secção consultar historial paciente
                            if (c1 == 1)
                            {
                                Console.WriteLine("CONSULTA DADOS DE PACIENTE:");
                                Console.WriteLine("---------------------------");

                                foreach (Paciente paciente in pacientes)
                                {
                                    Console.WriteLine($"Nº Utente: {paciente.NumUtente} | {paciente.Nome} | {paciente.DataNascimento}");
                                }

                                Console.WriteLine();
                                Console.Write("Selecione o número de utente: ");
                                int numUtente = Convert.ToInt32(Console.ReadLine());

                                Paciente? p1 = pacientes.Find(paciente => paciente.NumUtente.Equals(numUtente));
                                Console.WriteLine(p1);

                            }
                            
                            //Sub-secção introduzir valores pressão arterial
                            else if (c1 == 2)
                            {
                                Console.WriteLine("FICHA DE CONSULTA:");
                                Console.WriteLine("------------------");

                                foreach (Consulta consulta in consultas)
                                {
                                    Console.WriteLine($"Consulta #{consulta.IdConsulta}: {consulta.Paciente.Nome} | Nº Utente: {consulta.Paciente.NumUtente}");
                                }
                                Console.WriteLine();

                                Console.Write("Selecione o número de consulta: ");
                                int id_cons = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                int last_cons = consultas.Count;
                                //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                while (id_cons > last_cons || id_cons < 1)
                                {
                                    Console.WriteLine();
                                    Console.Write("Valor inserido não foi reconhecido no sistema." +
                                        "\nPor favor insira outro valor: ");
                                    id_cons = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                }

                                Console.WriteLine();
                                Consulta? cons1 = consultas.Find(consulta => consulta.IdConsulta.Equals(id_cons));

                                Console.WriteLine(cons1);
                                Console.WriteLine();
                                Console.Write("Insira o valor de colesterol: ");
                                int colesterol = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Insira o valor de glicose: ");
                                int glicose = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Insira o valor da PAD: ");
                                int valorPad = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Insira o valor da PAS: ");
                                int valorPas = Convert.ToInt32(Console.ReadLine());

                                string? hta = null;

                                if (valorPad < 80 && valorPas < 120)
                                {
                                    hta = "Ótima";
                                }
                                else if (valorPad < 90 && valorPas >= 140)
                                {
                                    hta = "Hipertensão Sistólica Isolada (2)";
                                }
                                else if (valorPad >= 80 && valorPad < 85 || valorPas >= 120 && valorPas < 130)
                                {
                                    hta = "Normal";
                                }
                                else if (valorPad >= 85 && valorPad < 90 || valorPas >= 130 && valorPas < 140)
                                {
                                    hta = "Normal Alta (1)";
                                }
                                else if (valorPad >= 90 && valorPad < 100 || valorPas >= 140 && valorPas < 160)
                                {
                                    hta = "HTA Grau I";
                                }
                                else if (valorPad >= 100 && valorPad < 110 || valorPas >= 160 && valorPas < 180)
                                {
                                    hta = "HTA Grau II";
                                }
                                else if (valorPad >= 110 || valorPas >= 180)
                                {
                                    hta = "HTA Grau III";
                                }
                                else
                                {
                                    Console.WriteLine("Erro");
                                }
                                Console.WriteLine();
                                Console.WriteLine("Nível HTA: " + hta);

                                //actualização automática dos valors PAD, PAS e HTA na ficha de consulta
                                if (cons1 != null)
                                {
                                    cons1.Paciente.ValorPad = valorPad;
                                    cons1.Paciente.ValorPas = valorPas;
                                    cons1.Paciente.Hta = hta;
                                    cons1.Paciente.Colesterol = colesterol;
                                    cons1.Paciente.Glicose = glicose;
                                }

                                Console.WriteLine();
                                Console.WriteLine("Ficha de consulta actualizada:");
                                Console.WriteLine("------------------------------");
                                Console.WriteLine(cons1);
                                Console.WriteLine();
                                Console.WriteLine("Fim de consulta");
                                Console.WriteLine();
                                Console.WriteLine();

                            }

                            break;

                        //equipamentos
                        case 2:
                            Console.WriteLine("1 - Requisitar Equipamento | 2 - Actualizar Estado Equipamento");
                            Console.Write("Seleccione uma opção: ");
                            int c2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //Sub-secção Requisitar Equipamento:
                            if (c2 == 1)
                            {
                                Console.WriteLine("REQUISIÇÃO DE EQUIPAMENTO");
                                Console.WriteLine("-------------------------");
                                Console.WriteLine();
                                Console.WriteLine("1 - Equipamento Informático | 2 - Equipamento Clínico");
                                Console.Write("Seleccione uma opção: ");
                                int req = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                // req. equipamento informático
                                if (req == 1)
                                {
                                    //apresenta os equipamentos presentes na lista de equipamentos informáticos
                                    foreach (Informatico informatico in informaticos)
                                    {
                                        Console.WriteLine($"Equipamento {informatico.IdEquipamento}: {informatico.Designacao} | {informatico.Marca} | Estado do equipamento: {informatico.EstadoEquipamento}");
                                    }
                                    Console.WriteLine();

                                    //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                    int last = informaticos.Count;

                                    Console.Write("Seleccione o ID do equipamento a requisitar: ");
                                    int id_ei = Convert.ToInt32(Console.ReadLine());

                                    //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                    while (id_ei > last || id_ei < 1)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Valor inserido não foi reconhecido no sistema." +
                                            "\nPor favor insira outro valor: ");
                                        id_ei = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine();
                                    Informatico? i1 = informaticos.Find(informatico => informatico.IdEquipamento.Equals(id_ei));

                                    //adiciona o equipamento seleccionado à lista de requisições de equipamentos informáticos
                                    reqEquipInformaticos.Add(i1);

                                    //actualização automática do estado do equipamentp para Indisponível
                                    if (i1 != null)
                                    {
                                        i1.EstadoEquipamento = EstadoEquipamento.Indisponível;
                                    }

                                    //apresentação da lista de requisição de equipamentos informaticos actualizada
                                    Console.WriteLine("Lista de requisição de equipamentos actualizada:");
                                    Console.WriteLine("------------------------------------------------");
                                    foreach (Informatico reqEquipInf in reqEquipInformaticos)
                                    {
                                        Console.WriteLine($"Equipamento {reqEquipInf.IdEquipamento}: {reqEquipInf.Designacao} | {reqEquipInf.Marca}");
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine("______________________________________________________________________________________________");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }

                                //req. equipamento clínico
                                else if (req == 2)
                                {
                                    //apresenta os equipamentos presentes na lista de equipamentos clínicos
                                    foreach (Clinico clinico in clinicos)
                                    {
                                        Console.WriteLine($"Equipamento {clinico.IdEquipamento}: {clinico.NomeMaterial} | Qtd: {clinico.Quantidade} | Estado do equipamento: {clinico.EstadoMaterial}");
                                    }
                                    Console.WriteLine();

                                    //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                    int last = clinicos.Count;

                                    Console.Write("Seleccione o ID do equipamento a requisitar: ");
                                    int id_ec = Convert.ToInt32(Console.ReadLine());

                                    //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                    while (id_ec > last || id_ec < 1)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Valor inserido não foi reconhecido no sistema." +
                                            "\nPor favor insira outro valor: ");
                                        id_ec = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine();
                                    Clinico? cl = clinicos.Find(clinico => clinico.IdEquipamento.Equals(id_ec));

                                    int qtd = 0;

                                    if (cl != null)
                                    {
                                        Console.Write("Indique a quantidade: ");
                                        qtd = Convert.ToInt32(Console.ReadLine());

                                        //não permite que o número a requisitar seja maior que o número em stock
                                        if (qtd <= cl.Quantidade && qtd > 0)
                                        {
                                            //adiciona o equipamento seleccionado à lista de requisições de equipamentos clínicos
                                            //e a quantidade requerida
                                            cl.AddReqClin(cl, qtd);   ////// está a dar erro

                                            //cálculo para retirar as quantidades do equipamento à lista
                                            cl.Quantidade -= qtd;

                                            if (cl.Quantidade == 0)
                                            {
                                                cl.EstadoMaterial = EstadoEquipamento.Indisponível;
                                            }

                                            //apresentação da lista de requisição de equipamentos clínicos actualizada
                                            Console.WriteLine("Lista de requisição de equipamentos actualizada:");
                                            Console.WriteLine("------------------------------------------------");
                                            foreach (Clinico reqEquipClin in reqEquipClinicos)
                                            {
                                                Console.WriteLine($"Equipamento {reqEquipClin.IdEquipamento}: {reqEquipClin.NomeMaterial} | Quantidade: {qtd}");
                                            }

                                            Console.WriteLine();
                                            Console.WriteLine("______________________________________________________________________________________________");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                        }

                                        //se o número a requisitar for maior que o número em stock
                                        else
                                        {
                                            Console.WriteLine("Número em stock insuficiente. Tente outra quantidade: ");
                                            qtd = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.Write("Valor inserido não foi reconhecido no sistema." +
                                        "\nPor favor insira outro valor: ");
                                }

                            }

                            //Sub-secção Actualizar Estado Equipamento:
                            else if (c2 == 2)
                            {
                                Console.WriteLine("ACTUALIZAÇÃO DE ESTADO DE EQUIPAMENTOS");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine();
                                Console.WriteLine("1 - Equipamento Informático | 2 - Equipamento Clínico");
                                Console.Write("Seleccione uma opção: ");
                                int req = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                //actualizar equipamento informático
                                if (req == 1)
                                {
                                    //apresenta os equipamentos presentes na lista de equipamentos informáticos
                                    foreach (Informatico informatico in informaticos)
                                    {
                                        Console.WriteLine($"Equipamento {informatico.IdEquipamento}: {informatico.Designacao} | {informatico.Marca} | Estado do equipamento: {informatico.EstadoEquipamento}");
                                    }
                                    Console.WriteLine();

                                    //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                    int last = informaticos.Count;

                                    Console.Write("Seleccione o ID do equipamento a actualizar: ");
                                    int id_ei = Convert.ToInt32(Console.ReadLine());

                                    //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                    while (id_ei > last || id_ei < 1)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Valor inserido não foi reconhecido no sistema." +
                                            "\nPor favor insira outro valor: ");
                                        id_ei = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine();
                                    Informatico? i1 = informaticos.Find(informatico => informatico.IdEquipamento.Equals(id_ei));

                                    //actualização automática do estado do equipamento para Disponível
                                    if (i1 != null)
                                    {
                                        i1.EstadoEquipamento = EstadoEquipamento.Disponível;
                                    }

                                    //apresentação da lista de equipamentos informáticos actualizada
                                    Console.WriteLine("Lista de equipamentos informáticos actualizada:");
                                    Console.WriteLine("-----------------------------------------------");
                                    foreach (Informatico informatico in informaticos)
                                    {
                                        Console.WriteLine($"Equipamento {informatico.IdEquipamento}: {informatico.Designacao} | {informatico.Marca} | Estado do equipamento: {informatico.EstadoEquipamento}");
                                    }
                                    Console.WriteLine();

                                    Console.WriteLine();
                                    Console.WriteLine("______________________________________________________________________________________________");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }

                                //actualizar equipamento clínico
                                else if (req == 2)
                                {
                                    //apresenta os equipamentos presentes na lista de equipamentos clinicos
                                    foreach (Clinico clinico in clinicos)
                                    {
                                        Console.WriteLine($"Equipamento {clinico.IdEquipamento}: {clinico.NomeMaterial} | Qtd: {clinico.Quantidade} | Estado do equipamento: {clinico.EstadoMaterial}");
                                    }
                                    Console.WriteLine();

                                    //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                    int last = clinicos.Count;

                                    Console.Write("Seleccione o ID do equipamento a actualizar: ");
                                    int id_ec = Convert.ToInt32(Console.ReadLine());

                                    //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                    while (id_ec > last || id_ec < 1)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Valor inserido não foi reconhecido no sistema." +
                                            "\nPor favor insira outro valor: ");
                                        id_ec = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                    }

                                    Console.Write("Indique a quantidade: ");
                                    int qtd = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine();
                                    Clinico? cl1 = clinicos.Find(clinico => clinico.IdEquipamento.Equals(id_ec));

                                    //cálculo para repor quantidade na lista
                                    int nQtd = cl1.Quantidade + qtd;

                                    if (cl1 != null)
                                    {
                                        cl1.Quantidade = nQtd;
                                        cl1.QtdReq += req;
                                        cl1.EstadoMaterial = EstadoEquipamento.Disponível;
                                    }

                                    Console.WriteLine("Lista de equipamentos clínicos requisitados:");
                                    Console.WriteLine("-------------------------------------------");
                                    foreach (Clinico reqEquipClinico in reqEquipClinicos)
                                    {
                                        Console.WriteLine($"Equipamento {reqEquipClinico.IdEquipamento}: {reqEquipClinico.NomeMaterial} | Quantidade: {reqEquipClinico.QtdReq}");
                                    }
                                    Console.WriteLine();

                                    Console.WriteLine();
                                    Console.WriteLine("______________________________________________________________________________________________");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }

                            }

                            break;

                        default:
                            Console.Write("Valor inserido não foi reconhecido no sistema");
                            Console.WriteLine();
                            break;
                    }
                }
                while (op != 0);
            }

            //Secção do MÉDICO - a parte final do email encaminha para a secção de médico (_med@smd.pt)
            else if (email.Contains("_med@smd.pt"))
            {
                Medico? med1 = medicos.Find(medico => medico.Email.Equals(email));

                Console.WriteLine($"Olá {med1.Nome}!");
                Console.WriteLine("Bem-vindo à página de Médico");
                Console.WriteLine();
                Console.WriteLine();

                int op;     //variante tem que estar fora do sistema do/while para ser reconhecido na pergunta como para para o loop
                int logout = 0;

                //Menu MÉDICO:
                do
                {
                    Console.WriteLine("1 - Consulta | 2 - Equipamento | 0 - Logout");
                    Console.Write("Seleccione uma opção: ");
                    op = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    switch (op)
                    {
                        //logouot
                        case 0:
                            logout = 0;
                            break;

                        //consulta
                        case 1:
                            Console.WriteLine("1 - Consultar historial do paciente | 2 - Ficha de consulta");
                            Console.Write("Seleccione uma opção: ");
                            int c1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //Sub-secção consultar historial paciente
                            if (c1 == 1)
                            {
                                Console.WriteLine("CONSULTA DADOS DE PACIENTE:");
                                Console.WriteLine("---------------------------");

                                foreach (Paciente paciente in pacientes)
                                {
                                    Console.WriteLine($"Nº Utente: {paciente.NumUtente} | {paciente.Nome} | {paciente.DataNascimento}");
                                }

                                Console.WriteLine();
                                Console.Write("Selecione o número de utente: ");
                                int numUtente = Convert.ToInt32(Console.ReadLine());

                                Paciente? p1 = pacientes.Find(paciente => paciente.NumUtente.Equals(numUtente));
                                Console.WriteLine(p1);
                            }

                            //Sub-secção Ficha de consulta
                            else if (c1 == 2)
                            {
                                Console.WriteLine("FICHA DE CONSULTA:");
                                Console.WriteLine("------------------");

                                foreach (Consulta consulta in consultas)
                                {
                                    Console.WriteLine($"Consulta #{consulta.IdConsulta}: {consulta.Paciente.Nome} | Nº Utente: {consulta.Paciente.NumUtente}");
                                }
                                Console.WriteLine();


                                Console.Write("Selecione o número de consulta: ");
                                int id_cons = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                int last_cons = consultas.Count;
                                //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                while (id_cons > last_cons || id_cons < 1)
                                {
                                    Console.WriteLine();
                                    Console.Write("Valor inserido não foi reconhecido no sistema." +
                                        "\nPor favor insira outro valor: ");
                                    id_cons = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                }

                                Console.WriteLine();
                                Consulta? cons1 = consultas.Find(consulta => consulta.IdConsulta.Equals(id_cons));

                                Console.WriteLine(cons1);
                                Console.WriteLine();
                                Console.Write("Actualizar ficha de consulta (s/n): ");
                                char ficha = char.Parse(Console.ReadLine());

                                if (ficha == 's')
                                {
                                    Console.Write("Insira o valor de colesterol: ");
                                    int colesterol = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Insira o valor de glicose: ");
                                    int glicose = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Insira o valor da PAD: ");
                                    int valorPad = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Insira o valor da PAS: ");
                                    int valorPas = Convert.ToInt32(Console.ReadLine());

                                    string hta = null;

                                    if (valorPad < 80 && valorPas < 120)
                                    {
                                        hta = "Ótima";
                                    }
                                    else if (valorPad < 90 && valorPas >= 140)
                                    {
                                        hta = "Hipertensão Sistólica Isolada (2)";
                                    }
                                    else if (valorPad >= 80 && valorPad < 85 || valorPas >= 120 && valorPas < 130)
                                    {
                                        hta = "Normal";
                                    }
                                    else if (valorPad >= 85 && valorPad < 90 || valorPas >= 130 && valorPas < 140)
                                    {
                                        hta = "Normal Alta (1)";
                                    }
                                    else if (valorPad >= 90 && valorPad < 100 || valorPas >= 140 && valorPas < 160)
                                    {
                                        hta = "HTA Grau I";
                                    }
                                    else if (valorPad >= 100 && valorPad < 110 || valorPas >= 160 && valorPas < 180)
                                    {
                                        hta = "HTA Grau II";
                                    }
                                    else if (valorPad >= 110 || valorPas >= 180)
                                    {
                                        hta = "HTA Grau III";
                                    }
                                    else
                                    {
                                        Console.WriteLine("Erro");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Nível HTA: " + hta);

                                    //actualização automática dos valors PAD, PAS e HTA na ficha de consulta
                                    if (cons1 != null)
                                    {
                                        cons1.Paciente.ValorPad = valorPad;
                                        cons1.Paciente.ValorPas = valorPas;
                                        cons1.Paciente.Hta = hta;
                                        cons1.Paciente.Colesterol = colesterol;
                                        cons1.Paciente.Glicose = glicose;
                                    }
                                }

                                string? nomeDoenca = null;
                                string? descricao = null;
                                string? posologia = null;

                                //Sub-secção - doença
                                Console.WriteLine("Secção de doença:");
                                Console.WriteLine("-----------------");
                                Console.WriteLine();
                                Console.Write("Reportar doença (s/n): ");
                                char d = char.Parse(Console.ReadLine());
                                Console.WriteLine();

                                //mensegem de erro case seja introduzido um valor errado
                                if (d != 's' && d != 'S' && d == 'n' && d == 'N')
                                {
                                    Console.WriteLine("Valor errado. Digite novamente");
                                    Console.Write("Reportar doença (s/n): ");
                                    d = char.Parse(Console.ReadLine());
                                    Console.WriteLine();

                                }

                                //se não houver doença a reportar a consulta é finalizada
                                else if (d == 'n' || d == 'N')
                                {
                                    Console.WriteLine("______________________________________");
                                }

                                //caso houver doença
                                else if (d == 's' || d == 'S')
                                {

                                    Console.Write("Descrição da doença: ");
                                    nomeDoenca = Console.ReadLine();
                                    Console.WriteLine();

                                    Console.Write("Indique a data de diagnóstico (dd/MM/yyyyy): ");
                                    DateOnly dataDiagnostico = DateOnly.Parse(Console.ReadLine());

                                    //Sub-secção - medicação
                                    Console.WriteLine();
                                    Console.Write("Prescrever medicação (s/n): ");
                                    char m = char.Parse(Console.ReadLine());
                                    Console.WriteLine();

                                    //mensegem de erro case seja introduzido um valor errado
                                    if (m != 's' && m != 'S' && m == 'n' && m == 'N')
                                    {
                                        Console.WriteLine("Valor errado. Digite novamente");
                                        Console.Write("Prescrever medicação (s/n): ");
                                        m = char.Parse(Console.ReadLine());
                                        Console.WriteLine();
                                    }
                                    //se não houver medicação a prescrever a consulta é finalizada
                                    else if (m == 'n' || m == 'N')
                                    {
                                        Console.WriteLine("______________________________________");
                                    }

                                    //caso houver medicação
                                    else if (m == 's' || m == 'S')
                                    {
                                        Console.WriteLine();
                                        Console.Write("Já está a tomar a medicação (s/n): ");
                                        char activa = char.Parse(Console.ReadLine());

                                        //mensegem de erro case seja introduzido um valor errado
                                        if (activa != 's' && activa != 'S' && activa == 'n' && activa == 'N')
                                        {
                                            Console.WriteLine("Valor errado. Digite novamente");
                                            Console.Write("Deseja nova prescição (s/n): ");
                                            m = char.Parse(Console.ReadLine());
                                            Console.WriteLine();
                                        }

                                        if (activa == 's' || activa == 'S')
                                        {
                                            Console.Write("Deseja nova prescição (s/n): ");
                                            char p = char.Parse(Console.ReadLine());

                                            //mensegem de erro case seja introduzido um valor errado
                                            if (p != 's' && p != 'S' && p == 'n' && p == 'N')
                                            {
                                                Console.WriteLine("Valor errado. Digite novamente");
                                                Console.Write("Deseja nova prescição (s/n): ");
                                                m = char.Parse(Console.ReadLine());
                                                Console.WriteLine();
                                            }

                                            if (p == 's' || p == 'S')
                                            {
                                                Console.Write("Descrição da medicação: ");
                                                descricao = Console.ReadLine();
                                                Console.Write("Posologia: ");
                                                posologia = Console.ReadLine();
                                                Console.WriteLine("______________________________________");
                                            }

                                            else if (p == 'n' || p == 'N')
                                            {
                                                Console.WriteLine("______________________________________");
                                            }

                                        }
                                        else if (activa == 'n' || activa == 'N')
                                        {
                                            Console.Write("Descrição da medicação: ");
                                            descricao = Console.ReadLine();
                                            Console.Write("Posologia: ");
                                            posologia = Console.ReadLine();
                                            Console.WriteLine();

                                            Console.WriteLine("______________________________________");
                                        }

                                    }

                                }

                                Console.WriteLine();
                                Console.WriteLine("Relatório da consulta:");
                                Console.WriteLine("----------------------");
                                Console.WriteLine(cons1);


                                if (nomeDoenca != null)
                                {
                                    Console.WriteLine("Doença: " + nomeDoenca);
                                    if (descricao != null)
                                    {
                                        Console.WriteLine("Medicação: " + descricao);
                                        Console.WriteLine("Posologia: " + posologia);
                                    }
                                }

                                Console.WriteLine();
                                Console.WriteLine("Fim de consulta");
                                Console.WriteLine("______________________________________");
                                Console.WriteLine();
                            }

                            break;

                        //equipamentos
                        case 2:
                            Console.WriteLine("1 - Requisitar Equipamento | 2 - Actualizar Estado Equipamento");
                            Console.Write("Seleccione uma opção: ");
                            int c2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            //Sub-secção Requisitar Equipamento:
                            if (c2 == 1)
                            {
                                Console.WriteLine("REQUISIÇÃO DE EQUIPAMENTO");
                                Console.WriteLine("-------------------------");
                                Console.WriteLine();
                                Console.WriteLine("1 - Equipamento Informático | 2 - Equipamento Clínico");
                                Console.Write("Seleccione uma opção: ");
                                int req = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                // req. equipamento informático
                                if (req == 1)
                                {
                                    //apresenta os equipamentos presentes na lista de equipamentos informáticos
                                    foreach (Informatico informatico in informaticos)
                                    {
                                        Console.WriteLine($"Equipamento {informatico.IdEquipamento}: {informatico.Designacao} | {informatico.Marca} | Estado do equipamento: {informatico.EstadoEquipamento}");
                                    }
                                    Console.WriteLine();

                                    //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                    int last = informaticos.Count;

                                    Console.Write("Seleccione o ID do equipamento a requisitar: ");
                                    int id_ei = Convert.ToInt32(Console.ReadLine());

                                    //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                    while (id_ei > last || id_ei < 1)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Valor inserido não foi reconhecido no sistema." +
                                            "\nPor favor insira outro valor: ");
                                        id_ei = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine();
                                    Informatico? i1 = informaticos.Find(informatico => informatico.IdEquipamento.Equals(id_ei));

                                    //adiciona o equipamento seleccionado à lista de requisições de equipamentos informáticos
                                    reqEquipInformaticos.Add(i1);

                                    //actualização automática do estado do equipamentp para Indisponível
                                    if (i1 != null)
                                    {
                                        i1.EstadoEquipamento = EstadoEquipamento.Indisponível;
                                    }

                                    //apresentação da lista de requisição de equipamentos informaticos actualizada
                                    Console.WriteLine("Lista de requisição de equipamentos actualizada:");
                                    Console.WriteLine("------------------------------------------------");
                                    foreach (Informatico reqEquipInf in reqEquipInformaticos)
                                    {
                                        Console.WriteLine($"Equipamento {reqEquipInf.IdEquipamento}: {reqEquipInf.Designacao} | {reqEquipInf.Marca}");
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine("______________________________________________________________________________________________");
                                    Console.WriteLine();
                                    Console.WriteLine();


                                }

                                //req. equipamento clínico
                                else if (req == 2)
                                {
                                    //apresenta os equipamentos presentes na lista de equipamentos clínicos
                                    foreach (Clinico clinico in clinicos)
                                    {
                                        Console.WriteLine($"Equipamento {clinico.IdEquipamento}: {clinico.NomeMaterial} | Qtd: {clinico.Quantidade} | Estado do equipamento: {clinico.EstadoMaterial}");
                                    }
                                    Console.WriteLine();

                                    //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                    int last = clinicos.Count;

                                    Console.Write("Seleccione o ID do equipamento a requisitar: ");
                                    int id_ec = Convert.ToInt32(Console.ReadLine());

                                    //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                    while (id_ec > last || id_ec < 1)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Valor inserido não foi reconhecido no sistema." +
                                            "\nPor favor insira outro valor: ");
                                        id_ec = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine();
                                    Clinico? cl = clinicos.Find(clinico => clinico.IdEquipamento.Equals(id_ec));

                                    int qtd = 0;

                                    if (cl != null)
                                    {
                                        Console.Write("Indique a quantidade: ");
                                        qtd = Convert.ToInt32(Console.ReadLine());

                                        //não permite que o número a requisitar seja maior que o número em stock
                                        if (qtd <= cl.Quantidade && qtd > 0)
                                        {
                                            //adiciona o equipamento seleccionado à lista de requisições de equipamentos clínicos
                                            //e a quantidade requerida
                                            cl.AddReqClin(cl, qtd);   ////// está a dar erro

                                            //cálculo para retirar as quantidades do equipamento à lista
                                            cl.Quantidade -= qtd;

                                            if (cl.Quantidade == 0)
                                            {
                                                cl.EstadoMaterial = EstadoEquipamento.Indisponível;
                                            }

                                            //apresentação da lista de requisição de equipamentos clínicos actualizada
                                            Console.WriteLine("Lista de requisição de equipamentos actualizada:");
                                            Console.WriteLine("------------------------------------------------");
                                            foreach (Clinico reqEquipClin in reqEquipClinicos)
                                            {
                                                Console.WriteLine($"Equipamento {reqEquipClin.IdEquipamento}: {reqEquipClin.NomeMaterial} | Quantidade: {qtd}");
                                            }

                                            Console.WriteLine();
                                            Console.WriteLine("______________________________________________________________________________________________");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                        }

                                        //se o número a requisitar for maior que o número em stock
                                        else
                                        {
                                            Console.WriteLine("Número em stock insuficiente. Tente outra quantidade: ");
                                            qtd = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.Write("Valor inserido não foi reconhecido no sistema." +
                                        "\nPor favor insira outro valor: ");
                                }
                            }

                            //Sub-secção Actualizar Estado Equipamento:
                            else if (c2 == 2)
                            {
                                Console.WriteLine("ACTUALIZAÇÃO DE ESTADO DE EQUIPAMENTOS");
                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine();
                                Console.WriteLine("1 - Equipamento Informático | 2 - Equipamento Clínico");
                                Console.Write("Seleccione uma opção: ");
                                int req = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                //actualizar equipamento informático
                                if (req == 1)
                                {
                                    //apresenta os equipamentos presentes na lista de equipamentos informáticos
                                    foreach (Informatico informatico in informaticos)
                                    {
                                        Console.WriteLine($"Equipamento {informatico.IdEquipamento}: {informatico.Designacao} | {informatico.Marca} | Estado do equipamento: {informatico.EstadoEquipamento}");
                                    }
                                    Console.WriteLine();

                                    //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                    int last = informaticos.Count;

                                    Console.Write("Seleccione o ID do equipamento a actualizar: ");
                                    int id_ei = Convert.ToInt32(Console.ReadLine());

                                    //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                    while (id_ei > last || id_ei < 1)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Valor inserido não foi reconhecido no sistema." +
                                            "\nPor favor insira outro valor: ");
                                        id_ei = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine();
                                    Informatico? i1 = informaticos.Find(informatico => informatico.IdEquipamento.Equals(id_ei));

                                    //actualização automática do estado do equipamento para Disponível
                                    if (i1 != null)
                                    {
                                        i1.EstadoEquipamento = EstadoEquipamento.Disponível;
                                    }

                                    //apresentação da lista de equipamentos informáticos actualizada
                                    Console.WriteLine("Lista de equipamentos informáticos actualizada:");
                                    Console.WriteLine("-----------------------------------------------");
                                    foreach (Informatico informatico in informaticos)
                                    {
                                        Console.WriteLine($"Equipamento {informatico.IdEquipamento}: {informatico.Designacao} | {informatico.Marca} | Estado do equipamento: {informatico.EstadoEquipamento}");
                                    }
                                    Console.WriteLine();

                                    Console.WriteLine();
                                    Console.WriteLine("______________________________________________________________________________________________");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }

                                //actualizar equipamento clínico
                                else if (req == 2)
                                {
                                    //apresenta os equipamentos presentes na lista de equipamentos clinicos
                                    foreach (Clinico clinico in clinicos)
                                    {
                                        Console.WriteLine($"Equipamento {clinico.IdEquipamento}: {clinico.NomeMaterial} | Qtd: {clinico.Quantidade} | Estado do equipamento: {clinico.EstadoMaterial}");
                                    }
                                    Console.WriteLine();

                                    //contar o número de itens na lista para delimitar a validação do número a seleccionar
                                    int last = clinicos.Count;

                                    Console.Write("Seleccione o ID do equipamento a actualizar: ");
                                    int id_ec = Convert.ToInt32(Console.ReadLine());

                                    //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                                    while (id_ec > last || id_ec < 1)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Valor inserido não foi reconhecido no sistema." +
                                            "\nPor favor insira outro valor: ");
                                        id_ec = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                    }

                                    Console.Write("Indique a quantidade: ");
                                    int qtd = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine();
                                    Clinico? cl1 = clinicos.Find(clinico => clinico.IdEquipamento.Equals(id_ec));

                                    //cálculo para repor quantidade na lista
                                    int nQtd = cl1.Quantidade + qtd;

                                    if (cl1 != null)
                                    {
                                        cl1.Quantidade = nQtd;
                                        cl1.EstadoMaterial = EstadoEquipamento.Disponível;
                                    }

                                    //apresentação da lista de equipamentos clínicos actualizada
                                    Console.WriteLine("Lista de equipamentos clínicos actualizada:");
                                    Console.WriteLine("-------------------------------------------");
                                    foreach (Clinico clinico in clinicos)
                                    {
                                        Console.WriteLine($"Equipamento {clinico.IdEquipamento}: {clinico.NomeMaterial} | Qtd: {clinico.Quantidade} | Estado do equipamento: {clinico.EstadoMaterial}");
                                    }
                                    Console.WriteLine();

                                    Console.WriteLine();
                                    Console.WriteLine("______________________________________________________________________________________________");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }

                            }

                            break;

                        default:
                            Console.Write("Valor inserido não foi reconhecido no sistema");
                            Console.WriteLine();
                            break;
                    }
                }
                while (op != 0);
            }

            //Secção do MOTORISTA - a parte final do email encaminha para a secção de motorista (_mot@smd.pt)
            else if (email.Contains("_mot@smd.pt"))
            {
                Motorista? mot1 = motoristas.Find(motorista => motorista.Email.Equals(email));

                Console.WriteLine($"Olá {mot1.Nome}!");
                Console.WriteLine("Bem-vindo à página de Motorista");
                Console.WriteLine();
                Console.WriteLine();

                int op;     //variante tem que estar fora do sistema do/while para ser reconhecido na pergunta como para para o loop
                int logout = 0;

                //Menu MOTORISTA:
                do
                {
                    Console.WriteLine("1 - Requisitar Viatura | 2 - Atualizar Estado de Viatura | 0 - Logout");
                    Console.Write("Seleccione uma opção: ");
                    op = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    switch (op)
                    {
                        //logouot
                        case 0:
                            logout = 0;
                            break;

                        //requisição de equipamento
                        case 1:
                            Console.WriteLine("REQUISIÇÃO DE EQUIPAMENTO");
                            Console.WriteLine("-------------------------");
                            Console.WriteLine();
                            //apresenta as viaturas presentes na lista de viaturas
                            foreach (Viatura viatura in viaturas)
                            {
                                Console.WriteLine($"Viatura {viatura.IdEquipamento}: {viatura.Marca} | {viatura.Modelo} | {viatura.Matricula} | Estado da viatura: {viatura.EstadoViatura}");
                            }

                            //contar o número de itens na lista para delimitar a validação do número a seleccionar
                            int last = viaturas.Count;

                            Console.WriteLine();
                            Console.Write("Seleccione o ID da viatura a requisitar: ");
                            int id_v = Convert.ToInt32(Console.ReadLine());

                            //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                            while (id_v > last || id_v < 1)
                            {
                                Console.WriteLine();
                                Console.Write("Valor inserido não foi reconhecido no sistema." +
                                    "\nPor favor insira outro valor: ");
                                id_v = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                            }

                            Console.WriteLine();
                            Viatura? v1 = viaturas.Find(viatura => viatura.IdEquipamento.Equals(id_v));

                            //adiciona a viatura seleccionada à lista de requisições de viaturas
                            reqViaturas.Add(v1);

                            //actualização automática do estado da viatura para Indisponível
                            if (v1 != null)
                            {
                                v1.EstadoViatura = EstadoEquipamento.Indisponível;
                            }

                            //apresentação da lista de requisição de viaturas actualizada
                            Console.WriteLine("Lista de requisição de viaturas actualizada:");
                            Console.WriteLine("--------------------------------------------");
                            foreach (Viatura reqViatura in reqViaturas)
                            {
                                Console.WriteLine($"Viatura {reqViatura.IdEquipamento}: {reqViatura.Marca} | {reqViatura.Modelo} | {reqViatura.Matricula} | {reqViatura.TipoViatura}");
                            }

                            Console.WriteLine();
                            Console.WriteLine("______________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine();
                            break;

                        //actualização estado viatura
                        case 2:
                            Console.WriteLine("ACTUALIZAÇÃO DE ESTADO DE VIATURA");
                            Console.WriteLine("---------------------------------");
                            Console.WriteLine();
                            //apresenta as viaturas presentes na lista de viaturas
                            foreach (Viatura viatura in viaturas)
                            {
                                Console.WriteLine($"Viatura {viatura.IdEquipamento}: {viatura.Marca} | {viatura.Modelo} | {viatura.Matricula} | Estado da viatura: {viatura.EstadoViatura}");
                            }
                            Console.WriteLine();

                            //contar o número de itens na lista para delimitar a validação do número a seleccionar
                            int last1 = viaturas.Count;

                            Console.Write("Seleccione o ID da viatura a actualizar: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            //se o valor do ID não corresponder com nenhum ID na lista, apresentar mensagem de erro e pedir novo número
                            while (id > last1 || id < 1)
                            {
                                Console.WriteLine();
                                Console.Write("Valor inserido não foi reconhecido no sistema." +
                                    "\nPor favor insira outro valor: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                            }

                            Console.WriteLine();
                            Viatura? v2 = viaturas.Find(viatura => viatura.IdEquipamento.Equals(id));

                            //actualização automática do estado da viatura para Disponível
                            if (v2 != null)
                            {
                                v2.EstadoViatura = EstadoEquipamento.Disponível;
                            }

                            //apresentação da lista de viaturas actualizada
                            Console.WriteLine("Lista de viaturas actualizada:");
                            Console.WriteLine("------------------------------");
                            foreach (Viatura Viatura in viaturas)
                            {
                                Console.WriteLine($"Viatura {Viatura.IdEquipamento}: {Viatura.Marca} | {Viatura.Modelo} | {Viatura.Matricula} | {Viatura.TipoViatura} | {Viatura.EstadoViatura}");
                            }

                            Console.WriteLine();
                            Console.WriteLine("______________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine();

                            break;

                        default:
                            Console.Write("Valor inserido não foi reconhecido no sistema");
                            Console.WriteLine();
                            break;
                    }

                }
                while (op != 0);

            }

            //________________________________________________________________________________________________________________

            //no caso de a extensão do email estar mal escrita, aparece um alerta de erro
            else
            {
                Console.WriteLine("Email inválido. Por favor insira novamente");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("______________________________________________________________________________________________");
            }

        } while (true);

    }

    //______________________________________________________________________________________________________________________

    //método para substituir os caracteres especiais para caracteres universais, de forma a poderem ser incluídos 
    //nos endereços de email e nas passwords
    private static char[] ReplaceSpecials(ref string s)
    {
        char[] str = new char[] { 'ã', 'á', 'à', 'â', 'Á', 'À', 'Â' };
        foreach (char c in str) { s = s.Replace(c, 'a'); }
        str = new char[] { 'ô', 'ó', 'ò', 'Ó', 'Ò' };
        foreach (char c in str) { s = s.Replace(c, 'o'); }
        str = new char[] { 'é', 'è', 'ê', 'É', 'È' };
        foreach (char c in str) { s = s.Replace(c, 'e'); }
        str = new char[] { 'í', 'ì', 'Í', 'Ì' };
        foreach (char c in str) { s = s.Replace(c, 'i'); }
        str = new char[] { 'ú', 'ù', 'Ú', 'Ù' };
        foreach (char c in str) { s = s.Replace(c, 'u'); }
        str = new char[] { 'ç' };
        foreach (char c in str) { s = s.Replace(c, 'c'); }

        return str;
    }

    //método para filtrar os vencimentos do colaboradores pelo ID da equipa seleccionada
    private static double Filtro(Equipa eqp, int idEquipa)
    {
        if (eqp.IdEquipa == idEquipa)
        {
            return eqp.VencimentoColab;
        }
        else
            return 0;

    }

}