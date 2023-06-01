using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApiMySQL.Models ;

public partial class MvcdbContext : DbContext
{
    public MvcdbContext()
    {
    }

    public MvcdbContext(DbContextOptions<MvcdbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("server=localhost;database=mvcdb;user id=mvc;password=mvc");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }


    public virtual DbSet<Person> Person { get; set; }
    public virtual DbSet<Address> Address { get; set; }
}
