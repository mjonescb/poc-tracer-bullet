using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_synthetic_transaction.Messages
{
    public abstract class Message
    {
        public bool Real { get; set; }
    }
}
