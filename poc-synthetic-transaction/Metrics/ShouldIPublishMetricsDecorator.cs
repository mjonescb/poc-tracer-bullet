using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_synthetic_transaction.Metrics
{
    public class ShouldIPublishMetricsDecorator : IPublishMetrics
    {
        private readonly IPublishMetrics _metricsPublisher;

        public ShouldIPublishMetricsDecorator(IPublishMetrics metricsPublisher)
        {
            _metricsPublisher = metricsPublisher;
        }

        public void Publish(string metric)
        {
            if (Global.State.Synthetic)
                _metricsPublisher.Publish(metric);
        }
    }
}
