using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.ViewModels
{
    public class dtPostLogJobRequest
    {
        public long? LogJobRequestID { get; set; }

        public string? SchedullerID { get; set; }

        public string? Job { get; set; }

        public string? Method { get; set; }

        public string? Request { get; set; }

        public string? Response { get; set; }

        public decimal? ExecutionTime { get; set; }

        public string? UserID { get; set; }
    }
}
