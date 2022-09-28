using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Command
{
    public class UpdateBandaCommand : IRequest<UpdateBandaCommandResponse>
    {
        public BandaInputDto Banda { get; set; }

        public UpdateBandaCommand(BandaInputDto banda)
        {
            Banda = banda;
        }
    }

    public class UpdateBandaCommandResponse
    {
        public BandaOutputDto Banda { get; set; }

        public UpdateBandaCommandResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }
    }
}
