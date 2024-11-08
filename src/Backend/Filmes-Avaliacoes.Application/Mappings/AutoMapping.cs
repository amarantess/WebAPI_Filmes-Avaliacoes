using AutoMapper;
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
        }

        private void Request()
        {
            CreateMap<FilmeDto, Filme>()
                .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src =>
		            DateTime.ParseExact(src.DataLancamento, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
		}
    }
}
