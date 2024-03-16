using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IResponseFormatter, TimeResponseFormatter>();
builder.Services.AddScoped<ITimeStamper, DefaultTimeStamper>();

var app = builder.Build();
app.UseMiddleware<WeatherMiddleware>();

//IResponseFormatter formatter = new TextResponseFormatter();
app.MapGet("middleware/function", 
    async (HttpContext context, IResponseFormatter formatter) => {
      await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
    }
);

//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);
//app.MapWeather("endpoint/class");
app.MapEndpoint<WeatherEndpoint>("endpoint/class");

app.MapGet("endpoint/function", async (HttpContext context) => {
  IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
  await formatter.Format(context, "Endpoint Function: It is sunny in LA");
});

app.Run();
