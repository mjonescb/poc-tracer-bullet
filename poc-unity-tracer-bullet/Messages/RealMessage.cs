using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_unity_tracer_bullet.Messages
{
    public class RealMessage : Message
    {
        public RealMessage() : base(tracerBullet: false) { }
    }
}
