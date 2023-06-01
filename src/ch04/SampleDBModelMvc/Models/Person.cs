using System;
using System.Collections.Generic;

namespace SampleDBModelMvc.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }
}
