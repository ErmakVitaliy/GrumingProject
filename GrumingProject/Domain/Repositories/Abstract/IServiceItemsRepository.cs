using GrumingProject.Domain.Entities;

namespace GrumingProject.Domain.Repositories.Absrtact
{
	public interface IServiceItemsRepository
	{
		IQueryable<ServiceItem> GetServiceItems();
		ServiceItem GetServiceByItem(Guid id);
		void SaveServiceItem(ServiceItem entity);
		void DeleteServiceItem(Guid id);
	}
}
