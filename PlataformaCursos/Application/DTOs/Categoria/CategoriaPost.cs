using PlataformaCursos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Categoria
{
    public class CategoriaPost
    {
        [JsonIgnore]
        public int Id { get;  set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get;  set; } = null!;

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblCursoCategoria> CursoCategoria { get;  set; } = new List<TblCursoCategoria>();

    }
}
