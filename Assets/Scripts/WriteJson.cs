using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace Assets.Scripts
{
    /// 
    /// Необходим для генерации списка игроков и
    /// последующей записи их в файл.
    ///
    class WriteJson
    {
        List<Player> players = new List<Player>();

        Random rand = new Random(DateTime.Now.Second);

        Boolean sex = true; // пол генерируемого игрока

        Dictionary dict = new Dictionary();

        int maxScore = 10000; // максимум генерируемых очков

        int ourPlayerId = 33; // идентификатор нашего игрока

        
        public WriteJson()
        {

        }

        /*
         * Запускает генерацию игроков, записывая их в список, также
         * добавляет в список нашего игрока Broccoli Games.
         * Далее записывает игроков в json-файл.
         */
        public void Write(int playersCount)
        {
            GeneratePlayers(playersCount);

            Player v = new Player(ourPlayerId, "Broccoli", "Games", rand.Next(maxScore + 1));

            players.Add(v);

            using (StreamWriter file = File.CreateText(@"players.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, players);
            }



        }

        /*
         * Генерация имени.
         */
        public String RandomFirstName()
        {

            if (rand.Next(1, 2) == 1)
            {
                sex = true;
                return dict.MaleNames[rand.Next(0, 10)];

            }
            else
            {
                sex = false;
                return dict.femaleNames[rand.Next(0, 10)];
            }


        }

        /*
         * Генерация фамилии.
         */
        public String RandomLastName()
        {

            if (sex == true)
            {
                return dict.lastMalNames[rand.Next(0, 10)];
            }
            else
            {
                return dict.lastFemNames[rand.Next(0, 10)];
            }


        }

        /*
         * Генерирует необходимое кол-во игроков (int end),
         * учитывая, что id нашего игрока уже занято.
         */
        public void GeneratePlayers(int end)
        {

            for (int i = 1; i < end; i++)
            {
                if (i == ourPlayerId) i++;
                Player player = new Player(i, RandomFirstName(), RandomLastName(), rand.Next(maxScore + 1));
                players.Add(player);

            }


        }
    }
}
