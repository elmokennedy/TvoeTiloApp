
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TvoeTiloApp.Api.Auth;
using TvoeTiloApp.Api.Extensions;
using TvoeTiloApp.Core.AutoMapperProfiles;
using TvoeTiloApp.Infrastructure.DataAccess.DbContexts;

namespace TvoeTiloApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCustomCoreServices();
            builder.Services.AddAutoMapper(x => x.AddProfile<MappingProfile>());

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOptions.Issuer,
                            ValidateAudience = true,
                            ValidAudience = AuthOptions.Audience,
                            ValidateLifetime = true,
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true
                        };
                    }
                );

            builder.Services.AddDbContext<TvoeTiloAppDbContext>(options => 
                options.UseSqlServer("Server=DESKTOP-VTKRU1B\\SQLEXPRESS;Database=TvoeTiloAppDb;Integrated Security=SSPI;TrustServerCertificate=True;"));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
