using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TW.UbiquitousId.Tests.Unit.IdComponents
{
    public class GuidIdComponentTests
    {
        [TestClass]
        public class BehaviorTests
        {
            [TestMethod]
            public void EqualsReturnsTrueWhenIdComponentValueIsEqual()
            {
                #region Arrange

                const String guidString = "39593d391da84dde917ade0d2d52976f";
                var thisIdComponent = new GuidIdComponent(guidString);
                var thatIdComponent = new GuidIdComponent(guidString);

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

                const String thisGuidString = "39593d391da84dde917ade0d2d52976f";
                var thisIdComponent = new GuidIdComponent(thisGuidString);
                const String thatGuidString = "738a4b50c28f4f3d84835cd7e76c2a4f";
                var thatIdComponent = new GuidIdComponent(thatGuidString);

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

                var isEqual = guidIdComponent.Equals(dayOfWeekEnumIdComponent);

                #endregion

                #region Assert

                isEqual.Should().BeFalse();

                #endregion
            }
        }
    }
}
