﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Repository.Mapping
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albuns");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Backdrop);
            builder.Property(x => x.DataLancamento).IsRequired();

            builder.HasMany(x => x.Musicas).WithOne().OnDelete(DeleteBehavior.Cascade); 

        }
    }
}
