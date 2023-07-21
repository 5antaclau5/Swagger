namespace SwaggerAPI.Models
{
    public class RequestHeader
    {
        public string Tenant { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Sender { get; set; }
        public string Signature { get; set; }
    }
}
