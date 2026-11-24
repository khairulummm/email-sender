using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Application.Interfaces.Modules.BUS.IKR;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.BUS.IKR
{
    public class IKRGenerateService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : IIKRGenerateService
    {
        private readonly ItrxBUSFTTHIKRGenerateService _trxBUSFTTHIKRGenerateService;

        public IKRGenerateService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   ItrxBUSFTTHIKRGenerateService trxBUSFTTHIKRGenerateService
                                   ) : this(unitOfWorkFactory, serviceProvider)
        {
            _trxBUSFTTHIKRGenerateService = trxBUSFTTHIKRGenerateService;
        }

        public async Task<trxBUSFTTHIKRGenerate> GetGenerate()
        {
            try
            {
                var listGenerate = await _trxBUSFTTHIKRGenerateService.GetListAsync(orderBy: x => x.OrderByDescending(y => y.ID));
                return listGenerate.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateNew(trxBUSFTTHIKRGenerate data)
        {
            try
            {
                await _trxBUSFTTHIKRGenerateService.AddAsync(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateFinishTime(trxBUSFTTHIKRGenerate data)
        {
            try
            {
                await _trxBUSFTTHIKRGenerateService.UpdateAsync(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
