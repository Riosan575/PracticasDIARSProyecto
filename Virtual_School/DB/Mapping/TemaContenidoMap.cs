using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtual_School.Models;

namespace Virtual_School.DB.Mapping
{
    public class TemaContenidoMap : IEntityTypeConfiguration<TemaContenido>
    {
        public void Configure(EntityTypeBuilder<TemaContenido> builder)
        {
            builder.ToTable("TemaContenido");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Tems)
                .WithMany()
                .HasForeignKey(o => o.IdTemaSeccion);

            builder.HasOne(o => o.Secciones)
                .WithMany()
                .HasForeignKey(o => o.IdSecciones);
        }
    }
}
