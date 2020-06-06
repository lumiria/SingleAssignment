using System;

namespace SignleAssignment
{
    public sealed class Once<T>
    {
        private T _value;

        internal Once()
        {
        }

        internal Once(T value)
        {
            Set(value);
        }

        public bool HasValue { get; private set; }

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
        public static Once<T> Create<T>() =>
            new Once<T>();

        public static Once<T> Create<T>(T value) =>
            new Once<T>(value);
    }
}
