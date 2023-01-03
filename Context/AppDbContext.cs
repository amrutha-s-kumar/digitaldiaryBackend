using digitaldiaryBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace digitaldiaryBackend.Context
{
    public class AppDbContext: DbContext
        
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> tblTodo { get; set; }

        public DbSet<Event> tblEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}
