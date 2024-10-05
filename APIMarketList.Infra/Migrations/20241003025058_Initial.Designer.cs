﻿// <auto-generated />
using System;
using APIMarketList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIMarketList.Infra.Data.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20241003025058_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APIMarketList.Domain.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("CanUpdate")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IncludedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ShoppingListId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListId");

                    b.HasIndex("UserId");

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("IncludedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("IncludedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("ShoppingList", (string)null);
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.ShoppingListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("IncludedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ShoppingListItem", (string)null);
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.ShoppingPurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("IncludedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime");

                    b.Property<int>("QuantityPurchased")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("ShoppingListItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListItemId");

                    b.ToTable("ShoppingPurchase", (string)null);
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("IncludedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.Member", b =>
                {
                    b.HasOne("APIMarketList.Domain.Entities.ShoppingList", "ShoppingList")
                        .WithMany("Members")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIMarketList.Domain.Entities.User", "User")
                        .WithMany("Members")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingList");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.ShoppingListItem", b =>
                {
                    b.HasOne("APIMarketList.Domain.Entities.Product", "Product")
                        .WithMany("ShoppingListItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIMarketList.Domain.Entities.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListItens")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.ShoppingPurchase", b =>
                {
                    b.HasOne("APIMarketList.Domain.Entities.ShoppingListItem", "ShoppingListItem")
                        .WithMany("ShoppingPurchases")
                        .HasForeignKey("ShoppingListItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingListItem");
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.Product", b =>
                {
                    b.Navigation("ShoppingListItems");
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.ShoppingList", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("ShoppingListItens");
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.ShoppingListItem", b =>
                {
                    b.Navigation("ShoppingPurchases");
                });

            modelBuilder.Entity("APIMarketList.Domain.Entities.User", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}