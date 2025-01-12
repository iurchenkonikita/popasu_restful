using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using REDTFUL_web.Client.Pages;
using REDTFUL_web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:7257")
    }); 
builder.Services.AddHttpClient("MyApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:7257");
    client.Timeout = TimeSpan.FromSeconds(10); // Установка таймаута
});





var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(REDTFUL_web.Client._Imports).Assembly);

await app.RunAsync();
