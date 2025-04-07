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
        public DbSet<Foodstuff> Foodstuffs { get; set; }

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

        }

        /// <summary>
        /// Configuring context
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
