using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> Get(int id)
        {
            return Response(await _facade.GetAsync(id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _facade.Delete(id);
            return Response(0, null);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] PersonRequest request)
        {
            var persondto = new PersonDto()
            {
                Id = request.Id,
                Name = request.Name,
                Phones = new List<PersonPhoneDto>()
                {
                    new PersonPhoneDto(){PhoneNumber=request.Localphone,PhoneNumberTypeID=1},
                    new PersonPhoneDto(){PhoneNumber=request.Cellphone,PhoneNumberTypeID=2}
                }
            };

            await _facade.Save(persondto);
            return Response(0, null);
        }
    }
}
