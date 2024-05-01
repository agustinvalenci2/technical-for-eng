// Contract:
// Author: [Your Name]
// Date: [Date]
// Description: This code defines the ApplicationDbContext class which represents the database context 
// for the application. It also includes the User class which represents the User entity in the database.

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace technical.Models
{
    // Represents the database context for the application.
    public class ApplicationDbContext : DbContext
    {
        // Constructor to initialize the DbContext with options.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Default constructor.
        public ApplicationDbContext() { }

        // Represents the Users table in the database.
        public DbSet<User> Users { get; set; }
    }
}

namespace technical.Models
{
    // Represents a user entity in the database.
    public class User
    {
        // Primary key for the User entity.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Name of the user.
        public string Name { get; set; }

        // Date of birth of the user.
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        // Indicates whether the user is active.
        public bool Active { get; set; }
    }
}
