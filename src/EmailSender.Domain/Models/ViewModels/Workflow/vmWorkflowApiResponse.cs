namespace DataIntegration.Domain.Models.ViewModels.Workflow
{
    public class vmWorkflowApiResponse<T>
    {
        public vmWorkflowApiResponse()
        {
            StatusCode = 0;
            Message = null;
        }

        public vmWorkflowApiResponse(int statusCode, string jsonError)
        {
            StatusCode = statusCode;
            Message = jsonError;
        }
        public int StatusCode { get; set; } // Kode status HTTP (200, 400, 500, dll.)
        public bool IsError { get; set; } = false; // Penanda apakah ini respons error
        public string Message { get; set; } = string.Empty; // Pesan deskriptif
        public T Data { get; set; } // Data payload (generik)
        public List<string> Errors { get; set; } // Daftar pesan error detail (misal: dari validasi atau exception)
    }
}
