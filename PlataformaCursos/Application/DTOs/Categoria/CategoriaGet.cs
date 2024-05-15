using PlataformaCursos.Domain.Entities;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Categoria
{
    public class CategoriaGet
    {
        public int Id { get;  set; }

        public string Nome { get;  set; } = null!;

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblCursoCategoria> CursoCategoria { get;  set; } = new List<TblCursoCategoria>();

    }
}
