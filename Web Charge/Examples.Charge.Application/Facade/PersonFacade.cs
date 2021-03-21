using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _personService.Delete(id);
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonDetailsObject = new List<PersonDetailsDto>();
            response.PersonDetailsObject.AddRange(result.Select(x => new PersonDetailsDto(x)));
            return response;
        }

        public async Task<PersonResponse> GetAsync(int id)
        {
            var result = await _personService.GetAsync(id);
            var response = new PersonResponse();
            response.PersonObject = new PersonDetailsDto(result);
            return response;
        }

        public async Task Save(PersonDto person)
        {
            var oldPerson = await _personService.GetAsync(person.Id.GetValueOrDefault());

            if (oldPerson == null)
            {
                await _personService.Save(_mapper.Map<Person>(person));
            }
            else
            {
                var phones = new List<PersonPhone>(person.Phones.Select(x => _mapper.Map<PersonPhone>(x)));
                oldPerson.Name = person.Name;
                oldPerson.Phones = new List<PersonPhone>();
                foreach (var item in phones ?? Enumerable.Empty<PersonPhone>())
                {
                    oldPerson.Phones.Add(item);
                }
                await _personService.Save(oldPerson);
            }
        }
    }
}
