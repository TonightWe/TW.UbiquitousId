using System;

namespace TW.UbiquitousId
{
    public class DateTimeIdComponentConverter : IIdComponentConverter
    {
        #region Methods

        public string Serialize(dynamic value)
        {
            if (!(value is DateTime))
            {
                throw new Exception(String.Format("{0} cannot serialize {1}", GetType(), value.GetType().Name));
            }
            // Use universal sortable format. 
            // Note: we must first convert it to UTC. the string format does not do that for us even though
            // it formats the outgoing value to the universal sortable format.
            return value.ToUniversalTime().ToString("u");
        }

        public dynamic Deserialize(string valueString, Type valueType)
        {
            if (!typeof(DateTime).IsAssignableFrom(valueType))
            {
                throw new Exception(String.Format("{0} cannot deserialize {1}", GetType(), valueType.Name));
            }
            return DateTime.Parse(valueString);
        }

        public bool IsConverterFor(Type valueType)
        {
            if (typeof(DateTime).IsAssignableFrom(valueType))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
