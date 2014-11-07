using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW.UbiquitousId
{
    /// <summary>
    /// A threadsafe implementation of <see cref="IIdComponentConverterContainer"/>
    /// </summary>
    public class DefaultIdComponentConverterContainer : IIdComponentConverterContainer
    {
        #region Constructors

        public DefaultIdComponentConverterContainer()
        {
            ValueConverters = new ConcurrentDictionary<Type, IIdComponentConverter>();
            ValueConverters.Add(typeof(DateTimeIdComponentConverter), new DateTimeIdComponentConverter());
            ValueConverters.Add(typeof (GuidIdComponentConverter), new GuidIdComponentConverter());
            ValueConverters.Add(typeof(EnumIdComponentConverter), new EnumIdComponentConverter());
            ValueConverters.Add(typeof(IntIdComponentConverter), new IntIdComponentConverter());
            ValueConverters.Add(typeof(LongIdComponentConverter), new LongIdComponentConverter());
            ValueConverters.Add(typeof (StringIdComponentConverter), new StringIdComponentConverter());
        }

        #endregion

        #region Properties

        public IDictionary<Type, IIdComponentConverter> ValueConverters { get; private set; }
        
        #endregion

        #region Methods

        public IIdComponentConverter GetConverterForType(Type valueType)
        {
            foreach (var valueConverter in ValueConverters.Values)
            {
                if (valueConverter.IsConverterFor(valueType))
                {
                    return valueConverter;
                }
            }
            throw new Exception(String.Format("Unable to resolve a {0} capable of converting {1}", typeof(IIdComponentConverter).Name, valueType.Name));
        }

        public IIdComponentConverterContainer AddConverter(IIdComponentConverter idComponentConverter)
        {
            ValueConverters.Add(idComponentConverter.GetType(), idComponentConverter);
            return this;
        }

        public IIdComponentConverterContainer RemoveConverter(IIdComponentConverter idComponentConverter)
        {
            ValueConverters.Remove(idComponentConverter.GetType());
            return this;
        }

        #endregion
    }
}
