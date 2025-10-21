using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MVC_Vue.Helpers
{
    // Lớp 'static' chứa các hàm 'static'
    public static class StringHelper
    {
        /**
         * 'this string text' biến hàm này thành một phương thức mở rộng.
         * Bạn có thể gọi: "Tên sản phẩm".GenerateSlug()
         */
        public static string GenerateSlug(this string text)
        {
            if (string.IsNullOrEmpty(text)) 
            {
                return "";
            }

            // 1. Bỏ dấu tiếng Việt
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            
            text = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            // 2. Chuyển sang chữ thường, thay khoảng trắng, 'đ'
            text = text.ToLowerInvariant()
                       .Replace(" ", "-")
                       .Replace("đ", "d"); 

            // 3. Xóa các ký tự đặc biệt
            text = Regex.Replace(text, @"[^a-z0-9\-]", ""); 
            
            // 4. Xóa các gạch nối thừa
            text = Regex.Replace(text, @"-+", "-");
            
            return text.Trim('-');
        }
    }
}