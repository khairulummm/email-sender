namespace DataIntegration.Application.Interfaces.Modules.BUS.IKR
{
    public interface IIKRGeneratePurchaseConfigurationService
    {
        Task<Dictionary<string, string>> GetAllConfiguration();
    }
}
