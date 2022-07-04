using Curs_work_API.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Curs_Work_Bot.Api
{
    internal class Api_Client
    {
        private HttpClient _client;
        private static string _adress;

        public Api_Client()
        {
            _adress = Constants.Adres;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);

        }
        public async Task<string> Get_Best_Games(string name)
        {
            var responce = await _client.GetAsync($"Curse_Work_/Top Best Games?platform={name}");
            responce.EnsureSuccessStatusCode();

            if (responce.IsSuccessStatusCode)
            {
                var content = responce.Content.ReadAsStringAsync().Result;
                //var games = JsonConvert.DeserializeObject<string>(content);
                if (content == ""|| content == " ")
                {
                    return "We could not find games. Try again later";
                }
                else
                {
                    return content;
                }
            }
            else return "Oops! Error";
        }
        public async Task<string> Get_New_Games(string name)
        {
            var responce = await _client.GetAsync($"/Curse_Work_/Top New Games?platform={name}");
            responce.EnsureSuccessStatusCode();

            if (responce.IsSuccessStatusCode)
            {
                var content = responce.Content.ReadAsStringAsync().Result;
                //var games = JsonConvert.DeserializeObject<string>(content);
                if (content == "" || content == " ")
                {
                    return "We could not find games. Try again later";
                }
                else
                {
                    return content;
                }
            }
            else return "Oops! Error";
        }
        public async Task<string> Get_Epic_Store()
        {
            // Curse_Work_ / Free EpicStore Game
            
            var responce = await _client.GetAsync("/Curse_Work_/Free EpicStore Game");
            responce.EnsureSuccessStatusCode();

            if (responce.IsSuccessStatusCode)
            {
                var content = responce.Content.ReadAsStringAsync().Result;
                //var games = JsonConvert.DeserializeObject<string>(content);
                if (content == "" || content == " ")
                {
                    return "We could not find games. Try again later";
                }
                else
                {
                    return content;
                }
            }
            else return "Oops! Error";
        }
        public async Task<List<Wishlist_games>> Get_Game_Price(string name)
        {
            try
            {
                var json = new WebClient().DownloadString($"https://gaming0bot0api.herokuapp.com/Curse_Work_/Search Game Price?Game_Name={name}");
                var gj = JsonConvert.DeserializeObject<List<Wishlist_games>>(json);
                return gj;
            }
            catch (SystemException)
            {
                List<Wishlist_games> eror = new List<Wishlist_games>();
                eror[0].Name = "Wrong game name ? try again";
                return eror;
            }
        }

        public async Task<string>Get_Game_Guide(string name)
        {
            try
            {
                var json = new WebClient().DownloadString($"https://gaming0bot0api.herokuapp.com/Curse_Work_/Search Guide Game?Game_Name={name}");
                return json;
            }
            catch (SystemException)
            {
                return "Wrong game name ? try again";
            }
        }
        
        public async Task<string> Get_Game_Videos(string name)
        {
            try
            {
                var json = new WebClient().DownloadString($"https://gaming0bot0api.herokuapp.com/Curse_Work_/Search Content of Game?Game_Name={name}");
                return json;
            }
            catch (SystemException)
            {
                return "Wrong game name ? try again";
            }

        }
        public async Task<string> Get_Game_Name(string name)
        {
            try
            {
                var json = new WebClient().DownloadString($"https://gaming0bot0api.herokuapp.com/Curse_Work_/Search Game Name?Game_Name={name}");
                return json;
            }
            catch (SystemException)
            {
                return "Wrong game name ? try again";
            }

        }

    }
}
