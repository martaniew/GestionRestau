﻿// <auto-generated />
using System;
using GestionRestau.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionRestau.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestionRestau.Models.Consommation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Paye")
                        .HasColumnType("bit");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.Property<int?>("TableConsId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProduitId");

                    b.HasIndex("TableConsId");

                    b.ToTable("Consommations");
                });

            modelBuilder.Entity("GestionRestau.Models.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categorie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CentreDeRevenu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nbpersonne")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.Property<string>("Statut")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("GestionRestau.Models.Serveur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Serveurs");
                });

            modelBuilder.Entity("GestionRestau.Models.TableCmd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Emplacement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbPlace")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<bool>("Occupation")
                        .HasColumnType("bit");

                    b.Property<int>("ServeurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServeurId");

                    b.ToTable("TableCmds");
                });

            modelBuilder.Entity("GestionRestau.Models.Consommation", b =>
                {
                    b.HasOne("GestionRestau.Models.Produit", "Produit")
                        .WithMany("Consommations")
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionRestau.Models.TableCmd", "TableCons")
                        .WithMany("Consommations")
                        .HasForeignKey("TableConsId");

                    b.Navigation("Produit");

                    b.Navigation("TableCons");
                });

            modelBuilder.Entity("GestionRestau.Models.TableCmd", b =>
                {
                    b.HasOne("GestionRestau.Models.Serveur", "Serveur")
                        .WithMany("Tables")
                        .HasForeignKey("ServeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serveur");
                });

            modelBuilder.Entity("GestionRestau.Models.Produit", b =>
                {
                    b.Navigation("Consommations");
                });

            modelBuilder.Entity("GestionRestau.Models.Serveur", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("GestionRestau.Models.TableCmd", b =>
                {
                    b.Navigation("Consommations");
                });
#pragma warning restore 612, 618
        }
    }
}
