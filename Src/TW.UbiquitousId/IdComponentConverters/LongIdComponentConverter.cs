using System;

namespace TW.UbiquitousId
{
    public class LongIdComponentConverter :
        IIdComponentConverter
    {
        #region Methods
        
        public string Serialize(
            dynamic value)
        {
            if (!(value is long))
            {
                throw new Exception(String.Format("{0} cannot serialize {1}", GetType(), value.GetType().Name));
            }
            return value.ToString();
        }

        public dynamic Deserialize(
            string valueString,
            Type valueType)
        {
            if (!typeof(long).IsAssignableFrom(valueType))
            {
                throw new Exception(String.Format("{0} cannot deserialize {1}", GetType(), valueType.Name));
            }
            return long.Parse(valueString);
        }

        public bool IsConverterFor(
            Type valueType)
        {
            if (typeof(long).IsAssignableFrom(valueType))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
