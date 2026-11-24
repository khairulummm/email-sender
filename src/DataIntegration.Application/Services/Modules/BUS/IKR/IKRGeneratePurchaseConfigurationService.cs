using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Application.Interfaces.Modules.BUS.IKR;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Modules.BUS.IKR
{
    public class IKRGeneratePurchaseConfigurationService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : IIKRGeneratePurchaseConfigurationService
    {
        private readonly ImstBUSIKRGeneratePurchaseConfigurationService _mstBUSIKRGeneratePurchaseConfigurationService;

        public IKRGeneratePurchaseConfigurationService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   ImstBUSIKRGeneratePurchaseConfigurationService mstBUSIKRGeneratePurchaseConfigurationService
                                   ) : this(unitOfWorkFactory, serviceProvider)
        {
            _mstBUSIKRGeneratePurchaseConfigurationService = mstBUSIKRGeneratePurchaseConfigurationService;
        }

        public async Task<Dictionary<string, string>> GetAllConfiguration()
        {
            try
            {
                var data = await _mstBUSIKRGeneratePurchaseConfigurationService.GetListAsync();
                return data.ToDictionary(x => x.ConfigKey, x => x.ConfigValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
