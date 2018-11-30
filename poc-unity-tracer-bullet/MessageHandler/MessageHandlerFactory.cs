using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IHandleMessages Create(bool tracerBullet = false)
        {
            if (tracerBullet)
                _unityContainer.RegisterType<IPublishMetrics, DontPublishMetrics>();
            else
            {
                _unityContainer.RegisterType<IPublishMetrics, DataDogMetrics>();
            }

            return _unityContainer.Resolve<IHandleMessages>();
        }
    }
}
