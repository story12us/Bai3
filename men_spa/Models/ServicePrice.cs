using System;
namespace men_spa.Models
{
    public struct ServicePrice
    {        
        public string name;
        public int price;
        public ServicePrice(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
