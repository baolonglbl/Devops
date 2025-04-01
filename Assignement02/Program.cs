{
    "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
        "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
            "applicationUrl": "http://localhost:18456",
      "sslPort": 44365
    }
    },
  "profiles": {
        "http": {
            "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5152",
      "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development"
      }
        },
    "https": {
            "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7000;http://localhost:5152",
      "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development"
      }
        },
    "IIS Express": {
            "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5152",
      "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development"
      }
        }
    }
}
var builder = WebApplication.CreateBuilder(args);// ? B?t HTTPS Redirection v?i c?ng HTTPS t? launchSettings.json
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7005; // ?? C?ng HTTPS ?ã khai báo trong launchSettings.json
}); builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); var app = builder.Build(); if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}// ? Middleware chuy?n h??ng HTTP sang HTTPS
app.UseHttpsRedirection(); app.UseAuthorization(); app.MapControllers(); app.Run();

