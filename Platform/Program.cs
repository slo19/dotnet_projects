var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) => {
    await next();
    await context.Response
        .WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
        });
app.Use(async (context, next) => {
    if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true") {
      context.Response.ContentType = "text/plain";
      await context.Response.WriteAsync("Custom Middleware \n");
    }
    await next();
});
app.MapGet("/", () => "Hello World!");
app.UseMiddleware<Platform.QueryStringMiddleWare>();
app.Run();