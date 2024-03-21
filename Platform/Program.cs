using Platform;

var builder = WebApplication.CreateBuilder(args);

var servicesConfig = builder.Configuration;
builder.Services.Configure<MessageOptions>(servicesConfig.GetSection("Location"));
var app = builder.Build();

var pipelineConfig = app.Configuration;

app.UseMiddleware<LocationMiddleware>();

app.MapGet("config", async (HttpContext context, IConfiguration config) =>
{
    string defaultDebug = config["Logging:LogLevel:Default"];
    await context.Response
      .WriteAsync($"The config setting is: {defaultDebug}");
});

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World!");
});

app.Run();
