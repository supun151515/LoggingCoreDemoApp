using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoggingCore.Pages
{
    public class IndexModel : PageModel
    {
        // Option 1 - to pass the IndexModel (ViewName in the logger)
        // This is the standard way of capturing the category
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ILogger _logger;
        public IndexModel(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("DemoCategory");
        }
         

        public void OnGet()
        {
            // Logging Levels
            // Different error levels from least significant to most significant
            _logger.LogTrace("This is a trace log"); // have a detailed view
            _logger.LogDebug("This is a debug log"); // debugging information etc.
            _logger.LogInformation("This is an information log"); // generally a flow for a particular customer
            _logger.LogWarning("This is a warning log"); // you have an issue (throw an exception , may be catch)
            _logger.LogError("This is an error log");  // Exception may crash
            _logger.LogCritical("This is an error log"); // Application is crashing , massive issue


            //_logger.LogInformation(LogginId.DemoCode, "This is first log Information");

            //// Advanced logging messages
            //_logger.LogError("The server went down temporarily at {Time}", DateTime.UtcNow);

            //try
            //{
            //    throw new Exception("You forgot to catch me");
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogCritical(ex, "There was a bad exception at {Time}", DateTime.UtcNow);
            //}

        }
    }

    public class LogginId
    {
        public const int DemoCode = 1001;

    }

}