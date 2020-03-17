using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Contracts;

namespace BusinessLogic.Services
{
    public interface IDtoService<TDto, TId> : IDisposable
        where TDto : class, IDto<TId>, new()
    {
        Task<TDto> AddAsync(TDto dto);

        Task<TDto> GetByIdAsync(TId key);

        Task<IEnumerable<TDto>> GetByFilterAsync(string filter);

        Task<TDto> UpdateAsync(TDto dto);

        Task<bool> DeleteAsync(TDto dto);
    }
}
