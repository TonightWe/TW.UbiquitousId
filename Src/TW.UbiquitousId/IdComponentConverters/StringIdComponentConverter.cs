using System;

namespace TW.UbiquitousId
{
    public class StringIdComponentConverter : IIdComponentConverter
    {
        #region Methods

        public string Serialize(dynamic value)
        {
            if (!(value is String))
            {
                throw new Exception(String.Format("{0} cannot serialize {1}", GetType(), value.GetType().Name));
            }
            return value.ToString();
        }

        public dynamic Deserialize(string valueString, Type valueType)
        {
            if (!typeof(String).IsAssignableFrom(valueType))
            {
                throw new Exception(String.Format("{0} cannot deserialize {1}", GetType(), valueType.Name));
            }
            return valueString;
        }

        public bool IsConverterFor(Type valueType)
        {
            if (typeof(String).IsAssignableFrom(valueType))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
