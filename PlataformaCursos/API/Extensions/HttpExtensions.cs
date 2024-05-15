using PlataformaCursos.API.Models;
using System.Text.Json;

namespace PlataformaCursos.API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationModel header)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Append("Pagination", JsonSerializer.Serialize(header, jsonOptions));
            response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
