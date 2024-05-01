using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapPost("/submit", async context =>
{
    var name = context.Request.Form["name"];
    var email = context.Request.Form["email"];

    await context.Response.WriteAsync($"Name: {name}\nEmail: {email}");
});

app.MapGet("/", async context =>
{
    await context.Response.SendFileAsync("./Pages/index.html");
});

app.Run();