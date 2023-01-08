using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActionCommandGame.Model;
using ActionCommandGame.Repository;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Extensions;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandGame.Services
{
    public class ItemService: IItemService
    {
        private readonly ActionCommandGameDbContext _dbContext;

        public ItemService(ActionCommandGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResult<ItemResult>> GetAsync(int id, string authenticatedUserId)
        {
            var item = await _dbContext.Items
                .ProjectToResult()
                .SingleOrDefaultAsync(i => i.Id == id);

            return new ServiceResult<ItemResult>(item);
        }

        public async Task<ServiceResult<IList<ItemResult>>> FindAsync(string authenticatedUserId)
        {
            var items = await _dbContext.Items
                .ProjectToResult()
                .ToListAsync();

            return new ServiceResult<IList<ItemResult>>(items);
        }
        public async Task<ServiceResult<ItemResult>> CreateAsync(ItemResult item, string authenticatedUserId)
        {
	        var dbItem = new Item
	        {
				Name = item.Name,
				Defense = item.Defense,
                Attack = item.Attack,
				Price = item.Price,
                Fuel = item.Fuel,
                Description = item.Description
	        };

	        _dbContext.Items.Add(dbItem);
	        await _dbContext.SaveChangesAsync();

	        return await GetAsync(dbItem.Id, authenticatedUserId);
        }
        public async Task<ServiceResult> DeleteAsync(int id)
        {
	        var serviceresult = new ServiceResult();
	        var item = new Item { Id = id };
	        _dbContext.Items.Attach(item);
	        _dbContext.Items.Remove(item);
	        await _dbContext.SaveChangesAsync();
	       
	        return serviceresult;

        }
	}
}
