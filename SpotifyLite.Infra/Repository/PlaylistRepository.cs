using SpotifyLite.Domain.Interfaces;
using SpotifyLite.Domain.Models;
using SpotifyLite.Infra.Context;
using SpotifyLite.Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Infra.Repository
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
