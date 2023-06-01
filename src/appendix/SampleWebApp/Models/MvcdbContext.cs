using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApp.Models ;

public partial class MvcdbContext : DbContext
{
    public MvcdbContext()
    {
    }

    public MvcdbContext(DbContextOptions<MvcdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Person { get; set; }
    public virtual DbSet<Address> Address { get; set; }
}
