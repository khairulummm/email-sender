using DataIntegration.Domain.Models.ViewModels.BUS.IKR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickerQ.Utilities.Models.Ticker;

namespace DataIntegration.Application.Interfaces.Scheduller.BUS
{
    public interface IIKRScheduller
    {
        Task<TimeTicker> GenerateAllStep(dtPostIKR param);
        Task<TimeTicker> GenerateStep1(dtPostIKR param);
        Task<TimeTicker> GenerateStep2(dtPostIKR param);
        Task<TimeTicker> GenerateStep3(dtPostIKR param);

    }
}
