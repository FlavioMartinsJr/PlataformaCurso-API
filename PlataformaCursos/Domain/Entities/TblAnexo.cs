using PlataformaCursos.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlataformaCursos.Domain.Entities;

public class TblAnexo
{
    [Key]
    public int Id { get; private set; }

    public string Nome { get;  set; } = null!;

    public string? ArquivoUrl { get;  set; }

    public int? CursoId { get; private set; }

    public DateTime? DataCriacao { get; private set; }

    public DateTime? DataAlteracao { get; set; }

    public TblCurso? Curso { get; private set; }

    public TblAnexo(int id, string nome, string? arquivoUrl, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        DomainExceptionValidation.When(id < 0, "O id tem que ser positivo");
        Id = id;
        ValidateDomain(nome, arquivoUrl, cursoId, dataCriacao, dataAlteracao);
    }

    public TblAnexo(string nome, string? arquivoUrl, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain(nome, arquivoUrl, cursoId, dataCriacao, dataAlteracao);
    }

    public void Update(string nome, string? arquivoUrl, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain(nome, arquivoUrl, cursoId, dataCriacao, dataAlteracao);
    }

    public void ValidateDomain(string nome, string? arquivoUrl, int? cursoId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        DomainExceptionValidation.When(cursoId < 0, "O cursoId tem que ser positivo");
        Nome = nome;
        ArquivoUrl = arquivoUrl;
        CursoId = cursoId;
        DataCriacao = dataCriacao;
        DataAlteracao = dataAlteracao;
    }
}
