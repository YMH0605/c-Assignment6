using System.Net;
using HRMAPI.Utility;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();

});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddlewareExtension();
    //app.UseExceptionHandler(options =>
    //{
    //    options.Run(async context =>
    //    {
    //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    //        var ex = context.Features.Get<IExceptionHandlerFeature>();
    //        if (ex != null)
    //        {
    //            //log the exception to the serilog
    //            await context.Response.WriteAsync("Custom Error = " + ex.Error.Message);
    //        }
    //    });
    //    //Run vs Use: Both used to creating middleware
    //    //Run: Adds a terminal middleware delegate to the application's request pipeline.
    //    //Use: Adds a middleware delegate to the application's xzrequest pipeline.
    //}); //UseExceptionHandler is a predefined middleware
}
 


app.UseAuthorization();

app.MapControllers();

app.Run();
