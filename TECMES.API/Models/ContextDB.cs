using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECMES.Models
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
            //se um objeto ja existe não considera o mesmo na proxima migração
            Database.EnsureCreated();
        }

   
        public DbSet<Produto> Produto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

        }
    }
}
