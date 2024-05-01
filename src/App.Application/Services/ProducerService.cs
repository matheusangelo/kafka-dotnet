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

            _adapter.CreateMessageProvider(entity);

            _messageRepository.Save(entity);

            return entity;
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