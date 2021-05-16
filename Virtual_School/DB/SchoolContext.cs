using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtual_School.DB.Mapping;
using Virtual_School.Models;

namespace Virtual_School.DB
{
    public class SchoolContext: DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<ContenidoCurso> Contenidos { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TomarCurso> TomarCursos { get; set; }
        public DbSet<Temas> Temas { get; set; }
        public DbSet<Comentarios> Coments { get; set; }
        public DbSet<Seccion> Seccions { get; set; }
        public DbSet<TemaSeccion> temaSeccions { get; set; }
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new ContenidoCursoMap());
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new TomarCursoMap());
            modelBuilder.ApplyConfiguration(new TemasMap());
            modelBuilder.ApplyConfiguration(new ComentarioMap());
            modelBuilder.ApplyConfiguration(new SeccionMap());
            modelBuilder.ApplyConfiguration(new TemaSeccionMap());
        }
    }
}
