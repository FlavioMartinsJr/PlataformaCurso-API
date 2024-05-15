namespace PlataformaCursos.API.Models
{
    public class ResponsePagination<T>
    {
        public PaginationModel PaginationModel { get; set; }
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = "Consulta Realizada com Sucesso";
        public bool Sucesso { get; set; } = true;

        public ResponsePagination(T? dados, PaginationModel pagination)
        {
            PaginationModel = pagination;
            Dados = dados;
        }
    }
   
}
