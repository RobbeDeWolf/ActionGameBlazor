using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;

namespace ActionCommandGame.Sdk.Abstractions
{
    public interface IItemApi
    {
        Task<ServiceResult<IList<ItemResult>>> FindAsync();
        Task<ServiceResult<ItemResult>> Create(ItemResult itemResult);
        Task<ServiceResult> Delete(int id);

    }
}
