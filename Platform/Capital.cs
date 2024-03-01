namespace Platform {
  public class Capital {
    private RequestDelegate? next;
    
    public Capital() {}

    public Capital(RequestDelegate nextDelegate) {
      next = nextDelegate;
    }

    public async Task Invoke(HttpContext context) {
      string[] parts = context.Request.Path.ToString()
        .Split("/", StringSplitOptions.RemoveEmptyEntries);
      if(parts.Length == 2 && parts[0] == "capital"){
        string? capital = null;
        string country = parts[1];
        switch (country.ToLower()) {
          case "egypt":
            capital = "Cairo";
            break;
          case "hungary":
            capital = "Budapest";
            break;
          case "monaco":
            context.Response.Redirect($"/population/{country}");
            break;
        }
        if(capital != null) {
          await context.Response
            .WriteAsync($"{capital} is the capital of {country}");
          return;
        }
      }
      if(next != null){
        await next(context);
      }
    }
  }
}

