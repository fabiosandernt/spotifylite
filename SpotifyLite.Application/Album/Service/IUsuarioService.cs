using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Atualizar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> Criar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> Deletar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> ObterPorId(Guid id);
        Task<List<UsuarioOutputDto>> ObterTodos();
    }
}
