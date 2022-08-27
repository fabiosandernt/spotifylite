﻿using FluentValidation;
using SpotifyLite.CrossCutting.Entity;
using SpotifyLite.CrossCutting.Utils;
using SpotifyLite.Domain.Rules;
using SpotifyLite.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Domain.Models
{
    public class Usuario : Entity<Guid>
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public virtual IList<Playlist> Playlists { get; set; }

        public void SetPassword()
        {
            this.Password.Valor = SecurityUtils.HashSHA1(this.Password.Valor);
        }

        public void Validate() =>
            new UsuarioValidator().ValidateAndThrow(this);
    }
}
