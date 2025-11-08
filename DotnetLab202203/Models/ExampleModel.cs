using DotnetLab202203.CustomValidate;
using System.ComponentModel.DataAnnotations;

namespace DotnetLab202203.Models
{
    public class ExampleModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "名前は10文字以下で入力してください。")]
        public string Name { get; set; } = string.Empty;

        [BirthDayValidator(ErrorMessage = "誕生日は過去日を入力してください。")]
        [Required]
        public DateTime BirthDay { get; set; } = DateTime.Now;
    }
}
