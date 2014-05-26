using System;

namespace TW.TypedId
{
    public class GuidIdComponent : IIdComponent<Guid>
    {
        #region Constructors

        /// <summary>
        /// Reconstructs an existing <see cref="GuidIdComponent"/> from <paramref name="guidString"/>
        /// </summary>
        /// <param name="guidString"></param>
        public GuidIdComponent(String guidString)
        {
            Value = Guid.Parse(guidString);
        }

        /// <summary>
        /// Constructs a new <see cref="GuidIdComponent"/>
        /// </summary>
        public GuidIdComponent()
        {
            Value = Guid.NewGuid();
        }

        #endregion

        #region Properties

        public Guid Value { get; private set; }

        #endregion

        #region Conversion Methods

        /// <summary>
        /// Returns this <see cref="GuidIdComponent"/> as a <see cref="String"/>
        /// Note: overrides Object.ToString()
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return Value.ToString("N");
        }

        #endregion
    }
}
