using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Application.Album.Dto
{
    public record PlaylistInputDto(Guid? Id,
        [Required(ErrorMessage = "O nome é requerido!")] string Nome, List<MusicaInputDto> musicas);
    public record PlaylistOutputDto(Guid Id, string Nome, List<MusicaOutputDto> musicas);
}
