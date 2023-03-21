using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudoWeb2.Models
{
    public class Materia
    {
         public int MateriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Card> Cards { get; set; }
        public List<Anotacao> Anotacoes { get; set; }
        public List<Questao> Questoes { get; set; }

    }
}