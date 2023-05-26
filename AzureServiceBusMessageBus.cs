using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StepIn.MessageBus
{
  public class AzureServiceBusMessageBus : IMessageBus
  {
    public async Task PuplishMessage(BaseMessage message, string topicName, string connectionString)
    {
      await using var client = new ServiceBusClient(connectionString);

      ServiceBusSender sender = client.CreateSender(topicName);

      var jsonMessage = JsonConvert.SerializeObject(message);
      ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage));

      await sender.SendMessageAsync(finalMessage);
      await client.DisposeAsync();
    }
  }
}