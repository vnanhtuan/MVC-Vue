using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

//builder.Services.AddMvc().AddRazorOptions(opt => {
//    opt.ViewLocationFormats.Add("/Views/Shared/VueComponents/{0}.cshtml");
//});

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

app.UseAuthorization();

// ROUTE CHO ADMIN SPA (SỬ DỤNG AREA)
app.MapControllerRoute(
    name: "admin",
    pattern: "manage/{*path}",
    defaults: new { area = "Admin", controller = "Manage", action = "Index" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "spa-fallback",
    pattern: "cart", // Chỉ bắt đường dẫn /cart
    defaults: new { controller = "Home", action = "Index" }); // Luôn trả về Home/Index

app.Run();
