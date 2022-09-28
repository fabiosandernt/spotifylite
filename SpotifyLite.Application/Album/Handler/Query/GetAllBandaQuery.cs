using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Query
{
    public class GetAllBandaQuery : IRequest<GetAllBandaQueryResponse>
    {

    }

    public class GetAllBandaQueryResponse
    {
        public IList<BandaOutputDto> Bandas { get; set; }

        public GetAllBandaQueryResponse(IList<BandaOutputDto> bandas)
        {
            Bandas = bandas;
        }
    }
}
