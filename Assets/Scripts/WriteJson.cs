using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class WriteJson
    {
        List<Player> players = new List<Player>();

        Random rand = new Random(DateTime.Now.Second);

        Boolean sex = true;

        Dictionary dict = new Dictionary();

        int maxScore = 100;



        public WriteJson()
        {

        }

        public void write()
        {
            GeneratePlayers(10000);

            Player v = new Player(33, "Broccoli", "Games", rand.Next(maxScore + 1));

            players.Add(v);

            using (StreamWriter file = File.CreateText(@"players.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, players);
            }



        }

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

        public void GeneratePlayers(int end)
        {

            for (int i = 1; i < end; i++)
            {
                if (i == 33) i++;
                Player player = new Player(i, RandomFirstName(), RandomLastName(), rand.Next(maxScore + 1));
                players.Add(player);

            }


        }
    }
}
