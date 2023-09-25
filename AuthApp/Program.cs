using System.Diagnostics;

namespace AuthApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Debug.WriteLine("starting web app");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection("MyApi"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            Debug.WriteLine($"MyKey {builder.Configuration["MyKey"]}");
            Console.WriteLine($"Console MyKey {builder.Configuration["MyKey"]}");

            app.Use(async (context, next) =>
            {
                ApiOptions option = new ApiOptions();
                Console.WriteLine($"MyKey {builder.Configuration["MyKey"]}");
                Console.WriteLine($"MyApi:url {builder.Configuration["MyApi:url"]}");
                Console.WriteLine($"MyApi:ApiKey value {builder.Configuration["MyApi:ApiKey"]}");

                builder.Configuration.GetSection("MyApi").Bind(option);
                var options = builder.Configuration.GetSection("MyApi").Get<ApiOptions>();

                Console.WriteLine($"MyApi:url {option.Url}");
                Console.WriteLine($"MyApi:ApiKey value {option.ApiKey}");

                Console.WriteLine($"MyApi:url {options.Url}");
                Console.WriteLine($"MyApi:ApiKey value {options.ApiKey}");

                Console.WriteLine($"MyApi:ApiKey1 value {builder.Configuration.GetValue<string>("MyApi:ApiKey1", "KEY1")}");

                await next();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}