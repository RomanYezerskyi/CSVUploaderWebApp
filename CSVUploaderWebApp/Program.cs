using System.Reflection;
using CSVUploaderWebApp.BL.Behaviors.AddContacts;
using CSVUploaderWebApp.BL.Behaviors.GetContacts;
using CSVUploaderWebApp.DependencyInjection;
using CSVUploaderWebApp.DL.Extensions;
using CSVUploaderWebApp.Middleware;
using MediatR;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMssqlDbContext(builder.Configuration);

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblyContaining<GetContactsHandler>();
});

builder.Services.AddValidatorsFromAssemblyContaining<UploadContactsFileValidator>();

builder.Services.InjectServices();

var app = builder.Build();

await EnsureMigration.EnsureMigrationOfContext(app);

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

app.UseCustomExceptionHandler();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Data}/{action=Index}/{id?}");

app.Run();
