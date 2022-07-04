using Curs_work_API.Models;
using Curs_Work_Bot.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Curs_Work_Bot.Json;


namespace Curs_Work_Bot.Bot
{
    public class BotUpdate
    {
        public string text;
        public long id;
        public string username;
    }
    internal class TG_Bot_curse_work
    {
        static TelegramBotClient Bot = new TelegramBotClient("5468707258:AAEo4UOSxL7ruK7E0uwr-haH4r31wolrlvY");
        static List<BotUpdate> botUpdates = new List<BotUpdate>();
        public static void Start()
        {
            try 
            {
                Json.Wishlist.Open();
            }
            catch
            {
                Json.Wishlist.Save();
            }
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage,
                }
            };
            Bot.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions);
            Console.ReadKey();


        }
        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
                throw new NotImplementedException();    
        }

        private static async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            List<string> comands = new List<string>();
            comands.Add("/start");
            comands.Add("/back");
            comands.Add("Top best games for platform");
            comands.Add("Top new games for platform");
            comands.Add("Epic Store Distribution");
            comands.Add("Sony");
            comands.Add("Microsoft");
            comands.Add("PC");
            comands.Add("Nintendo");
            comands.Add("Mobile devices");
            comands.Add("PlayStation 3");
            comands.Add("PlayStation 4");
            comands.Add("PlayStation 5");
            comands.Add("Xbox series x");
            comands.Add("Xbox One");
            comands.Add("Xbox 360");
            comands.Add("3ds");
            comands.Add("Wii U");
            comands.Add("Android");
            comands.Add("IOS");
            comands.Add("PS 5");
            comands.Add("Xbox SX");
            comands.Add("Nintendo Switch");
            comands.Add("Computer");
            comands.Add("Mobile device");
            comands.Add("Android 🤖");
            comands.Add("IOS 🍎");
            comands.Add("Price");
            comands.Add("Guide");
            comands.Add("Videos");
            comands.Add("Games");

            string platform = "";
            string result = "";
            string search_word = "";
            int numb = 0;
            var id = update.Message.Chat.Id;

            Wishlist contr = new Wishlist();
            Wishlist_games wishlist = new Wishlist_games("",0,"","");
            Wishlist_games wishlist_game = new Wishlist_games("", 0, "", "");
            Api_Client client = new Api_Client();
            List<Wishlist_games> list_1 = new List<Wishlist_games>();
            if (update.Type == UpdateType.Message)
            {
                if (update.Message.Type == MessageType.Text)
                {
                   
                    var messege = update.Message;
                    if (messege.Text.ToLower() == "/start")
                    {
                        await bot.SendTextMessageAsync(messege.Chat, $"Hello! {update.Message.Chat.FirstName}");
                        await bot.SendTextMessageAsync(messege.Chat, $"Full List of special Comands");
                        await bot.SendTextMessageAsync(messege.Chat, $"/back --- main menu");
                        await bot.SendTextMessageAsync(messege.Chat, $"/search_word name ------- Enter search word , before searching games");
                        await bot.SendTextMessageAsync(messege.Chat, $"/list ------- List of commands");
                        ReplyKeyboardMarkup keyboardMarkup = new(new[] {
                            new KeyboardButton[] { "Top best games for platform", "Top new games for platform" , "Epic Store Distribution" },
                            new KeyboardButton[] { "Search Game and more" , "Add Wish List"}})
                        {
                            
                            ResizeKeyboard = true
                        };
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose , what you want", replyMarkup: keyboardMarkup);
                    }
                    else if (messege.Text.ToLower() == "/back")
                    {
                        ReplyKeyboardMarkup keyboardMarkup = new(new[] {
                            new KeyboardButton[] { "Top best games for platform", "Top new games for platform" , "Epic Store Distribution" },
                            new KeyboardButton[] { "Search Game and more" , "Add Wish List"}})
                        {

                            ResizeKeyboard = true
                        };
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose , what you want", replyMarkup: keyboardMarkup);
                    }
                    else if (messege.Text == "/list")
                    {
                        await bot.SendTextMessageAsync(messege.Chat, $"Full List of special Comands");
                        await bot.SendTextMessageAsync(messege.Chat, $"/back --- main menu");
                        await bot.SendTextMessageAsync(messege.Chat, $"/search_word name ------- Enter search word , before searching games");
                    }
                    if (messege.Text.Contains("/search_word "))
                    {
                        
                        search_word = messege.Text;
                        search_word = search_word.Replace("/search_word ","");
                        System.IO.File.WriteAllText("game.json", JsonConvert.SerializeObject(search_word));
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Game name entered");
                    }
                    if (messege.Text.Contains("/pos "))
                    {

                        search_word = messege.Text;
                        search_word = search_word.Replace("/search_word ", "");
                        System.IO.File.WriteAllText("game.json", JsonConvert.SerializeObject(search_word));
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Game name entered");
                    }

                    if (messege.Text == "Top best games for platform")
                    {
                        ReplyKeyboardMarkup keyboardMarkup = new(new[] { new KeyboardButton[] { "Sony", "Microsoft", "Nintendo" , "PC" , "Mobile devices"} })
                        {
                            ResizeKeyboard = true
                        };
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose Company , or you can always /back", replyMarkup: keyboardMarkup);
                    }
                    switch (messege.Text)
                        {
                            case "Sony":
                                {
                                    ReplyKeyboardMarkup keyboardMarkup_1 = new(new[] { new KeyboardButton[] { "PlayStation 3", "PlayStation 4", "PlayStation 5" } })
                                    {
                                        ResizeKeyboard = true
                                    };
                                    await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose Platform", replyMarkup: keyboardMarkup_1);
                                    break;
                                }
                            case "Microsoft":
                                {
                                    ReplyKeyboardMarkup keyboardMarkup_1 = new(new[] { new KeyboardButton[] { "Xbox series x", "Xbox One", "Xbox 360" } })
                                    {
                                        ResizeKeyboard = true
                                    };
                                    await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose Platform", replyMarkup: keyboardMarkup_1);
                                    break;
                                }
                            case "Nintendo":
                                {
                                    ReplyKeyboardMarkup keyboardMarkup_1 = new(new[] { new KeyboardButton[] { "Switch", "3ds", "Wii U" } })
                                    {
                                        ResizeKeyboard = true
                                    };
                                    await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose Platform", replyMarkup: keyboardMarkup_1);
                                    break;
                                }
                            case "PC":
                                {
                                    await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for PC");
                                   
                                    result = client.Get_Best_Games("pc").Result;
                                    await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                                }
                            case "Mobile devices":
                                {
                                      ReplyKeyboardMarkup keyboardMarkup_1 = new(new[] { new KeyboardButton[] { "Android", "IOS" } })
                                      {
                                            ResizeKeyboard = true
                                      };
                                      await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose Platform", replyMarkup: keyboardMarkup_1);
                                      break;
                                }

                        }
                    platform = messege.Text.ToLower();
                    switch (platform)
                    {
                        case "playstation 3":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("ps3").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }

                        case "playstation 4":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("ps4").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }

                        case "playstation 5":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("ps5").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "xbox series x":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("xbox-series-x").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "xbox one":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("xbox-one").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "xbox 360":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("xbox-360").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "switch":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("switch").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "wii u":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("wii-u").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "3ds":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("3ds").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "android":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("android").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "ios":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top BEST Games for {platform}");
                                result = client.Get_Best_Games("ios").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                    }
                    if (messege.Text == "Top new games for platform")
                    {
                        ReplyKeyboardMarkup keyboardMarkup = new(new[] { new KeyboardButton[] { "PS 5", "Xbox SX", "Nintendo Switch", "Computer", "Mobile device" } })
                        {
                            ResizeKeyboard = true
                        };
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose Platform", replyMarkup: keyboardMarkup);
                        platform = messege.Text.ToLower();
                    }
                    switch (platform)
                    {
                        case "ps 5":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top NEW Games for {platform}");
                                result = client.Get_New_Games("ps5").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "xbox sx":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top NEW Games for {platform}");
                                result = client.Get_New_Games("xbox-series-x").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "nintendo switch":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top NEW Games for {platform}");
                                result = client.Get_New_Games("switch").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "computer":
                            {
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top NEW Games for {platform}");
                                result = client.Get_New_Games("pc").Result;
                                await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                        case "mobile device":
                            {
                                ReplyKeyboardMarkup keyboardMarkup_1 = new(new[] { new KeyboardButton[] { "Android 🤖", "IOS 🍎" } })
                                {
                                    ResizeKeyboard = true
                                };
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose Platform", replyMarkup: keyboardMarkup_1);
                                platform = messege.Text.ToLower();
                                await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                                break;
                            }
                    }
                    if (messege.Text == "Android 🤖")
                    {
                        await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top NEW Games for android");
                        result = client.Get_New_Games("android").Result;
                        await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                    }
                    else if (messege.Text == "IOS 🍎")
                    {
                        await Bot.SendTextMessageAsync(messege.Chat.Id, $"Top NEW Games for ios");
                        result = client.Get_New_Games("ios").Result;
                        await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                    }
                    if (messege.Text == "Epic Store Distribution")
                    {
                        
                        result += client.Get_Epic_Store().Result;
                        await Bot.SendTextMessageAsync(messege.Chat.Id, $"{result}");
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "You can return by clicking /back");
                    }
                    ////////////////////////////// ////////////////////////////// //////////////////////////////////////////////////////////// //////////////////////////////
                    ////////////////////////////// ////////////////////////////// //////////////////////////////////////////////////////////// //////////////////////////////
                    ///
                    if(messege.Text == "/addwish")
                    {
                       
                        list_1.AddRange(client.Get_Game_Price(search_word).Result);
                        ReplyKeyboardMarkup keyboardMarkup = new(new[] { new KeyboardButton[] { "1", "2", "3", "4" , "5"} })
                        {
                            ResizeKeyboard = true
                        };
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose option", replyMarkup: keyboardMarkup);
                        
                        numb = Convert.ToInt32(messege.Text);
                        wishlist_game = list_1[numb];
                        if (!Json.Wishlist.ListOfUsers.ContainsKey(id.ToString()))
                        {
                            Json.Wishlist.ListOfUsers.Add(id.ToString(), new List<Wishlist_games>());
                        }
                        Json.Wishlist.ListOfUsers[id.ToString()].Add(wishlist_game);
                        Json.Wishlist.Save();
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Done, you can always /back");
                    }
                    if(messege.Text == "/deletewish")
                    {
                        int pos = 0;
                        Json.Wishlist.ListOfUsers[id.ToString()].RemoveAt(pos);
                        Json.Wishlist.Save();
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Done, you can always /back");
                    }
                    if(messege.Text == "/show")
                    {
                        float count = 0;
                        for (int i = 0; i < Json.Wishlist.ListOfUsers[id.ToString()].Count; i++)
                        {
                            result += "Game Name" + Json.Wishlist.ListOfUsers[id.ToString()][i].Name + "\n";
                            result += "Store Name" + Json.Wishlist.ListOfUsers[id.ToString()][i].Store + "\n";
                            result += "Price" + Json.Wishlist.ListOfUsers[id.ToString()][i].Price + "\n";
                            result += "URL" + Json.Wishlist.ListOfUsers[id.ToString()][i].URL + "\n";
                            count += Json.Wishlist.ListOfUsers[id.ToString()][i].Price;
                        }
                        await Bot.SendTextMessageAsync(messege.Chat.Id, result);
                        await Bot.SendTextMessageAsync(messege.Chat.Id, $"Total Price {count}");
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Done, you can always /back");
                    }
                    if(messege.Text == "Search Game and more")
                    {
                        ReplyKeyboardMarkup keyboardMarkup = new(new[] { new KeyboardButton[] { "Guide", "Videos", "Search" , "Store" } })
                        {
                            ResizeKeyboard = true
                        };
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Choose option", replyMarkup: keyboardMarkup);
                    }
                    if (messege.Text == "Guide")
                    {
                        string game = "";
                        try
                        {
                            game = JsonConvert.DeserializeObject<string>(System.IO.File.ReadAllText("game.json"));
                            Console.WriteLine(result);
                        }
                        catch
                        {
                            await Bot.SendTextMessageAsync(messege.Chat.Id, "Something Wrong ,  can  /back");
                        }
                        result = client.Get_Game_Guide(game).Result;
                        await Bot.SendTextMessageAsync(messege.Chat.Id, result);
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Done, you can always /back");
                    }
                    else if (messege.Text == "Videos")
                    {
                        string game = "";
                        try
                        {
                            game = JsonConvert.DeserializeObject<string>(System.IO.File.ReadAllText("game.json"));
                            Console.WriteLine(result);
                        }
                        catch
                        {
                            await Bot.SendTextMessageAsync(messege.Chat.Id, "Something Wrong ,  can  /back");
                        }
                        result = client.Get_Game_Videos(game).Result;
                        await Bot.SendTextMessageAsync(messege.Chat.Id, result);
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Done, you can always /back");
                    }
                    else if (messege.Text == "Search")
                    {
                        string game = "";
                        try
                        {
                            game = JsonConvert.DeserializeObject<string>(System.IO.File.ReadAllText("game.json"));
                            Console.WriteLine(result);
                        }
                        catch
                        {
                            await Bot.SendTextMessageAsync(messege.Chat.Id, "Something Wrong ,  can  /back");
                        }
                        result = client.Get_Game_Name(game).Result;
                        await Bot.SendTextMessageAsync(messege.Chat.Id, result);
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Done, you can always /back");
                    }
                    else if (messege.Text == "Store")
                    {
                        try
                        {
                            result = JsonConvert.DeserializeObject<string>(System.IO.File.ReadAllText("game.json"));
                            Console.WriteLine(result);
                        }
                        catch
                        {
                            await Bot.SendTextMessageAsync(messege.Chat.Id, "Something Wrong ,  can  /back");
                        }
                        list_1.AddRange(client.Get_Game_Price(result).Result);
                        foreach (var item in list_1)
                        {
                            await Bot.SendTextMessageAsync(messege.Chat.Id, $"Game Name {item.Name} , URL {item.URL}");
                        }
                        await Bot.SendTextMessageAsync(messege.Chat.Id, "Done, you can always /back");
                    }
                    
                }
            }
        }
    }
}
