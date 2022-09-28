using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Query
{
    public class GetAlbumQuery : IRequest<GetAlbumQueryResponse>
    {
        public Guid IdAlbum { get; set; }

        public GetAlbumQuery(Guid id)
        {
            IdAlbum = id;
        }


    }

    public class GetAlbumQueryResponse
    {
        public AlbumOutputDto Album { get; set; }

        public GetAlbumQueryResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
