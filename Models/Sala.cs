using System.Collections.Generic;

namespace Models
{
    public class Sala
    {
        public static int ID = 0;
        private static List<Sala> Salas = new List<Sala>();
        public int Id { set; get; }
        public string Numero { set; get; }
        public string Equipamentos { set; get; }

        public Sala(
            string Numero,
            string Equipamentos
        ) : this(++ID, Numero, Equipamentos)
        {

        }

        private Sala(
            int Id,
            string Numero,
            string Equipamentos
        )
        {
            this.Id = Id;
            this.Numero = Numero;
            this.Equipamentos = Equipamentos;

            Salas.Add(this);
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nNúmero: {this.Numero}"
                + $"\nEquipamentos: {this.Equipamentos}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Sala.ReferenceEquals(obj, this))
            {
                return false;
            }
            Sala it = (Sala) obj;
            return it.Id == this.Id;
        }


        public static List<Sala> GetSalas()
        {
            return Salas;
        }

        public static void RemoverSala(Sala sala)
        {
            Salas.Remove(sala);
        }
    }
}