using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyLite.Application.Album.Dto;
using SpotifyLite.Application.Album.Handler.Command;
using SpotifyLite.Application.Album.Handler.Query;
using SpotifyLite.Domain.Interfaces;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetAllUsuarioQuery()));
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetUsuarioQuery(id)));
        }

        [HttpPost()]
        public async Task<IActionResult> Criar(UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new CreateUsuarioCommand(dto));
            return Created($"{result.Usuario.Id}", result.Usuario);
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new UpdateUsuarioCommand(dto));
            return Ok(result.Usuario);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteUsuarioCommand(dto));
            return Ok(result.Usuario);
        }

    }
}
