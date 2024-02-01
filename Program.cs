using WholesaleEcomBackend.Data;
using WholesaleEcomBackend.Data.Interfaces;
using WholesaleEcomBackend.Extensions;
using WholesaleEcomBackend.Middleware;
using WholesaleEcomBackend.Repository;
using WholesaleEcomBackend.Repository.Interfaces;
using WholesaleEcomBackend.Services;
using WholesaleEcomBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WholesaleEcomBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureCors();

            builder.Services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
                // Other logging providers

            });

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StoreContext>(x =>
                x.UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IBrandRepo, BrandRepo>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<ISubCategoryRepo, SubCategoryRepo>();
            builder.Services.AddScoped<ISubSubCategoryRepo, SubSubCategoryRepo>();
            builder.Services.AddScoped<ICharacteristicRepo, CharacteristicRepo>();


            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<ICharacteristicService, CharacteristicService>();
            builder.Services.AddScoped<WholesaleEcomBackend.Services.Interfaces.IAuthenticationService, WholesaleEcomBackend.Services.AuthenticationService>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);

            //To make sure HttpContextAccessor
            //is available to be injected as a dependency in DbContext.
            builder.Services.AddHttpContextAccessor();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}