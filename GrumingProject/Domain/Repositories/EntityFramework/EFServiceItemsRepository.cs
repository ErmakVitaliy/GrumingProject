using GrumingProject.Domain.Entities;
using GrumingProject.Domain.Repositories.Absrtact;
using Microsoft.EntityFrameworkCore;

namespace GrumingProject.Domain.Repositories.EntityFramework
{
	public class EFServiceItemsRepository : IServiceItemsRepository
	{
		private readonly AppDbContext context;

		public EFServiceItemsRepository(AppDbContext context)
		{
			this.context = context;
		}

		public void DeleteServiceItem(Guid id)
		{
			context.ServiceItems.Remove(new ServiceItem { Id = id });
			context.SaveChanges();
		}

		public ServiceItem GetServiceByItem(Guid id)
		{
			return context.ServiceItems.FirstOrDefault(x => x.Id == id);
		}

		public IQueryable<ServiceItem> GetServiceItems()
		{
			return context.ServiceItems;
		}

		public void SaveServiceItem(ServiceItem entity)
		{
			if (entity.Id == default)
				context.Entry(entity).State = EntityState.Added;
			else
				context.Entry(entity).State = EntityState.Modified;
			context.SaveChanges();
		}
	}
}
