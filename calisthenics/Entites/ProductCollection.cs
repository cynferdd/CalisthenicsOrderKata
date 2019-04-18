using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calisthenics.Entites
{
    /// <summary>
    /// List of products and behaviours
    /// </summary>
    public class ProductCollection
    {
        private Dictionary<Product, int> OrderLines;
        public ProductCollection()
        {
            OrderLines = new Dictionary<Product, int>();
        }
        

        /// <summary>
        /// Retrieving the total
        /// </summary>
        /// <returns>New Price</returns>
        public Price GetTotal()
        {
            Price result = new Price();
            foreach (var item in OrderLines)
            {
                Product product = item.Key;
                int quantity = item.Value;
                Price currentPrice = product.GetPriceFromQuantity(quantity);
                currentPrice.AddPriceTo(result);
            }
            return result;
        }

        /// <summary>
        /// Adding a product to the order
        /// </summary>
        /// <param name="product">product to add</param>
        /// <param name="quantity">quantity</param>
        public void AddProduct(Product product, int quantity)
        {
            OrderLines.Add(product, quantity);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in OrderLines)
            {
                Product product = item.Key;
                int quantity = item.Value;
                Price currentPrice = product.GetPriceFromQuantity(quantity);
                string line = string.Format("{0} - {1} => {2}", product.ToString(), quantity, currentPrice.ToString());
                sb.AppendLine(line);
            }
            return sb.ToString();
        }
    }
}
