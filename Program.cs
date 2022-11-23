using Amboosh_Library.Data;
using Amboosh_Library.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(Options => Options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddTransient<BookService>();
builder.Services.AddTransient<PublisherService>();
builder.Services.AddTransient<AuthorService>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //to revert to the pre-6.0 behavior, add the following at the start of your application, before any Npgsql operations are invoked

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();