using technical.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Retrieve connection string from appsettings.json.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                     connectionString,
                    new MySqlServerVersion(new Version(8, 0, 36))
                )
            );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapGet("/users", async (ApplicationDbContext db) =>
    await db.Users.ToListAsync());
app.MapGet("/users/{id}", async(int id, ApplicationDbContext db) =>
    await db.Users.FindAsync(id)
        is User user
            ? Results.Ok(user)
: Results.NotFound());

app.MapPost("/users", async (User inputUser, ApplicationDbContext db) =>
{
    db.Users.Add(inputUser);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{inputUser.Id}", inputUser);
});

app.MapPut("/users/{id}", async (int id, User inputUser, ApplicationDbContext db) =>
{
    var user = await db.Users.FindAsync(id);

    if (user is null) return Results.NotFound();

    user.Name = inputUser.Name;
    user.Birthday = inputUser.Birthday;
    user.Active = inputUser.Active;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/users/{id}", async (int id, ApplicationDbContext db) =>
{
    if (await db.Users.FindAsync(id) is User user)
    {
        db.Users.Remove(user);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});
app.Run();
