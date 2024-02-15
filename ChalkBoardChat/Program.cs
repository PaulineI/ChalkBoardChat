using ChalkBoardChat.Data.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();




// H�mta anslutningsstr�ngen fr�n konfigurationen
var connectionString = builder.Configuration.GetConnectionString("AuthConnection");

// L�gg till AuthDbContext-tj�nsten i beh�llaren och konfigurera den f�r att anv�nda en SQL Server-databas med angiven anslutningsstr�ng
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));




// L�gg till tj�nster f�r Identity i beh�llaren, konfigurera anv�ndarklass (IdentityUser) och rollklass (IdentityRole), och ange att de ska anv�nda AuthDbContext f�r att lagra anv�ndar- och rollinformation
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

//Kollar vilken roll som �r inloggad
app.UseAuthentication();

app.UseAuthorization();  // Anv�nd auktorisering f�r att best�mma om en anv�ndare har beh�righet att komma �t en viss resurs

app.MapRazorPages();

app.Run();
