using Microsoft.EntityFrameworkCore;
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
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(SpotifyContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Album>> ObterTodosAlbuns()
        {
            return await this.Query.Include(x => x.Musicas).ToListAsync();
        }

    }
}
