using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Application.Album.Service;
using SpotifyLite.Application.AzureBlob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Application.ConfigurationModule).Assembly);

            services.AddMediatR(typeof(Application.ConfigurationModule).Assembly);

            services.AddScoped<IBandaService, BandaService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPlaylistService, PlaylistService>();

            services.AddScoped<AzureBlobStorage>();

            services.AddHttpClient();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidateAudience = false,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ACDt1vR3lXToPQ1g3MyN"))
                        };
                    });

            var info = new OpenApiInfo();
            info.Version = "V1";
            info.Title = "API Projeto Spotify";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira : Bearer {seu token}",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In= ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
