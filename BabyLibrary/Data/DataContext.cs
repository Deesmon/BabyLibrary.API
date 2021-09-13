using BabyLibrary.Domain.EFCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLibrary.Data
{
    /// <summary>
    /// DbContext for BabyLibrary domain storage including BabyLibrary and Authentication.
    /// Will probably refactor this to separate BabyLibrary and Authentication domain but will
    /// keep this that way for now.
    /// </summary>
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base (options)
        {

        }

        public DbSet<BookEFCore> Books { get; set; }
        public DbSet<BookLoanEFCore> BookLoans { get; set; }
        public DbSet<BookReservationEFCore> BookReservations { get; set; }
    }
}
