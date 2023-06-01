using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HtmlHelperViewMvc.Models;

namespace HtmlHelperViewMvc.Data;

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
}
