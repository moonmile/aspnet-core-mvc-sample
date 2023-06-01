using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SampleRoutingApiMvc.Models;
namespace SampleRoutingApiMvc.Data;

public partial class MvcdbContext : DbContext
{
    public MvcdbContext()
    {
    }

    public MvcdbContext(DbContextOptions<MvcdbContext> options)
        : base(options)
    {
    }
    public DbSet<Person> Person { get; set; }
}
