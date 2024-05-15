using PlataformaCursos.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PlataformaCursos.Domain.Entities;

public class TblCategoria
{
    [Key]
    public int Id { get; private set; }

    public string Nome { get; private set; } = null!;

    public ICollection<TblCursoCategoria> CursoCategoria { get; private set; } = new List<TblCursoCategoria>();

    public TblCategoria(int id, string nome)
    {
        DomainExceptionValidation.When(id < 0, "O id tem que ser positivo");
        Id = id;
        ValidateDomain(nome);
    }

    public TblCategoria(string nome)
    {
        ValidateDomain(nome);
    }

    public void Update(string nome)
    {
        ValidateDomain(nome);
    }
    public void ValidateDomain(string nome)
    {
        Nome = nome;
    }
}
