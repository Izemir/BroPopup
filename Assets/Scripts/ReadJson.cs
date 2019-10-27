using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;



namespace Assets.Scripts
{
    /// 
    /// Необходим для чтения списка игроков из json-файла,
    /// сортировки списка и высленения нашего игрока.
    ///
    class ReadJson
    {
        List<Player> players = new List<Player>();

        public Player ourPlayer { get; set; } // наш игрок

        public int ourPlayerPlace { get; set; } // место нашего игрока

        public ReadJson()
        {

        }

        /*
         * Чтение файла, сортировка, перебор списка игроков
         * для нахождения нашего игрока и его места в списке.
         */
        public List<Player> Read(int id)
        {

            try
            {
                using (StreamReader r = new StreamReader("players.json"))
                {

                    string json = r.ReadLine();
                    players = JsonConvert.DeserializeObject<List<Player>>(json);


                }

                players.Sort(SortByScore);


                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].id == id)
                    {
                        ourPlayer = players[i];
                        ourPlayerPlace = i + 1;
                        break;
                    }
                }
            }            
            catch (FileNotFoundException ex) { Debug.WriteLine("JSON-файл не найден"); }
            

            

            return players;
        }

        /*
         * Сортировщик, от большего к меньшему.
         */
        private int SortByScore(Player x, Player y)
        {
            if (x.score == 0 || y.score == 0)
            {
                return 0;
            }
            
            return -1 * x.score.CompareTo(y.score);
        }
    }
}
