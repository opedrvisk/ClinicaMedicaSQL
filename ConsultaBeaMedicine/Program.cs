using System;

namespace ClinicaMedicaSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Cadastrar Paciente");
                Console.WriteLine("2. Cadastrar Médico");
                Console.WriteLine("3. Cadastrar Recepcionista");
                Console.WriteLine("4. Agendar Consulta");
                Console.WriteLine("5. Deletar Paciente");
                Console.WriteLine("6. Deletar Médico");
                Console.WriteLine("7. Deletar Recepcionista");
                Console.WriteLine("8. Deletar Consulta");
                Console.WriteLine("9. Listar Pacientes");
                Console.WriteLine("10. Listar Médicos");
                Console.WriteLine("11. Listar Recepcionistas");
                Console.WriteLine("12. Listar Consultas");
                Console.WriteLine("13. Consultar Paciente por ID");
                Console.WriteLine("14. Consultar Médico por ID");
                Console.WriteLine("15. Consultar Recepcionista por ID");
                Console.WriteLine("16. Consultar Consulta por ID");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome: ");
                        string nomeP = Console.ReadLine();
                        Console.Write("CPF: ");
                        string cpfP = Console.ReadLine();
                        Console.Write("Convênio: ");
                        string conv = Console.ReadLine();
                        new Paciente(nomeP, cpfP, conv).Salvar();
                        break;

                    case "2":
                        Console.Write("Nome: ");
                        string nomeM = Console.ReadLine();
                        Console.Write("CPF: ");
                        string cpfM = Console.ReadLine();
                        Console.Write("Especialidade: ");
                        string esp = Console.ReadLine();
                        new Medico(nomeM, cpfM, esp).Salvar();
                        break;

                    case "3":
                        Console.Write("Nome: ");
                        string nomeR = Console.ReadLine();
                        Console.Write("CPF: ");
                        string cpfR = Console.ReadLine();
                        Console.Write("Turno: ");
                        string turno = Console.ReadLine();
                        new Recepcionista(nomeR, cpfR, turno).Salvar();
                        break;

                    case "4":
                        Console.Write("ID do paciente: ");
                        int pid = int.Parse(Console.ReadLine());
                        Console.Write("ID do médico: ");
                        int mid = int.Parse(Console.ReadLine());
                        Console.Write("Data e hora (dd-mm-yyyy HH:mm): ");
                        DateTime data = DateTime.Parse(Console.ReadLine());
                        new Consulta(pid, mid, data).Salvar();
                        break;

                     case "5":
                         Console.Write("ID do paciente: ");
                        int idP = int.Parse(Console.ReadLine());
                        Paciente.Deletar(idP);
                        break;

                     case "6":
                         Console.Write("ID do médico: ");
                        int idM = int.Parse(Console.ReadLine());
                        Medico.Deletar(idM);
                        break;

                    case "7":
                         Console.Write("ID da recepcionista: ");
                        int idR = int.Parse(Console.ReadLine());
                        Recepcionista.Deletar(idR);
                        break;


                    case "8":
                         Console.Write("ID da consulta: ");
                        int idC = int.Parse(Console.ReadLine());
                        Consulta.Deletar(idC);
                        break;

                    case "9":
                        Paciente.ListarTodos();
                        break;

                    case "10":
                        Medico.ListarTodos();
                        break;

                    case "11":
                        Recepcionista.ListarTodos();
                        break;

                    case "12":
                        Consulta.ListarTodas();
                        break;

                    case "13":
                        Console.Write("ID do paciente: ");
                        int pacienteId = int.Parse(Console.ReadLine());
                        Paciente.ConsultarPorId(pacienteId);
                        break;

                    case "14":
                        Console.Write("ID do Médico: ");
                        int medicoId = int.Parse(Console.ReadLine());
                        Medico.ConsultarPorId(medicoId);
                        break;

                    case "15":
                        Console.Write("ID da recepcionista: ");
                        int recepcionistaId = int.Parse(Console.ReadLine());
                        Recepcionista.ConsultarPorId(recepcionistaId);
                        break;

                    case "16":
                        Console.Write("ID da consulta: ");
                        int consultaId = int.Parse(Console.ReadLine());
                        Consulta.ConsultarPorId(consultaId);
                        break;


                    case "0":
                        return;
                }
            }
        }
    }
}
