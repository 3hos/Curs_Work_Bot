namespace Curs_work_API.Models
{
    public class Wishlist_games
    {
        public string Name { get; set; }
        public float Price { get; set; } 
        public string Store { get; set; }
        public string URL { get; set; }
        public Wishlist_games(string name , float price , string store , string url)
        {
            this.Name = name;
            this.Price = price;
            this.Store = store;
            this.URL = url;
        }

    }
}
