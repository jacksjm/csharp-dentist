namespace Models
{
    public class Auth
    {
        public static Paciente Paciente;
        public static Dentista Dentista;

        public static bool isLogeed;

        public static void Login(
            string Email,
            string Senha
        )
        {
            Paciente paciente = Paciente.GetPacientes()
                .Find(Paciente => Paciente.Email == Email && BCrypt.Net.BCrypt.Verify(Senha, Paciente.Senha));

            if (paciente != null)
            {
                System.Console.WriteLine(paciente.Senha);
                isLogeed = true;
                Paciente = paciente;
                Dentista = null;
            }
            else
            {
                Dentista dentista = Dentista.GetDentistas()
                    .Find(Dentista => Dentista.Email == Email && BCrypt.Net.BCrypt.Verify(Senha, Dentista.Senha));
                System.Console.WriteLine(dentista.Senha);
                if (dentista != null)
                {
                    isLogeed = true;
                    Dentista = dentista;
                    Paciente = null;
                }
                else
                {
                    Logout();
                    throw new System.Exception("Login inválido");
                }
            }
        }

        public static void Logout()
        {
            isLogeed = false;
            Dentista = null;
            Paciente = null;
        }
    }
}