var builder = WebApplication.CreateBuilder(args);

// ? B?t HTTPS Redirection v?i c?ng HTTPS t? launchSettings.json
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7005; // ?? C?ng HTTPS ?ã khai báo trong launchSettings.json
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ? Middleware chuy?n h??ng HTTP sang HTTPS
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
