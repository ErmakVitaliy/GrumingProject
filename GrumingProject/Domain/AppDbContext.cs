using GrumingProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrumingProject.Domain
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<TextField> TextFields { get; set; }
		public DbSet<ServiceItem> ServiceItems { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "92178FA5-D127-4C34-9F8C-BF61FB770E95",
				Name = "admin",
				NormalizedName = "ADMIN"

			});

			builder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = "987530A2-805A-4AEC-98CA-2BB4B9883CBF",
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "my@mail.ru",
				NormalizedEmail = "MY@MAIL.RU",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "gavgav"),
				SecurityStamp = string.Empty
			});

			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				UserId = "987530A2-805A-4AEC-98CA-2BB4B9883CBF",
				RoleId = "92178FA5-D127-4C34-9F8C-BF61FB770E95"
			});

			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("47B6AD17-5ABB-4C8D-90B2-4062D9123F65"),
				CodeWord = "PageIndex",
				Title = "Главная"
			});
			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("E76B95C2-DD35-4BA3-94DB-7A0BCC5F39A7"),
				CodeWord = "PageService",
				Title = "Наши услуги"
			});
			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("D2BB8EA3-5CF9-4633-9A25-8969AFB42CE7"),
				CodeWord = "PageContacts",
				Title = "Контакты"
			});
		}
	}
}
