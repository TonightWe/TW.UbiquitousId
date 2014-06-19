using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seterlund.CodeGuard;

namespace TW.UbiquitousId
{
    public interface IComponentSeparator
    {
        #region Conversion Methods

        String ToString();

        #endregion
    }

    public class ComponentSeparator : IComponentSeparator
    {
        #region Constructors

        public ComponentSeparator(String componentSeparatorString)
        {
            _value = Guard.That(componentSeparatorString)
                   .IsTrue(_componentSeparatorString => 
                       !String.IsNullOrEmpty(_componentSeparatorString),
                       "Component separator cannot be null or empty").Value;
        }

        #endregion

        #region Fields

        private readonly String _value;

        #endregion

        #region Conversion Methods

        /// <summary>
        /// Returns this <see cref="ComponentSeparator"/> as a <see cref="String"/>
        /// Note: overrides Object.ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _value;
        }

        #endregion
    }
}
