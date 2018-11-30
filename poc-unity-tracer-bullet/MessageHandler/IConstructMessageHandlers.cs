using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using poc_synthetic_transaction.Messages;

namespace poc_synthetic_transaction.MessageHandler
{
    public interface IConstructMessageHandlers
    {
        void Handle(Message message);
    }
}
