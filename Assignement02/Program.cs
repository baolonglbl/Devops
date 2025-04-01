var builder = WebApplication.CreateBuilder(args);

// Chỉ bật HTTPS Redirection trong Development
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.HttpsPort = 7005;
    });
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection(); // Chỉ chạy HTTPS trong Development
}

app.UseAuthorization();
app.MapControllers();

app.Run();