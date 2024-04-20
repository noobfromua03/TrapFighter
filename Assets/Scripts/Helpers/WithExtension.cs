using System;

namespace Helpers
{
    public static class WithExtension
    {
        public static void With<T>(this T obj, Action<T> action)
        {
            action(obj);
        }

        public static void With<T>(this T obj, Action action)
        {
            action();
        }
    }
}
