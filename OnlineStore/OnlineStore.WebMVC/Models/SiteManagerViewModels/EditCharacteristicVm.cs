using OnlineStore.Application.Characteristics.DTO;

namespace OnlineStore.WebMVC.Models.SiteManagerViewModels
{
    public class EditCharacteristicVm
    {
        public List<CharacteristicDto> Characteristics { get; set; } = new();
    }
}
