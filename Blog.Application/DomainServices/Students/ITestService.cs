using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.DomainServices.Students
{
    public interface ITestService
    {
        Task<List<int>> TestAsync();
    }
}