
using Microsoft.EntityFrameworkCore;
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

            builder.Services.AddDbContext<TvoeTiloAppDbContext>(options => 
                options.UseSqlServer("Server=DESKTOP-VTKRU1B\\SQLEXPRESS;Database=TvoeTiloAppDb;Integrated Security=SSPI;TrustServerCertificate=True;"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
