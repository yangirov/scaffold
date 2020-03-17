using BusinessLogic.Services.Base;
using Contracts.Models;
using DataAccess.Models;
using DataAccess.Repositories;

using AutoMapper;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Services
{
    public class {ServiceName} : BaseDtoService<{ModelName}, {ModelName}Dto, int>
    {
        protected override IRepository<{ModelName}, int> repository { get; }
        protected override IMapper mapper { get; set; }
        protected override ILogger logger { get; }

        public {ServiceName}(string connection, ILogger logger, IMapper mapper)
        {
            this.repository = new {ModelName}Repository(connection);
            this.logger = logger;
            this.mapper = mapper;
        }
    }
}
