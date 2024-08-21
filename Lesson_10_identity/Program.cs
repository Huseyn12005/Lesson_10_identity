using Lesson_10_identity.Datas;
using Lesson_10_identity.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// ----------------------------------------------------------------------------------

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});



builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
{
    //options.User.RequireUniqueEmail = false;
    //options.User.AllowedUserNameCharacters = "abc";

    //options.Lockout = new LockoutOptions()
    //{
    //    DefaultLockoutTimeSpan = TimeSpan.Zero,
    //    AllowedForNewUsers = true,

    //};

    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
    

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.Password.RequiredLength = 8;
//});

// ----------------------------------------------------------------------------------



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
