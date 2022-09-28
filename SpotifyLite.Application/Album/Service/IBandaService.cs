using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Service
{
    public interface IBandaService
    {
        Task<BandaOutputDto> Criar(BandaInputDto dto);
        Task<BandaOutputDto> Atualizar(BandaInputDto dto);
        Task<BandaOutputDto> Deletar(BandaInputDto dto);
        Task<BandaOutputDto> ObterPorId(Guid id);
        Task<List<BandaOutputDto>> ObterTodos();
    }
}