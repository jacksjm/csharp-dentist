using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class SalaController
    {
        public static Sala IncluirSala(
            string Numero,
            string Equipamentos
        )
        {
            if (String.IsNullOrEmpty(Numero)) {
                throw new Exception("Número é obrigatório");
            }

            return new Sala(Numero, Equipamentos);
        }

        public static Sala AlterarSala(
            int Id,
            string Numero,
            string Equipamentos
        )
        {
            Sala sala = GetSala(Id);

            if (!String.IsNullOrEmpty(Numero)) {
                sala.Numero = Numero;
            }
            sala.Equipamentos = Equipamentos;

            return sala;
        }

        public static Sala ExcluirSala(
            int Id
        )
        {
            Sala sala = GetSala(Id);
            Models.Sala.RemoverSala(sala);
            return sala;
        }

        public static List<Sala> VisualizarSalas()
        {
            return Models.Sala.GetSalas();  
        }

        public static Sala GetSala(
            int Id
        )
        {
            List<Sala> salasModels = Models.Sala.GetSalas();
            IEnumerable<Sala> salas = from Sala in salasModels
                            where Sala.Id == Id
                            select Sala;
            Sala sala = salas.First();
            
            if (sala == null)
            {
                throw new Exception("Sala não encontrada");
            }

            return sala;
        }
    }
}