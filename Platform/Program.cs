using Platform;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var logger = app.Services
      .GetRequiredService<ILoggerFactory>().CreateLogger("Pipeline");

logger.LogDebug("Pipeline configuration starting");

app.MapGet("population/{city?}", Population.Endpoint);

logger.LogDebug("Pipeline configuration complete");

app.Run();
