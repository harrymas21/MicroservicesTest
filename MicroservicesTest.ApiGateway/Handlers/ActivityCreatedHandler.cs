using System;
using System.Threading.Tasks;
using MicroservicesTest.ApiGateway.Models;
using MicroservicesTest.ApiGateway.Repositories;
using MicroservicesTest.Common.Events;

namespace MicroservicesTest.ApiGateway.Handlers
{
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        private readonly IActivityRepository _repository;

        public ActivityCreatedHandler(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(ActivityCreated @event)
        {
            await _repository.AddAsync(new Activity
            {
                Id = @event.Id,
                UserId = @event.UserId,
                Category = @event.Category,
                Name = @event.Name,
                CreatedAt = @event.CreatedAt,
                Description = @event.Description
            });
            Console.WriteLine($"Activity created: {@event.Name}");
        }
    }
}