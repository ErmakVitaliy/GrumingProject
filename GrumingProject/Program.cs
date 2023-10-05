using GrumingProject.Domain.Repositories.Absrtact;
using GrumingProject.Domain.Repositories.EntityFramework;
using GrumingProject.Service;
using GrumingProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GrumingProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			//Подключаем конфиг из файла appsetting.json
			builder.Configuration.Bind("Project", new Config());

			//подключаем нужный функционал приложения в качестве сервисов
			builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
			builder.Services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
			builder.Services.AddTransient<DataManager>();

			//Подключаем контекст БД
			builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite(Config.ConnectionString));

			//Настраиваем identity систему
			builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
			{
				opts.User.RequireUniqueEmail = true;
				opts.Password.RequiredLength = 6;
				opts.Password.RequireNonAlphanumeric = false;
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireDigit = false;
			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

			//Настраиваем authentication cookie
			builder.Services.ConfigureApplicationCookie(option =>
			{
				option.Cookie.Name = "myCompanyAuth";
				option.Cookie.HttpOnly = true;
				option.LoginPath = "/account/login";
				option.AccessDeniedPath = "/account/accessdenied";
				option.SlidingExpiration = true;
			});

			//Настраиваем политику авторизации для Admin area
			builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
			});

			builder.Services.AddControllersWithViews(x =>
			{
				x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
			});

			var app = builder.Build();

			app.UseStaticFiles();

            app.UseRouting();

			//Настраиваем аутентификацию и авторизацию
			app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=index}/{id?}");

			app.MapDefaultControllerRoute();

			app.Run();
        }
    }
}