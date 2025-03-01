using Microsoft.EntityFrameworkCore;
using Quartica.Web.Service.DdContextConfiguration;
using Quartica.Web.Service.Interfaces;
using Quartica.Web.Service.Models;
using System.Diagnostics.CodeAnalysis;

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

        public async Task<MessageType> fetchMessageTypesAync(long messageTypeId)
        {
            return await dBContext.messageTypes.FindAsync(messageTypeId);
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

        public async Task<bool> RemoveMessageType(long messageTypeId)
        {
            var responce = await dBContext.messageTypes.FindAsync(messageTypeId);
            if (responce != null)
            {
                dBContext.messageTypes.Remove(responce);
            }
            var success = await dBContext.SaveChangesAsync();
            return success == 1 ? true : false;
        }
    }
}
