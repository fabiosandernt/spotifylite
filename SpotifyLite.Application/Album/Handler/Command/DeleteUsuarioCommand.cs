using MediatR;
using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Command
{
    public class DeleteUsuarioCommand : IRequest<DeleteUsuarioCommandResponse>
    {
        public UsuarioInputDto Usuario { get; set; }

        public DeleteUsuarioCommand(UsuarioInputDto usuario)
        {
            Usuario = usuario;
        }
    }

    public class DeleteUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public DeleteUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
