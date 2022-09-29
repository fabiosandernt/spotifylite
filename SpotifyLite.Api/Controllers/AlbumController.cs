using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpotifyLite.Application.Album.Handler.Command;
using SpotifyLite.Application.Album.Handler.Query;
using SpotifyLite.Application.AzureBlob;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator mediator;

        private IHttpClientFactory httpClientFactory;

        private AzureBlobStorage storage;

        public AlbumController(IMediator mediator, IHttpClientFactory httpClientFactory, AzureBlobStorage storage)
        {
            this.mediator = mediator;
            this.httpClientFactory = httpClientFactory;
            this.storage = storage;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetAllAlbumQuery()));
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetAlbumQuery(id)));
        }

        [HttpPost()]
        public async Task<IActionResult> Criar(AlbumInputDto dto)
        {

            HttpClient httpClient = this.httpClientFactory.CreateClient();

            using var response = await httpClient.GetAsync(dto.Backdrop);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();

                var fileName = $"{Guid.NewGuid()}.jpg";

                var pathStorage = await this.storage.UploadFile(fileName, stream);

                dto.Backdrop = pathStorage;

            }

            var result = await this.mediator.Send(new CreateAlbumCommand(dto));
            return Created($"{result.Album.Id}", result.Album);
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new UpdateAlbumCommand(dto));
            return Ok(result.Album);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteAlbumCommand(dto));
            return Ok(result.Album);
        }

    }
}
