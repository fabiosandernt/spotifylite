using MediatR;
using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Query
{
    public class GetPlaylistQuery : IRequest<GetPlaylistQueryResponse>
    {
        public Guid IdPlaylist { get; set; }

        public GetPlaylistQuery(Guid id)
        {
            IdPlaylist = id;
        }

    }

    public class GetPlaylistQueryResponse
    {
        public PlaylistOutputDto Playlist { get; set; }

        public GetPlaylistQueryResponse(PlaylistOutputDto playlist)
        {
            Playlist = playlist;
        }
    }
}
