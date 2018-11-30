using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_synthetic_transaction.Messages;
using poc_synthetic_transaction.Metrics;

namespace poc_synthetic_transaction.MessageHandler
{
    public class ProposalGenerator : IHandleMessages
    {
        private readonly IPublishMetrics _metricsPublisher;

        public ProposalGenerator(IPublishMetrics metricsPublisher)
        {
            _metricsPublisher = metricsPublisher;
        }

        public void Handle(Message message)
        {
            _metricsPublisher.Publish($"generate.message #type:{message.GetType()}]");
        }
    }
}
