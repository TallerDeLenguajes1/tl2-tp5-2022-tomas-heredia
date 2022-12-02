using Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//para cookies
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(100000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



// Para repositorio de cadetes (inyección de dependencia para el repositorio de cadetes)
builder.Services.AddTransient<IRepoCadete, RepoCadete>();
builder.Services.AddTransient<IRepoCliente, RepoCliente>();
builder.Services.AddTransient<IRepoPedido, RepoPedido>();
builder.Services.AddTransient<IRepoUsuario, RepoUsuario>();
var app = builder.Build();
//para cookies
app.UseSession();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
