using ActionCommandGame.Api.Authentication.Extensions;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Model.Results;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Api.Controllers
{
    public class GameController : ApiBaseController
    {
        private readonly IGameService _gameService;
        private readonly INegativeGameEventService _negativeGameEventService;
        private readonly IPositiveGameEventService _positiveGameEventService;

        public GameController(IGameService gameService, INegativeGameEventService negativeGameEvent, IPositiveGameEventService positiveGameEvent)
        {
            _gameService = gameService;
            _negativeGameEventService = negativeGameEvent;
            _positiveGameEventService = positiveGameEvent;
        }
        [HttpPost("game/{playerId}/perform-action")]
        public async Task<IActionResult> PerformAction(int playerId)
        {
            var result = await _gameService.PerformActionAsync(playerId, User.GetId());
            return Ok(result);
        }

        [HttpPost("game/{playerId}/buy/{itemId}")]
        public async Task<IActionResult> Buy(int playerId, int itemId)
        {
            var result = await _gameService.BuyAsync(playerId, itemId, User.GetId());
            return Ok(result);
        }
        [HttpPost("events/Negative")]
        public async Task<IActionResult> CreateNegativeEvent(NegativeGameEventResult nwevent)
        {
	        var newevent = await _negativeGameEventService.CreateAsync(nwevent, User.GetId());
	        return Ok(newevent);
        }
        [HttpPost("events/Positive")]
        public async Task<IActionResult> CreatePositiveEvent(PositiveGameEventResult nwevent)
        {
	        var newevent = await _positiveGameEventService.CreateAsync(nwevent, User.GetId());
	        return Ok(newevent);
        }
	}
}
