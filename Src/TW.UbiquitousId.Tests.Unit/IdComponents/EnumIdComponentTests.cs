using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TW.UbiquitousId.Tests.Unit.IdComponents
{
    public class EnumIdComponentTests
    {
        [TestClass]
        public class BehaviorTests
        {
            [TestMethod]
            public void EqualsReturnsTrueWhenIdComponentValueIsEqual()
            {
                #region Arrange

                const String dayOfWeekEnumString = "0";
                var thisIdComponent = new EnumIdComponent<DayOfWeek>(dayOfWeekEnumString);
                var thatIdComponent = new EnumIdComponent<DayOfWeek>(dayOfWeekEnumString);

                #endregion

                #region Act

                var isEqual = thisIdComponent.Equals(thatIdComponent);

                #endregion

                #region Assert

                isEqual.Should().BeTrue();

                #endregion
            }

            [TestMethod]
            public void EqualsReturnsFalseWhenIdComponentValueIsNotEqual()
            {
                #region Arrange

                const String thisDayOfWeekEnumString = "0";
                var thisIdComponent = new EnumIdComponent<DayOfWeek>(thisDayOfWeekEnumString);
                const String thatDayOfWeekEnumString = "1";
                var thatIdComponent = new EnumIdComponent<DayOfWeek>(thatDayOfWeekEnumString);

                #endregion

                #region Act

                var isEqual = thisIdComponent.Equals(thatIdComponent);

                #endregion

                #region Assert

                isEqual.Should().BeFalse();

                #endregion
            }

            [TestMethod]
            public void EqualsReturnsFalseWhenIdComponentTypeIsNotEqual()
            {
                #region Arrange

                const String guidString = "39593d391da84dde917ade0d2d52976f";
                var guidIdComponent = new GuidIdComponent(guidString);
                const String dayOfWeekEnumString = "0";
                var dayOfWeekEnumIdComponent = new EnumIdComponent<DayOfWeek>(dayOfWeekEnumString);

                #endregion

                #region Act

                var isEqual = dayOfWeekEnumIdComponent.Equals(guidIdComponent);

                #endregion

                #region Assert

                isEqual.Should().BeFalse();

                #endregion
            }
        }
    }
}
