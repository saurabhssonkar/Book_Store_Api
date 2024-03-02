using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using BookStore.Models.DataManager;
using BookStore.Models.DTO;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


// var builder = WebApplication.CreateBuilder(args);




// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();
// public void ConfigureServices(IServiceCollection services)
// {
//     services.AddDbContext<BookStoreContext>(opts => opts.UseMySql(Configuration["ConnectionString:DefaultConnection"]));
//     services.AddScoped<IDataRepository<Author, AuthorDto>, AuthorDataManager>();
//     services.AddScoped<IDataRepository<Book, BookDto>, BookDataManager>();
//     services.AddScoped<IDataRepository<Publisher, PublisherDto>, PublisherDataManager>();

//     services.AddControllers()
//         .AddNewtonsoftJson(
//             options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//         );
// }

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();



var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Dependency Injection
builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 23))));

builder.Services.AddScoped<IDataRepository<Author, AuthorDto>, AuthorDataManager>();
builder.Services.AddScoped<IDataRepository<Book, BookDto>, BookDataManager>();
builder.Services.AddScoped<IDataRepository<Publisher, PublisherDto>, PublisherDataManager>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(
        options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
