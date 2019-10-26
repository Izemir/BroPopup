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

        public Player ourPlayer { get; set; }

        public int ourPlayerPlace { get; set; }

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


            for (int i=0;i<players.Count;i++)
            {
                if (players[i].id == id)
                {
                    ourPlayer = players[i];
                    ourPlayerPlace = i+1;
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
