using ChalkBoardChat.Data.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();




// Hämta anslutningssträngen från konfigurationen
var connectionString = builder.Configuration.GetConnectionString("AuthConnection");

// Lägg till AuthDbContext-tjänsten i behållaren och konfigurera den för att använda en SQL Server-databas med angiven anslutningssträng
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));





// AppDbContext för att spara messages
var connectionStringMessages = builder.Configuration.GetConnectionString("AppDbConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStringMessages));

// Lägg till tjänster för Identity i behållaren, konfigurera användarklass (IdentityUser) och rollklass (IdentityRole), och ange att de ska använda AuthDbContext för att lagra användar- och rollinformation
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();


var app = builder.Build();

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

//Kollar vilken roll som är inloggad
app.UseAuthentication();

app.UseAuthorization();  // Använd auktorisering för att bestämma om en användare har behörighet att komma åt en viss resurs

app.MapRazorPages();

app.Run();
