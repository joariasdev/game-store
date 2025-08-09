using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain
{
    public class GameConsole
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public double Price { get; set; }
        public string Manufacturer { get; set; }
        public int Stock { get; set; }
        public int TimesSold { get; set; }
    }
}
