using FluentAssertions;
using Test.Helpers;
using Test.Models;

namespace Test.Tests;

public class RecordClassTests
{
    [TestCase(true)]
    public void Equal_Should_BeTrue(bool doAssertion)
    {
        var n = new RecordClassModel(1);
        var m = new RecordClassModel(1);
        var equals = n.Equals(m);

        if (doAssertion)
        {
            equals.Should().BeTrue();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_Equal_Should_BeTrue() =>
        PerformanceTestHelper.Iterate(() => Equal_Should_BeTrue(false));

    [TestCase(true)]
    public void NotEqual_BeFalse(bool doAssertion)
    {
        var n = new RecordClassModel(1);
        var m = new RecordClassModel(2);
        var equals = n.Equals(m);

        if (doAssertion)
        {
            equals.Should().BeFalse();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_NotEqual_BeFalse() =>
        PerformanceTestHelper.Iterate(() => NotEqual_BeFalse(false));

    [TestCase(true)]
    public void RecordClassValueMutation_Mutation_NotAllowed(bool doAssertion)
    {
        var n = new RecordClassModel(1);
        var m = n;
        // Mutating RecordClassModel.Integer is NOT allowed
        // m.Integer = 2;
        var equals = n.Equals(m);

        if (doAssertion)
        {
            equals.Should().BeTrue();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_RecordClassValueMutation_Mutation_NotAllowed() =>
        PerformanceTestHelper.Iterate(() => RecordClassValueMutation_Mutation_NotAllowed(false));

    [TestCase(true)]
    public void RecordClassReferenceMutation_NotEqual_BeTrue(bool doAssertion)
    {
        var n = new RecordClassModel(1, new ClassModel(1));
        var m = n;
        // Mutating RecordClassModel.ClassModel is NOT allowed
        // Mutating RecordClassModel.ClassModel.Integer IS allowed
        // m.ClassModel = new ClassModel(2);
        m.ClassModel.Integer = 2;
        var equals = n.Equals(m);

        if (doAssertion)
        {
            equals.Should().BeTrue();
        }
    }

    [Test]
    [Category("Performance")]
    public void PerformanceTest_RecordClassReferenceMutation_NotEqual_BeTrue() =>
        PerformanceTestHelper.Iterate(() => RecordClassReferenceMutation_NotEqual_BeTrue(false));
}