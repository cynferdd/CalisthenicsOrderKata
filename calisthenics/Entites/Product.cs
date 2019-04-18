using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calisthenics.Entites
{
    /// <summary>
    /// Definition of a product and behaviour
    /// </summary>
    public class Product
    {

        private string Name;
        private Price Price;
        private ProductType Type;

        public Product(string name, Price price, ProductType type = ProductType.Default)
        {
            Name = name;
            Price = price;
            Type = type;
        }

        public Price GetPriceFromQuantity(int quantity)
        {
            float discount = GetDiscount(quantity);
            return Price.CalculatePrice(quantity, discount);
        }

        private float GetDiscount(int quantity)
        {
            if (this.Type == ProductType.Hygienic && quantity>=3)
            {
                return 0.8f;
            }
            if (this.Type == ProductType.Cosmetic && quantity >= 2)
            {
                return 0.85f;
            }
            if (this.Type == ProductType.Tech && quantity >= 2)
            {
                return 0.9f;
            }
            return 1;
        }

        public override string ToString()
        {
            return string.Format("{0} : {1}", Name, Price.ToString());
        }
    }
}
