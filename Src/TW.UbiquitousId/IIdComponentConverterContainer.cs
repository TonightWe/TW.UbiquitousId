using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.UbiquitousId
{
    public interface IIdComponentConverterContainer
    {
        #region Methods

        /// <summary>
        /// Adds an <see cref="IIdComponentConverter"/> to this <see cref="IIdComponentConverterContainer"/>
        /// </summary>
        /// <param name="idComponentConverter"></param>
        /// <returns></returns>
        IIdComponentConverterContainer AddConverter(IIdComponentConverter idComponentConverter);
        /// <summary>
        /// Removes an <see cref="IIdComponentConverter"/> from this <see cref="IIdComponentConverterContainer"/>
        /// </summary>
        /// <param name="idComponentConverter"></param>
        /// <returns></returns>
        IIdComponentConverterContainer RemoveConverter(IIdComponentConverter idComponentConverter);
        /// <summary>
        /// Gets an <see cref="IIdComponentConverter"/> from this <see cref="IIdComponentConverterContainer"/>
        /// which is capable of converting <paramref name="valueType"/>
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        IIdComponentConverter GetConverterForType(Type valueType);

        #endregion
    }
}
