using System;

namespace TW.TypedId
{
    /// <summary>
    /// Represents a component of a <see cref="IId{T}"/>
    /// </summary>
    public interface IIdComponent<T> : IIdComponent
    {
        #region Properties

        T Value { get; }

        #endregion
    }

    public interface IIdComponent
    {
        #region Methods

        String ToString();

        #endregion
    }
}
