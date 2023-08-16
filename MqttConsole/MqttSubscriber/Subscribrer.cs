using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System.Text;

namespace MqttSubscriber
{
    internal class Subscribrer
    {
        static async Task Main(string[] args)
        {
            var faectory = new MqttFactory();
            var client = faectory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                               .WithClientId(Guid.NewGuid().ToString())
                               .WithTcpServer("broker.emqx.io", 1883)
                               .WithCleanSession(true)
                               .Build();

            client.UseConnectedHandler(async e =>
            {
                Console.WriteLine("Conneted to the server");

                var topic = new TopicFilterBuilder()
                                .WithTopic("test0")
                                .Build();
                await client.SubscribeAsync(topic);
            });

            client.UseDisconnectedHandler(e =>
            {
                Console.WriteLine("Disconneted from the server");
            });

            client.UseApplicationMessageReceivedHandler(e =>
            {
                Console.WriteLine($"Received Message {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            });

            await client.ConnectAsync(options);

            // Console.WriteLine("Please pass the message to subscriber");

            Console.ReadLine();

            await client.DisconnectAsync();
        }
    }
}