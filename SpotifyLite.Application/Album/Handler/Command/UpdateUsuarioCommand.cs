using MediatR;
using SpotifyLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Handler.Command
{
    public class UpdateUsuarioCommand : IRequest<UpdateUsuarioCommandResponse>
    {
        public UsuarioInputDto Usuario { get; set; }

        public UpdateUsuarioCommand(UsuarioInputDto usuario)
        {
            Usuario = usuario;
        }
    }

    public class UpdateUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public UpdateUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
