using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Query
{
    public class GetBandaQuery : IRequest<GetBandaQueryResponse>
    {
        public Guid IdBanda { get; set; }

        public GetBandaQuery(Guid id)
        {
            IdBanda = id;
        }

    }

    public class GetBandaQueryResponse
    {
        public BandaOutputDto Banda { get; set; }

        public GetBandaQueryResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }
    }
}
