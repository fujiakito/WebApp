using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class GetProductsDto
    {
        public string Id { get; set; }

        public DateTime Timestamp { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}