using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_unity_tracer_bullet.Metrics
{
    public class DataDogMetrics : IPublishMetrics
    {
        public void Publish(string metric)
        {
            Console.WriteLine($"[{this.GetType()}]: {metric}");
        }
    }
}
