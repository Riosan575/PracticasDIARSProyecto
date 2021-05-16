using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtual_School.Models;

namespace Virtual_School.DB.Mapping
{
    public class ContenidoCursoMap: IEntityTypeConfiguration<ContenidoCurso>
    {
        public void Configure(EntityTypeBuilder<ContenidoCurso> builder)
        {
            builder.ToTable("ContenidoCurso");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Cursos)
               .WithMany()
               .HasForeignKey(o => o.IdCurso);


            //builder.HasOne(o => o.Coments)
            //   .WithMany()
            //   .HasForeignKey(o => o.ComentarioId);
        }
    }
}
