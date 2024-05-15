using PlataformaCursos.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PlataformaCursos.Domain.Entities;

public class TblCurso
{
    [Key]
    public int Id { get; private set; }

    public string Titulo { get; private set; } = null!;

    public string Descricao { get; private set; } = null!;

    public string ImagemUrl { get; private set; } = null!;

    public decimal Preco { get; private set; }

    public bool Publicado { get; private set; }
    public bool Ativo { get; private set; } = true;

    public int UsuarioId { get; private set; }

    public DateTime? DataCriacao { get; private set; }

    public DateTime? DataAlteracao { get; private set; }

    public ICollection<TblAnexo> Anexo { get; private set; } = new List<TblAnexo>();

    public ICollection<TblCapitulo> Capitulo { get; private set; } = new List<TblCapitulo>();

    public IEnumerable<TblCursoCategoria> CursoCategoria { get; private set; } = new List<TblCursoCategoria>();

    public ICollection<TblMatricula> Matricula { get; private set; } = new List<TblMatricula>();

    public TblUsuario? Usuario { get; private set; }

    public TblCurso(int id, string titulo, string descricao, string imagemUrl, decimal preco, bool publicado, int usuarioId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        DomainExceptionValidation.When(id < 0, "O id tem que ser positivo");
        Id = id;
        ValidateDomain(titulo, descricao, imagemUrl, preco, publicado, usuarioId, dataCriacao, dataAlteracao);
    }

    public TblCurso( string titulo, string descricao, string imagemUrl, decimal preco, bool publicado, int usuarioId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain(titulo, descricao, imagemUrl, preco, publicado, usuarioId, dataCriacao, dataAlteracao);
    }

    public void Update(string titulo, string descricao, string imagemUrl, decimal preco, bool publicado, int usuarioId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        ValidateDomain(titulo, descricao, imagemUrl, preco, publicado, usuarioId, dataCriacao, dataAlteracao);
    }
    public void Excluir()
    {
        Ativo = false;
    }
    public void ValidateDomain(string titulo, string descricao, string imagemUrl, decimal preco, bool publicado, int usuarioId, DateTime? dataCriacao, DateTime? dataAlteracao)
    {
        DomainExceptionValidation.When(usuarioId < 0, "O usuarioId tem que ser positivo");
       
        Titulo = titulo;
        Descricao = descricao;
        ImagemUrl = imagemUrl;
        Preco = preco;
        Publicado = publicado;
        UsuarioId = usuarioId;
        DataCriacao = dataCriacao;
        DataAlteracao = dataAlteracao;
        Ativo = true;
    }
}
