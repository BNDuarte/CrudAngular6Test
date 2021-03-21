using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonResponse : BaseResponse
    {
        public List<PersonDto> PersonObjects { get; set; }
        public PersonDetailsDto PersonObject { get; set; }
        public List<PhoneNumberTypeDto> TypesNumbersObject { get; set; }
        public List<PersonDetailsDto> PersonDetailsObject { get; set; }
    }
}
