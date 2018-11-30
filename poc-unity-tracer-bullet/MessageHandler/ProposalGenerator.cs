using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_unity_tracer_bullet.Messages;
using poc_unity_tracer_bullet.Metrics;

namespace poc_unity_tracer_bullet.MessageHandler
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
            _metricsPublisher.Publish("message.processed");
        }
    }
}
