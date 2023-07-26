using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class DeleteCarBrand:IDTO
    {
        [DefaultValue(1)]
        public int CarId { get; set; }

        [DefaultValue(1)]
        public int BrandId { get; set; }
    }
}
