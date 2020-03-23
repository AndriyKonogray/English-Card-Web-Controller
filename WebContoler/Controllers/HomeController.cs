using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebContoler.Controllers
{
    
    public class HomeController : Controller
    {
        string activeDeck;
        string firstPlayerPoints;
        String secondPlayerPoints;
        //База Данных

        // GET: Home
        public ActionResult Index()
        {
            return View("Default");
        }
        [HttpPost]
        public async Task<string> Ai(string k)
        {
            {

                string pcK = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<string>(k));
                int k1=Convert.ToInt32(k);
                k1++;
                pcK = Convert.ToString(k1);
                return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(String.Format(pcK)));
            }

        }
        [HttpPost]
        public async Task<string> Cheker(string EngWord)
        {
            {

                string userWord = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<string>(EngWord));
                return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(String.Format(userWord)));
            }

        }
        [HttpPost]
        public async Task<string> Hello(string name)
        {
            
            string userName = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<string>(name));
            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(String.Format("Hello {0}!", userName)));
        }
        [HttpPost]
        public async Task<string>Deck(string deck)
        {
           
            string userDeck = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<string>(deck));
             Random rng = new Random();
            int[] idDeck = new int[20];
            deck = null;
            bool marker = false;
            for (int i = 0; i < 20; i++)
            {
                marker = false;
                while (marker != true)
                {
                    marker = true;
                    idDeck[i] = rng.Next(1, 51);
                    for (int j = 0; j < i; j++)
                    {

                        if (idDeck[j] == idDeck[i])
                        {
                            marker = false;
                            j = i;
                        }

                    }
                }
                deck = deck + idDeck[i] + " ";
            }
            userDeck = deck;
            activeDeck = userDeck;
            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(String.Format(userDeck)));
        }
    }
}