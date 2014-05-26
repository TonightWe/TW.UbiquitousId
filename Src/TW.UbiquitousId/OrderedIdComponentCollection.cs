using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TW.UbiquitousId
{
    public class OrderedIdComponentEnumerable : IEnumerable<IIdComponent>
    {
        #region Constructors
        /// <summary>
        /// Reconstructs an existing <see cref="OrderedIdComponentEnumerable"/>
        ///  from the <paramref name="idString" />
        /// </summary>
        /// <param name="idString">The tonight we identifier string.</param>
        /// <param name="componentSeparator">The component separator.</param>
        /// <param name="idComponentFactory">The identifier component factory.</param>
        /// <param name="idComponentTypeOrder">The identifier component orderer.</param>
        public OrderedIdComponentEnumerable(
            string idString,
            char componentSeparator,
            IIdComponentFactory idComponentFactory,
            IEnumerable<Type> idComponentTypeOrder)
        {
            _orderedIdComponents = GetOrderedIdComponents(idString, componentSeparator, idComponentFactory, idComponentTypeOrder);
        }

        /// <summary>
        /// Constructs a new <see cref="Id{T}"/>
        /// </summary>
        public OrderedIdComponentEnumerable(
            IEnumerable<IIdComponent> unorderedIdComponents,
            IEnumerable<Type> idComponentTypeOrder)
        {
            _orderedIdComponents = GetOrderedIdComponents(unorderedIdComponents, idComponentTypeOrder);
        }

        #endregion

        #region Fields

        private readonly IEnumerable<IIdComponent> _orderedIdComponents;

        #endregion

        #region Methods

        private static IEnumerable<IIdComponent> GetOrderedIdComponents(
            IEnumerable<IIdComponent> unorderedIdComponents,
            IEnumerable<Type> idComponentTypeOrder)
        {
            var orderedIdComponents = new List<IIdComponent>();
            foreach (var idComponentType in idComponentTypeOrder)
            {
                orderedIdComponents.Add(unorderedIdComponents.Single(idComponent => idComponent.GetType().Equals(idComponentType)));
            }
            return orderedIdComponents;
        }

        private static IEnumerable<IIdComponent> GetOrderedIdComponents(
            String idString,
            char componentSeparator,
            IIdComponentFactory idComponentFactory,
            IEnumerable<Type> idComponentTypeOrder)
        {
            var idComponentStrings = idString.Split(componentSeparator);
            var orderedIdComponents = new List<IIdComponent>();
            for (var currentPosition = 0; currentPosition < idComponentTypeOrder.Count(); currentPosition++)
            {
                // get the (expected) id component type at the current position
                var currentIdComponentType = idComponentTypeOrder.ElementAt(currentPosition);
                // get the idComponent token at the current position
                var currentIdComponentToken = idComponentStrings[currentPosition];
                // build the id component
                var idComponent = idComponentFactory.Build(currentIdComponentType, currentIdComponentToken);

                orderedIdComponents.Add(idComponent);
            }
            return orderedIdComponents;
        }

        public IEnumerator<IIdComponent> GetEnumerator()
        {
            return _orderedIdComponents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
