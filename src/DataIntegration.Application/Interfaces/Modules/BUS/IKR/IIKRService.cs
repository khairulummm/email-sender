using DataIntegration.Domain.Models.ViewModels.BUS.IKR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.BUS.IKR
{
    public interface IIKRService
    {
        Task GenerateAllStep(dtPostIKR post);
        Task Step1(dtPostIKR post);
        Task Step2(dtPostIKR post);
        Task Step3();
    }
}
