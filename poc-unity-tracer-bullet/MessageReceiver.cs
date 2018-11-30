using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_synthetic_transaction.Core;

using poc_unity_tracer_bullet.MessageHandler;
using poc_unity_tracer_bullet.Messages;
using poc_unity_tracer_bullet.Metrics;
using poc_unity_tracer_bullet.Queue;

namespace poc_unity_tracer_bullet
{
    public class MessageReceiver
    {
        private readonly MessageQueue _messageQueue;
        private readonly IPublishMetrics _metricsPublisher;
        private readonly MessageHandlerFactory _messageHandlerFactory;

        public MessageReceiver(
            MessageQueue messageQueue,
            IPublishMetrics metricsPublisher,
            MessageHandlerFactory messageHandlerFactory)
        {
            _messageQueue = messageQueue;
            _metricsPublisher = metricsPublisher;
            _messageHandlerFactory = messageHandlerFactory;
        }

        public void Run()
        {
            var queue = new MessageQueue();

            _metricsPublisher.Publish("process.started");

            foreach (var message in queue.Receive())
            {
                using (var context = OperationContext<Message>.Start(message))
                {
                    var handler = _messageHandlerFactory.Create();

                    _metricsPublisher.Publish($"queue.message.received [#tracerbullet:{message.TracerBullet}]");
                    
                    handler.Handle(message);

                    _metricsPublisher.Publish("queue.message.deleted");
                }
            }

            _metricsPublisher.Publish("process.finished");
        }
    }
}
