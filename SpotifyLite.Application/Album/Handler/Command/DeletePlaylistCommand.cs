using MediatR;
using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Command
{
    public class DeletePlaylistCommand : IRequest<DeletePlaylistCommandResponse>
    {
        public PlaylistInputDto Playlist { get; set; }

        public DeletePlaylistCommand(PlaylistInputDto playlist)
        {
            Playlist = playlist;
        }
    }

    public class DeletePlaylistCommandResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public DeletePlaylistCommandResponse(PlaylistOutputDto playlist)
        {
            Playlist = playlist;
        }
    }
}
