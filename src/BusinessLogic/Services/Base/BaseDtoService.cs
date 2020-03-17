using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Contracts;
using DataAccess.Models;
using DataAccess.Repositories;

using AutoMapper;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Services.Base
{
	public abstract class BaseDtoService<TEntity, TDto, TId> : IDtoService<TDto, TId>
		where TEntity : class, IBaseEntity<TId>, new()
		where TDto : class, IDto<TId>, new()
	{
		protected abstract IRepository<TEntity, TId> repository { get; }

        protected abstract IMapper mapper { get; set; }

		protected abstract ILogger logger { get; }

		public async virtual Task<TDto> AddAsync(TDto dto)
		{
			try
			{
				TEntity dbEntity = mapper.Map<TEntity>(dto);
				var addRes = await repository.AddAsync(dbEntity);
				var result = mapper.Map<TDto>(addRes);
				return result;
			}
			catch (Exception e)
			{
				logger.LogError("ошибка добавления данных", dto, e, GetType().Name, "AddAsync");
				return null;
			}
		}

		public async virtual Task<bool> DeleteAsync(TDto dto)
		{
			try
			{
				TEntity dbEntity = mapper.Map<TEntity>(dto);
				var res = await repository.DeleteAsync(dbEntity.Identifier);
				return res;
			}
			catch (Exception e)
			{
				logger.LogError("ошибка удаления данных", dto, e, GetType().Name, "DeleteAsync");
				return false;
			}
		}

		public async virtual Task<TDto> GetByIdAsync(TId key)
		{
			try
			{
				var res = await repository.GetAsync(key);
				var result = mapper.Map<TDto>(res);
				return result;
			}
			catch (Exception e)
			{
				logger.LogError("ошибка получения данных", key, e, GetType().Name, "GetAsync");
				return null;
			}
		}

		public async virtual Task<IEnumerable<TDto>> GetByFilterAsync(string filter)
		{
			try
			{
				var list = await repository.GetByFilterAsync(filter);
				var result = mapper.Map<IEnumerable<TDto>>(list);
				return result;
			}
			catch (Exception e)
			{
				logger.LogError("ошибка получения данных", filter, e, GetType().Name, "GetBystringAsync");
				return null;
			}
		}

		public async virtual Task<TDto> UpdateAsync(TDto dto)
		{
			try
			{
				TEntity dbEntity = mapper.Map<TEntity>(dto);
				var updRes = await repository.UpdateAsync(dbEntity);
				var result = mapper.Map<TDto>(updRes);
				return result;
			}
			catch (Exception e)
			{
				logger.LogError("ошибка обновления данных", dto, e, GetType().Name, "UpdateAsync");
				return null;
			}
		}

		public void Dispose()
		{
			repository.Dispose();
		}
	}
}
