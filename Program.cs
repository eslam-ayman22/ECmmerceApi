using EcommerceApi.Data;
using EcommerceApi.Repository;
using EcommerceApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(
              options=>options.UseSqlServer
              (builder.Configuration.GetConnectionString("DefaultConnecttion")));

            builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
