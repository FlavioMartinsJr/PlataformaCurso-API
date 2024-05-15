using System.Net;

namespace PlataformaCursos.API.Models
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Mensagem { get; set; } = null!;

        public ResponseModel(HttpStatusCode statusCode, string mensagem)
        {
            UpdateResponse(statusCode, mensagem);
        }

        public void UpdateResponse(HttpStatusCode statusCode, string mensagem)
        {
            Mensagem = mensagem;
            StatusCode = statusCode;
        }
    }
}
