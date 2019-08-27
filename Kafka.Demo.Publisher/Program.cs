using Confluent.Kafka;
using SharedConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Demo.Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {

            /*
             Objective create a push notification into kafka cluster
             */

            Console.WriteLine("Press any key to proceed with sending messages");
            Console.ReadKey();

            var conf = new ProducerConfig {
                BootstrapServers = KafkaServers.DefaultServer,

                SecurityProtocol = SecurityProtocol.Plaintext,
                SaslUsername = "alice",
                SaslPassword = "alice"
            };

            Action<DeliveryReport<Null, string>> handler = r =>
                Console.WriteLine(!r.Error.IsError
                    ? $"Delivered message to {r.TopicPartitionOffset}"
                    : $"Delivery Error: {r.Error.Reason}");

            using (var p = new ProducerBuilder<Null, string>(conf).Build())
            {
                for (int i = 0; i < 100; ++i)
                {
                    var message = $"{i.ToString()} at  {DateTime.Now.ToString("HH:mm:ss:FFFF")}";
                    p.Produce(TopicNames.DefaultTopic, new Message<Null, string> { Value = message }, handler);
                    //await p.ProduceAsync(TopicNames.DefaultTopic, new Message<Null, string> { Value = message });
                }

                // wait for up to 10 seconds for any inflight messages to be delivered.
                p.Flush(TimeSpan.FromSeconds(10));
            }

            Console.WriteLine("Finished sending messages. Press any key to close the app");
            Console.ReadKey();

        }
    }
}
