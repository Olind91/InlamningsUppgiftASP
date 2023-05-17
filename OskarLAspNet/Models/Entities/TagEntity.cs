using OskarLAspNet.Models.Dtos;

namespace OskarLAspNet.Models.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; } = null!;
        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();



        //Vill inte returna TagEntity så därför skapas Tag som vi sedan omvandlar med implicit så det inte behövs göra varje gång.
        public static implicit operator Tag(TagEntity entity)
        {
            if (entity != null) //1:28:30 f.10
            {
                return new Tag
                {
                    Id = entity.Id,
                    TagName = entity.TagName,

                };
            }
            return null!;
        }
    }
}
