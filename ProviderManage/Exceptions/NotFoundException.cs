namespace ProviderManage.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Message = ex.Message
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unhandled exception");

                context.Response.StatusCode = 500;

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Message = "Internal Server Error"
                    });
            }
        }

    }

    [Serializable]
    internal class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
