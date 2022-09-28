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
    public class BandaRepository : Repository<Banda>, IBandaRepository
    {
        public BandaRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
