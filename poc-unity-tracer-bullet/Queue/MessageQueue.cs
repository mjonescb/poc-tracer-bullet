using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_unity_tracer_bullet.Messages;

namespace poc_unity_tracer_bullet.Queue
{
    public class MessageQueue
    {
        public List<Message> Receive()
        {
            return new List<Message>() { new RealMessage(), new TracerBulletMessage()};
        }
    }
}
