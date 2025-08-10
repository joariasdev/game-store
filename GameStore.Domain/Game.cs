using System.ComponentModel.DataAnnotations;

namespace GameStore.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Console { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        [Display(Name = "Units Sold")]
        public int TimesSold { get; set; }
    }
}
