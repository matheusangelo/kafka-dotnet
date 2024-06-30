using App.Application.Contracts;
using App.Domain.Entities;
using App.Domain.Repositories;
using AutoMapper;
using FluentValidation;

namespace App.Application.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IMessageReposity _messageRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Message> _validator;
        private readonly IBrokerAdapter _adapter;

        public ProducerService(
                IMessageReposity messageReposity,
                IMapper mapper,
                IValidator<Message> validator,
                IBrokerAdapter adapter
            )
        {
            _messageRepository = messageReposity;
            _mapper = mapper;
            _validator = validator;
            _adapter = adapter;
        }
        public Message CreateMessage(CreateMessageDTO dto)
        {

            Message entity = _mapper.Map<Message>(dto);
            
            var validation = _validator.Validate(entity);
            
            if (!validation.IsValid){
                throw new ValidationException(validation.Errors);
            }

            entity.InsertedDate = DateTime.Now;

            _adapter.CreateMessageProvider(entity);

            _messageRepository.Save(entity);

            return entity;
        }
        public Message UpdateMessage(CreateMessageDTO dto)
        {

            Message entity = _mapper.Map<Message>(dto);

            var validation = _validator.Validate(entity);
            
            if (!validation.IsValid){
                throw new ValidationException(validation.Errors);
            }
            
            var currentMessage = _messageRepository.Get(entity);
 
             if (currentMessage is null){
                throw new Exception($"MessageID {currentMessage?.Id} does not exists");
            }

            _adapter.CreateMessageProvider(entity);

            _messageRepository.Update(entity);

            return entity;
        }
    }
}