using System.Collections.Generic;
using System.Threading.Tasks;

using Contracts.Models;
using BusinessLogic.Services;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("{ModelName}")]
    public class {ModelName}Controller : ControllerBase
    {
        private readonly IDtoService<{ModelName}Dto, int> service;

        public {ModelName}Controller(IDtoService<{ModelName}Dto, int> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<{ModelName}Dto>> GetAll() => await service.GetByFilterAsync(string.Empty);

        [HttpGet]
        [Route("{id}")]
        public async Task<{ModelName}Dto> GetById([FromRoute] int id) => await service.GetByIdAsync(id);

        [HttpPost]
        public async Task<{ModelName}Dto> Add([FromBody] {ModelName}Dto dto) => await service.AddAsync(dto);

        [HttpPut]
        public async Task<{ModelName}Dto> Update([FromBody] {ModelName}Dto dto) => await service.UpdateAsync(dto);

        [HttpDelete]
        public async Task<bool> Delete([FromBody] {ModelName}Dto dto) => await service.DeleteAsync(dto);
    }
}
