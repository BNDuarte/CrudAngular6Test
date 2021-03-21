using System.Collections.Generic;

namespace Examples.Charge.Application.Dtos
{
    public class PersonDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<PersonPhoneDto> Phones { get; set; }
    }
}
