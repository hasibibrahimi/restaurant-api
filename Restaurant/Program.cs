using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RestaurantDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDbConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();

builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();

builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
   opt.TokenLifespan = TimeSpan.FromHours(2));

var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
var tokenValidationParamters = new TokenValidationParameters
{
	ValidateIssuer = false,
	ValidateAudience = false,
	ValidateLifetime = true,
	ValidateIssuerSigningKey = true,
	ValidIssuer = builder.Configuration["JWT:Issuer"],
	ValidAudience = builder.Configuration["JWT:Audience"],
	IssuerSigningKey = new SymmetricSecurityKey(Key),
	ClockSkew = TimeSpan.Zero
};
builder.Services.AddSingleton(tokenValidationParamters);
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
	.AddJwtBearer(o =>
	{
		o.SaveToken = true;
		o.TokenValidationParameters = tokenValidationParamters;
	});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.User.RequireUniqueEmail = true;

})
   .AddEntityFrameworkStores<RestaurantDBContext>()
   .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
	options.AddPolicy("MyPolicy",
		builder => {
			builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
		}
	)
);

var app = builder.Build();

app.UseCors("MyPolicy");
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
