using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete;
using MyBlog.Data.Abstract;
using MyBlog.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;

namespace MyBlog.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IBlogRepository, EfCoreBlogRepository>();
            builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            builder.Services.AddScoped<IMessagesRepository, EfCoreMessagesRepository>();
            builder.Services.AddScoped<ICommentRepository, EfCoreCommentRepository>();
            builder.Services.AddScoped<IAuthorRepository, EfCoreAuthorRepository>();

            builder.Services.AddScoped<IBlogService, BlogManager>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<IMessagesService, MessageManager>();
            builder.Services.AddScoped<ICommentService, CommetManager>();
            builder.Services.AddScoped<IAuthorService, AuthorManager>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();


            if (builder.Environment.IsDevelopment())
            {
                SeedDatabase.Seed();
            }
            builder.Services.AddMvc();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "MyBlogAdmin";
                options.LoginPath = "/Login/Login";
                options.AccessDeniedPath = "/Login/Login";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                    name: "blogdetails",
                    pattern: "{url}",
                    defaults: new { controller = "Home", action = "BlogDetails" }
                );

            app.MapControllerRoute(
                     name: "home",
                     pattern: "home/{category?}",
                     defaults: new { controller = "Home", action = "list" }
                 );


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}