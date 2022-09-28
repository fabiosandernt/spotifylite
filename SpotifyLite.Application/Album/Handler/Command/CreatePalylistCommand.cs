using MediatR;
using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Command
{
    public class CreatePlaylistCommand : IRequest<CreatePlaylistCommandResponse>
    {
        public PlaylistInputDto Playlist { get; set; }

        public CreatePlaylistCommand(PlaylistInputDto playlist)
        {
            Playlist = playlist;
        }
    }

    public class CreatePlaylistCommandResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public CreatePlaylistCommandResponse(PlaylistOutputDto playlist)
        {
            Playlist = playlist;
        }
    }
}
