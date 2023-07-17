using DAL.Interfaces;
using Domain.Entity;
using Domain.Responce;
using DAL.Repositories;
using Service.Interfaces;
using Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddScoped<IBaseRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
