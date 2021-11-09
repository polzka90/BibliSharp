using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliSharp.DbModels
{
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto(DbContextOptions<BibliotecaContexto> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Emprestismo> Emprestismos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Aluno>().HasKey(m => m.Id);
            builder.Entity<Emprestismo>().HasKey(m => m.EmprestismoId);
            builder.Entity<Livro>().HasKey(m => m.Id);
            builder.Entity<Usuario>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
