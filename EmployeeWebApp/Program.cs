using EmployeeWebApp.Services;
using EmployeeWebApp.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();