using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TraversalApi.DAL.Entities;

namespace TraversalApi.DAL.Context
{
    public class ApiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=GUNCU; database=TraversalDBAPI; integrated security=true;");
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
