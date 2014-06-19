using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Seterlund.CodeGuard;

namespace TW.UbiquitousId
{
    #region Interfaces

    public interface IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        : IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        #region Properties

        T14 Component14 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        : IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        #region Properties

        T13 Component13 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        : IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        #region Properties

        T12 Component12 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        : IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        #region Properties

        T11 Component11 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        : IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        #region Properties

        T10 Component10 { get; }

        #endregion
    }

    public interface IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
        : IId<T0, T1, T2, T3, T4, T5, T6, T7, T8>
    {
        #region Properties

        T9 Component9 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3, T4, T5, T6, T7, T8>
        : IId<T0, T1, T2, T3, T4, T5, T6, T7>
    {
        #region Properties

        T8 Component8 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3, T4, T5, T6, T7>
        : IId<T0, T1, T2, T3, T4, T5, T6>
    {
        #region Properties

        T7 Component7 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3, T4, T5, T6>
        : IId<T0, T1, T2, T3, T4, T5>
    {
        #region Properties

        T6 Component6 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3, T4, T5>
        : IId<T0, T1, T2, T3, T4>
    {
        #region Properties

        T5 Component5 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3, T4>
        : IId<T0, T1, T2, T3>
    {
        #region Properties

        T4 Component4 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2, T3>
        : IId<T0, T1, T2>
    {
        #region Properties

        T3 Component3 { get; }

        #endregion
    }
    public interface IId<T0, T1, T2>
        : IId<T0, T1>
    {
        #region Properties

        T2 Component2 { get; }

        #endregion
    }
    public interface IId<T0, T1>
        : IId<T0>
    {
        #region Properties

        T1 Component1 { get; }

        #endregion
    }

    public interface IId<T0> : IId
    {
        #region Properties

        T0 Component0 { get; }

        #endregion
    }

    public interface IId : IEnumerable<Object>
    {
        #region Conversion Methods

        String ToString();

        #endregion
    }

    #endregion

    #region Implementations

    public class Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        : Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>,
        IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            T6 component6,
            T7 component7,
            T8 component8,
            T9 component9,
            T10 component10,
            T11 component11,
            T12 component12,
            T13 component13,
            T14 component14,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            component5,
            component6,
            component7,
            component8,
            component9,
            component10,
            component11,
            component12,
            component13,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component14 = component14;
            Components.Add(component14);
        }

        #endregion

        #region Properties

        public T14 Component14 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        : Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>,
        IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            T6 component6,
            T7 component7,
            T8 component8,
            T9 component9,
            T10 component10,
            T11 component11,
            T12 component12,
            T13 component13,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            component5,
            component6,
            component7,
            component8,
            component9,
            component10,
            component11,
            component12,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component13 = component13;
            Components.Add(component13);
        }

        #endregion

        #region Properties

        public T13 Component13 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        : Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>,
        IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            T6 component6,
            T7 component7,
            T8 component8,
            T9 component9,
            T10 component10,
            T11 component11,
            T12 component12,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            component5,
            component6,
            component7,
            component8,
            component9,
            component10,
            component11,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component12 = component12;
            Components.Add(component12);
        }

        #endregion

        #region Properties

        public T12 Component12 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        : Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>,
        IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            T6 component6,
            T7 component7,
            T8 component8,
            T9 component9,
            T10 component10,
            T11 component11,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            component5,
            component6,
            component7,
            component8,
            component9,
            component10,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component11 = component11;
            Components.Add(component11);
        }

        #endregion

        #region Properties

        public T11 Component11 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        : Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>,
        IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            T6 component6,
            T7 component7,
            T8 component8,
            T9 component9,
            T10 component10,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            component5,
            component6,
            component7,
            component8,
            component9,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component10 = component10;
            Components.Add(component10);
        }

        #endregion

        #region Properties

        public T10 Component10 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
        : Id<T0, T1, T2, T3, T4, T5, T6, T7, T8>,
        IId<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            T6 component6,
            T7 component7,
            T8 component8,
            T9 component9,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            component5,
            component6,
            component7,
            component8,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component9 = component9;
            Components.Add(component9);
        }

        #endregion

        #region Properties

        public T9 Component9 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4, T5, T6, T7, T8>
        : Id<T0, T1, T2, T3, T4, T5, T6, T7>,
        IId<T0, T1, T2, T3, T4, T5, T6, T7, T8>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            T6 component6,
            T7 component7,
            T8 component8,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            component5,
            component6,
            component7,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component8 = component8;
            Components.Add(component8);
        }

        #endregion

        #region Properties

        public T8 Component8 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4, T5, T6, T7>
        : Id<T0, T1, T2, T3, T4, T5, T6>,
        IId<T0, T1, T2, T3, T4, T5, T6, T7>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            T6 component6,
            T7 component7,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            component5,
            component6,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component7 = component7;
            Components.Add(component7);
        }

        #endregion

        #region Properties

        public T7 Component7 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4, T5, T6>
        : Id<T0, T1, T2, T3, T4, T5>,
        IId<T0, T1, T2, T3, T4, T5, T6>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            T6 component6,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            component5,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component6 = component6;
            Components.Add(component6);
        }

        #endregion

        #region Properties

        public T6 Component6 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4, T5>
        : Id<T0, T1, T2, T3, T4>,
        IId<T0, T1, T2, T3, T4, T5>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            T5 component5,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            component4,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component5 = component5;
            Components.Add(component5);
        }

        #endregion

        #region Properties

        public T5 Component5 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3, T4>
        : Id<T0, T1, T2, T3>,
        IId<T0, T1, T2, T3, T4>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            T4 component4,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            component3,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component4 = component4;
            Components.Add(component4);
        }

        #endregion

        #region Properties

        public T4 Component4 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2, T3>
        : Id<T0, T1, T2>,
        IId<T0, T1, T2, T3>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            T3 component3,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            component2,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component3 = component3;
            Components.Add(component3);
        }

        #endregion

        #region Properties

        public T3 Component3 { get; private set; }

        #endregion
    }

    public class Id<T0, T1, T2>
        : Id<T0, T1>,
        IId<T0, T1, T2>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            T2 component2,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            component1,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component2 = component2;
            Components.Add(component2);
        }

        #endregion

        #region Properties

        public T2 Component2 { get; private set; }

        #endregion
    }

    public class Id<T0, T1>
        : Id<T0>,
        IId<T0, T1>
    {
        #region Constructors

        public Id(
            string idString,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            idString,
            componentSeparator,
            idComponentConverterContainer)
        {
        }

        public Id(
            T0 component0,
            T1 component1,
            string componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
            : base(
            component0,
            componentSeparator,
            idComponentConverterContainer)
        {
            Component1 = component1;
            Components.Add(component1);
        }

        #endregion

        #region Properties

        public T1 Component1 { get; private set; }

        #endregion
    }

    public class Id<T0>
        : IId<T0>
    {
        #region Constructors

        /// <summary>
        /// Deserializes a serialized <see cref="Id{T1}"/>
        /// </summary>
        /// <param name="idString"></param>
        /// <param name="componentSeparator"></param>
        /// <param name="idComponentConverterContainer"></param>
        public Id(
            String idString,
            String componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
        {
            Components = new List<Object>();
            _componentSeparator = new ComponentSeparator(componentSeparator);
            _idComponentConverterContainer = idComponentConverterContainer ?? new DefaultIdComponentConverterContainer();

            var componentOrder = GetType().GetGenericArguments();
            var idComponentStrings = Regex.Split(idString, Regex.Escape(_componentSeparator.ToString()));
            for (var currentPosition = 0; currentPosition < componentOrder.Count(); currentPosition++)
            {
                var currentIdComponentType = componentOrder.ElementAt(currentPosition);
                var currentValueConverter = _idComponentConverterContainer.GetConverterForType(currentIdComponentType);
                var currentIdComponentString = idComponentStrings[currentPosition];
                var currentComponent = currentValueConverter.Deserialize(currentIdComponentString, currentIdComponentType);
                Components.Add(currentComponent);
            }

            Component0 = (T0)Components.ElementAt(0);
        }

        /// <summary>
        /// Constructs a new <see cref="Id{T1}"/>
        /// </summary>
        /// <param name="component0"></param>
        /// <param name="componentSeparator"></param>
        /// <param name="idComponentConverterContainer"></param>
        public Id(
            T0 component0,
            String componentSeparator = DefaultComponentSeparator,
            IIdComponentConverterContainer idComponentConverterContainer = null)
        {
            Component0 = component0;
            Components = new List<object> { component0 };
            _componentSeparator = new ComponentSeparator(componentSeparator);
            _idComponentConverterContainer = idComponentConverterContainer ?? new DefaultIdComponentConverterContainer();
        }

        #endregion

        #region Constants

        protected const String DefaultComponentSeparator = "|";

        #endregion

        #region Fields

        private readonly IComponentSeparator _componentSeparator;
        private readonly IIdComponentConverterContainer _idComponentConverterContainer = new DefaultIdComponentConverterContainer();

        #endregion

        #region Properties

        protected ICollection<object> Components { get; private set; }
        public T0 Component0 { get; private set; }

        #endregion

        #region Methods

        public IEnumerator<object> GetEnumerator()
        {
            return Components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Conversion Methods


        /// <summary>
        /// Returns this <see cref="IId{T1}"/> as a <see cref="String"/>
        /// Note: overrides Object.ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var idStringBuilder = new StringBuilder();

            // iterate over all id components up to the last id component
            for (var currentPosition = 0; currentPosition < Components.Count() - 1; currentPosition++)
            {
                // get the id component at the current position
                var currentIdComponent = Components.ElementAt(currentPosition);
                // get the value converter for the current idcomponent
                var currentValueConverter = _idComponentConverterContainer.GetConverterForType(currentIdComponent.GetType());
                // append element with trailing separator
                idStringBuilder.AppendFormat("{0}{1}", currentValueConverter.Serialize(currentIdComponent), _componentSeparator);
            }

            // append last element with no trailing separator
            var lastComponent = Components.Last();
            var lastComponentConverter = _idComponentConverterContainer.GetConverterForType(lastComponent.GetType());
            idStringBuilder.Append(lastComponentConverter.Serialize(lastComponent));

            return idStringBuilder.ToString();
        }

        #endregion
    }

    #endregion
}
