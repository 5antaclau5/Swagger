namespace SwaggerAPI.Models
{
    public class ErrorResponse
    {
        public string? Type { get; set; }
        public string? Code { get; set; }
        public string? Message { get; set; }
        public string? DisplayMessage { get; set; }
        public string? Parameter { get; set; }
        public string? SessionID { get; set; }
    }
}