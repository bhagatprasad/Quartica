using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Interfaces
{
    public interface IMessageTypeService
    {
        Task<List<MessageType>> fetchMessageTypesAync();
        Task<MessageType> InsertOrUpdateMessageTypeAsync(MessageType messageType);  
    }
}
