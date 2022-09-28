using AutoMapper;
using SpotifyLite.Application.Album.Dto;
using SpotifyLite.Domain.Interfaces;
using SpotifyLite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public async Task<UsuarioOutputDto> Criar(UsuarioInputDto dto)
        {
            Usuario usuario = this.mapper.Map<Usuario>(dto);

            await this.usuarioRepository.Save(usuario);

            var banda2 = this.mapper.Map<UsuarioOutputDto>(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<UsuarioOutputDto> Atualizar(UsuarioInputDto dto)
        {
            var usuario = this.mapper.Map<Usuario>(dto);

            await this.usuarioRepository.Update(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<UsuarioOutputDto> Deletar(UsuarioInputDto dto)
        {
            var usuario = this.mapper.Map<Usuario>(dto);

            await this.usuarioRepository.Delete(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<UsuarioOutputDto> ObterPorId(Guid id)
        {
            var usuario = await this.usuarioRepository.Get(id);

            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<List<UsuarioOutputDto>> ObterTodos()
        {
            var result = await this.usuarioRepository.GetAll();

            return this.mapper.Map<List<UsuarioOutputDto>>(result);
        }

    }
}
