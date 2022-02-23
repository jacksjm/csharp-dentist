using System;
using Views;
using Controllers;
using Models;

namespace ConsultorioOdontologico
{
    public class Program
    {
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }

        public static void Main(string[] args)
        {
            DentistaController.InserirDentista("José do Carmo", "111.111.111-11", "47 99999-9999", "jose.carmo@dentista.com", "123456", "12345/SC", 15000, "Ortodontia");
            PacienteController.InserirPaciente("Amélia da Silva", "111.111.111-11", "47 88888-8888", "amelia.silva@paciente.com", "123456", Convert.ToDateTime("1990-01-01"));
            SalaController.IncluirSala("B135", "RaioX");
            //MenuPrincipal();

            do
            {
                Console.WriteLine("Informe o usuário: ");
                string Email = Console.ReadLine();
                Console.WriteLine("Informe a senha: ");
                string Senha = ReadPassword();
                
                try
                {
                    Auth.Login(Email, Senha);
                    if (Auth.Dentista != null) {
                        MenuPrincipal();
                    }
                    if (Auth.Paciente != null) {
                        MenuPaciente();
                    }
                    Auth.Logout();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            } while (!Auth.isLogeed);
        }

        public static void MenuPaciente()
        {
            Console.WriteLine($" ============= BEM VINDO PACIENTE {Auth.Paciente.Nome} ============ ");
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("| Operação | Descrição               |");
            Console.WriteLine("|----------|-------------------------|");
            Console.WriteLine("|    0     | Sair                    |");
            Console.WriteLine("|    1     | Visualizar Agendamentos |");
            Console.WriteLine("|    2     | Confirmar Agendamentos  |");
            Console.WriteLine("+------------------------------------+");
            int opt = 0;

            do
            {
                Console.WriteLine("Digite a operação: ");
                try
                {
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }
                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Obrigado por utilizar o sistema");
                        break;
                    case 1:
                        AgendamentoView.GetAgendamentosPorPaciente(Auth.Paciente.Id);
                        break;
                    case 2:
                        AgendamentoView.ConfirmarAgendamento();
                        break;
                    default:
                        Console.WriteLine("Operação inválida");
                        break;
                }  
            } while(opt != 0);
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine(" ============= BEM VINDO ============ ");
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("| Operação | Descrição               |");
            Console.WriteLine("|----------|-------------------------|");
            Console.WriteLine("| 0        | Sair                    |");
            Console.WriteLine("| 1        | Incluir Dentista        |");
            Console.WriteLine("| 2        | Incluir Paciente        |");
            Console.WriteLine("| 3        | Incluir Sala            |");
            Console.WriteLine("| 4        | Incluir Agendamento     |");
            Console.WriteLine("| 5        | Alterar Dentista        |");
            Console.WriteLine("| 6        | Alterar Paciente        |");
            Console.WriteLine("| 7        | Alterar Sala            |");
            Console.WriteLine("| 8        | Alterar Agendamento     |");
            Console.WriteLine("| 9        | Excluir Dentista        |");
            Console.WriteLine("| 10       | Excluir Paciente        |");
            Console.WriteLine("| 11       | Excluir Sala            |");
            Console.WriteLine("| 12       | Excluir Agendamento     |");
            Console.WriteLine("| 13       | Visualizar Dentistas    |");
            Console.WriteLine("| 14       | Visualizar Pacientes    |");
            Console.WriteLine("| 15       | Visualizar Salas        |");
            Console.WriteLine("| 16       | Visualizar Agendamentos |");
            Console.WriteLine("+------------------------------------+");

            int opt = 0;

            do
            {
                try
                {
                    Console.WriteLine("Digite a operação: ");
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }
                try{
                    switch (opt)
                    {
                        case 0:
                        {
                            Console.WriteLine("Obrigado por utilizar o sistema!");
                            break;
                        }
                        case 1:
                        {
                            DentistaView.InserirDentista();
                            break;
                        }
                        case 2:
                        {
                            PacienteView.InserirPaciente();
                            break;
                        }
                        case 3:
                        {
                            SalaView.InserirSala();
                            break;
                        }
                        case 4:
                        {
                            AgendamentoView.InserirAgendamento();
                            break;
                        }
                        case 5:
                        {
                            DentistaView.AlterarDentista();
                            break;
                        }
                        case 6:
                        {
                            PacienteView.AlterarPaciente();
                            break;
                        }
                        case 7:
                        {
                            SalaView.AlterarSala();
                            break;
                        }
                        case 8:
                        {
                            AgendamentoView.AlterarAgendamento();
                            break;
                        }
                        case 9:
                        {
                            DentistaView.ExcluirDentista();
                            break;
                        }
                        case 10:
                        {
                            PacienteView.ExcluirPaciente();
                            break;
                        }
                        case 11:
                        {
                            SalaView.ExcluirSala();
                            break;
                        }
                        case 12:
                        {
                            AgendamentoView.ExcluirAgendamento();
                            break;
                        }
                        case 13:
                        {
                            DentistaView.ListarDentistas();
                            break;
                        }
                        case 14:
                        {
                            PacienteView.ListarPacientes();
                            break;
                        }
                        case 15:
                        {
                            SalaView.ListarSalas();
                            break;
                        }
                        case 16:
                        {
                            AgendamentoView.ListarAgendamentos();
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Operação inválida");
                            break;
                        }
                    }
                } 
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    opt = 99;
                }
            } while (opt != 0);
        }
    }
}
