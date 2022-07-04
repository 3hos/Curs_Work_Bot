using Curs_work_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Curs_Work_Bot.Json
{
    internal class Wishlist
    {
        public Wishlist()
        {
            ListOfUsers =  new Dictionary<string, List<Wishlist_games>>();
        }
        public static Dictionary<string, List<Wishlist_games>> ListOfUsers { get; set; }

        public static void Save()
        {
            string Js = JsonSerializer.Serialize(ListOfUsers);
            File.WriteAllText("users.json", Js);
        }
        public static void Open()
        {
            var Js = File.ReadAllText("users.json");
            ListOfUsers = JsonSerializer.Deserialize<Dictionary<string, List<Wishlist_games>>>(Js);
        }
        
    }
    
}
