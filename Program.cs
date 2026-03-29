using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OllamaSharp;
using Radzen;
using RestSharp;
using VocabHub.Business;
using VocabHub.Components;
using VocabHub.Data.Models;
using VocabHub.Providers.WordDictionary;
using VocabHub.Providers.WordDictionary.DictionaryAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRadzenComponents();
builder.Services.AddDbContext<VocabHubDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VocabHubDatabase"));
});
builder.Services.AddSingleton<StoryGenerator>();

builder.Services.AddSingleton<IChatClient>(provider =>
{
    return new OllamaApiClient("http://localhost:11434", defaultModel: "llama3.2:latest");
});

builder.Services.AddSingleton<IRestClient>(provider =>
{
    return new RestClient("https://api.dictionaryapi.dev/api/v2/entries/en/");
});
builder.Services.AddScoped<IWordDictionary, DictionaryAPIService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
