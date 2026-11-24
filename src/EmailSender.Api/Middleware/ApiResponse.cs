using System.Text.Json.Serialization;

namespace DataIntegration.API.Middleware
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; } // Kode status HTTP (200, 400, 500, dll.)

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)] // Sembunyikan jika nilainya default (false)
        public bool IsError { get; set; } = false; // Penanda apakah ini respons error

        public string Message { get; set; } = string.Empty; // Pesan deskriptif

        // Sembunyikan jika null (untuk respons error tanpa data spesifik)
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; } // Data payload (generik)

        // Sembunyikan jika null atau kosong (hanya muncul saat ada error)
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; } // Daftar pesan error detail (misal: dari validasi atau exception)

        // --- Factory Methods untuk kemudahan ---

        public static ApiResponse<T> Success(int statusCode, T data, string message = "Success")
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                IsError = false,
                Message = message,
                Data = data
            };
        }

        // Overload untuk sukses tanpa data spesifik (misal: operasi Delete)
        public static ApiResponse<object> Success(int statusCode, string message = "Success")
        {
            return new ApiResponse<object> // Menggunakan object karena tidak ada data spesifik
            {
                StatusCode = statusCode,
                IsError = false,
                Message = message,
                Data = null // Eksplisit null
            };
        }

        public static ApiResponse<T> Fail(int statusCode, string message, List<string>? errors = null)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                IsError = true,
                Message = message,
                Errors = errors ?? new List<string>(), // Pastikan Errors tidak null
                Data = default // Data tidak relevan untuk error
            };
        }

        public static ApiResponse<object> Fail(int statusCode, string message, Exception ex, bool includeStackTrace = false)
        {
            var errors = new List<string>();
            var currentEx = ex;
            while (currentEx != null)
            {
                errors.Add(currentEx.Message);
                if (includeStackTrace && !string.IsNullOrEmpty(currentEx.StackTrace))
                {
                    errors.Add("StackTrace: " + currentEx.StackTrace); // Opsional: tambahkan stack trace (hati-hati di production)
                }
                currentEx = currentEx.InnerException;
            }

            return new ApiResponse<object> // Menggunakan object karena ini error global
            {
                StatusCode = statusCode,
                IsError = true,
                Message = message, // Pesan umum error
                Errors = errors,    // Detail dari exception dan inner exceptions
                Data = null
            };
        }
    }
}
