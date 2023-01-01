using NetDevPack.Messaging;

namespace SmartTeste.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
