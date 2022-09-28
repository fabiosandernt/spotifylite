using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Command
{
    public class DeleteAlbumCommand : IRequest<DeleteAlbumCommandResponse>
    {
        public AlbumInputDto Album { get; set; }

        public DeleteAlbumCommand(AlbumInputDto album)
        {
            Album = album;
        }
    }

    public class DeleteAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public DeleteAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
