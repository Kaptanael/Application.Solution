using Application.ViewModel.Value;
using Application.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Service
{
    public interface IValueService
    {
        Task<bool> AddAsync(Value value, CancellationToken cancellationToken = default(CancellationToken));

        bool Update(Value value);

        bool Delete(Value value);

        Task<Value> GetByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<ValueForListDto>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> IsDuplicateAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}
