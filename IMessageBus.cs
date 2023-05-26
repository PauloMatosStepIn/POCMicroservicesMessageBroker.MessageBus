using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepIn.MessageBus
{
  public interface IMessageBus
  {
    Task PuplishMessage(BaseMessage message, string topicName, string connectionString);
  }
}
