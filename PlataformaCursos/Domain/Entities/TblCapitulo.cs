using PlataformaCursos.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PlataformaCursos.Domain.Entities;

public class TblCapitulo
{
    [Key]
    public int Id { get; private set; }

    public string Titulo { get;  set; } = null!;

    public string Descricao { get;  set; } = null!;

    public string? VideoUrl { get;  set; }

    public int? CursoId { get; private set; }

    public DateTime? DataCriacao { get; private set; }

    public DateTime? DataAlteracao { get;  set; }

    public TblCurso? Curso { get; private set; }

    public ICollection<TblMatriculaCapitulo> MatriculaCapitulo { get; private set; } = new List<TblMatriculaCapitulo>();

    public TblCapitulo(int id, string titulo, string descricao, string? videoUrl, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        DomainExceptionValidation.When(id < 0, "O id tem que ser positivo");
        Id = id;
        ValidateDomain(titulo, descricao, videoUrl, cursoId, dataCriacao, dataAlteracao);
    }

    public TblCapitulo(string titulo, string descricao, string? videoUrl, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain(titulo, descricao, videoUrl, cursoId, dataCriacao, dataAlteracao);
    }

    public void Update(string titulo, string descricao, string? videoUrl, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain( titulo,  descricao,  videoUrl,  cursoId, dataCriacao,  dataAlteracao);
    }
    public void ValidateDomain(string titulo, string descricao, string? videoUrl, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        DomainExceptionValidation.When(cursoId < 0, "O cursoId tem que ser positivo");
        Titulo = titulo;
        Descricao = descricao;
        VideoUrl = videoUrl;
        CursoId = cursoId;
        DataCriacao = dataCriacao;
        DataAlteracao = dataAlteracao;
    }
}
