using System;

namespace DogStoreTranslation.Models
{
    public class DogProduct
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string DogSize { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}