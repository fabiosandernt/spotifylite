using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Service
{
    public interface IAlbumService
    {
        Task<AlbumOutputDto> Criar(AlbumInputDto dto);
        Task<AlbumOutputDto> Atualizar(AlbumInputDto dto);
        Task<AlbumOutputDto> Deletar(AlbumInputDto dto);
        Task<AlbumOutputDto> ObterPorId(Guid id);
        Task<List<AlbumOutputDto>> ObterTodos();
    }
}