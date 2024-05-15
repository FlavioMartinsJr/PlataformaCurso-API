namespace PlataformaCursos.API.Errors
{
    public class ApiException
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }

        public ApiException(string statusCode, string message, string detail)
        {
            StatusCode = statusCode;
            Message = message;
            Detail = detail;
        }
    }
}
