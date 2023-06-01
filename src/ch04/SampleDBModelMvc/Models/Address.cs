using System;
using System.Collections.Generic;

namespace SampleDBModelMvc.Models;

public partial class Address
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
