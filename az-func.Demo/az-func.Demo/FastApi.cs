using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace az_func.Demo;

public class FastApi
{
    private readonly ILogger<FastApi> _logger;
    private readonly IQuoteService _quoteService;

    public FastApi(ILogger<FastApi> logger , IQuoteService quoteService)
    {
        _logger = logger;
        _quoteService = quoteService;
    }

    // [Function("FastApi")]
    // public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    // {
    //     _logger.LogInformation("C# HTTP trigger function processed a request.");
    //     return new OkObjectResult("Welcome to Azure Functions!");
    // }


    [Function("DailyQuotes")]
    public IActionResult GetDailyQuotes([HttpTrigger(AuthorizationLevel.Function,"get", Route = "daily-quote")] HttpRequest req, string? category)
    {
        category ??= "all";
        _logger.LogInformation("Incoming Category: {category}", category);
        var q = category != "all" 
            ? _quoteService.GetRandomQuoteWithCategory(category)
            : _quoteService.GetRandomQuote();

        var time = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
        var resp = new OkObjectResult(new { quote = q , generateTime = time});
        _logger.LogInformation("Generated Response: Quote: {Author}, Time: {Time}", q.author, time);
        return resp;
    }

}