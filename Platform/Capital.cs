namespace Platform {
  public class Capital {
    private ReequestDelegate? next;
    
    public Capital() {}

    public Capital(ReequestDelegate nextDelegate) {
      next = nextDelegate;
    }

    public async Task Invoke(HttpContext context) {
      string[] parts = context.Request.Path.ToString()
        .Split("/", StringSplitOptions.RemoveEmptyEntries);
      if(parts.Length == 2 && parts[0] == "capital"){
        string? capital = null;
        string country = parts[1];
        switch (country.ToLower()) {
          case "Egypt":
            capital = "Cairo";
            break;
          case "Hungary":
            capital = "Budapest";
            break;
          case "monaco":
            context.Response.Redirect($"/population/{country}");
            break;
        }
        if(capital != null) {
          await context.Reponse
            .WriteAsync($"{capital} is the capital {country}");
          return;
        }
      }
      if(next != null){
        await next(context);
      }
    }
  }
}

