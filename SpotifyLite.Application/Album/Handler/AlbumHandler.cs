using MediatR;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Application.Album.Handler.Command;
using SpotifyLite.Application.Album.Handler.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Handler
{
    public class AlbumHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumCommandResponse>,
                                IRequestHandler<UpdateAlbumCommand, UpdateAlbumCommandResponse>,
                                IRequestHandler<DeleteAlbumCommand, DeleteAlbumCommandResponse>,
                                IRequestHandler<GetAllAlbumQuery, GetAllAlbumQueryResponse>,
                                IRequestHandler<GetAlbumQuery, GetAlbumQueryResponse>

    {
        private readonly IAlbumService _albumService;

        public AlbumHandler(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<CreateAlbumCommandResponse> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Criar(request.Album);
            return new CreateAlbumCommandResponse(result);
        }

        public async Task<UpdateAlbumCommandResponse> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Atualizar(request.Album);
            return new UpdateAlbumCommandResponse(result);
        }

        public async Task<DeleteAlbumCommandResponse> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Deletar(request.Album);
            return new DeleteAlbumCommandResponse(result);
        }

        public async Task<GetAllAlbumQueryResponse> Handle(GetAllAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.ObterTodos();
            return new GetAllAlbumQueryResponse(result);
        }

        public async Task<GetAlbumQueryResponse> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.ObterPorId(request.IdAlbum);
            return new GetAlbumQueryResponse(result);
        }
    }
}
