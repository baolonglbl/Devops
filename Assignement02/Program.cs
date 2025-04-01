var builder = WebApplication.CreateBuilder(args);

// Chỉ bật HTTPS Redirection trong Development
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.HttpsPort = 7005;
    });
}

// Thêm các dịch vụ cần thiết
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Assignment02 API",
        Version = "v1",
        Description = "API for Assignment02"
    });
});

var app = builder.Build();

// Bật Swagger và Swagger UI trong cả Development và Production
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignment02 API V1");
});

// Chỉ bật HTTPS Redirection trong Development
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();

app.Run();