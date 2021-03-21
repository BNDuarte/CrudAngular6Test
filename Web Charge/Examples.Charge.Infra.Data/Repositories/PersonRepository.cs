using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Delete(Person person)
        {
            _context.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person.Include(p => p.Phones).ThenInclude(p => p.PhoneNumberType));

        public async Task<Person> GetAsync(int id)
        {
            return await _context.Person.Include(p => p.Phones).ThenInclude(p => p.PhoneNumberType).FirstOrDefaultAsync(c => c.BusinessEntityID == id);
        }

        public async Task Save(Person person)
        {
            var oldEntity = await _context.Person.FindAsync(person.BusinessEntityID);

            if (oldEntity == null)
            {
                await _context.AddAsync(person);
            }
            else
            {
                _context.Entry(oldEntity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                _context.Update(person);
            }

            await _context.SaveChangesAsync();
        }
    }
}
