using PlataformaCursos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Curso
{
    public class CursoPost
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Titulo é obrigatório")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "O Descricao é obrigatório")]
        public string Descricao { get; set; } = null!;

        [Required(ErrorMessage = "O ImagemUrl é obrigatório")]
        public string ImagemUrl { get; set; } = null!;

        public decimal Preco { get; set; }

        public bool Publicado { get; set; } = true;

        [JsonIgnore]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O DataCriacao é obrigatório")]
        public DateTime? DataCriacao { get; set; }

        [Required(ErrorMessage = "O DataAlteracao é obrigatório")]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblAnexo> Anexo { get; set; } = new List<TblAnexo>();

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblCapitulo> Capitulo { get; set; } = new List<TblCapitulo>();

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblCursoCategoria> CursoCategoria { get; set; } = new List<TblCursoCategoria>();

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblMatricula> Matricula { get; set; } = new List<TblMatricula>();

        [JsonIgnore]
        [IgnoreDataMember]
        public TblUsuario? Usuario { get; set; }

    }
}
