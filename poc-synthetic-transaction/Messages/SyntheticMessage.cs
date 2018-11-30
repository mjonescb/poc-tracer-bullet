using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_synthetic_transaction.Messages
{
    public class SyntheticMessage : Message
    {
        public SyntheticMessage()
        {
            Real = false;
        }
    }
}
