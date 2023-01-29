using System.Globalization;
using WorldAround.API;
using WorldAround.Application;
using WorldAround.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddInfrastructure(configuration);
services.AddApplication();
services.AddApi(configuration);

services.AddCors(options =>
{
    options.AddPolicy("localhostUIOrigins",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200")
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });

    options.AddPolicy("prodUIOrigins",
        policy =>
        {
            policy
                .WithOrigins("https://worldaround.azurewebsites.net")
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var cultureInfo = new CultureInfo("en-US");

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(app.Environment.IsDevelopment()
    ? "localhostUIOrigins"
    : "prodUIOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
