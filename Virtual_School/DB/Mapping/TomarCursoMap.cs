using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtual_School.Models;

namespace Virtual_School.DB.Mapping
{
    public class TomarCursoMap: IEntityTypeConfiguration<TomarCurso>
    {
        public void Configure(EntityTypeBuilder<TomarCurso> builder)
        {
            builder.ToTable("TomarCurso");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Cursos)
                .WithMany()
                .HasForeignKey(o => o.IdCurso);

            builder.HasOne(o => o.Accounts)
                .WithMany()
                .HasForeignKey(o => o.IdUsuario);
        }
    }
}
