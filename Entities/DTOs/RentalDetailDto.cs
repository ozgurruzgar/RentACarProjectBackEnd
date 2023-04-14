using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string CarColorName { get; set; }
        public string CarBrandName { get; set; }
        public string CustomerFullName { get; set; }
        public string CarName { get; set; }
        public string ModelYear { get; set; }
        public string Description { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime RentDate { get; set; }
    }
}
