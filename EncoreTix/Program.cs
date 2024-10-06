
using EncoreTix.Core.Configuration;
using EncoreTix.Core.Management;
using EncoreTix.Core.Services;
using EncoreTix.Core.Services.AttractionService;
using EncoreTix.Core.Services.EvenServices;
using Microsoft.Extensions.Options;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TicketMasterApiSettings>(builder.Configuration.GetSection("TicketMasterApi"));
builder.Services.AddTransient<ApiKeyHandler>();

builder.Services.AddHttpClient<IAttractionsService, AttractionsService>()
    .ConfigureHttpClient((serviceProvider, client) =>
    {
        var apiSettings = serviceProvider.GetRequiredService<IOptions<TicketMasterApiSettings>>().Value;
        client.BaseAddress = new Uri(apiSettings.BaseUrl);
    })
    .AddHttpMessageHandler<ApiKeyHandler>();

builder.Services.AddHttpClient<IEventService, EventService>().ConfigureHttpClient((serviceProvider, client) =>
    {
        var apiSettings = serviceProvider.GetRequiredService<IOptions<TicketMasterApiSettings>>().Value;
        client.BaseAddress = new Uri(apiSettings.BaseUrl);
    })
    .AddHttpMessageHandler<ApiKeyHandler>(); ;
builder.Services.AddTransient<IAttractionDetailManagement, AttractionDetailManagement>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLogging();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
