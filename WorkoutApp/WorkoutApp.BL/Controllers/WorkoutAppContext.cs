using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkoutApp.BL.Models;

namespace WorkoutApp.BL.Controllers
{
    internal class WorkoutAppContext : DbContext
    {
        /// <summary>
        /// Table for exercises
        /// </summary>
        public DbSet<Exercise> Exercises { get; set; }

        /// <summary>
        /// Table for foodstuffs
        /// </summary>
        public DbSet<Product> Products { get; set; }


        /// <summary>
        /// Table for genders
        /// </summary>
        public DbSet<Gender> Genders { get; set; }

        /// <summary>
        /// Table for ingestions
        /// </summary>
        public DbSet<Ingestion> Ingestions { get; set; }

        /// <summary>
        /// Table for physical activities
        /// </summary>
        public DbSet<PhysicalActivity> PhysicalActivities { get; set; }

        /// <summary>
        /// Table for users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Create WorkoutAppContext by default
        /// </summary>
        public WorkoutAppContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Configuring context for MSSQL
        /// </summary>
        /// <param name = "optionsBuilder" ></ param >
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        /// <summary>
        /// Configuring context for SQLite
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=helloapp.db");
        //}
    }
}
