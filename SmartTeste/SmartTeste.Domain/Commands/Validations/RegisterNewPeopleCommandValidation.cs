using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTeste.Domain.Commands.Validations
{
    public class RegisterNewPeopleCommandValidation : PeopleValidation<RegisterNewPeopleCommand>
    {
        public RegisterNewPeopleCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
