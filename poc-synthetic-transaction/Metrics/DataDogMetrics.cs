using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_synthetic_transaction.Metrics
{
    public class DataDogMetrics : IPublishMetrics
    {
        public void Publish(string metric)
        {
            Console.WriteLine($"[{nameof(DataDogMetrics)}]: {metric}");
        }
    }
}
