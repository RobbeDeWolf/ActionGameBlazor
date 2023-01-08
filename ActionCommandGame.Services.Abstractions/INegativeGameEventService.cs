using System.Collections.Generic;
using System.Threading.Tasks;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;

namespace ActionCommandGame.Services.Abstractions
{
    public interface INegativeGameEventService
    {
        Task<ServiceResult<NegativeGameEventResult>> GetRandomNegativeGameEvent(string authenticatedUserId);
        Task<ServiceResult<IList<NegativeGameEventResult>>> Find(string authenticatedUserId);
        Task<ServiceResult<NegativeGameEventResult>> CreateAsync(NegativeGameEventResult newevent, string authenticatedUserId);

    }
}
