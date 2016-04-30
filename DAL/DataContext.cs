using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataContext : DbContext
    {

        public DataContext()
            : base("UserDB")
        {

        }
        public DbSet<Model.User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseInitializer());

            base.OnModelCreating(modelBuilder);

        }
    }

    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // Seeding data here

            context.Users.Add(new Model.User
            {
                Id = 1,
                UserName = "orr",
                FirstName = "Orr",
                LastName = "Morad",
                Password = "1234"
            });

            context.Users.Add(new Model.User
            {
                Id = 2,
                UserName = "noam",
                FirstName = "Noam",
                LastName = "Caftori",
                Password = "1234"
            });

            context.Users.Add(new Model.User
            {
                Id = 3,
                UserName = "client3",
                FirstName = "First3",
                LastName = "Last3",
                Password = "1234"
            });

            context.Users.Add(new Model.User
            {
                Id = 4,
                UserName = "client4",
                FirstName = "First4",
                LastName = "Last4",
                Password = "1234"
            });

            context.SaveChanges();
        }
    }
}
