namespace Trip.Api.Common.ExceptionHandling.Models
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
        public Error[] Details { get; set; }
        public InnerErrorModel InnerError { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
    }

    public class InnerErrorModel
    {
        public string Code { get; set; }
        public InnerErrorModel InnerError { get; set; }
     
    }
}
