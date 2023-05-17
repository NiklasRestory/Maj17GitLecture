using Maj9AspNetDbFK.Models;
using Microsoft.EntityFrameworkCore;

namespace Maj9AspNetDbFK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // I imported Microsoft.AspNetCore.Mvc.NewtonsoftJson.
            // The reason for this is that when importing from
            // my database, if I grab Students for instance right
            // now, I import the Students, and I import that Student's
            // Courses... then I import the Students of those Courses,
            // then the Students of those Courses, and so on. That is
            // repeat infinitely. To stop it, I add NewtonsoftJson options
            // here to change ReferenceLoopHandling to Ignore. That way,
            // it'll not import infinitely.
            builder.Services.AddControllers().AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling
                     = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            builder.Services.AddDbContext<DatabaseContext>(
                (options) => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("SQLServerConnection")        
                )
            );

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

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();

            app.Run();
        }
    }
}