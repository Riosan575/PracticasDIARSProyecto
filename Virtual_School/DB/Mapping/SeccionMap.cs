using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtual_School.Models;

namespace Virtual_School.DB.Mapping
{
    public class SeccionMap: IEntityTypeConfiguration<Seccion>
    {
        public void Configure(EntityTypeBuilder<Seccion> builder)
        {
            builder.ToTable("Seccion");
            builder.HasKey(o => o.Id);

            //builder.HasOne(o => o.Cursos)
            //    .WithMany()
            //    .HasForeignKey(o => o.IdCurso);
        }
    }
}
