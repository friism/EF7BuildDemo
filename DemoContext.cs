using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace BuildDemo
{
    public class DemoContext : DbContext
    {
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(@"Server=localhost;User ID=npgsql_tests;Password=npgsql_tests;Database=build_demo");
            //builder.UseSqlServer(@"Server=(localdb)\v11.0;Database=Blogging;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
