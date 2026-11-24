namespace DataIntegration.Application.Interfaces.Modules.BUS.SPH.NonNetwork
{
    public interface IAssignVendorTokenService
    {
        Task UpdateTokenVendorAsync(long assignVendorId, IServiceProvider serviceProvider);
    }
}
