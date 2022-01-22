using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


// Option 1 : for general logging
CreateHostBuilder(args).Build().Run();


// Log that an application started, check why it is not working
//var host = CreateHostBuilder(args).Build();
//var logger = host.Services.GetRequiredService<ILogger<Program>>();
//logger.LogInformation("The application has started");
//host.Run();


static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args).ConfigureLogging((context,logging) =>
    {
        logging.ClearProviders();
        logging.AddConfiguration(context.Configuration.GetSection("Logging"));
        logging.AddDebug();
        logging.AddConsole();

    }).ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<IStartup>();
    });
}