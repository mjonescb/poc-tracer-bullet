using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_unity_tracer_bullet.MessageHandler;
using poc_unity_tracer_bullet.Metrics;
using poc_unity_tracer_bullet.Queue;

using Unity;

namespace poc_unity_tracer_bullet
{
    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<MessageQueue>();
            unityContainer.RegisterType<IPublishMetrics, MetricsPublisher>();
            unityContainer.RegisterType<IHandleMessages, MessageHandler.MessageHandler>();
            unityContainer.RegisterInstance(unityContainer);

            var messageReceiver = unityContainer.Resolve<MessageReceiver>();
            messageReceiver.Run();
            Console.ReadKey();
        }
    }
}
