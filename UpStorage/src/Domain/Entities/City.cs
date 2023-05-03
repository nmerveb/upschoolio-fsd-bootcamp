using Domain.Common;

namespace Domain.Entities
{
    public class City : EntityBase<int>
    {
        public string Name { get; set; }
        public int CountryId { get; set; } //her sehri eklerken ulkenin id sini eklemeliyiz.
        public Country Country { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
