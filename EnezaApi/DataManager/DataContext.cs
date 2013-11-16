using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EnezaApi.Models;

namespace EnezaApi.DataManager
{
    public class DataContext : DbContext
    {
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<AssignmentGrade> AssignmentGrade { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageType> MessageType { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<TeacherClass> TeacherClass { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> Pages { get; set; }
        
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