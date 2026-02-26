using BabaPlayShared.Library.Models.Requests.Associations;
using BabaPlayShared.Library.Models.Responses.Associations;
using static BabaPlayShared.Library.Wrappers.IResponseWrapper;
using App.Infrastructure.Extensions;
using App.Infrastructure.Services.Associations;
using System.Net.Http.Json;

namespace App.Infrastructure.Services.Implementations.Associations;

public class AssociationService(HttpClient httpClient, ApiSettings apiSettings) : IAssociationService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ApiSettings _apiSettings = apiSettings;

    public async Task<IResponseWrapper<int>> CreateAsync(CreateAssociationRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(_apiSettings.AssociationEndpoints!.Create, request);
        return await response.WrapToResponse<int>();
    }

    public async Task<IResponseWrapper<int>> DeleteAsync(string associationId)
    {
        var response = await _httpClient.DeleteAsync(_apiSettings.AssociationEndpoints!.GetDelete(associationId));
        return await response.WrapToResponse<int>();
    }

    public async Task<IResponseWrapper<List<AssociationResponse>>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(_apiSettings.AssociationEndpoints!.All);
        return await response.WrapToResponse<List<AssociationResponse>>();
    }

    public async Task<IResponseWrapper<AssociationResponse>> GetByIdAsync(string associationId)
    {
        var response = await _httpClient.GetAsync(_apiSettings.AssociationEndpoints!.GetById(associationId));
        return await response.WrapToResponse<AssociationResponse>();
    }

    public async Task<IResponseWrapper<AssociationResponse>> GetByNameAsync(string associationName)
    {
        var response = await _httpClient.GetAsync(_apiSettings.AssociationEndpoints!.GetByName(associationName));
        return await response.WrapToResponse<AssociationResponse>();
    }

    public async Task<IResponseWrapper<int>> UpdateAsync(UpdateAssociationRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync(_apiSettings.AssociationEndpoints!.Update, request);
        return await response.WrapToResponse<int>();
    }
}
