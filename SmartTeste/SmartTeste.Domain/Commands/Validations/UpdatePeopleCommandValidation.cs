namespace SmartTeste.Domain.Commands.Validations
{
    public class UpdatePeopleCommandValidation : PeopleValidation<UpdatePeopleCommand>
    {
        public UpdatePeopleCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
