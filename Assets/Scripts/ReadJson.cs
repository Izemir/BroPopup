using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class ReadJson
    {
        List<Player> players = new List<Player>();

        Player ourPlayer;

        public ReadJson()
        {

        }

        public List<Player> read(int id)
        {

            using (StreamReader r = new StreamReader("players.json"))
            {

                string json = r.ReadLine();
                players = JsonConvert.DeserializeObject<List<Player>>(json);


            }

            players.Sort(SortByScore);


            foreach (Player pl in players)
            {
                if (pl.id == id)
                {
                    ourPlayer = pl;
                    break;
                }
            }

            return players;
        }

        private int SortByScore(Player x, Player y)
        {
            if (x.score == 0 || y.score == 0)
            {
                return 0;
            }

            // CompareTo() method 
            return -1 * x.score.CompareTo(y.score);
        }
    }
}
