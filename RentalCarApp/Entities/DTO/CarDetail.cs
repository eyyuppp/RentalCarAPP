  using Core.Entities;

namespace Entities.DTO
{
    //first,firstordefault =ilk veriyi döndür
    //single,singleordefault=tüm verileri kontrol eder (zorunlu)

    //Genel olarak, DTO'lar veri transferi için kullanılan basit veri taşıyıcılarıdır.
    public class CarDetail: IDTO
    {
        public int CarDetailId { get; set; }
        public int ModelYear { get; set; }
        public decimal UnitPrice { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
    }
}
