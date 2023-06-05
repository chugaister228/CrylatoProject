using CrylatoFront.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<PhrasesService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("PhrasesApi"));
});

builder.Services.AddHttpClient<CommentsService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("CommentsApi"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
