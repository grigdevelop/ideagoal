using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.Services.Dto;
using AutoMapper;
using IdeaGoal.Domain.Services.Account.Dto;
using IdeaGoal.Domain.Services.Ideas.Dto;
using IdeaGoal.Domain.Services.Components.Dto;

namespace IdeaGoal.Domain.Utilities
{
    public static class MapperExtensions
    {
        public static TEntity ToEntity<TEntity, TEntityDto>(this IEntityDto entityDto)
            where TEntity: class, IEntity
        {
            return entityDto == null ? null : Mapper.Map<TEntity>(entityDto);
        }

        public static TEntityDto ToEntityDto<TEntityDto>(this IEntity entity)
            where TEntityDto: class, IEntityDto
        {
            return entity == null ? null : Mapper.Map<TEntityDto>(entity);
        }

        public static void Configure()
        {
            Mapper.Initialize(cfg => {

                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();

                cfg.CreateMap<Idea, IdeaDto>();
                cfg.CreateMap<IdeaDto, Idea>();

                cfg.CreateMap<Component, ComponentDto>();
                cfg.CreateMap<ComponentDto, Component>();
            });
        }
    }
}
