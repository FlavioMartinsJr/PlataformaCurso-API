using PlataformaCursos.Domain.Entities;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.CursoCategoria
{
    public class CursoCategoriaGet
    {
        public int Id { get;  set; }

        public int CursoId { get;  set; }

        public int CategoriaId { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCategoria Categoria { get;  set; } = null!;

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCurso Curso { get;  set; } = null!;

    }
}
