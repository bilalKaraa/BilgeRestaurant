using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeRestaurant.Models
{
   public class BaseEntitty
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public decimal Adet { get; set; }
        public override string ToString()
        {
            return $" {Ad} {Fiyat:C2}  {Aciklama}";
        }
    }
}
