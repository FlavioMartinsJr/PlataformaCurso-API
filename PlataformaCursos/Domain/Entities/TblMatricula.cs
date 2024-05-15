using PlataformaCursos.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PlataformaCursos.Domain.Entities;

public class TblMatricula
{
    [Key]
    public int Id { get; private set; }

    public int? UsuarioId { get; private set; }

    public int? CursoId { get; private set; }

    public DateTime? DataCriacao { get; private set; }

    public DateTime? DataAlteracao { get; private set; }

    public TblCurso Curso { get; private set; } = null!;

    public ICollection<TblMatriculaCapitulo> MatriculaCapitulo { get; private set; } = new List<TblMatriculaCapitulo>();

    public TblUsuario Usuario { get; private set; } = null!;

    public TblMatricula(int id, int? usuarioId, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        DomainExceptionValidation.When(id < 0, "O Id tem que ser positivo");
        Id = id;
        ValidateDomain(usuarioId, cursoId, dataCriacao, dataAlteracao);
    }

    public TblMatricula(int? usuarioId, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain(usuarioId, cursoId, dataCriacao, dataAlteracao);
    }

    public void Update(int? usuarioId, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain(usuarioId, cursoId, dataCriacao, dataAlteracao);
    }

    public void ValidateDomain(int? usuarioId, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        DomainExceptionValidation.When(usuarioId < 0, "O usuarioId tem que ser positivo");
        DomainExceptionValidation.When(cursoId < 0, "O cursoId tem que ser positivo");

        UsuarioId = usuarioId;
        CursoId = cursoId;
        DataCriacao = dataCriacao;
        DataAlteracao = dataAlteracao;
    }
}
