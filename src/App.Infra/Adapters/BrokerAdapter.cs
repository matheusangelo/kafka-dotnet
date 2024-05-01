using App.Application.Contracts;
using App.Domain.Entities;

namespace App.Infra.Adapters
{
    public sealed class BrokerAdapter : IBrokerAdapter
    {
        public Message CreateMessageProvider(Message message)
        {
            return message;
        }

        public Message UpdateMessageProvider(Message message)
        {
            return message;
        }
    }
}