using Core.Entities;

namespace Entities.Concrete
{
    //Araç markası
    //Modellerimizi oluşturuyoruz
    public class Brand : IEntity
    {
        public int BrandID { get; set; }
        public string? BrandName { get; set; }
    }
}
