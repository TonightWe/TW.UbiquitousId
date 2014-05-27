using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seterlund.CodeGuard;

namespace TW.UbiquitousId
{
    public class IdSchema : IIdSchema
    {
        #region Constructors

        /// <summary>
        /// Constructs an <see cref="IdSchema"/>.
        /// </summary>
        /// <param name="componentOrder">Specifies the order (by type) in which components of the id will appear</param>
        /// <param name="componentSeparator">Specifies the character that should be used to separate components of the id</param>
        public IdSchema(IEnumerable<Type> componentOrder, char componentSeparator = DefaultComponentSeparator)
        {
            ComponentOrder = Guard.That(componentOrder).IsNotNull().IsNotEmpty().Value;
            ComponentSeparator = componentSeparator;
        }

        #endregion

        #region Constants

        private const char DefaultComponentSeparator = '|';

        #endregion

        #region Properties

        public IEnumerable<Type> ComponentOrder { get; private set; }
        public char ComponentSeparator { get; private set; }

        #endregion
    }

    /// <summary>
    /// Defines a schema for an <see cref="IId"/>
    /// </summary>
    public interface IIdSchema
    {
        #region Properties

        /// <summary>
        /// Specifies the order (by type) in which components of the id will appear
        /// </summary>
        IEnumerable<Type> ComponentOrder { get; }
        /// <summary>
        /// Specifies the character that should be used to separate components of the id
        /// </summary>
        char ComponentSeparator { get; }

        #endregion
    }
}
