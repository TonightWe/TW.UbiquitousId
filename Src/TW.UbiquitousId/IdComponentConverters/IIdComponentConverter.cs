using System;

namespace TW.UbiquitousId
{
    public interface IIdComponentConverter
    {
        #region Methods

        string Serialize(dynamic value);
        dynamic Deserialize(string valueString, Type valueType);
        bool IsConverterFor(Type valueType);

        #endregion
    }
}
