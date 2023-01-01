using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTeste.Domain.Commands.Validations
{
    public class RemovePeopleCommandValidation : PeopleValidation<RemovePeopleCommand>
    {
        public RemovePeopleCommandValidation()
        {
            ValidateId();
        }
    }
}
