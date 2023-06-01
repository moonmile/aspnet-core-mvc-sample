using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SampleControllerMvc.Models;

namespace SampleControllerMvc.Data;

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

    public virtual DbSet<Book> Book { get; set; }
}
