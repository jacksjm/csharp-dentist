namespace Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nNome: {this.Nome}"
                + $"\nC.P.F.: {this.Cpf}"
                + $"\nTelefone: {this.Fone}"
                + $"\nEmail: {this.Email}";
        }

        public Pessoa(
            int Id,
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha
        )
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Fone = Fone;
            this.Email = Email;
            this.Senha = Senha;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Pessoa.ReferenceEquals(this, obj))
            {
                return false;
            }
            Pessoa it = (Pessoa) obj;
            return it.Id == this.Id;
        }
    }
}