using Azure;
using Microsoft.AspNetCore.Identity;
using PlataformaCursos.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PlataformaCursos.Domain.Entities;

public class TblUsuario
{
    [Key]
    public int Id { get;private set; }

    public string Email { get; private set; } = null!;
    public byte[] SenhaHash { get; private set; } = null!;
    public byte[] SenhaSalt { get; private set; } = null!;

    public bool IsProfessor { get; private set; } = false;
    public bool IsAdmin { get; private set; } = false;

    public bool Ativo { get; private set; } = true;

    public DateTime? DataCriacao { get; private set; }

    public DateTime? DataAlteracao { get; private set; }

    public ICollection<TblCurso> Curso { get; private set; } = new List<TblCurso>();

    public ICollection<TblMatricula> Matricula { get; private set; } = new List<TblMatricula>();

    public TblUsuario(int id, string email, bool isProfessor, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        DomainExceptionValidation.When(id < 0, "O ID tem que ser positivo");
        Id = id;
        ValidateDomain(email, isProfessor, dataCriacao, dataAlteracao);
    }

    public TblUsuario(string email, bool isProfessor, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain(email, isProfessor, dataCriacao, dataAlteracao);
    }

    public void Update(string email, bool isProfessor, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain(email, isProfessor, dataCriacao, dataAlteracao);
    }
    public void UpdateSenha(byte[] senhaHash, byte[] senhaSalt)
    {
        SenhaHash = senhaHash;
        SenhaSalt = senhaSalt;
    }
    public void SetAdmin(bool isAdmin)
    {
        IsAdmin = isAdmin;
    }
    public void Delete()
    {
        Ativo = false;
    }

    public void ValidateDomain( string email, bool isProfessor, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
      
        Email = email;
        IsProfessor = isProfessor;
        IsAdmin = false;
        Ativo = true;
        DataCriacao = dataCriacao;
        DataAlteracao = dataAlteracao;

    }

}
