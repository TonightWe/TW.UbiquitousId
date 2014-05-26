using System;

namespace TW.TypedId
{
    public interface IIdComponentFactory
    {
        #region Methods

        /// <summary>
        /// Builds an <see cref="IIdComponent" /> from the <paramref name="idComponentString" />
        /// </summary>
        /// <param name="idComponentType">Type of the identifier component.</param>
        /// <param name="idComponentString">The identifier component string.</param>
        /// <returns></returns>
        IIdComponent Build(Type idComponentType, String idComponentString);

        #endregion
    }
}
