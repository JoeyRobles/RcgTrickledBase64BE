using JoeyRcgTryOut.Infrastructure.Services;
using JoeyRcgTryOut.Services.Encoding;
using JoeyRcgTryOut.Services.Encoding.Hubs;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IEncodingService, EncodingService>();

builder.Services.AddControllers();
builder.Services.AddSignalR();

var origins = config.GetValue<string>("AllowedOrigins").Split(',');
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins(origins)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapHub<EncodingHub>("/encoding");

app.Run();
