using Contracts.Models;
using DataAccess.Models;

using AutoMapper;

namespace BusinessLogic.Mappers
{
    public class {ModelName}Profile : Profile
    {
        public {ModelName}Profile()
        {
            CreateMap<{ModelName}, {ModelName}Dto>();
            CreateMap<{ModelName}Dto, {ModelName}>();
        }
    }
}