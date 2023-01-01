using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTeste.Domain.Events
{
    public class PeopleEventHandler :
        INotificationHandler<PeopleRegisteredEvent>,
        INotificationHandler<PeopleUpdatedEvent>,
        INotificationHandler<PeopleRemovedEvent>
    {
        public Task Handle(PeopleUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(PeopleRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(PeopleRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
