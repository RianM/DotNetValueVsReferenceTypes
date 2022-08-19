using FluentAssertions;
using Test.Helpers;

namespace Test.Tests;

public class PrimitiveTests
{
    [TestCase(true)]
    public void PrimitiveTest_Equal_Should_BeTrue(bool doAssertion)
    {
        var n = 1;
        var m = 1;
        bool equals = n.Equals(m);

        if (doAssertion)
        {
            equals.Should().BeTrue();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_PrimitiveTest_Equal_Should_BeTrue() =>
        PerformanceTestHelper.Iterate(() => PrimitiveTest_Equal_Should_BeTrue(false));

    [TestCase(true)]
    public void PrimitiveTest_NotEqual_Should_BeFalse(bool doAssertion)
    {
        var n = 1;
        var m = 2;
        var equals = n.Equals(m);

        if (doAssertion)
        {
            equals.Should().BeFalse();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_PrimitiveTest_NotEqual_Should_BeFalse() =>
        PerformanceTestHelper.Iterate(() => PrimitiveTest_NotEqual_Should_BeFalse(false));

    [TestCase(true)]
    public void PrimitiveTest_EqualMutation_Should_BeFalse(bool doAssertion)
    {
        var n = 1;
        var m = n;
        m = 2;
        var equals = n.Equals(m);

        if (doAssertion)
        {
            equals.Should().BeFalse();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_PrimitiveTest_EqualMutation_Should_BeFalse() =>
        PerformanceTestHelper.Iterate(() => PrimitiveTest_EqualMutation_Should_BeFalse(false));
}