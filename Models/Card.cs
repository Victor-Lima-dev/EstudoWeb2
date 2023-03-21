using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudoWeb2.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string Enunciado { get; set; }
        public string Resposta { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
    }
}