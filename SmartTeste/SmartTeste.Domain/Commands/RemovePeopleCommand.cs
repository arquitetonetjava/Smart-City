using SmartTeste.Domain.Commands.Validations;

namespace SmartTeste.Domain.Commands
{
    public class RemovePeopleCommand : PeopleCommand
    {
        public RemovePeopleCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePeopleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
