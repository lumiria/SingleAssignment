using System;
using System.Text.Json.Serialization;

namespace SignleAssignment
{
    /// <summary>
    /// Represents a value type that can be assigned a value only once.
    /// </summary>
    /// <typeparam name="T">The underlying value type of the <see cref="Once{T}"/> generic type.</typeparam>
    public sealed class Once<T>
    {
        private T _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Once"/> class.
        /// </summary>
        public Once()
        {
            //Required for JsonSerializer.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Once{T}"/> class to the specified value.
        /// </summary>
        /// <param name="value"></param>
        internal Once(T value)
        {
            Set(value);
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Once{T}"/> object has a value.
        /// </summary>
        [JsonIgnore]
        public bool HasValue { get; private set; }

        /// <summary>
        /// Gets the value of the current <see cref="Once{T}"/> object if it has been assigned a value.
        /// </summary>
        /// <exception cref="InvalidOperationException">The <see cref="HasValue"/> property is false.</exception>
        public T Value
        {
            get => _value;
            set
            {
                if (HasValue)
                {
                    throw new InvalidOperationException();
                }
                Set(value);
            }
        }

        /// <summary>
        /// Sets the value if a value is not assigned to the current <see cref="Once{T}"/> object.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <returns>true if the current <see cref="Once{T}"/> object has not had a value; otherwise, false.</returns>
        public bool TrySet(T value)
        {
            if (HasValue)
            {
                return false;
            }
            Set(value);
            return true;
        }

        public static implicit operator T (Once<T> self) =>
            self == null ? default : self._value;

        private void Set(T value)
        {
            _value = value;
            HasValue = true;
        }
    }

    public static class Once
    {
        /// <summary>
        /// Creates a new <see cref="Once{T}"/> object.
        /// </summary>
        /// <typeparam name="T">The underlying value type of the <see cref="Once{T}"/> generic type.</typeparam>
        /// <returns></returns>
        public static Once<T> Create<T>() =>
            new Once<T>();

        /// <summary>
        /// Creates a new <see cref="Once{T}"/> object initialized to a specified value.
        /// </summary>
        /// <typeparam name="T">The underlying value type of the <see cref="Once{T}"/> generic type.</typeparam>
        /// <param name="value">A value.</param>
        /// <returns>A <see cref="Once{T}"/> object whose <see cref="Value"/> property is assigned with the value parameter.</returns>
        public static Once<T> Create<T>(T value) =>
            new Once<T>(value);
    }
}
