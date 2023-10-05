using GrumingProject.Domain.Repositories.Absrtact;

namespace GrumingProject.Domain
{
    public class DataManager
    {
        public DataManager(ITextFieldsRepository? textFields, IServiceItemsRepository? serviceItems)
        {
            TextFields = textFields;
            ServiceItems = serviceItems;
        }

        public ITextFieldsRepository? TextFields { get; set; }
        public IServiceItemsRepository? ServiceItems { get; set; }
    }
}
