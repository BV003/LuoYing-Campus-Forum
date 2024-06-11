using System.Collections.Specialized;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.X509;
using softs;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        String? connnectionString = builder.Configuration.GetConnectionString("DB");
        builder.Services.AddDbContext<UserDbContext>(opt => opt.UseMySQL(connnectionString));
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<CourseService>();
        builder.Services.AddScoped<TimetableService>();
        builder.Services.AddScoped<PostService>();
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
