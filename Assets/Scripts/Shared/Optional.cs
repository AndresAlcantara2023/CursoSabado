using System;

namespace Magas.SystemUtilities
{
    public class NullOptional<T> : Optional<T>
    {
        #region CONSTRUCTORS

        public NullOptional(T value) : base(value)
        {
        }

        #endregion

        #region BEHAVIORS

        public override void Else(Action action)
        {
        }

        #endregion
    }

    public class Optional<T>
    {
        #region FIELDS

        private readonly T _value = default;

        #endregion

        #region PROPERTIES

        public T Get => _value == null ? throw new Exception("The element is null") : _value;

        #endregion

        #region CONSTRUCTORS

        public Optional(T value)
        {
            _value = value;
        }

        public Optional()
        {
        }

        #endregion

        #region BEHAVIORS

        public bool IsPresent()
        {
            return _value != null;
        }

        public Optional<T> IfPresent(Action<T> consumer)
        {
            if (_value == null)
                return this;

            consumer(_value);
            return new NullOptional<T>(_value);
        }

        public virtual void Else(Action action)
        {
            action();
        }

        public T OrElse(T elseValue)
        {
            if (_value == null)
                return elseValue;

            return _value;
        }

        public T OrElseThrow(Exception exceptionToThrow)
        {
            if (_value == null)
                throw exceptionToThrow;

            return _value;
        }

        #endregion
    }
}
