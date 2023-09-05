using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace MqttPublisher
{
    class Publisher
    {
        static async Task Main(string[] args)
        {
            var faectory = new MqttFactory();
            var client = faectory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                               .WithClientId(Guid.NewGuid().ToString())
                               .WithTcpServer("localhost", 1883)
                               .WithCleanSession(true)
                               .Build();

            client.UseConnectedHandler(e =>
            {
                Console.WriteLine("Conneted to the server");
            });

            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("Disconneted from the server");
            });

            await client.ConnectAsync(options);

            await PublishMessage(client);

            await client.DisconnectAsync();
        }

        private static async Task PublishMessage(IMqttClient client)
        {
            Console.WriteLine("Please pass the message to subscriber");

            var payload = Console.ReadLine();

            var message = new MqttApplicationMessageBuilder().
                                    WithTopic("test0")
                                    .WithPayload(payload)
                                    .WithAtLeastOnceQoS()
                                    .Build();
            if (client.IsConnected)
            {
                await client.PublishAsync(message);
            }
        }
    }
}