using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleMvc.Models;

public partial class Person
{
    public int Id { get; set; }
    [Display(Name = "名前")]
    [MaxLength(10, ErrorMessage = "名前は10文字以内でお願いします")]
    public string Name { get; set; } = null!;
    [Display(Name = "年齢")]
    [DisplayFormat(DataFormatString = "{0} 歳")]
    [Range(18, 100, ErrorMessage = "年齢は18歳から100歳までです")]
    public int Age { get; set; }
}
