using SmartTeste.Domain.Commands.Validations;

namespace SmartTeste.Domain.Commands
{
    public class UpdatePeopleCommand : PeopleCommand
    {
        public UpdatePeopleCommand(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePeopleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
