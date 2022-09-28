using AutoMapper;
using SpofityLite.Application.Album.Dto;
using SpotifyLite.Domain.Interfaces;
using SpotifyLite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Service
{
    public class BandaService : IBandaService
    {
        private readonly IBandaRepository bandaRepository;
        private readonly IMapper mapper;

        public BandaService(IBandaRepository bandaRepository, IMapper mapper)
        {
            this.bandaRepository = bandaRepository;
            this.mapper = mapper;
        }

        public async Task<BandaOutputDto> Criar(BandaInputDto dto)
        {
            Banda banda = this.mapper.Map<Banda>(dto);

            await this.bandaRepository.Save(banda);

            var banda2 = this.mapper.Map<BandaOutputDto>(banda);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<BandaOutputDto> Atualizar(BandaInputDto dto)
        {
            var banda = this.mapper.Map<SpotifyLite.Domain.Models.Banda>(dto);

            await this.bandaRepository.Update(banda);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<BandaOutputDto> Deletar(BandaInputDto dto)
        {
            var banda = this.mapper.Map<Banda>(dto);

            await this.bandaRepository.Delete(banda);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<BandaOutputDto> ObterPorId(Guid id)
        {
            var banda = await this.bandaRepository.Get(id);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<List<BandaOutputDto>> ObterTodos()
        {
            var result = await this.bandaRepository.GetAll();

            return this.mapper.Map<List<BandaOutputDto>>(result);
        }
    }
}
