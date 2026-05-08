using System.ComponentModel.DataAnnotations;

namespace PersonalLibraryManager.Validation
{
    /// <summary>
    /// Validation attribute để đảm bảo ReadingTime không nhỏ hơn Year
    /// </summary>
    public class ReadingTimeAfterYearAttribute : ValidationAttribute
    {
        private readonly string _yearPropertyName;

        public ReadingTimeAfterYearAttribute(string yearPropertyName)
        {
            _yearPropertyName = yearPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Lấy giá trị ReadingTime (DateTime? có thể null)
            var readingTime = (DateTime?)value;

            // Lấy giá trị của property Year từ model
            var yearProperty = validationContext.ObjectType.GetProperty(_yearPropertyName);
            if (yearProperty == null)
            {
                return new ValidationResult($"Không tìm thấy property '{_yearPropertyName}'");
            }

            var yearValue = yearProperty.GetValue(validationContext.ObjectInstance);
            var year = (int?)yearValue;

            // Nếu ReadingTime là null -> bỏ qua validation (không bắt buộc)
            // Nếu bạn muốn bắt buộc phải có ReadingTime, hãy thêm [Required] attribute
            if (!readingTime.HasValue || !year.HasValue)
            {
                return ValidationResult.Success;
            }

            // Kiểm tra điều kiện: năm của ReadingTime phải >= Year
            if (readingTime.Value.Year < year.Value)
            {
                return new ValidationResult(
                    $"Thời gian đọc (năm {readingTime.Value.Year}) không được nhỏ hơn năm phát hành (năm {year.Value})",
                    new[] { validationContext.MemberName }
                );
            }

            return ValidationResult.Success;
        }
    }
}