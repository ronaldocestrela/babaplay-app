using BabaPlayShared.Library.Models.Requests.Tenancy;
using BabaPlayShared.Library.Models.Responses.Tenency;
using static BabaPlayShared.Library.Wrappers.IResponseWrapper;

namespace App.Infrastructure.Services.Tenancy;

public interface ITenantService
{
    Task<IResponseWrapper<List<TenantResponse>>> GetAllAsync();
    Task<IResponseWrapper<TenantResponse>> GetByIdAsync(string tenantId);
    Task<IResponseWrapper<string>> CreateAsync(CreateTenantRequest request);
    Task<IResponseWrapper<string>> UpgradeSubscriptionAsync(UpdateTenantSubscriptionRequest request);
    Task<IResponseWrapper<string>> ActivateAsync(string tenantId);
    Task<IResponseWrapper<string>> DeActivateAsync(string tenantId);
}
