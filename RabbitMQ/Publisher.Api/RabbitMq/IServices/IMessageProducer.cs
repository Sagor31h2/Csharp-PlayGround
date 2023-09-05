namespace Publisher.Api.RabbitMq.IServices
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
