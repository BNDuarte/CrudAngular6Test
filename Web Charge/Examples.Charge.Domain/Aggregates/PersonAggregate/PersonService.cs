using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPhoneNumberTypeRepository _typeRepository;
        public PersonService(IPersonRepository personRepository, IPhoneNumberTypeRepository typeRepository)
        {
            _personRepository = personRepository;
            _typeRepository = typeRepository;
        }

        public async Task Delete(int id)
        {
            var person = await GetAsync(id);
            await _personRepository.Delete(person);
        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<Person> GetAsync(int id)
        {
            return await _personRepository.GetAsync(id);
        }


        public async Task Save(Person person)
        {
            for (int i = 0; i < person.Phones.Count(); i++)
            {
                person.Phones.ToArray()[i].PhoneNumberType = await _typeRepository.GetAsync(person.Phones.ToArray()[i].PhoneNumberTypeID);
            }

            await _personRepository.Save(person);
        }
    }
}

