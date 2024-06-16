using System.Text.Json;
using App.Application.Contracts;
using App.Domain.Entities;
using Confluent.Kafka;

namespace App.Infra.Adapters
{
    public sealed class BrokerAdapter : IBrokerAdapter
    {
        private readonly ProducerConfig _producerConfig;
        public BrokerAdapter()
        {
            _producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };

        }
        public async Task<Message> CreateMessageProvider(Message message)
        {

            using var producer = new ProducerBuilder<Null, string>(_producerConfig).Build();

            try
            {
                var deliveryResult = await producer.ProduceAsync("app-topic", new Message<Null, string> { Value = JsonSerializer.Serialize(message) });
                Console.WriteLine($"Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
            return message;
        }

        public Message UpdateMessageProvider(Message message)
        {
            return message;
        }
    }
}