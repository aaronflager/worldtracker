using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorldTracker.Repositories;

namespace WorldTracker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170321024650_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorldTracker.Models.Character", b =>
                {
                    b.Property<int>("CharacterID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Background");

                    b.Property<string>("Backstory");

                    b.Property<string>("Class")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Race")
                        .IsRequired();

                    b.HasKey("CharacterID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("WorldTracker.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("SiteLocationID")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("WorldDate");

                    b.HasKey("EventID");

                    b.HasIndex("SiteLocationID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WorldTracker.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Geography");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WorldTracker.Models.Event", b =>
                {
                    b.HasOne("WorldTracker.Models.Location", "Site")
                        .WithMany()
                        .HasForeignKey("SiteLocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
