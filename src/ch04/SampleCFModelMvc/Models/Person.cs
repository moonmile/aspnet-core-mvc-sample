using System;
using System.Collections.Generic;

namespace SampleCFModelMvc.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
    // Addressへ外部リンク
    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;
}
