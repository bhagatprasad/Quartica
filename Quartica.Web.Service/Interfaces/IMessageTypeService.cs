using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Interfaces
{
    public interface IMessageTypeService
    {
        Task<List<MessageType>> fetchMessageTypesAync();

        Task<MessageType> fetchMessageTypesAync(long messageTypeId);
        Task<bool> RemoveMessageType(long messageTypeId);

        Task<MessageType> InsertOrUpdateMessageTypeAsync(MessageType messageType);  
    }
}
