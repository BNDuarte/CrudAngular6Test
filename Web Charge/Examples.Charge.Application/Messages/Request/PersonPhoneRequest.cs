namespace Examples.Charge.Application.Messages.Request
{
    public class PersonPhoneRequest
    {
        public int? Id { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
    }
}
