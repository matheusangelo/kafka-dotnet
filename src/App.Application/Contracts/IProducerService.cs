using App.Domain.Entities;

namespace App.Application.Contracts
{
    public interface IProducerService
    {
        Message CreateMessage(CreateMessageDTO dto);
        Message ReprocessMessage(CreateMessageDTO dto);
        Message UpdateMessage(CreateMessageDTO dto);
    }
}