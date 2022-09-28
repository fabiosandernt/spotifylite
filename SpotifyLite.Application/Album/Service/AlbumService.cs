using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
        }

        public async Task<AlbumOutputDto> Criar(AlbumInputDto dto)
        {
            var album = this.mapper.Map<SpotifyLite.Domain.Models.Album>(dto);

            await this.albumRepository.Save(album);

            return this.mapper.Map<AlbumOutputDto>(album);

        }

        public async Task<AlbumOutputDto> Atualizar(AlbumInputDto dto)
        {
            var album = this.mapper.Map<SpotifyLite.Domain.Models.Album>(dto);

            await this.albumRepository.Update(album);

            return this.mapper.Map<AlbumOutputDto>(album);

        }

        public async Task<AlbumOutputDto> Deletar(AlbumInputDto dto)
        {
            var album = this.mapper.Map<SpotifyLite.Domain.Models.Album>(dto);

            await this.albumRepository.Delete(album);

            return this.mapper.Map<AlbumOutputDto>(album);

        }

        public async Task<List<AlbumOutputDto>> ObterTodos()
        {
            var album = await this.albumRepository.GetAll();

            return this.mapper.Map<List<AlbumOutputDto>>(album);
        }

        public async Task<AlbumOutputDto> ObterPorId(Guid id)
        {
            var album = await this.albumRepository.Get(id);

            return this.mapper.Map<AlbumOutputDto>(album);

        }
    }
}
