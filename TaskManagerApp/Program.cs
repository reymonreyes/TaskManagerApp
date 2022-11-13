using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TaskManagerApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TaskManagerAppContextConnection") ?? throw new InvalidOperationException("Connection string 'TaskManagerAppIdentityContextConnection' not found.");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<TaskManagerAppContext>();
builder.Services.AddDbContext<TaskManagerAppIdentityContext>(opts => opts.UseSqlServer(connectionString));
builder.Services.AddSingleton<TokenProvider>();
builder.Services.AddSingleton<AppConfig>();

builder.Services.AddDefaultIdentity<TaskManagerAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<TaskManagerAppIdentityContext>();

//builder.Services.AddAuthorization(opts =>
//{
//    opts.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//});

var app = builder.Build();
SetupDirectories(app);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();
app.UseAuthorization();
//use a download razor page?
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, app.Configuration.GetValue<string>("UploadsDirectory"))),
//    RequestPath = "/fileattachments"
//});

app.Run();

void SetupDirectories(WebApplication application)
{
    var appConfig = application.Services.GetService<AppConfig>();
    var uploadsDirConfig = application.Configuration.GetValue<string>("UploadsDirectory");
    var uploadsDirFullPath = Path.Combine(application.Environment.ContentRootPath, uploadsDirConfig);
    if (!Directory.Exists(uploadsDirFullPath))
        Directory.CreateDirectory(uploadsDirFullPath);

    appConfig!.UploadsDirFullPath = uploadsDirFullPath;
}