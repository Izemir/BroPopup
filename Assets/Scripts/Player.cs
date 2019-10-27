using System;

namespace Assets.Scripts
{
    /// 
    /// Класс игрока, в нем хранится вся информация об игроке.
    ///
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

        /*
         * Созданная для отладки функция, возвращающая строкой информацию по игроку.
         */
        public String toString()
        {
            return "Player:" + firstName + " " + lastName + ", id: " + id + ", score:" + score;
        }

        /*
         * Возвращает имя и фамилию игрока.
         */
        public String nameToString()
        {
            return firstName + " " + lastName;
        }
    }
}
