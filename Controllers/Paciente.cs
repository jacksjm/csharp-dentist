using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class PacienteController 
    {
        public static Paciente InserirPaciente(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DataNascimento
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }

            if (String.IsNullOrEmpty(Cpf))
            {
                throw new Exception("Cpf inválido");
            }

            if (String.IsNullOrEmpty(Fone))
            {
                throw new Exception("Telefone inválido");
            }

            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("Email inválido");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Senha inválida");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            if (DataNascimento == null || DataNascimento > DateTime.Now)
            {
                throw new Exception("Data de Nacimento inválida");
            }

            return new Paciente(Nome, Cpf, Fone, Email, Senha, DataNascimento);
        }

        public static Paciente AlterarPaciente(
            int Id,
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DataNascimento
        )
        {
            Paciente paciente = GetPaciente(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                paciente.Nome = Nome;
            }

            if (!String.IsNullOrEmpty(Cpf))
            {
                paciente.Cpf = Cpf;
            }

            if (!String.IsNullOrEmpty(Fone))
            {
                paciente.Fone = Fone;
            }

            if (!String.IsNullOrEmpty(Email))
            {
                paciente.Email = Email;
            }

            if (!String.IsNullOrEmpty(Senha))
            {
                paciente.Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            if (DataNascimento > DateTime.Now)
            {
                throw new Exception("Data de Nacimento inválida");
            }

            if (DataNascimento != null)
            {
                paciente.DataNascimento = DataNascimento;
            }

            return paciente;
        }

        public static Paciente ExcluirPaciente(
            int Id
        )
        {
            Paciente paciente = GetPaciente(Id);
            Paciente.RemoverPaciente(paciente);
            return paciente;
        }

        public static List<Paciente> VisualizarPaciente()
        {
            return Paciente.GetPacientes();
        }

        public static Paciente GetPaciente(int Id)
        {
            Paciente paciente = (
                from Paciente in Paciente.GetPacientes()
                    where Paciente.Id == Id
                    select Paciente
            ).First();

            if (paciente == null)
            {
                throw new Exception("Paciente não encontrado");
            }

            return paciente;
        }
    }
}