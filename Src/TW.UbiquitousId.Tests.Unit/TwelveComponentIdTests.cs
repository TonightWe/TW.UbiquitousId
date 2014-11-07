﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TW.UbiquitousId.Tests.Unit
{
    public class TwelveComponentIdTests
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
                const DateTimeKind expectedComponent9 = DateTimeKind.Utc;
                var expectedComponent10 = DateTime.Today.ToString();
                var expectedComponent11 = String.Format("I have spaces and a datetime equal to {0}",DateTime.UtcNow);


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
                    expectedComponent8,
                    expectedComponent9,
                    expectedComponent10,
                    expectedComponent11
                };

                var id = new Id<Guid, String, DateTime, DayOfWeek,DateTime,Guid,DayOfWeek,String,DateTime,DateTimeKind,String,String>(
                    expectedComponent0,
                    expectedComponent1,
                    expectedComponent2,
                    expectedComponent3,
                    expectedComponent4,
                    expectedComponent5,
                    expectedComponent6,
                    expectedComponent7,
                    expectedComponent8,
                    expectedComponent9,
                    expectedComponent10,
                    expectedComponent11);

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
                expectedIdStringBuilder.Append("|1000000000000000");
                expectedIdStringBuilder.Append("|0");
                expectedIdStringBuilder.Append("|22345324534534534");
                expectedIdStringBuilder.Append("|a4bac0922c674c1b80016b680e31ba44");
                expectedIdStringBuilder.Append("|3");
                expectedIdStringBuilder.Append("|helloworldagain");
                expectedIdStringBuilder.Append("|22345324534534534");
                expectedIdStringBuilder.Append("|1");
                expectedIdStringBuilder.Append("|goodbyeworld");
                expectedIdStringBuilder.Append("|goodbyeworldagain");
                var expectedIdString = expectedIdStringBuilder.ToString();

                var id = new Id<Guid, String, long, DayOfWeek,DateTime,Guid,DayOfWeek,String,DateTime,DateTimeKind,String,String>(expectedIdString);

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
