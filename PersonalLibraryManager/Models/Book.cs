using Microsoft.EntityFrameworkCore;
using PersonalLibraryManager.Validation;
using System.ComponentModel.DataAnnotations;

namespace PersonalLibraryManager.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Book
    {
        [Key]
        [Display(Name = "Mã số sách")]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        [Display(Name = "Tên sách")]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        [Display(Name = "Tên tác giả")]
        public string Author { get; set; } = string.Empty;

        [Display(Name = "Năm phát hành")]
        public int Year { get; set; }

        [Display(Name = "Thể loại sách")]
        [MaxLength(50)]
        public string Genre { get; set; } = string.Empty;

        [Display(Name = "Đánh giá cá nhân")]
        [MaxLength(500)]
        public string? Review { get; set; }

        [Display(Name = "Thời gian đọc")]
        [ReadingTimeAfterYear("Year")]
        public DateTime? ReadingTime { get; set; }
    }
}