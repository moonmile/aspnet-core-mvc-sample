using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApiMySQL.Models;

[Table("person")]
public partial class Person
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
    // Addressへ外部リンク
    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;
}
