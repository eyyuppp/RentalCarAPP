using Core.Entities;
using Entities.Concrete;

namespace Entities.DTO
{
    public class AddCarColor : IDTO
    {
        //Mappings
        public Car Car { get; set; }
        public Color Color { get; set; }
    }
}
