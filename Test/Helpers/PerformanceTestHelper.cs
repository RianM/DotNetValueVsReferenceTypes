namespace Test.Helpers;

/// <summary>
/// Adds too much overhead
/// </summary>
public static class PerformanceTestHelper
{
    private const int Iterations = 1000000;
    
    public static void Iterate(Action action)
    {
        for (int i = 0; i < Iterations; i++)
        {
            action.Invoke();
        }
    } 
}