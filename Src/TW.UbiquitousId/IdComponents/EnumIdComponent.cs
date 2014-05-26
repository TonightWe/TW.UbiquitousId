using System;
using Seterlund.CodeGuard;

namespace TW.UbiquitousId
{
    public class EnumIdComponent<TEnum> : IIdComponent<TEnum>
    {
        #region Constructors

        /// <summary>
        /// Reconstructs an existing <see cref="EnumIdComponent{T}"/> from <paramref name="enumString"/>
        /// </summary>
        /// <param name="enumString"></param>
        public EnumIdComponent(String enumString)
        {
            Value = (TEnum)Enum.Parse(typeof(TEnum), enumString, true);
        }

        public EnumIdComponent(TEnum tonightWePlatformObjectType)
        {
            Guard.That(tonightWePlatformObjectType).Is(typeof(Enum));
            Value = tonightWePlatformObjectType;
        }

        #endregion

        #region Properties

        public TEnum Value { get; private set; }

        #endregion

        #region Methods

        public bool Equals(IIdComponent other)
        {
            if (!GetType().Equals(other.GetType()))
            {
                return false;
            }
            if (ToString() != other.ToString())
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        /// Returns this <see cref="EnumIdComponent{T}"/> as a <see cref="String"/>
        /// Note: overrides Object.ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ((dynamic)Value).ToString("D");
        }

        #endregion
    }
}
