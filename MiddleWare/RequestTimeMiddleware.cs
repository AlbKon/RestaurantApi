
using System.Diagnostics;

namespace RestaurantAPI.MiddleWare
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private Stopwatch _stopwatch;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;

        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
             await next.Invoke(context);
             _stopwatch.Stop();

             var elapsedMiliseconds = _stopwatch.ElapsedMilliseconds;
             if(elapsedMiliseconds>= 4000)
             {
                 var message = $"{context.Request.Method} at {context.Request.Path} took: {elapsedMiliseconds} ms";
                 _logger.LogInformation(message);
             }
        }
    }
}
