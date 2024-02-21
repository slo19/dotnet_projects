namespace Platform {
  public class QueryStringMiddleWare {
    private RequestDelegate next;
    public QueryStringMiddleWare(RequestDelegate nextDelegate) {
      next = nextDelegate;
    }

    public async Task Invoke(HttpContext context) {
      if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true") {
        if (!context.Response.HasStarted) {
          context.Response.ContentType = "text/plain";
        }
        await context.Response.WriteAsync("Class-based Middleware \n");
      }
      await next(context);
    }
  }
}
