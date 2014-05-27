using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TW.UbiquitousId.Tests.Unit
{
    public class IdTests
    {
        [TestClass]
        public class ConstructionTests
        {
            [TestMethod]
            public void ComponentsOrderedAccordingToSchema()
            {
                #region Arrange

                var schema = A.Fake<IIdSchema>();
                A.CallTo(() => schema.ComponentOrder).Returns(new List<Type>
                {
                    typeof(Guid),
                    typeof(String),
                    typeof(DateTime),
                    typeof(DayOfWeek)
                });
                A.CallTo(() => schema.ComponentSeparator).Returns('|');

                var expectedComponents = new List<Object>
                {
                    Guid.NewGuid(),
                    Guid.NewGuid().ToString(),
                    DateTime.UtcNow,
                    DayOfWeek.Friday
                };

                var id = new Id(expectedComponents, schema);

                #endregion

                #region Act

                var actualComponents = id.Components;

                #endregion

                #region Assert

                actualComponents.Should().Equal(expectedComponents);

                #endregion
            }
        }
        [TestClass]
        public class ReconstructionTests
        {
            [TestMethod]
            public void ComponentsOrderedAccordingToSchema()
            {
                #region Arrange

                var schema = A.Fake<IIdSchema>();
                A.CallTo(() => schema.ComponentOrder).Returns(new List<Type>
                {
                    typeof(Guid),
                    typeof(String),
                    typeof(DateTime),
                    typeof(DayOfWeek)
                });
                A.CallTo(() => schema.ComponentSeparator).Returns('|');

                const string expectedIdString = "fe67da762a214fa2b356d9e5da80edfc|helloworld|2009-06-15 20:45:30Z|0";

                var id = new Id(expectedIdString, schema);

                #endregion

                #region Act

                var actualIdString = id.ToString();

                #endregion

                #region Assert

                actualIdString.ShouldBeEquivalentTo(expectedIdString);

                #endregion
            }
        }
    }
}
