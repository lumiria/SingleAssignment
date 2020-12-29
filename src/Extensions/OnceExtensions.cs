#nullable enable
using System;

namespace SignleAssignment.Extensions
{
    public static class OnceExtensions
    {
        /// <summary>
        /// Runs a work.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="action">The work to execute if the current <see cref="Once{T}"/> object has a value.</param>
        /// <param name="actionIfEmpty">The work to execute if the curremt <see cref="Once{T}"/> object has not a value.</param>
        public static void Run<T>(this Once<T> self, Action<T>? action, Action? actionIfEmpty)
        {
            if (self.HasValue)
            {
                action?.Invoke(self);
                return;
            }
            actionIfEmpty?.Invoke();
        }

        /// <summary>
        /// Sets a value by using the specified function if the value does not already exist. Returns the new value, or the existing value if the value exists.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="setter">The function of the value to add.</param>
        /// <returns>The value. This will be either the existing value if the value is already, or the new value if the value was not in myself.</returns>
        public static T GetOrSet<T>(this Once<T> self, Func<T> valueFactory)
        {
            if (self.HasValue)
            {
                return self;
            }
            self.TrySet(valueFactory());
            return self;
        }
    }
}
