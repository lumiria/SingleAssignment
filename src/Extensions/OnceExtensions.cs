#nullable enable
using System;

namespace SignleAssignment.Extensions
{
    public static class OnceExtensions
    {
        public static void Run<T>(this Once<T> self, Action<T>? action, Action? actionIfEmpty)
        {
            if (self.HasValue)
            {
                action?.Invoke(self);
                return;
            }
            actionIfEmpty?.Invoke();
        }
    }
}
