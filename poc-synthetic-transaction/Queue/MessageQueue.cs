using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_synthetic_transaction.Messages;

namespace poc_synthetic_transaction.Queue
{
    public class MessageQueue
    {
        public List<Message> Receive()
        {
            return new List<Message>() { new RealMessage(), new SyntheticMessage()};
        }
    }
}
