using System;

namespace TW.UbiquitousId
{
    public class EnumIdComponentConverter : IIdComponentConverter
    {
        #region Methods

        public string Serialize(dynamic value)
        {
            if (!(value is Enum))
            {
                throw new Exception(String.Format("{0} cannot serialize {1}", GetType(), value.GetType().Name));
            }
            // Use numeric format
            return value.ToString("D");
        }

        public dynamic Deserialize(string valueString, Type valueType)
        {
            if (!typeof(Enum).IsAssignableFrom(valueType))
            {
                throw new Exception(String.Format("{0} cannot deserialize {1}", GetType(), valueType.Name));
            }
            return Enum.Parse(valueType, valueString, true);
        }

        public bool IsConverterFor(Type valueType)
        {
            if (typeof(Enum).IsAssignableFrom(valueType))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
