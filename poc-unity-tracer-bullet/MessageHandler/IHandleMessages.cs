using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_unity_tracer_bullet.Messages;

namespace poc_unity_tracer_bullet.MessageHandler
{
    public interface IHandleMessages
    {
        void Handle(Message message);
    }
}
