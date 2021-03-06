﻿using System;
using System.Runtime.CompilerServices;

namespace TW.UbiquitousId
{
    public class DateTimeIdComponentConverter : IIdComponentConverter
    {
        #region Methods

        public string Serialize(
            dynamic value)
        {
            if (!(value is DateTime))
            {
                throw new Exception(String.Format("{0} cannot serialize {1}", GetType(), value.GetType().Name));
            }
            // Convert to decimal ticks of represented universal time
            // Note: we must first convert it to UTC.
            return value.ToUniversalTime().Ticks.ToString("D");
        }

        public dynamic Deserialize(
            string valueString,
            Type valueType)
        {
            if (!typeof(DateTime).IsAssignableFrom(valueType))
            {
                throw new Exception(String.Format("{0} cannot deserialize {1}", GetType(), valueType.Name));
            }
            return new DateTime(long.Parse(valueString),DateTimeKind.Utc);
        }

        public bool IsConverterFor(
            Type valueType)
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
