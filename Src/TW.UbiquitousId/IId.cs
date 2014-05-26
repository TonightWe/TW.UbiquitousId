using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TW.UbiquitousId
{
    public class Id<T> : IId<T>
    {
        #region Constructors

        public Id(char componentSeparator, IEnumerable<IIdComponent> orderedIdComponents)
        {
            _componentSeparator = componentSeparator;
            OrderedIdComponents = orderedIdComponents;
        }

        #endregion

        #region Fields

        /// <summary>
        /// The separator used to separate the components of this <see cref="IId{T}"/>
        /// </summary>
        private readonly char _componentSeparator;

        #endregion

        #region Properties

        public IEnumerable<IIdComponent> OrderedIdComponents { get; private set; }

        #endregion

        #region Conversion Methods

        public override string ToString()
        {
            var idStringBuilder = new StringBuilder();

            // iterate over all id components up to the last id component
            for (var currentPosition = 0; currentPosition < OrderedIdComponents.Count() - 1; currentPosition++)
            {
                // get the id component at the current position
                var currentIdComponent = OrderedIdComponents.ElementAt(currentPosition);
                // append element with trailing separator
                idStringBuilder.AppendFormat("{0}{1}", currentIdComponent, _componentSeparator);
            }

            // append last element with no trailing separator
            idStringBuilder.Append(OrderedIdComponents.Last());

            return idStringBuilder.ToString();
        }

        #endregion
    }

    public interface IId<T> : IId
    {
        
    }

    public interface IId
    {
        #region Conversion Methods

        /// <summary>
        /// Returns this <see cref="IId"/> as a <see cref="String"/>
        /// </summary>
        /// <returns></returns>
        String ToString();

        #endregion
    }
}
