﻿
using AutoMapper;
using FilmesApi.Data.DTOS.Endereco;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
            CreateMap<CreateEnderecoDTO, Endereco>();
        }
    }
}
