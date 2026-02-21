namespace Funcer.Helpers;

public static class SequentialTaskExecutor
{
    extension<TValue>(IEnumerable<Task<TValue>> tasks)
    {
        public async Task<IEnumerable<TValue>> ExecuteSequentially()
        {
            var results = new List<TValue>();
            foreach (var task in tasks)
            {
                results.Add(await task);
            }
            return results.ToList();
        }
    }
    
    extension(IEnumerable<Task> tasks)
    {
        public async Task ExecuteSequentially()
        {
            foreach (var task in tasks)
            {
                await task;
            }
        }
    }
}