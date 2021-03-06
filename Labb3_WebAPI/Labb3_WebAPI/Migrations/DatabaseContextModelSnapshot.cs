// <auto-generated />
using Labb3_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb3_WebAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labb3_WebAPI.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InterestDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestId = 1,
                            InterestDescription = "Reading, talking, watching and playing games",
                            InterestTitle = "Gaming"
                        },
                        new
                        {
                            InterestId = 2,
                            InterestDescription = "Loves cooking food",
                            InterestTitle = "Cooking"
                        },
                        new
                        {
                            InterestId = 3,
                            InterestDescription = "Looking and talking about art",
                            InterestTitle = "Art"
                        },
                        new
                        {
                            InterestId = 4,
                            InterestDescription = "Watching and commenting on Youtube videos",
                            InterestTitle = "Youtube"
                        },
                        new
                        {
                            InterestId = 5,
                            InterestDescription = "Reading, talking and writing about programming",
                            InterestTitle = "Programming"
                        });
                });

            modelBuilder.Entity("Labb3_WebAPI.Models.InterestLink", b =>
                {
                    b.Property<int>("InterestLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<int>("LinkId")
                        .HasColumnType("int");

                    b.HasKey("InterestLinkId");

                    b.HasIndex("InterestId");

                    b.HasIndex("LinkId");

                    b.ToTable("InterestLinks");

                    b.HasData(
                        new
                        {
                            InterestLinkId = 1,
                            InterestId = 1,
                            LinkId = 1
                        },
                        new
                        {
                            InterestLinkId = 2,
                            InterestId = 2,
                            LinkId = 2
                        },
                        new
                        {
                            InterestLinkId = 3,
                            InterestId = 3,
                            LinkId = 3
                        },
                        new
                        {
                            InterestLinkId = 4,
                            InterestId = 3,
                            LinkId = 4
                        },
                        new
                        {
                            InterestLinkId = 5,
                            InterestId = 4,
                            LinkId = 5
                        },
                        new
                        {
                            InterestLinkId = 6,
                            InterestId = 5,
                            LinkId = 6
                        });
                });

            modelBuilder.Entity("Labb3_WebAPI.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LinkUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkId");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            LinkId = 1,
                            LinkUrl = "https://www.pcgamer.com/"
                        },
                        new
                        {
                            LinkId = 2,
                            LinkUrl = "https://www.cookingclassy.com/"
                        },
                        new
                        {
                            LinkId = 3,
                            LinkUrl = "https://www.reddit.com/r/Art/"
                        },
                        new
                        {
                            LinkId = 4,
                            LinkUrl = "https://www.artstation.com/?sort_by=community"
                        },
                        new
                        {
                            LinkId = 5,
                            LinkUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                        },
                        new
                        {
                            LinkId = 6,
                            LinkUrl = "https://stackoverflow.com/"
                        });
                });

            modelBuilder.Entity("Labb3_WebAPI.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PersonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            PersonName = "Maria",
                            PhoneNumber = "2489576"
                        },
                        new
                        {
                            PersonId = 2,
                            PersonName = "Erik",
                            PhoneNumber = "3498672"
                        },
                        new
                        {
                            PersonId = 3,
                            PersonName = "Anna",
                            PhoneNumber = "4903567934"
                        },
                        new
                        {
                            PersonId = 4,
                            PersonName = "Lars",
                            PhoneNumber = "52579398467"
                        },
                        new
                        {
                            PersonId = 5,
                            PersonName = "Margareta",
                            PhoneNumber = "6934856734"
                        });
                });

            modelBuilder.Entity("Labb3_WebAPI.Models.PersonInterest", b =>
                {
                    b.Property<int>("PersonInterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("PersonInterestId");

                    b.HasIndex("InterestId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonInterests");

                    b.HasData(
                        new
                        {
                            PersonInterestId = 1,
                            InterestId = 1,
                            PersonId = 1
                        },
                        new
                        {
                            PersonInterestId = 2,
                            InterestId = 2,
                            PersonId = 1
                        },
                        new
                        {
                            PersonInterestId = 3,
                            InterestId = 2,
                            PersonId = 2
                        },
                        new
                        {
                            PersonInterestId = 4,
                            InterestId = 3,
                            PersonId = 3
                        },
                        new
                        {
                            PersonInterestId = 5,
                            InterestId = 4,
                            PersonId = 4
                        },
                        new
                        {
                            PersonInterestId = 6,
                            InterestId = 5,
                            PersonId = 5
                        });
                });

            modelBuilder.Entity("Labb3_WebAPI.Models.InterestLink", b =>
                {
                    b.HasOne("Labb3_WebAPI.Models.Interest", "Interest")
                        .WithMany("InterestLinks")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb3_WebAPI.Models.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labb3_WebAPI.Models.PersonInterest", b =>
                {
                    b.HasOne("Labb3_WebAPI.Models.Interest", "Interest")
                        .WithMany("PersonInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb3_WebAPI.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
