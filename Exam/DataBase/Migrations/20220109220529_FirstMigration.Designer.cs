﻿// <auto-generated />
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataBase.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220109220529_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DataBase.Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ArmorClass")
                        .HasColumnType("integer");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("integer");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("integer");

                    b.Property<int>("Damage")
                        .HasColumnType("integer");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("integer");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Weapon")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Monsters");

                    b.HasCheckConstraint("CK_Monsters_ArmorClass_Range", "\"ArmorClass\" >= 0 AND \"ArmorClass\" <= 100");

                    b.HasCheckConstraint("CK_Monsters_AttackModifier_Range", "\"AttackModifier\" >= 0 AND \"AttackModifier\" <= 2147483647");

                    b.HasCheckConstraint("CK_Monsters_AttackPerRound_Range", "\"AttackPerRound\" >= 0 AND \"AttackPerRound\" <= 2147483647");

                    b.HasCheckConstraint("CK_Monsters_Damage_Range", "\"Damage\" >= 0 AND \"Damage\" <= 2147483647");

                    b.HasCheckConstraint("CK_Monsters_DamageModifier_Range", "\"DamageModifier\" >= 0 AND \"DamageModifier\" <= 2147483647");

                    b.HasCheckConstraint("CK_Monsters_HitPoints_Range", "\"HitPoints\" >= 0 AND \"HitPoints\" <= 2147483647");

                    b.HasCheckConstraint("CK_Monsters_Weapon_Range", "\"Weapon\" >= 0 AND \"Weapon\" <= 2147483647");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorClass = 15,
                            AttackModifier = 3,
                            AttackPerRound = 1,
                            Damage = 23,
                            DamageModifier = 6,
                            HitPoints = 92,
                            Name = "Tree Blight",
                            Weapon = 9
                        },
                        new
                        {
                            Id = 2,
                            ArmorClass = 12,
                            AttackModifier = 2,
                            AttackPerRound = 1,
                            Damage = 6,
                            DamageModifier = 2,
                            HitPoints = 58,
                            Name = "Banshee",
                            Weapon = 12
                        },
                        new
                        {
                            Id = 3,
                            ArmorClass = 15,
                            AttackModifier = 2,
                            AttackPerRound = 1,
                            Damage = 14,
                            DamageModifier = 21,
                            HitPoints = 45,
                            Name = "Hell Hound",
                            Weapon = 5
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
