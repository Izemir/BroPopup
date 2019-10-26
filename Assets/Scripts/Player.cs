using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Player
    {
        public int id { get; set; }
        public String firstName { get; set; }
        public string lastName { get; set; }
        public int score { get; set; }

        public Player(int id, String firstName, String lastName, int score)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.score = score;
        }

        public String toString()
        {
            return "Player:" + firstName + " " + lastName + ", id: " + id + ", score:" + score;
        }

        public String nameToString()
        {
            return firstName + " " + lastName;
        }
    }
}
