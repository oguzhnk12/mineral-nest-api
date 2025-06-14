using Application;
using Presentation.Middlewares;
using System.Text.Json.Serialization;

// Uygulama yapılandırma nesnesi oluşturulması.
var builder = WebApplication.CreateBuilder(args);

// Katman servisleri DI konteynerine ekleniyor.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

// Controller'lar ve JSON enum desteği eklenmesi.
builder.Services.AddControllers()
      .AddJsonOptions(opt =>
      {
          opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
      });

// Swagger ve API Explorer servisleri eklenmesi.
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
        Description = "Bearer şeması ile JWT yetkilendirme başlığı. \r\n\r\n Aşağıdaki kutuya 'Bearer' [boşluk] ve ardından tokenınızı girin.\r\n\r\nÖrnek: \"Bearer abc123\""
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

// HTTP Context erişimi için servis eklenmesi.
builder.Services.AddHttpContextAccessor();

// Uygulama instance'ı oluşturuluyor.
var app = builder.Build();

// HTTP Pipeline yapılandırması.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

// Global hata yönetimi için middleware.
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
