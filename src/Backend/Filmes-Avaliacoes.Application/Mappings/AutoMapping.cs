﻿using AutoMapper;
using Filmes_Avaliacoes.Application.DTOs;
using Filmes_Avaliacoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes_Avaliacoes.Application.Mappings
{
	public class AutoMapping : Profile
	{

        public AutoMapping()
        {
            Request();
            RequestEdicao();
            RequestAvaliacao();
            EdicaoAvaliacao();
		}

        private void Request()
        {
            CreateMap<FilmeDto, Filme>()
                .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src =>
		            DateTime.ParseExact(src.DataLancamento, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}

        private void RequestEdicao()
        {
            CreateMap<FilmeEdicaoDto, Filme>()
                .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src =>
					DateTime.ParseExact(src.DataLancamento, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
		}

        private void RequestAvaliacao()
        {
            CreateMap<AvaliacaoDto, Avaliacao>();
        }

        private void EdicaoAvaliacao()
        {
            CreateMap<AvaliacaoEdicaoDto, Avaliacao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

    }
}
