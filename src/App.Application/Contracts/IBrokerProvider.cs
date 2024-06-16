using App.Domain.Entities;

namespace App.Application.Contracts
{
    public interface IBrokerAdapter{
        Message UpdateMessageProvider(Message message);
        Task<Message> CreateMessageProvider(Message message);

    }
}