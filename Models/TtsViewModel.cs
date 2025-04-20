#nullable enable
using System.ComponentModel.DataAnnotations;

namespace TtsMp3Demo.Models
{
    public class TtsViewModel
    {
        [Required(ErrorMessage = "請輸入要轉語音的文字。")]
        [Display(Name = "輸入文字")]
        public string Msg { get; set; } = string.Empty;

        [Display(Name = "語音語者")]
        // 這裡改預設為 Matthew
        public string Lang { get; set; } = "Matthew";

        public string? Mp3Url { get; set; }
        public string? Error { get; set; }
    }
}
#nullable disable
