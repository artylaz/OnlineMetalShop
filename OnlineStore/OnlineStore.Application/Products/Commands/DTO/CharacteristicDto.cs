using AutoMapper;
using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain;

namespace OnlineStore.Application.Products.Commands.DTO
{
    public class CharacteristicDto:IMapWith<Characteristic>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CharacteristicDto, Characteristic>();
        }
    }
}
