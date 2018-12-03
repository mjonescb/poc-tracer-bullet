using System;
using poc_unity_tracer_bullet.Messages;

namespace poc_synthetic_transaction.Core
{
    public class OperationContext
    {
        public Message Message { get; }

        OperationContext(Message message)
        {
            Message = message;
        }

        private static OperationContext _current;

        public static OperationContext GetCurrent() => _current;

        public static IDisposable Start(Message message)
        {
            if(_current != null)
            {
                throw new InvalidOperationException("You can't do this coz a context is already in scope.");
            }

            _current = new OperationContext(message);

            return new Disposer();
        }

        public class Disposer : IDisposable
        {
            public void Dispose()
            {
                _current = default(OperationContext);
            }
        }
    }
}
