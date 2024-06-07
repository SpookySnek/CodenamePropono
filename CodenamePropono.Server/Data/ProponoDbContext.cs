using CodenamePropono.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CodenamePropono.Server.Data;

public class ProponoDbContext : DbContext
{
    public ProponoDbContext(DbContextOptions<ProponoDbContext> options)
        : base(options)
    {
        var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        if(dbCreater != null)
        {
            // Create Database 
            if(!dbCreater.CanConnect())
            {
                dbCreater.Create();
            }
 
            // Create Tables
            if (!dbCreater.HasTables())
            {
                dbCreater.CreateTables();
            }
        }
    }
 
    public DbSet<User> Users { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Photo> Photos { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User() { Id = 1337, Username = "MrCool", JoinDate = DateTime.Now, LastLogin = DateTime.Now }
            );
    }
}