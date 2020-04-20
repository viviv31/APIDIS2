﻿// <auto-generated />
using APIDIS2.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIDIS2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200420022604_InitialCreate1")]
    partial class InitialCreate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIDIS2.Models.Fireball_model+description_fireball", b =>
                {
                    b.Property<string>("date")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("altitude");

                    b.Property<string>("energy");

                    b.Property<string>("impact_e");

                    b.Property<string>("lat_dir");

                    b.Property<string>("latitude");

                    b.Property<string>("long_dir");

                    b.Property<string>("longitude");

                    b.Property<int>("velocity");

                    b.HasKey("date");

                    b.ToTable("description_fireballs");
                });
#pragma warning restore 612, 618
        }
    }
}
