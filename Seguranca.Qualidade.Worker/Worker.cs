namespace Segurança.Qualidade.Worker
{
    using MediatR;
    using Microsoft.Azure.ServiceBus;
    using Microsoft.Azure.ServiceBus.Core;
    using Microsoft.Extensions.Hosting;
    using Segurança.Qualidade.Application.Domain.NormasTecnicasAggregate;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Text;
    using Segurança.Qualidade.Application.Command;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;
        private readonly IMessageReceiver _subscriptionReceiver;

        public Worker(ILogger<Worker> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _subscriptionReceiver = new MessageReceiver(config.GetValue<string>("AzureServiceBus:ConnectionString"), 
                                                        config.GetValue<string>("AzureServiceBus:QueueName"));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await RecuperarMensagensFilaAsync(stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }

        async Task RecuperarMensagensFilaAsync(CancellationToken cancellationToken)
        {
            var doneReceiving = new TaskCompletionSource<bool>();

            cancellationToken.Register(
                async () =>
                {
                    await _subscriptionReceiver.CloseAsync();
                    doneReceiving.SetResult(true);
                });

            var messageHandlerOption = new MessageHandlerOptions(OnErrorException)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false,
                MaxAutoRenewDuration = TimeSpan.FromSeconds(60)
            };

            _subscriptionReceiver.RegisterMessageHandler(ProcessMessagemAsync, messageHandlerOption);

            await doneReceiving.Task;
        }

        public async Task ProcessMessagemAsync(Message message, CancellationToken cancellationToken)
        {
            var evento = FromBody(message.Body);
            var command = new ReceberNormasTecnicasCommand(evento);
            var normaTecnica = await _mediator.Send(command);

            await _subscriptionReceiver.CompleteAsync(message.SystemProperties.LockToken);
        }

        public static NormasTecnicas FromBody(byte[] body)
        {
            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var _body = Encoding.UTF8.GetString(body);
            return JsonConvert.DeserializeObject<NormasTecnicas>(_body, jsonSettings);
        }

        Task OnErrorException(ExceptionReceivedEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
