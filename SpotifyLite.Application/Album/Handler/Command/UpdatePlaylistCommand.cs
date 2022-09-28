using MediatR;
using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Command
{
    public class UpdatePlaylistCommand : IRequest<UpdatePlaylistCommandResponse>
    {
        public PlaylistInputDto Playlist { get; set; }

        public UpdatePlaylistCommand(PlaylistInputDto playlist)
        {
            Playlist = playlist;
        }
    }

    public class UpdatePlaylistCommandResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public UpdatePlaylistCommandResponse(PlaylistOutputDto playlist)
        {
            Playlist = playlist;
        }
    }
}
