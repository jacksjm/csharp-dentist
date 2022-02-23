using System;
using System.Collections.Generic;

namespace Models
{
    public class Paciente : Pessoa
    {
        public static int ID = 0;
        private static List<Paciente> Pacientes = new List<Paciente>();
        public DateTime DataNascimento { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\nData de Nascimento: {this.DataNascimento}";
        }

        public Paciente(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DataNascimento
        ) : this(++ID, Nome, Cpf, Fone, Email, Senha, DataNascimento)
        {}

        private Paciente(
            int Id,
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DataNascimento
        ) : base(Id, Nome, Cpf, Fone, Email, Senha)
        {
            this.DataNascimento = DataNascimento;
            
            Pacientes.Add(this);
        }

        public static List<Paciente> GetPacientes()
        {
            return Pacientes;
        }

        public static void RemoverPaciente(Paciente paciente)
        {
            Pacientes.Remove(paciente);
        }

    }
}