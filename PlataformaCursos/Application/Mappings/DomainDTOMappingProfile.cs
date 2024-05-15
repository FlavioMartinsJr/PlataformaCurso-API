using AutoMapper;
using PlataformaCursos.Application.DTOs;
using PlataformaCursos.Application.DTOs.Anexo;
using PlataformaCursos.Application.DTOs.Capitulo;
using PlataformaCursos.Application.DTOs.Categoria;
using PlataformaCursos.Application.DTOs.Curso;
using PlataformaCursos.Application.DTOs.CursoCategoria;
using PlataformaCursos.Application.DTOs.Matricula;
using PlataformaCursos.Application.DTOs.MatriculaCapitulo;
using PlataformaCursos.Application.DTOs.Usuario;
using PlataformaCursos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaCursos.Application.Mappings
{
    public class DomainDTOMappingProfile : Profile
    {
        public DomainDTOMappingProfile() 
        {
            CreateMap<TblUsuario, UsuarioGet>().ReverseMap();
            CreateMap<TblUsuario, UsuarioPost>().ReverseMap();
            CreateMap<TblUsuario, UsuarioPut>().ReverseMap();

            CreateMap<TblMatricula, MatriculaGet>().ReverseMap().ForMember(x => x.Usuario, option => option.MapFrom(x => x.UsuarioId));
            CreateMap<TblMatricula, MatriculaPost>().ReverseMap();
            CreateMap<TblMatricula, MatriculaPut>().ReverseMap();

            CreateMap<TblMatriculaCapitulo, MatriculaCapituloGet>().ReverseMap().ForMember(x => x.Matricula, option => option.MapFrom(x => x.MatriculaId));
            CreateMap<TblMatriculaCapitulo, MatriculaCapituloPost>().ReverseMap();

            CreateMap<TblCurso, CursoGet>().ReverseMap().ForMember(x => x.Usuario, option => option.MapFrom(x => x.UsuarioId));
            CreateMap<TblCurso, CursoPost>().ReverseMap();
            CreateMap<TblCurso, CursoPut>().ReverseMap();

            CreateMap<TblCapitulo, CapituloGet>().ReverseMap().ForMember(x => x.Curso, option => option.MapFrom(x => x.CursoId));
            CreateMap<TblCapitulo, CapituloPost>().ReverseMap();
            CreateMap<TblCapitulo, CapituloPut>().ReverseMap();

            CreateMap<TblAnexo, AnexoGet>().ReverseMap().ForMember(x => x.Curso, option => option.MapFrom(x => x.CursoId));
            CreateMap<TblAnexo, AnexoPost>().ReverseMap();
            CreateMap<TblAnexo, AnexoPut>().ReverseMap();

            CreateMap<TblCategoria, CategoriaGet>().ReverseMap();
            CreateMap<TblCategoria, CategoriaPost>().ReverseMap();
            CreateMap<TblCategoria, CategoriaPut>().ReverseMap();

            CreateMap<TblCursoCategoria, CursoCategoriaGet>().ReverseMap().ForMember(x => x.Curso, option => option.MapFrom(x => x.CursoId));
            CreateMap<TblCursoCategoria, CursoCategoriaPost>().ReverseMap();

        }
    }
}
