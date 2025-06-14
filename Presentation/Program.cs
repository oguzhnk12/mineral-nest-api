using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Katman servislerini kapsayıcıya eklenmesi.
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

// Controller'ların kapsayıcıya eklenmesi.
builder.Services.AddControllers()
      .AddJsonOptions(opt =>
      {
          opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
      });


builder.Services.AddHttpContextAccessor();

// Swagger ve API Explorer'ın kapsayıcıya eklenmesi.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MineralNest.Api", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Kimlik Doğrulama",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Bearer şeması kullanılarak JWT Yetkilendirme başlığı. \r\n\r\n Aşağıdaki metin kutusuna 'Bearer' [boşluk] ve ardından jetonunuzu girin.\r\n\r\nÖrnek: \"Bearer abc123\""
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
