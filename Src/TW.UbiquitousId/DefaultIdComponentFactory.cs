using System;
using System.Collections.Generic;

namespace TW.UbiquitousId
{
    public class DefaultIdComponentFactory : IIdComponentFactory
    {
        #region Fields

        private readonly Dictionary<Type, Func<String, IIdComponent>> _idComponentBuilderRegistry = new Dictionary<Type, Func<string, IIdComponent>>();

        #endregion

        #region Methods

        public DefaultIdComponentFactory RegisterBuilder<T>(Func<String, T> idComponentTypeFactory)
            where T : IIdComponent
        {
            _idComponentBuilderRegistry.Add(typeof(T),idComponentString => idComponentTypeFactory.Invoke(idComponentString));
            return this;
        }

        /// <summary>
        /// Registers a builder for an IIdComponent type
        /// </summary>
        /// <param name="idComponentType"></param>
        /// <param name="idComponentTypeFactory"></param>
        /// <returns></returns>
        public DefaultIdComponentFactory RegisterBuilder(Type idComponentType,
            Func<String, IIdComponent> idComponentTypeFactory)
        {
            _idComponentBuilderRegistry.Add(idComponentType,idComponentTypeFactory);
            return this;
        }

        /// <summary>
        /// Resolves the registered builder for <paramref name="idComponentType"/> and uses it to
        /// reconstruct the <see cref="IIdComponent"/>
        /// </summary>
        /// <param name="idComponentType"></param>
        /// <param name="idComponentString"></param>
        /// <returns></returns>
        public IIdComponent Build(Type idComponentType, string idComponentString)
        {
            return _idComponentBuilderRegistry[idComponentType].Invoke(idComponentString);
        }

        #endregion
    }
}
