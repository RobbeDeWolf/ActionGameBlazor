﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActionCommandGame.Model;
using ActionCommandGame.Repository;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Extensions;
using ActionCommandGame.Services.Helpers;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandGame.Services
{
    public class NegativeGameEventService: INegativeGameEventService
    {
        private readonly ActionCommandGameDbContext _database;

        public NegativeGameEventService(ActionCommandGameDbContext database)
        {
            _database = database;
        }
        
        public async Task<ServiceResult<NegativeGameEventResult>> GetRandomNegativeGameEvent(string authenticatedUserId)
        {
            var gameEvents = await Find(authenticatedUserId);
            var randomEvent = GameEventHelper.GetRandomNegativeGameEvent(gameEvents.Data);
            return new ServiceResult<NegativeGameEventResult>(randomEvent);
        }

        public async Task<ServiceResult<IList<NegativeGameEventResult>>> Find(string authenticatedUserId)
        {
            var negativeGameEvents = await _database.NegativeGameEvents
                .ProjectToResult()
                .ToListAsync();

            return new ServiceResult<IList<NegativeGameEventResult>>(negativeGameEvents);
        }

        public async Task<ServiceResult<NegativeGameEventResult>> CreateAsync(NegativeGameEventResult newevent, string authenticatedUserId)
        {
	        var dbevent = new NegativeGameEvent
	        {
		        Name = newevent.Name,
		        Description = newevent.Description,
		        DefenseWithGearDescription = newevent.DefenseWithGearDescription,
		        DefenseWithoutGearDescription = newevent.DefenseWithoutGearDescription,
		        DefenseLoss = newevent.DefenseLoss,
		        Probability = newevent.Probability 

			};

	        _database.NegativeGameEvents.Add(dbevent);
	        await _database.SaveChangesAsync();
             // needs checks
	        return new ServiceResult<NegativeGameEventResult>();
        }
	}
}
