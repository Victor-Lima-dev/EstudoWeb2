using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudoWeb2.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudoWeb2.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Questao> Questoes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Anotacao> Anotacoes { get; set; }
        public DbSet<Card> Cards { get; set; }

        
        
    }
}