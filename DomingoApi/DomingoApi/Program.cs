using DomingoApi.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cadena de conexion a la db
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnetionString"));

});


//Configuracion de Cors 
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyCorsPolicy", configurePolicy: policyBuilder => {
        policyBuilder.WithOrigins("http://localhost:4200");
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowCredentials();
    }); 
});

var app = builder.Build();
app.UseHttpsRedirection();

app.UseStaticFiles(); // 🔴 here it is
app.UseRouting(); // 🔴 here it is

app.UseCors("MyCorsPolicy");
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
