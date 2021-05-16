using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtual_School.Models;

namespace Virtual_School.DB.Mapping
{
    public class ComentarioMap: IEntityTypeConfiguration<Comentarios>
    {
        public void Configure(EntityTypeBuilder<Comentarios> builder)
        {
            builder.ToTable("Comentarios");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Accounts)
                .WithMany()
                .HasForeignKey(o => o.UsuarioId);
        }
    }
}
