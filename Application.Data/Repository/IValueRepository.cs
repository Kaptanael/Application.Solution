using System.Threading;
using System.Threading.Tasks;
using Applicationa.Model;

namespace Applicationa.Data.Repository
{
    public interface IValueRepository: IRepository<Value>
    {
        Task<bool> IsDuplicateAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}
