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
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IMapper mapper;

        public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            this.playlistRepository = playlistRepository;
            this.mapper = mapper;
        }

        public async Task<PlaylistOutputDto> Criar(PlaylistInputDto dto)
        {
            Playlist playlist = this.mapper.Map<Playlist>(dto);

            await this.playlistRepository.Save(playlist);

            var playlist2 = this.mapper.Map<PlaylistOutputDto>(playlist);

            return this.mapper.Map<PlaylistOutputDto>(playlist);
        }

        public async Task<PlaylistOutputDto> Atualizar(PlaylistInputDto dto)
        {
            var playlist = this.mapper.Map<Playlist>(dto);

            await this.playlistRepository.Update(playlist);

            return this.mapper.Map<PlaylistOutputDto>(playlist);
        }

        public async Task<PlaylistOutputDto> Deletar(PlaylistInputDto dto)
        {
            var playlist = this.mapper.Map<Playlist>(dto);

            await this.playlistRepository.Delete(playlist);

            return this.mapper.Map<PlaylistOutputDto>(playlist);
        }

        public async Task<PlaylistOutputDto> ObterPorId(Guid id)
        {
            var playlist = await this.playlistRepository.Get(id);

            return this.mapper.Map<PlaylistOutputDto>(playlist);
        }

        public async Task<List<PlaylistOutputDto>> ObterTodos()
        {
            var result = await this.playlistRepository.GetAll();

            return this.mapper.Map<List<PlaylistOutputDto>>(result);
        }

    }
}
