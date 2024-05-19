using App.Domain.Entities;
using App.Domain.Repositories;

namespace App.Infra.Repositories
{
    public class MessageRepository : IMessageReposity
    {

        public void Delete(Message message)
        {
        }

        public void Save(Message message)
        {
        }

        public void Update(Message message)
        {
        }

        Message IMessageReposity.Get(Message message)
        {
            throw new NotImplementedException();
        }
    }
}