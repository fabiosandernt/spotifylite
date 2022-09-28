using MediatR;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Application.Album.Handler.Command;
using SpotifyLite.Application.Album.Handler.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler
{
    public class BandaHandler : IRequestHandler<CreateBandaCommand, CreateBandaCommandResponse>,
                                 IRequestHandler<UpdateBandaCommand, UpdateBandaCommandResponse>,
                                 IRequestHandler<DeleteBandaCommand, DeleteBandaCommandResponse>,
                                 IRequestHandler<GetAllBandaQuery, GetAllBandaQueryResponse>,
                                 IRequestHandler<GetBandaQuery, GetBandaQueryResponse>

    {
        private readonly IBandaService _bandaService;

        public BandaHandler(IBandaService bandaService)
        {
            _bandaService = bandaService;
        }

        public async Task<CreateBandaCommandResponse> Handle(CreateBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Criar(request.Banda);
            return new CreateBandaCommandResponse(result);
        }

        public async Task<UpdateBandaCommandResponse> Handle(UpdateBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Atualizar(request.Banda);
            return new UpdateBandaCommandResponse(result);
        }

        public async Task<DeleteBandaCommandResponse> Handle(DeleteBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Deletar(request.Banda);
            return new DeleteBandaCommandResponse(result);
        }

        public async Task<GetAllBandaQueryResponse> Handle(GetAllBandaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.ObterTodos();
            return new GetAllBandaQueryResponse(result);
        }

        public async Task<GetBandaQueryResponse> Handle(GetBandaQuery request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.ObterPorId(request.IdBanda);
            return new GetBandaQueryResponse(result);
        }
    }
}
