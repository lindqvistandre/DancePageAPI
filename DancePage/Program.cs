using Microsoft.EntityFrameworkCore;
using DancePage.Data;
using DancePage.DataAccessUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DanceDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<DanceDbContext>();
builder.Services.AddScoped<IGifsInfoDataAccess, GifsInfoDataAccess>();
builder.Services.AddScoped<IUsersDataAccess, UsersDataAccess>();
builder.Services.AddControllers();
builder.Services.AddCors();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
