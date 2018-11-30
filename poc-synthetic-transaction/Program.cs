using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_synthetic_transaction.MessageHandler;
using poc_synthetic_transaction.Metrics;
using poc_synthetic_transaction.Queue;

using Unity;

namespace poc_synthetic_transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<MessageQueue>();
            unityContainer.RegisterType<IPublishMetrics, DataDogMetrics>();
            unityContainer.RegisterType<IHandleMessages, ProposalGenerator>();

            var messageReceiver = unityContainer.Resolve<MessageReceiver>();
            messageReceiver.Run();
            Console.ReadKey();
        }
    }
}
