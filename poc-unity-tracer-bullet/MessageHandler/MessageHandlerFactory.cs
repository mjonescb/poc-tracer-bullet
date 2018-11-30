using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_synthetic_transaction.Core;

using poc_unity_tracer_bullet.Messages;
using poc_unity_tracer_bullet.Metrics;

using Unity;

namespace poc_unity_tracer_bullet.MessageHandler
{
    public class MessageHandlerFactory
    {
        private readonly UnityContainer _unityContainer;

        public MessageHandlerFactory(UnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public IHandleMessages Create()
        {
            if(OperationContext<Message>.GetCurrent().TracerBullet)
            {
                _unityContainer.RegisterType<IPublishMetrics, NoopPublisher>();
            }
            else
            {
                _unityContainer.RegisterType<IPublishMetrics, MetricsPublisher>();
            }
            
            return _unityContainer.Resolve<IHandleMessages>();
        }
    }
}
