using OpenableProject.Models;
using OpenableProject.Services;
using OpenableProject.Storage;

namespace UnitTest;

public class OrderStorageTest
{
    private const int NumberOfTasks = 80;
    
    
    [Fact]
    public async Task Add_ShouldBeThreadSafe_WhenCalledConcurrently()
    {
        var tasks = new Task[NumberOfTasks];
        
        for (int taskIndex = 0; taskIndex < NumberOfTasks; taskIndex++)
        {
            var tempIndex = taskIndex;
            tasks[taskIndex] = Task.Run(() =>
            {
                var order = new Order { CustomerName = $"Order_{tempIndex}" };
                OrderStorage.Add(order);
            });
        }
        await Task.WhenAll(tasks);
        
        var orders = OrderStorage.GetAll();
        var orderIds = orders.Select(order => order.Id).ToList();
        Assert.Equal(orderIds.Count, orderIds.Distinct().Count());  // 確保 ID 唯一
        Assert.Equal(NumberOfTasks , orderIds.Count);  // 確認無 Id 衝突導致的拋棄，使數量與執行次數一致
    }
    
    
    [Fact]
    public async Task AddByOperator_NotThreadSafe_WhenCalledConcurrently()
    {
        var tasks = new Task[NumberOfTasks];
        
        for (int taskIndex = 0; taskIndex < NumberOfTasks; taskIndex++)
        {
            var tempIndex = taskIndex;
            tasks[taskIndex] = Task.Run(() =>
            {
                var order = new Order { CustomerName = $"Order_{tempIndex}" };
                OrderStorage.AddByOperator(order);
            });
        }
        await Task.WhenAll(tasks);
        
        var orders = OrderStorage.GetAll();
        var orderIds = orders.Select(order => order.Id).ToList();
        Assert.NotEqual(NumberOfTasks, orderIds.Count);  // 確認 Id 衝突導致的拋棄，使數量與執行次數不一致
    }
}