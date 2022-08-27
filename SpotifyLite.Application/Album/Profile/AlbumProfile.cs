﻿using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<Musica, MusicaOutputDto>()
                .ForMember(x => x.Duracao, f => f.MapFrom(m => m.Duracao.ValorFormatado()));

            CreateMap<MusicaInputDto, Musica>()
                .ForPath(x => x.Duracao.Valor, f => f.MapFrom(m => m.Duracao));

            CreateMap<SpotifyLite.Domain.Models.Album, AlbumOutputDto>();

            CreateMap<AlbumInputDto, SpotifyLite.Domain.Models.Album>();

            CreateMap<BandaInputDto, Banda>();

            CreateMap<Banda, BandaOutputDto>();

        }

    }
}
