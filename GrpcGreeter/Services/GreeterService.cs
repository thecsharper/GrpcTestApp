using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Grpc.Core;

namespace GrpcGreeter
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Request Name: {request.Name} Age: {request.Age} Corpus: {request.Corpus} Context host: { context.Host}");
            
            return Task.FromResult(new HelloReply
            {
                Message = $"Hello {request.Name}, your age is {request.Age}, Corpus: {request.Corpus}"
            });
        }
    }
}
