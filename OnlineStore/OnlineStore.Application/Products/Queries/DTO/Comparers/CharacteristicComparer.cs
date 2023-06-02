using System.Diagnostics.CodeAnalysis;

namespace OnlineStore.Application.Products.Queries.DTO.Comparers
{
    public class CharacteristicComparer : IEqualityComparer<CharacteristicDto>
    {
        public bool Equals(CharacteristicDto x, CharacteristicDto y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode([DisallowNull] CharacteristicDto obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
