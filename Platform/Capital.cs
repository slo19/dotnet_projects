namespace Platform {
  public class Capital {

    public static async Task Endpoint(HttpContext context) {
      string? capital = null;
      string? country = context.Request.RouteValues["country"] as string;
      switch ((country ?? "").ToLower()){
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
      } else {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
      }
    }
  }
}

