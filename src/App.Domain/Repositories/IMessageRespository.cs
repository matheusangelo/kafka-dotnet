using App.Domain.Entities;

namespace App.Domain.Repositories
{
    public interface IMessageReposity{
        void Save(Message message);
        void Update(Message message);
        void Delete(Message message);
    }
}