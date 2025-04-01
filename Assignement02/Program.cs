var builder = WebApplication.CreateBuilder(args);// Chỉ bật HTTPS Redirection trong Development
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.HttpsPort = 7005;
    });
}// Thêm các dịch vụ cần thiết
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); var app = builder.Build();// Bật Swagger và Swagger UI trong cả Development và Production
app.UseSwagger();
app.UseSwaggerUI();// Chỉ bật HTTPS Redirection trong Development
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseAuthorization();
app.MapControllers(); app.Run();

