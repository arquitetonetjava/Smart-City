using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using SmartTeste.Domain.Events;
using SmartTeste.Domain.Interfaces;
using SmartTeste.Domain.Models;

namespace SmartTeste.Domain.Commands
{
    public class PeopleCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewPeopleCommand, ValidationResult>,
    IRequestHandler<UpdatePeopleCommand, ValidationResult>,
    IRequestHandler<RemovePeopleCommand, ValidationResult>
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleCommandHandler(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewPeopleCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var people = new People(Guid.NewGuid(), message.Name, message.Email, message.BirthDate);

            if (await _peopleRepository.GetByEmail(people.Email) != null)
            {
                AddError("The people e-mail has already been taken.");
                return ValidationResult;
            }

            people.AddDomainEvent(new PeopleRegisteredEvent(people.Id, people.Name, people.Email, people.BirthDate));

            _peopleRepository.Add(people);

            return await Commit(_peopleRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdatePeopleCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var people = new People(message.Id, message.Name, message.Email, message.BirthDate);
            var existingPeople = await _peopleRepository.GetByEmail(people.Email);

            if (existingPeople != null && existingPeople.Id != people.Id)
            {
                if (!existingPeople.Equals(people))
                {
                    AddError("The people e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            people.AddDomainEvent(new PeopleUpdatedEvent(people.Id, people.Name, people.Email, people.BirthDate));

            _peopleRepository.Update(people);

            return await Commit(_peopleRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemovePeopleCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var people = await _peopleRepository.GetById(message.Id);

            if (people is null)
            {
                AddError("The people doesn't exists.");
                return ValidationResult;
            }

            people.AddDomainEvent(new PeopleRemovedEvent(message.Id));

            _peopleRepository.Remove(people);

            return await Commit(_peopleRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _peopleRepository.Dispose();
        }
    }
}
