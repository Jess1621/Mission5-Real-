using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieApplicationContext : DbContext
    {
        //Constructor
        public MovieApplicationContext (DbContextOptions<MovieApplicationContext> options) : base (options)
        {
            //Leave Blank For Now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Seeding Data
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Fantasy" },
                new Category { CategoryID = 5, CategoryName = "Horror" },
                new Category { CategoryID = 6, CategoryName = "Mystery" },
                new Category { CategoryID = 7, CategoryName = "Romance" },
                new Category { CategoryID = 8, CategoryName = "Thriller" },
                new Category { CategoryID = 9, CategoryName = "Other" }
                );

            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    ApplicationID = 1,
                    CategoryID = 1,
                    Title = "Jason Bourne: Bourne Identity",
                    Year = 2002,
                    Director = "Doug Liman",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Awesome Movie!"
                },

                new ApplicationResponse
                {
                    ApplicationID = 2,
                    CategoryID = 3,
                    Title = "Warrior",
                    Year = 2011,
                    Director = "Gavin O'Conner",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Watch alone, makes me emotional"
                },

                new ApplicationResponse
                {
                    ApplicationID = 3,
                    CategoryID = 4,
                    Title = "Dune",
                    Year = 2021,
                    Director = "Denis Villeneuve",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Super Awesome Movie, should read the book too..."
                }
            );
        }
    }
}
