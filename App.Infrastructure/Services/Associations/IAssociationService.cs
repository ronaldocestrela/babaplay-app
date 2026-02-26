using System;
using BabaPlayShared.Library.Models.Requests.Associations;
using BabaPlayShared.Library.Models.Responses.Associations;
using static BabaPlayShared.Library.Wrappers.IResponseWrapper;

namespace App.Infrastructure.Services.Associations;

public interface IAssociationService
{
    Task<IResponseWrapper<List<AssociationResponse>>> GetAllAsync();
    Task<IResponseWrapper<int>> CreateAsync(CreateAssociationRequest request);
    Task<IResponseWrapper<int>> UpdateAsync(UpdateAssociationRequest request);
    Task<IResponseWrapper<int>> DeleteAsync(string associationId);
    Task<IResponseWrapper<AssociationResponse>> GetByIdAsync(string associationId);
    Task<IResponseWrapper<AssociationResponse>> GetByNameAsync(string associationName);
}
