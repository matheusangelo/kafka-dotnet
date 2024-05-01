using App.Application.Contracts;
using App.Domain.Entities;

namespace App.Application.Services
{
    public class ProducerService : IProducerService
    {
        public Message CreateMessage(CreateMessageDTO dto)
        {
            return new Message("TEST", DateTime.Now);
        }

        public Message ReprocessMessage(CreateMessageDTO dto)
        {
            throw new NotImplementedException();
        }

        public Message UpdateMessage(CreateMessageDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}