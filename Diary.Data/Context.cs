using Microsoft.EntityFrameworkCore;
using Diary.Entities;
using Microsoft.Extensions.Configuration;

namespace Diary.Data
{
    public class Context : DbContext
    {
        const string SQL_CONNECTION_CONFIG_NAME = "Diary";
        readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(SQL_CONNECTION_CONFIG_NAME);
        }

        public DbSet<SpecialTask> SpecialTasks { get; set; }
        public DbSet<SpecialTaskFile> SpecialTaskFiles { get; set; }
        public DbSet<SpecialTaskAnswer> SpecialTaskAnswers { get; set; }
        public DbSet<SpecialTaskAnswerFile> SpecialTaskAnswerFiles { get; set; }
        public DbSet<SpecialTaskAnswerScore> SpecialTaskAnswerScores { get; set; }
        
        public DbSet<Score> Scores { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChildParentRelationship> ChildParents { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<ClassStudentRelationship> ClassStudents { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyValue> PropertyValues { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LessonFile> LessonFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
