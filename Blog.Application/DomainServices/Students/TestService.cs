using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.DomainServices.Students
{
    public class TestService : ITestService
    {
        public async Task<List<int>> TestAsync()
        {
            return await Task.FromResult(
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
                );
        }
    }
}