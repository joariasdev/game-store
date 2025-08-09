using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Console { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int TimesSold { get; set; }
    }
}
