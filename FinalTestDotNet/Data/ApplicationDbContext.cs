using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalTestDotNet.Models;

namespace FinalTestDotNet.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<FinalTestDotNet.Models.ComicBooks> ComicBooks { get; set; } = default!;

public DbSet<FinalTestDotNet.Models.Customers> Customers { get; set; } = default!;

public DbSet<FinalTestDotNet.Models.Rentals> Rentals { get; set; } = default!;
public DbSet<RentalDetails> RentalDetails { get; set; } = default!;
}