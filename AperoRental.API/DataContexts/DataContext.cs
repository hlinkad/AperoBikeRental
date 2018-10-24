

using AperoRental.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AperoRental.API.DataContexts {

    public class DataContext : DbContext {
   
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }
        
        public DbSet<Bike> Bikes {get;set;}

        public DbSet<Speed> Speeds{get;set;}
    }
}