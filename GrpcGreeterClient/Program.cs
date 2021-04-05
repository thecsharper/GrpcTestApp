using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    public class Program
    {
        public static async Task Main()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Hello World!", Age = 21, Corpus = HelloRequest.Types.Corpus.Web });

            Console.WriteLine($"Greetings: {reply.Message}");
            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
        }
    }
}
