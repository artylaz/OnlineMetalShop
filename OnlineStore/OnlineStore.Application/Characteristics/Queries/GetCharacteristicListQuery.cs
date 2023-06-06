using MediatR;
using OnlineStore.Application.Characteristics.DTO;

namespace OnlineStore.Application.Characteristics.Queries
{
    public class GetCharacteristicListQuery : IRequest<List<CharacteristicDto>>
    {
        public Guid? ProductId { get; set; }
    }
}
