using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_synthetic_transaction.Core
{
    public class OperationContext<T>
    {
        private static T _current;

        public static T GetCurrent() => _current;

        public static IDisposable Start(T @object)
        {
            _current = @object;

            return new Disposer();
        }

        public class Disposer : IDisposable
        {
            public void Dispose()
            {
                _current = default(T);
            }
        }
    }
}
