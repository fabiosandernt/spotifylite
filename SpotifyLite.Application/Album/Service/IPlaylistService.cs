using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Service
{
    public interface IPlaylistService
    {
        Task<PlaylistOutputDto> Atualizar(PlaylistInputDto dto);
        Task<PlaylistOutputDto> Criar(PlaylistInputDto dto);
        Task<PlaylistOutputDto> Deletar(PlaylistInputDto dto);
        Task<PlaylistOutputDto> ObterPorId(Guid id);
        Task<List<PlaylistOutputDto>> ObterTodos();
    }
}
