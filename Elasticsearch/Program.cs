
using Elasticsearch;
using Elasticsearch.Net;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// .DefaultMappingFor<User>(m => m.IndexName("users"))
var uri = new Uri("https://localhost:9200");
//.BasicAuthentication("elastic", "3ZyXTb087yF3cE+Ts9yk")
var settings = new ConnectionSettings(uri)
    .BasicAuthentication("elastic", "3ZyXTb087yF3cE+Ts9yk")
    .DefaultMappingFor<User>(m => m.IndexName("users"));

builder.Services.AddSingleton<IElasticClient>(new ElasticClient(settings));

builder.Services.AddControllers();
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
