﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaraunt.RestarauntSystem.DAL.DbContexts;

#nullable disable

namespace Restaraunt.Migrations
{
    [DbContext(typeof(RestarauntContext))]
    [Migration("20231213150743_RestarauntDbInitialMigration")]
    partial class RestarauntDbInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.Dish", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dishies");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.IngredientDish", b =>
                {
                    b.Property<long>("DishId")
                        .HasColumnType("bigint");

                    b.Property<long>("IngredientId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.HasKey("DishId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("IngredientsDishies");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.OrderDetail", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("PortionId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.HasKey("OrderId", "PortionId");

                    b.HasIndex("PortionId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.Portion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("DishId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.ToTable("Portions");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.IngredientDish", b =>
                {
                    b.HasOne("Restaraunt.RestarauntSystem.DAL.Entities.Dish", "Dish")
                        .WithMany("IngredientsDishes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaraunt.RestarauntSystem.DAL.Entities.Ingredient", "Ingredient")
                        .WithMany("IngredientDishes")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.OrderDetail", b =>
                {
                    b.HasOne("Restaraunt.RestarauntSystem.DAL.Entities.Order", "Order")
                        .WithMany("OrdersDetail")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaraunt.RestarauntSystem.DAL.Entities.Portion", "Portion")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PortionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Portion");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.Portion", b =>
                {
                    b.HasOne("Restaraunt.RestarauntSystem.DAL.Entities.Dish", "Dish")
                        .WithMany("Portions")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.Dish", b =>
                {
                    b.Navigation("IngredientsDishes");

                    b.Navigation("Portions");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.Ingredient", b =>
                {
                    b.Navigation("IngredientDishes");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrdersDetail");
                });

            modelBuilder.Entity("Restaraunt.RestarauntSystem.DAL.Entities.Portion", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
