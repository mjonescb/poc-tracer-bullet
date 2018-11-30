using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_unity_tracer_bullet.Metrics
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
