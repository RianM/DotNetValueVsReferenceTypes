using FluentAssertions;
using Test.Helpers;
using Test.Models;

namespace Test.Tests;

public class ClassModelTests
{
    [TestCase(true)]
    public void Equal_Should_BeFalse(bool doAssertion)
    {
        var n = new ClassModel(1);
        var m = new ClassModel(1);
        bool equals = n.Equals(m);
        
        if (doAssertion)
        {
            equals.Should().BeFalse();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_Equal_Should_BeFalse() =>
        PerformanceTestHelper.Iterate(() => Equal_Should_BeFalse(false));

    [TestCase(true)]
    public void NotEqual_Should_BeFalse(bool doAssertion)
    {
        var n = new ClassModel(1);
        var m = new ClassModel(2);
        var equals = n.Equals(m);
        
        if (doAssertion)
        {
            equals.Should().BeFalse();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_NotEqual_Should_BeFalse() =>
        PerformanceTestHelper.Iterate(() => NotEqual_Should_BeFalse(false));

    [TestCase(true)]
    public void EqualMutation_Should_BeTrue(bool doAssertion)
    {
        var n = new ClassModel(1);
        var m = n;
        m.Integer = 2;
        var equals = n.Equals(m);

        if (doAssertion)
        {
            equals.Should().BeTrue();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_EqualMutation_Should_BeTrue() =>
        PerformanceTestHelper.Iterate(() => EqualMutation_Should_BeTrue(false));

    [TestCase(true)]
    public void NotEqualMutation_Should_BeEqual(bool doAssertion)
    {
        var n = new ClassModel(1);
        var m = n;
        m.Integer = 2;
        var equals = n.Equals(m);
        var classPrimitiveEquals = n.Integer.Equals(m.Integer);
        
        if (doAssertion)
        {
            equals.Should().BeTrue();
            classPrimitiveEquals.Should().BeTrue();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_NotEqualMutation_Should_BeEqual() =>
        PerformanceTestHelper.Iterate(() => NotEqualMutation_Should_BeEqual(false));
}