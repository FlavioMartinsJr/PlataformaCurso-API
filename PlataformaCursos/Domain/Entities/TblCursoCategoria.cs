using PlataformaCursos.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlataformaCursos.Domain.Entities;

public class TblCursoCategoria
{
    [Key]
    public int Id { get; private set; }

    public int CursoId { get; private set; }

    public int CategoriaId { get; private set; }

    public TblCategoria Categoria { get; private set; } = null!;

    public TblCurso Curso { get; private set; } = null!;

    public TblCursoCategoria(int id, int cursoId, int categoriaId)
    {
        DomainExceptionValidation.When(id < 0, "O id tem que ser positivo");
        Id = id;
        ValidateDomain(cursoId, categoriaId);
    }

    public TblCursoCategoria(int cursoId, int categoriaId)
    {
        ValidateDomain(cursoId, categoriaId);
    }

    public void Update(int cursoId, int categoriaId)
    {
        ValidateDomain(cursoId, categoriaId);
    }

    public void ValidateDomain(int cursoId, int categoriaId)
    {
        DomainExceptionValidation.When(CursoId < 0, "O CursoId tem que ser positivo");
        DomainExceptionValidation.When(categoriaId < 0, "O categoriaId tem que ser positivo");
        
        CursoId = cursoId;
        CategoriaId = categoriaId;
    }
}
