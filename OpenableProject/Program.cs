using OpenableProject.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddProblemDetails();//自動設定 Response 的 ContentType 與 StatusCode
builder.Services.AddExceptionHandler<OrderNotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler(_ => { });
app.MapControllers();

app.Run();

