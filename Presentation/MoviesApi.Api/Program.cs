using MoviesApi.Persistence;
using MoviesApi.Application;
using MoviesApi.�nfrastructure;
using MoviesApi.Mapper;
using MoviesApi.Application.Exceptions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json",optional:false )
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional:true);


builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();
builder.Services.AddCustomMapper();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("vl", new OpenApiInfo { Title = "Movie API", Version = "v1", Description = "Movie API swagger client" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey,
        Scheme= "Bearer",
        BearerFormat="HWT",
        In=ParameterLocation.Header,
        Description = "`Bearer` yaz�p bo�luk b�rakt�ktan s�nra Token'� Girebilirsiniz  \r\n\r\n "
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureEcxeptionHandleMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
