using Microsoft.EntityFrameworkCore;
using Diary.Entities;
using Microsoft.Extensions.Configuration;

namespace Diary.Data
{
    public class Context : DbContext
    {
        const string SQL_CONNECTION_CONFIG_NAME = "SqlConnectionString";
        readonly string _connectionString;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }
        public Context(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(SQL_CONNECTION_CONFIG_NAME);
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects{ get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ChildParentRelationship> ChildParents { get; set; }
        public DbSet<ClassStudentRelationship> ClassStudents { get; set; }
    }
}
