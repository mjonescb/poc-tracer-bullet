using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_unity_tracer_bullet.Messages;

namespace poc_unity_tracer_bullet.Metrics
{
    public class MetricsPublisher : IPublishMetrics
    {
        public void Publish(string metric)
        {
            Console.WriteLine($"[{this.GetType().Name}]: {metric}");
        }
    }
}
