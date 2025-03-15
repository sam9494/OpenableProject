using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenableProject.ExceptionHandler;
using OpenableProject.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo{ Title = "OpenTableProject", Version = "v1" });
    
    // 安全定義 "Bearer"
    // Define OAuth2.0 scheme
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization"
    });
    
    // 安全要求
    option.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
builder.Services.AddControllers();

// 其他服務
builder.Services.AddScoped<IUserInfoService, UserInfoService>(); 

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// 自定義的例外處理
builder.Services.AddExceptionHandler<NotExistExceptionHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenTableProject v1");
        options.OAuthClientId("swagger");
        options.OAuthAppName("OpenTableProject");
        options.OAuthUsePkce();
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler( // 通用的例外處理
    new ExceptionHandlerOptions()
    {
        ExceptionHandler = context =>
        {
            context.Response.StatusCode = 500;
            context.Response.WriteAsJsonAsync(
                new
                {
                    title = "An unexpected error occured.",
                    traceId = context.TraceIdentifier
                });
            return Task.CompletedTask;
        }
    });

// 方便測試用 可以省略----------------
app.MapGet("/exception", () =>
{
    throw new InvalidOperationException("An unexpected error occured.");
});

app.MapGet("/not-exist-exception", () =>
{
    throw new NotExistException("XoX");
});
// 方便測試用 可以省略----------------

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

