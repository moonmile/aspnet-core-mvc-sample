using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;

namespace HtmlHelperViewMvc.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]                                                  // 入力必須
        [MaxLength(20, ErrorMessage = "最大文字数は20文字までです")]   // 最大文字数を制限
        [Display(Name = "名前")]
        public string Name { get; set; } = "";

        [Range(18, 100, ErrorMessage = "年齢は18歳から100歳までです")]   // 範囲制限
        [Display(Name = "年齢")]
        [DisplayFormat(DataFormatString = "{0} 歳")]
        public int? Age { get; set; }                               // NULLを有効にする

        // Addressへ外部リンク
        [Display(Name = "都道府県")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }

        // 入社日（日付）
        [Display(Name = "入社日")]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        [DataType(DataType.Date)]
        [ValidJoinDate]
        public DateTime? JoinDate { get; set; }
        // 出社
        [Display(Name = "出社状態")]
        public bool IsAttendance { get; set; }
        // Email
        [Display(Name = "メールアドレス")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";
        // ブログページ(URL)
        [Display(Name = "ブログのURL")]
        [StringLength(1000)]
        [DataType(DataType.Url)]
        public string Blog { get; set; } = "";
        // 社員番号（正規表現) XXX-9999 形式
        [RegularExpression("[A-Z]{3}-[0-9]{4}")]
        [StringLength(8)]
        [Display(Name = "社員番号")]
        public string EmployeeNo { get; set; } = "";
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidJoinDate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = Convert.ToDateTime(value);
                if (date > DateTime.Now)
                {
                    return new ValidationResult("入社日は本日以前を指定してください");
                }
            }
            return ValidationResult.Success;
        }
    }

}
