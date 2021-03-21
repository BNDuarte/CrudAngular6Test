using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Cellphone { get; set; }
        public string Localphone { get; set; }
        //public List<PersonPhoneRequest> Phones { get; set; }
    }
}
