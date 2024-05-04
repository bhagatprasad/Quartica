using Microsoft.EntityFrameworkCore;
using Quartica.Web.Service.DdContextConfiguration;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;

namespace Quartica.Web.Service.Repository
{
    public class MessageTypeService : IMessageTypeService
    {
        private readonly ApplicationDBContext dBContext;
        public MessageTypeService(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<List<MessageType>> fetchMessageTypesAync()
        {
            var responce = await dBContext.messageTypes.ToListAsync();
            return responce;
        }

        public async Task<MessageType> InsertOrUpdateMessageTypeAsync(MessageType messageType)
        {
            if (messageType == null)
                return null;

            if (messageType.Id > 0)
            {
                var dbMessageType = await dBContext.messageTypes.FindAsync(messageType.Id);

                if (dbMessageType != null)
                {
                    dbMessageType.Name = messageType.Name;
                    dbMessageType.Code = messageType.Code;
                    dbMessageType.ModifiedBy = messageType.ModifiedBy;
                    dbMessageType.ModifiedOn = messageType.ModifiedOn;
                }
                await dBContext.SaveChangesAsync();

                return dbMessageType;
            }

            await dBContext.messageTypes.AddAsync(messageType);
            await dBContext.SaveChangesAsync();
            return messageType;
        }
    }
}
