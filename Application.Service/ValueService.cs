using Application.Service;
using Application.ViewModel.Value;
using Application.Data.UnitOfWork;
using Application.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ValueService : IValueService
    {
        private readonly IUnitOfWork _uow;

        public ValueService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> AddAsync(Value value, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _uow.Values.AddAsync(value);
            return await _uow.SaveAsync(cancellationToken) > 0 ? true : false;
        }

        public bool Update(Value value)
        {
            var updatedValue = _uow.Values.Update(value);
            return _uow.Save() > 0 ? true : false;
        }

        public bool Delete(Value value)
        {
            var deletedValue = _uow.Values.Delete(value);
            return _uow.Save() > 0 ? true : false;
        }

        public async Task<IEnumerable<ValueForListDto>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            
            var values = await _uow.Values.GetAllAsync();
            
            List<ValueForListDto> valueForListDtos = new List<ValueForListDto>();
            foreach (var value in values)
            {
                ValueForListDto valueForListDto = new ValueForListDto();
                valueForListDto.Id = value.Id;
                valueForListDto.Name = value.Name;
                valueForListDtos.Add(valueForListDto);
            }            

            return valueForListDtos;
        }

        public async Task<Value> GetByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var value = await _uow.Values.GetByIdAsync(id);

            //ValueForListDto valueForListDto = new ValueForListDto();
            //valueForListDto.Id = value.Id;
            //valueForListDto.Name = value.Name;

            return value;
        }

        public async Task<bool> IsDuplicateAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var value = await _uow.Values.IsDuplicateAsync(name);
            return value;
        }
    }
}
