using PlataformaCursos.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.Curso
{
    public class CursoGet
    {
        public int Id { get;  set; }

        public string Titulo { get;  set; } = null!;

        public string Descricao { get;  set; } = null!;

        public string ImagemUrl { get;  set; } = null!;

        public decimal Preco { get;  set; }

        public bool Publicado { get;  set; }

        public int UsuarioId { get;  set; }

        public DateTime? DataCriacao { get;  set; }

        public DateTime? DataAlteracao { get;  set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblAnexo> Anexo { get;  set; } = new List<TblAnexo>();

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblCapitulo> Capitulo { get;  set; } = new List<TblCapitulo>();

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblCursoCategoria> CursoCategoria { get;  set; } = new List<TblCursoCategoria>();

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<TblMatricula> Matricula { get;  set; } = new List<TblMatricula>();

        [JsonIgnore]
        [IgnoreDataMember]
        public TblUsuario? Usuario { get;  set; }

    }
}
