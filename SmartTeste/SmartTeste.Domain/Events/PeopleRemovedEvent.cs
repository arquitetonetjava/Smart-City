using NetDevPack.Messaging;

namespace SmartTeste.Domain.Events
{
    public class PeopleRemovedEvent : Event
    {
        public PeopleRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
