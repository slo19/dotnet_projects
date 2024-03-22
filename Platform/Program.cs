using Platform;

var builder = WebApplication.CreateBuilder(args);

var servicesConfig = builder.Configuration;
builder.Services.Configure<MessageOptions>(servicesConfig.GetSection("Location"));

var servicesEnv = builder.Environment;
// use environment to set up services

var app = builder.Build();

var pipelineConfig = app.Configuration;

var pipelineEnv = app.Environment;
// use environment to set up pipeline

app.UseMiddleware<LocationMiddleware>();

app.MapGet("config", async (HttpContext context,
      IConfiguration config, IWebHostEnvironment env) =>
{
    string defaultDebug = config["Logging:LogLevel:Default"];
    await context.Response
      .WriteAsync($"The config setting is: {defaultDebug}");
    string environ = config["ASPNETCORE_ENVIRONMENT"];
    await context.Response.WriteAsync($"\nThe env setting is: {env.EnvironmentName}");
});

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World!");
});

app.Run();
