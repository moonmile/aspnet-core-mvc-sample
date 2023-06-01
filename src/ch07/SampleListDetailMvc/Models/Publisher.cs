using System.ComponentModel.DataAnnotations;

namespace SampleListDetailMvc.Models
{
    /// <summary>
    /// 出版社
    /// </summary>
    public class Publisher
    {
        public int Id { get; set; }
        [Display(Name = "出版社名")]
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Book>? Book { get; set; }
    }
}
