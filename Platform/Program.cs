using Platform;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("{first:alpha:length(3)}/{second:bool}/", async context => {
    await context.Response.WriteAsync("Request was routed\n");
    foreach (var kvp in context.Request.RouteValues) 
    {
        await context.Response.WriteAsync($"{kvp.Key}: {kvp.Value}\n");
    }
});

app.MapGet("capital/{country:regex(^egypt|hungary|monaco$)}", Capital.Endpoint);
app.MapGet("size/{city?}", Population.Endpoint)
    .WithMetadata(new RouteNameMetadata("population"));

//app.Run(async (context) => {
//   await context.Response.WriteAsync("Terminal Middleware Reached"); 
//});

app.Run();
