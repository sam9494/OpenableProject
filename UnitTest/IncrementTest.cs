namespace UnitTest;

public class IncrementTest
{
    private const int NumberOfTasks = 1000;// 800 會失敗

    [Fact]
    public async Task AddByOperator_NotThreadSafe_WhenCalledConcurrently()
    {
        int addActualResult = 0;
        var tasks = new Task[NumberOfTasks];
        
        for (int taskIndex = 0; taskIndex < NumberOfTasks; taskIndex++)
        {
            tasks[taskIndex] = Task.Run(() =>
            {
                addActualResult++;
            });
        }
        await Task.WhenAll(tasks);
        
        Assert.NotEqual(NumberOfTasks, addActualResult);// 加總與執行次數不匹配 
    }
    
    [Fact]
    public async Task InterlockedIncrement_ThreadSafe_WhenCalledConcurrently()
    {
        int addActualResult = 0;
        var tasks = new Task[NumberOfTasks];
        
        for (int taskIndex = 0; taskIndex < NumberOfTasks; taskIndex++)
        {
            tasks[taskIndex] = Task.Run(() =>
            {
                Interlocked.Increment(ref addActualResult);
            });
        }
        await Task.WhenAll(tasks);
        
        Assert.Equal(NumberOfTasks, addActualResult); // 加總與執行次數匹配
    }
}