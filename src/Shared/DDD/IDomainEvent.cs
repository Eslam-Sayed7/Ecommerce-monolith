using MediatR;

namespace Shared.DDD;

public interface IDomainEvent : INotification
{
   Guid EventId => Guid.NewGuid();
   DateTime OccurredOn => DateTime.Now;
   public string EventType => GetType().AssemblyQualifiedName!;
}