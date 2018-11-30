using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_synthetic_transaction.MessageHandler;
using poc_synthetic_transaction.Metrics;
using poc_synthetic_transaction.Queue;

namespace poc_synthetic_transaction
{
    public class MessageReceiver
    {
        private readonly MessageQueue _messageQueue;
        private readonly IPublishMetrics _metricsPublisher;
        private readonly IHandleMessages _messageHandler;

        public MessageReceiver(
            MessageQueue messageQueue,
            IPublishMetrics metricsPublisher,
            IHandleMessages messageHandler)
        {
            _messageQueue = messageQueue;
            _metricsPublisher = metricsPublisher;
            _messageHandler = messageHandler;
        }

        public void Run()
        {
            var queue = new MessageQueue();

            foreach(var message in queue.Receive())
            {
                _metricsPublisher.Publish("read.message");
                _messageHandler.Handle(message);
            }
            _metricsPublisher.Publish("finished.reading.messages");
        }
    }
}
