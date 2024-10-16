using medicalcenter.project.api.CrossCutting.DependencyInjection;
using medicalcenter.project.api.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers( );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer( );
builder.Services.AddSwaggerGen( );

var connectionString = builder.Configuration.GetConnectionString( "DefaultConnection" );

builder.Services.AddDbContext<SqlServerDbContext>( options =>
{
    options.UseSqlServer( connectionString );
} );

builder.Services.ConfigureDependenciesRepository( );
builder.Services.ConfigureDependenciesService( );

builder.Services.AddCors( );

var app = builder.Build( );

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment( ) )
{
    app.UseSwagger( );
    app.UseSwaggerUI( );
}

app.UseCors( options =>
{
    options.WithOrigins( "http://localhost:3000" );
    options.AllowAnyMethod( );
    options.AllowAnyHeader( );
} );

app.UseHttpsRedirection( );

app.UseAuthorization( );

app.MapControllers( );

app.Run( );