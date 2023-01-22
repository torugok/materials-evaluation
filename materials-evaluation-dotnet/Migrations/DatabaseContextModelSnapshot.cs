﻿// <auto-generated />
using System;
using MaterialsEvaluation.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MaterialsEvaluation.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("MaterialsEvaluation.Database.Batch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AmountOfTests")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CalculatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("QualityVisionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("QualityVisionId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.QualityProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("QuantitativeDecimals")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("QuantitativeInferiorLimit")
                        .HasColumnType("REAL");

                    b.Property<double?>("QuantitativeNominalValue")
                        .HasColumnType("REAL");

                    b.Property<double?>("QuantitativeSuperiorLimit")
                        .HasColumnType("REAL");

                    b.Property<string>("QuantitativeUnit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("QualityProperties");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.QualityVision", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AvaliationCalculationType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AvaliationGrouping")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AvaliationMinQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.ToTable("QualityVisions");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.QualityVisionProperties", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("QualityPropertyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("QualityVisionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QualityPropertyId");

                    b.HasIndex("QualityVisionId", "QualityPropertyId")
                        .IsUnique();

                    b.ToTable("QualityVisionProperties");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BatchId")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Passed")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("QualityPropertyId")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("ResultQualitative")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("ResultQuantitative")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.HasIndex("QualityPropertyId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.Batch", b =>
                {
                    b.HasOne("MaterialsEvaluation.Database.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaterialsEvaluation.Database.QualityVision", "QualityVision")
                        .WithMany("Batches")
                        .HasForeignKey("QualityVisionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("QualityVision");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.QualityVision", b =>
                {
                    b.HasOne("MaterialsEvaluation.Database.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.QualityVisionProperties", b =>
                {
                    b.HasOne("MaterialsEvaluation.Database.QualityProperty", "QualityProperty")
                        .WithMany()
                        .HasForeignKey("QualityPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaterialsEvaluation.Database.QualityVision", "QualityVision")
                        .WithMany("QualityProperties")
                        .HasForeignKey("QualityVisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QualityProperty");

                    b.Navigation("QualityVision");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.Test", b =>
                {
                    b.HasOne("MaterialsEvaluation.Database.Batch", "Batch")
                        .WithMany("Tests")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaterialsEvaluation.Database.QualityProperty", "QualityProperty")
                        .WithMany("Tests")
                        .HasForeignKey("QualityPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("QualityProperty");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.Batch", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.QualityProperty", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("MaterialsEvaluation.Database.QualityVision", b =>
                {
                    b.Navigation("Batches");

                    b.Navigation("QualityProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
