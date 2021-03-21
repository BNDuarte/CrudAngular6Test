using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Linq;

namespace Examples.Charge.Application.Dtos
{
    public class PersonDetailsDto
    {
        public PersonDetailsDto(Person person)
        {
            Id = person.BusinessEntityID;
            Name = person.Name;
            Cellphone = person.Phones.FirstOrDefault(c => c.PhoneNumberTypeID == 2).PhoneNumber;
            Localphone = person.Phones.FirstOrDefault(c => c.PhoneNumberTypeID == 1).PhoneNumber;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Cellphone { get; set; }
        public string Localphone { get; set; }
    }
}
