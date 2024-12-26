using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Domain.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string? PropertyType { get; set; }
        public string? Location { get; set; }
        public decimal Price { get; set; }
        public string? Features { get; set; }
        public string? BrokerContact { get; set; }
    }
}
