using GameLibrary.Api;
using GameLibrary.Components;
using GameLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<GameLibraryDbContext>(options => 
    options.UseSqlite("Data Source=GameLibrary.db"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(DomainRepository<>));

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

app.MapStaticAssets();
app.UseAntiforgery();
app.MapControllerActions();

app.MapRazorComponents<App>().AddInteractiveWebAssemblyRenderMode().AddAdditionalAssemblies(typeof(GameLibrary.Client._Imports).Assembly);

app.Run();