using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Dto
{
    public record UsuarioInputDto(Guid? Id,
        [Required(ErrorMessage = "O nome é requerido!")] string Nome,
        [Required(ErrorMessage = "O Email é requerido!")] string Email,
        [Required(ErrorMessage = "A Senha é requerida!")] string Password);
    public record UsuarioOutputDto(Guid Id, string Nome, string Email, string Password);
}
