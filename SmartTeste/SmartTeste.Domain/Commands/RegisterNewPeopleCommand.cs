using SmartTeste.Domain.Commands.Validations;

namespace SmartTeste.Domain.Commands
{
    public class RegisterNewPeopleCommand : PeopleCommand
    {
        public RegisterNewPeopleCommand(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPeopleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
