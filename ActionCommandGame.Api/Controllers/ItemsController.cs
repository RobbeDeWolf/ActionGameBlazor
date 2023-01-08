using ActionCommandGame.Api.Authentication.Extensions;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Model.Results;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Api.Controllers
{
    public class ItemsController : ApiBaseController
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("items")]
        public async Task<IActionResult> Find()
        {
            var result = await _itemService.FindAsync(User.GetId());
            return Ok(result);
        }
        [HttpPost("items")]
        public async Task<IActionResult> Create(ItemResult item)
        {
	        var newitem = await _itemService.CreateAsync(item, User.GetId());
	        return Ok(newitem);
        }
        [HttpDelete("items/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
	        var isDeleted = await _itemService.DeleteAsync(id);
	        return Ok(isDeleted);
        }
	}
}
