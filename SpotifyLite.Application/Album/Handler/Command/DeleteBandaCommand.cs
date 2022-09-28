using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Command
{
    public class DeleteBandaCommand : IRequest<DeleteBandaCommandResponse>
    {
        public BandaInputDto Banda { get; set; }

        public DeleteBandaCommand(BandaInputDto banda)
        {
            Banda = banda;
        }
    }

    public class DeleteBandaCommandResponse
    {
        public BandaOutputDto Banda { get; set; }

        public DeleteBandaCommandResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }
    }
}
