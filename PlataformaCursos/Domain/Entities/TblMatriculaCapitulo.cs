using PlataformaCursos.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace PlataformaCursos.Domain.Entities;

public class TblMatriculaCapitulo
{
    [Key]
    public int Id { get; private set; }

    public bool Completo { get; set; }

    public int MatriculaId { get; private set; }

    public int CapituloId { get; private set; }

    public TblCapitulo Capitulo { get; private set; } = null!;

    public TblMatricula Matricula { get; private set; } = null!;

    public TblMatriculaCapitulo(int id, bool completo, int matriculaId, int capituloId)
    {
        DomainExceptionValidation.When(id < 0, "O ID tem que ser positivo");
        Id = id;
        ValidateDomain(completo, matriculaId, capituloId);
    }

    public TblMatriculaCapitulo(bool completo, int matriculaId, int capituloId)
    {
        ValidateDomain(completo, matriculaId, capituloId);
    }

    public void Update(bool completo, int matriculaId, int capituloId)
    {
        ValidateDomain(completo, matriculaId, capituloId);
    }

    public void ValidateDomain(bool completo, int matriculaId, int capituloId)
    {
        DomainExceptionValidation.When(matriculaId < 0, "O matriculaId tem que ser positivo");
        DomainExceptionValidation.When(capituloId < 0, "O capituloId tem que ser positivo");
        
        Completo = completo;
        MatriculaId = matriculaId;
        CapituloId = capituloId;
    }
}
