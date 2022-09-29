﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpotifyLite.Infra.Context;

#nullable disable

namespace SpotifyLite.Infra.Migrations
{
    [DbContext(typeof(SpotifyContext))]
    partial class SpotifyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicaPlaylist", b =>
                {
                    b.Property<Guid>("MusicasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaylistsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MusicasId", "PlaylistsId");

                    b.HasIndex("PlaylistsId");

                    b.ToTable("MusicaPlaylist");
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Backdrop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BandaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("BandaId");

                    b.ToTable("Albuns", (string)null);
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Banda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Banda", (string)null);
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Musica", (string)null);
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Playlists", (string)null);
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("MusicaPlaylist", b =>
                {
                    b.HasOne("SpotifyLite.Domain.Models.Musica", null)
                        .WithMany()
                        .HasForeignKey("MusicasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotifyLite.Domain.Models.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Album", b =>
                {
                    b.HasOne("SpotifyLite.Domain.Models.Banda", null)
                        .WithMany("Albums")
                        .HasForeignKey("BandaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Musica", b =>
                {
                    b.HasOne("SpotifyLite.Domain.Models.Album", null)
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SpotifyLite.Domain.ValueObjects.Duracao", "Duracao", b1 =>
                        {
                            b1.Property<Guid>("MusicaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasColumnType("int")
                                .HasColumnName("Duracao");

                            b1.HasKey("MusicaId");

                            b1.ToTable("Musica");

                            b1.WithOwner()
                                .HasForeignKey("MusicaId");
                        });

                    b.Navigation("Duracao")
                        .IsRequired();
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Playlist", b =>
                {
                    b.HasOne("SpotifyLite.Domain.Models.Usuario", null)
                        .WithMany("Playlists")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Usuario", b =>
                {
                    b.OwnsOne("SpotifyLite.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .HasColumnType("nvarchar(1024)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("SpotifyLite.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Password");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Banda", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("SpotifyLite.Domain.Models.Usuario", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
