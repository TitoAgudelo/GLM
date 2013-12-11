using IntranetGLM2013.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace IntranetGLM2013.DAL
{
    public class GLMEEDContext : DbContext
    {
        public GLMEEDContext() : base("GLMEED") { }


        public DbSet<LunchItem> LunchItems { get; set; }
        public DbSet<DailyLunch> DailyLunches { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}