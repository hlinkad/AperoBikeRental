using AperoRental.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AperoRental.API.DataContexts {

    public class DataContext : DbContext {
   
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder){
    
        modelBuilder.Entity<Bike>().Ignore(t => t.Speed);
        base.OnModelCreating(modelBuilder);
    }

        public DbSet<Bike> Bikes {get;set;}

        public DbSet<Speed> Speeds{get;set;}

        public DbSet<Admin> Admins {get;set;}
    }
}