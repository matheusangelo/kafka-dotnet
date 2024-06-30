using App.Domain.Entities;
using App.Domain.Repositories;
using App.Infra.Contexts;

namespace App.Infra.Repositories
{
    public class MessageRepository : IMessageReposity
    {

        private readonly Context _dbContext;
        public MessageRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(Message message)
        {
            _dbContext.messages.Remove(message);
            _dbContext.SaveChanges();            
        }

        public void Save(Message message)
        {
            _dbContext.messages.Add(message);
            _dbContext.SaveChanges();
        }

        public void Update(Message message)
        {
            _dbContext.messages.Update(message);
            _dbContext.SaveChanges();          
        }

        public Message Get(Message message)
        {
            var messageEntity = _dbContext.messages
                                    .Where(m => m.Id == message.Id)
                                    .FirstOrDefault();

            if (messageEntity == null)
                throw new Exception($"Message with ID {message.Id} is not a message");
            
            return messageEntity;
        }
    }
}