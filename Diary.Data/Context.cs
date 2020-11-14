﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<Score> Scores { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChildParentRelationship> ChildParents { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<ClassStudentRelationship> ClassStudents { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyValue> PropertyValues { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
