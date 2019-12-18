using AutoMapper;
using DTOs = DTO;
using v1 = Models.V1;

namespace API.Infrastructure
{
    public class ModelMapperFactory
    {
        public static IMapper CreateMapperV1()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // cfg.CreateMap<Models.V1.SOURCE, DTOs.V1.DESTINATION>();

                cfg.CreateMap<v1.Person, DTOs.V1.Person>();
            });
            return config.CreateMapper();
        }
    }
}