using System.ComponentModel.DataAnnotations;

namespace SampleListDetailMvc.Models
{
    /// <summary>
    /// 著者名
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        [Display(Name = "著者名")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "年齢")]
        public int Age { get; set; }
        [Display(Name = "都道府県")]
        public int AddressId { get; set; }

        public virtual ICollection<Book>? Book { get; set; }
        public virtual Address? Address { get; set; }
    }
}
