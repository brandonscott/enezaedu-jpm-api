using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EnezaApi.Models;

namespace EnezaApi.DataManager
{
    public class DataContext: DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentGrade> AssignmentGrades { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DataContext()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        //we not going to create model automatically
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Beach>().Property(a => a.Latitude).HasPrecision(9, 6);
        }

    }
}