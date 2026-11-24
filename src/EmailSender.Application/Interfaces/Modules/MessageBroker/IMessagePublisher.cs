using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.MessageBroker
{
	public interface IMessagePublisher
	{
		Task Publish(string queueName, string message);
	}
}
