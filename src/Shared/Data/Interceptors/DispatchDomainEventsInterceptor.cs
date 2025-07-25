using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.DDD;

namespace Shared.Data.Interceptors;

public class DispatchDomainEventsInterceptor(IMediator mediator) : ISaveChangesInterceptor
{
    // allow to interact with the data when saving to the database 
    public InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return result;
    }

    public async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        await DispatchDomainEvents(eventData.Context);
        return result;
    }
    private async Task DispatchDomainEvents(DbContext? context)
    {
        if (context == null) return;
        var aggregates = context.ChangeTracker
            .Entries<IAggregate>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);
        
        var domainEvents = aggregates
            .SelectMany(e => e.DomainEvents)
            .ToList();
        aggregates.ToList().ForEach(a => a.ClearDomainEvents());
        
        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}