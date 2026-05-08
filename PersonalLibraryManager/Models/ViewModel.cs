using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonalLibraryManager.Models
{
    public class BookViewModel
    {
        [DisplayName("Mã số sách")]
        public int Id { get; set; }

        [DisplayName("Tên sách")]
        public string TenSach { get; set; } = string.Empty;

        [DisplayName("Tên tác giả")]
        public string TacGia { get; set; } = string.Empty;

        [DisplayName("Năm phát hành")]
        public int NamPhatHanh { get; set; }

        [DisplayName("Thể loại sách")]
        public string TheLoai { get; set; } = string.Empty;

        [DisplayName("Đánh giá cá nhân")]
        public string? DanhGia { get; set; }

        [DisplayName("Thời gian đọc")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? ThoiGianDoc { get; set; }
    }
}
