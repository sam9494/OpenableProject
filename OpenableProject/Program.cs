using OpenableProject.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//非自動綁定，而是按註冊順序逐一執行，有回傳 true 代表已處理，後續 Handler 就不再執行
builder.Services.AddExceptionHandler<OrderNotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<NullExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// 使用 IExceptionHandler 就要連帶使用，不然會噴錯
// 注入 IProblemDetailsService 可以自動設定 Response 的 ContentType，但 StatusCode 還是要手動設定
// postman 目前例外都能套用 ProblemDetails 格式
// swagger 目前只有自定義例外與 NotImplementedException 才會真的套用 ProblemDetails，其他不會
builder.Services.AddProblemDetails();


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

