using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Command
{
    public class UpdateAlbumCommand : IRequest<UpdateAlbumCommandResponse>
    {
        public AlbumInputDto Album { get; set; }

        public Guid IdBanda { get; set; }

        public UpdateAlbumCommand(AlbumInputDto album)
        {
            Album = album;
        }
    }

    public class UpdateAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public UpdateAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
