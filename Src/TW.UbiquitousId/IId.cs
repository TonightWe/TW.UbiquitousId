using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Seterlund.CodeGuard;

namespace TW.UbiquitousId
{
    public class Id : IId
    {
        #region Constructors

        /// <summary>
        /// Reconstructs an existing <see cref="Id" /> from <paramref name="idString" />
        /// </summary>
        /// <param name="idString">The identifier string.</param>
        /// <param name="idSchema">The identifier syntax.</param>
        /// <param name="idComponentConverterContainer">The value converter container.</param>
        public Id(String idString, IIdSchema idSchema, IIdComponentConverterContainer idComponentConverterContainer = null)
        {
            _idComponentConverterContainer = idComponentConverterContainer ?? new DefaultIdComponentConverterContainer();
            var idComponentStrings = idString.Split(idSchema.ComponentSeparator);
            for (var currentPosition = 0; currentPosition < idSchema.ComponentOrder.Count(); currentPosition++)
            {
                var currentIdComponentType = idSchema.ComponentOrder.ElementAt(currentPosition);
                var currentValueConverter = _idComponentConverterContainer.GetConverterForType(currentIdComponentType);
                var currentIdComponentString = idComponentStrings[currentPosition];
                var currentComponent = currentValueConverter.Deserialize(currentIdComponentString, currentIdComponentType);
                _components.Add(currentComponent);
            }
            _idSchema = Guard.That(idSchema).IsNotNull().Value;
        }

        /// <summary>
        /// Constructs a new <see cref="Id" /> from <paramref name="orderedComponents" />
        /// </summary>
        /// <param name="orderedComponents">The ordered components of this <see cref="Id"/></param>
        /// <param name="idSchema">The identifier syntax.</param>
        /// <param name="idComponentConverterContainer">The value converter container.</param>
        public Id(IEnumerable<Object> orderedComponents, IIdSchema idSchema, IIdComponentConverterContainer idComponentConverterContainer = null)
        {
            _idComponentConverterContainer = idComponentConverterContainer ?? new DefaultIdComponentConverterContainer();
            // validate ordered components meet provided syntax
            _components = Guard.That(orderedComponents)
                .IsNotNull()
                .IsNotEmpty()
                .IsTrue(
                    _orderedComponents =>
                        _orderedComponents.Count() == idSchema.ComponentOrder.Count(),
                    String.Format("The count of the {0} passed in did not match the count defined in the {1}",
                        orderedComponents.GetType().Name, idSchema.GetType().Name))
                .IsTrue(
                    _orderedComponents =>
                        _orderedComponents.Select(orderedComponent => orderedComponent.GetType())
                            .SequenceEqual(idSchema.ComponentOrder),
                    String.Format("The order of the {0} passed in did not match the order defined in the {1}",
                        orderedComponents.GetType().Name, idSchema.GetType().Name))
                .Value.ToList();

            _idSchema = Guard.That(idSchema).IsNotNull().Value;
        }

        #endregion

        #region Fields

        private readonly List<Object> _components = new List<object>();
        private readonly IIdSchema _idSchema;
        private readonly IIdComponentConverterContainer _idComponentConverterContainer;

        #endregion

        #region Methods
        public bool Equals(IId other)
        {
            if (!ToString().Equals(other.ToString()))
            {
                return false;
            }
            return true;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Conversion Methods

        public override string ToString()
        {
            var idStringBuilder = new StringBuilder();

            // iterate over all id components up to the last id component
            for (var currentPosition = 0; currentPosition < _components.Count() - 1; currentPosition++)
            {
                // get the id component at the current position
                var currentIdComponent = _components.ElementAt(currentPosition);
                // get the value converter for the current idcomponent
                var currentValueConverter = _idComponentConverterContainer.GetConverterForType(currentIdComponent.GetType());
                // append element with trailing separator
                idStringBuilder.AppendFormat("{0}{1}", currentValueConverter.Serialize(currentIdComponent), _idSchema.ComponentSeparator);
            }

            // append last element with no trailing separator
            var lastComponent = _components.Last();
            var lastComponentConverter = _idComponentConverterContainer.GetConverterForType(lastComponent.GetType());
            idStringBuilder.Append(lastComponentConverter.Serialize(lastComponent));

            return idStringBuilder.ToString();
        }

        #endregion
    }

    public interface IId : IEnumerable<Object>, IEquatable<IId>
    {
    }
}
