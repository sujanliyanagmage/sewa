using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using sewa.Entities;

namespace sewa.DBConfig
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
			Trace.WriteLine("XXXXXXXXXXXXXXXXX");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
	}
}

