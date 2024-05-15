using PlataformaCursos.Domain.Entities;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PlataformaCursos.Application.DTOs.MatriculaCapitulo
{
    public class MatriculaCapituloGet
    {
        public int Id { get; private set; }

        public bool Completo { get; set; }

        public int MatriculaId { get; private set; }

        public int CapituloId { get; private set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public TblCapitulo Capitulo { get; private set; } = null!;

        [JsonIgnore]
        [IgnoreDataMember]
        public TblMatricula Matricula { get; private set; } = null!;

    }
}
