using MediatR;
using OnlineStore.Application.Pictures.DTO;

namespace OnlineStore.Application.Pictures.Queries.GetPictures
{
    public class GetPicturesQuery : IRequest<List<PictureDto>>
    {
    }
}
