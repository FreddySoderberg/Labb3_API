using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_WebAPI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<InterestLink> InterestLinks{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data
            modelBuilder.Entity<Person>().HasData(new List<Person>() 
            { 
                new Person{ PersonId = 1, PersonName = "Maria", PhoneNumber = "2489576"},
                new Person{ PersonId = 2, PersonName = "Erik", PhoneNumber = "3498672"},
                new Person{ PersonId = 3, PersonName = "Anna", PhoneNumber = "4903567934"},
                new Person{ PersonId = 4, PersonName = "Lars", PhoneNumber = "52579398467"},
                new Person{ PersonId = 5, PersonName = "Margareta", PhoneNumber = "6934856734"}
            });

            modelBuilder.Entity<Interest>().HasData(new List<Interest>() 
            {
                new Interest{ InterestId = 1, InterestTitle = "Gaming", InterestDescription = "Reading, talking, watching and playing games"},
                new Interest{ InterestId = 2, InterestTitle = "Cooking", InterestDescription = "Loves cooking food"},
                new Interest{ InterestId = 3, InterestTitle = "Art", InterestDescription = "Looking and talking about art"},
                new Interest{ InterestId = 4, InterestTitle = "Youtube", InterestDescription = "Watching and commenting on Youtube videos"},
                new Interest{ InterestId = 5, InterestTitle = "Programming", InterestDescription = "Reading, talking and writing about programming"}
            });

            modelBuilder.Entity<Link>().HasData(new List<Link>() 
            {
                new Link{ LinkId = 1, LinkUrl = "https://www.pcgamer.com/"},
                new Link{ LinkId = 2, LinkUrl = "https://www.cookingclassy.com/"},
                new Link{ LinkId = 3, LinkUrl = "https://www.reddit.com/r/Art/"},
                new Link{ LinkId = 4, LinkUrl = "https://www.artstation.com/?sort_by=community"},
                new Link{ LinkId = 5, LinkUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"},
                new Link{ LinkId = 6, LinkUrl = "https://stackoverflow.com/"},
            });

            modelBuilder.Entity<PersonInterest>().HasData(new List<PersonInterest>()
            {
                new PersonInterest{PersonInterestId = 1, PersonId = 1, InterestId = 1},
                new PersonInterest{PersonInterestId = 2, PersonId = 1, InterestId = 2},
                new PersonInterest{PersonInterestId = 3, PersonId = 2, InterestId = 2},
                new PersonInterest{PersonInterestId = 4, PersonId = 3, InterestId = 3},
                new PersonInterest{PersonInterestId = 5, PersonId = 4, InterestId = 4},
                new PersonInterest{PersonInterestId = 6, PersonId = 5, InterestId = 5},
            });

            modelBuilder.Entity<InterestLink>().HasData(new List<InterestLink>()
            {
                new InterestLink{InterestLinkId= 1, InterestId = 1, LinkId = 1},
                new InterestLink{InterestLinkId= 2, InterestId = 2, LinkId = 2},
                new InterestLink{InterestLinkId= 3, InterestId = 3, LinkId = 3},
                new InterestLink{InterestLinkId= 4, InterestId = 3, LinkId = 4},
                new InterestLink{InterestLinkId= 5, InterestId = 4, LinkId = 5},
                new InterestLink{InterestLinkId= 6, InterestId = 5, LinkId = 6},
            });
        }
    }
}
