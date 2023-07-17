using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TodoListWeb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnection")
));

//builder.Services.AddSwaggerGen();

var app = builder.Build();

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
//app.UseSwagger();

app.UseAuthorization();

app.MapControllerRoute(
name: "default",
pattern: "{controller=Job}/{action=Index}");

//app.MapControllerRoute(
//name: "Create",
//pattern: "{controller=Job}/{action=CreateJob}");

//app.MapControllerRoute(
//name: "Update",
//pattern: "{controller=Job}/{action=UpdateJob}");

//app.UseSwaggerUI();



app.Run();
