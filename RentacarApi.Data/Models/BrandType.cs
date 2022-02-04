using RentacarApi.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentacarApi.Data.Models
{
    public class BrandType
    {
        public EBrand BrandId { get; set; }
        public EType TypeId { get; set; }

    }
}
