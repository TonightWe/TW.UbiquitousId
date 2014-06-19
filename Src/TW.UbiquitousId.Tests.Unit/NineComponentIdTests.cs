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
    public class NineComponentIdTests
    {
        [TestClass]
        public class ConstructionTests
        {
            [TestMethod]
            public void ComponentsOrderedAccordingToGenericParameterOrder()
            {
                #region Arrange

                var expectedComponent0 = Guid.NewGuid();
                var expectedComponent1 = Guid.NewGuid().ToString();
                var expectedComponent2 = DateTime.UtcNow;
                const DayOfWeek expectedComponent3 = DayOfWeek.Friday;
                var expectedComponent4 = DateTime.MinValue;
                var expectedComponent5 = Guid.NewGuid();
                const DayOfWeek expectedComponent6 = DayOfWeek.Sunday;
                var expectedComponent7 = Guid.NewGuid().ToString();
                var expectedComponent8 = DateTime.MaxValue;


                var expectedComponents = new List<Object>
                {
                    expectedComponent0,
                    expectedComponent1,
                    expectedComponent2,
                    expectedComponent3,
                    expectedComponent4,
                    expectedComponent5,
                    expectedComponent6,
                    expectedComponent7,
                    expectedComponent8
                };

                var id = new Id<Guid, String, DateTime, DayOfWeek,DateTime,Guid,DayOfWeek,String,DateTime>(
                    expectedComponent0,
                    expectedComponent1,
                    expectedComponent2,
                    expectedComponent3,
                    expectedComponent4,
                    expectedComponent5,
                    expectedComponent6,
                    expectedComponent7,
                    expectedComponent8);

                #endregion

                #region Act

                var actualComponents = id;

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
            public void ComponentsOrderedAccordingToGenericParameterOrder()
            {
                #region Arrange

                var expectedIdStringBuilder = new StringBuilder();
                expectedIdStringBuilder.Append("fe67da762a214fa2b356d9e5da80edfc");
                expectedIdStringBuilder.Append("|helloworld");
                expectedIdStringBuilder.Append("|2009-06-15 20:45:30Z");
                expectedIdStringBuilder.Append("|0");
                expectedIdStringBuilder.Append("|0001-01-02 00:00:00Z");
                expectedIdStringBuilder.Append("|a4bac0922c674c1b80016b680e31ba44");
                expectedIdStringBuilder.Append("|3");
                expectedIdStringBuilder.Append("|helloworldagain");
                expectedIdStringBuilder.Append("|9999-12-31 23:59:59Z");
                var expectedIdString = expectedIdStringBuilder.ToString();

                var id = new Id<Guid, String, DateTime, DayOfWeek,DateTime,Guid,DayOfWeek,String,DateTime>(expectedIdString);

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
