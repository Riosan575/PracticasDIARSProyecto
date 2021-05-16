using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtual_School.Models;

namespace Virtual_School.DB.Mapping
{
    public class TemaSeccionMap: IEntityTypeConfiguration<TemaSeccion>
    {
        public void Configure(EntityTypeBuilder<TemaSeccion> builder)
        {
            builder.ToTable("TemaSeccion");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Cursos)
                .WithMany()
                .HasForeignKey(o => o.IdCurso);

            builder.HasOne(o => o.Seccions)
                .WithMany()
                .HasForeignKey(o => o.IdSeccion);
        }
    }
}
