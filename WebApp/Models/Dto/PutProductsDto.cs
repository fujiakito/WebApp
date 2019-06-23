using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class PutProductsDto
    {
        public string Id { get; set; }

        public DateTime Timestamp { get; set; }

        public List<Product> Products { get; set; }
    }
}