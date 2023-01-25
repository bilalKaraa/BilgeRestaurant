using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeRestaurant.Models
{
    public class Siparis : BaseEntitty
    {
        public List<Icecek> SecilenIcecek { get; set; }
        public List<AraSicak> SecilenArasicak { get; set; }
        public List<AnaYemek> SecilenAnaYemek { get; set; }
        public List<Tatli> SecilenTatli { get; set; }
        public Siparis()
        {
            SecilenIcecek = new List<Icecek>();
            SecilenArasicak = new List<AraSicak>();
            SecilenAnaYemek = new List<AnaYemek>();
            SecilenTatli = new List<Tatli>();
        }

    }
}
