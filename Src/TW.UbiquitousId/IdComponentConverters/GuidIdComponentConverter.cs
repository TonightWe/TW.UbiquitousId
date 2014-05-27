using System;

namespace TW.UbiquitousId
{
    public class GuidIdComponentConverter : IIdComponentConverter
    {
        #region Methods

        public string Serialize(dynamic value)
        {
            if (!(value is Guid))
            {
                throw new Exception(String.Format("{0} cannot serialize {1}",GetType(), value.GetType().Name));
            }
            // Use No hyphen format
            return value.ToString("N");
        }

        public dynamic Deserialize(string valueString, Type valueType)
        {
            if (!typeof(Guid).IsAssignableFrom(valueType))
            {
                throw new Exception(String.Format("{0} cannot deserialize {1}", GetType(), valueType.Name));
            }
            return Guid.Parse(valueString);
        }

        public bool IsConverterFor(Type valueType)
        {
            if (typeof(Guid).IsAssignableFrom(valueType))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
