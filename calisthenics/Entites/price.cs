using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calisthenics.Entites
{
    /// <summary>
    /// Price definition and behaviours
    /// </summary>
    public class Price
    {
        private float Amount;
        private Currency Currency;
        public Price()
        {
            this.Amount = 0;
            this.Currency = Currency.EUR;
        }

        public Price(float amount, Currency currency = Currency.EUR)
        {
            this.Amount = amount;
            this.Currency = currency;

        }

        public Price CalculatePrice(int quantity, float discount)
        {
            return new Price(this.Amount * quantity * discount);
        }

        public void AddPriceTo(Price price)
        {
            price.AddAmount(this.Amount);
        }

        private void AddAmount(float amount)
        {
            this.Amount += amount;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Amount.ToString(), this.Currency.ToString());
        }
    }
}
