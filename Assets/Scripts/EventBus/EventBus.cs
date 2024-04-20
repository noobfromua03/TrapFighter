using System.Collections.Generic;

namespace BusEvents
{
    public static class EventBus<T> where T : IBusEvent
    {
        static readonly HashSet<IEventBinding<T>> bindings = new HashSet<IEventBinding<T>>();

        public static EventBinding<T> Register(EventBinding<T> binding)
        {
            bindings.Add(binding);
            return binding;
        }

        public static void Deregister(EventBinding<T> binding) => bindings.Remove(binding);

        public static void Raise(T @event)
        {
            foreach (var binding in bindings)
            {
                binding.OnEvent.Invoke(@event);
                binding.OnEventNoArgs.Invoke();
            }
        }

        static void Clear()
        {
            bindings.Clear();
        }
    }
}