using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudoWeb2.Models
{
   public class Anotacao
    {
        public int AnotacaoId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }

        
    }
}