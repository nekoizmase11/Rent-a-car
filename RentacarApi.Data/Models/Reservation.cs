using System;
using System.Collections.Generic;

namespace RentacarApi.Data.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public string Status { get; set; } = null!;

        public virtual Car Car { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
