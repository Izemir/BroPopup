
namespace Assets.Scripts
{
    /// 
    /// Словарь имен и фамилий, созданный помочь генерировать имена игроков.
    ///
    class Dictionary
    {
        public string[] MaleNames { get; }
        public string[] femaleNames { get; }
        public string[] lastFemNames { get; }
        public string[] lastMalNames { get; }

        public Dictionary()
        {
            MaleNames = new string[10] { "Марк", "Антон", "Павел", "Карл", "Иван", "Максим", "Георгий", "Александр", "Сигурд", "Боромир" };
            femaleNames = new string[10] { "Анна", "Мария", "Екатерина", "Елизавета", "Павла", "Гвендолин", "Алена", "Александра", "Дарья", "Вера" };
            lastFemNames = new string[10] { "Бечина", "Смирнова", "Петрова", "Бутько", "Ложкина", "Картошкина", "Шварц", "Чуприна", "Кузнецова", "Сталина" };
            lastMalNames = new string[10] { "Сталин", "Смирнов", "Петров", "Яблочкин", "Рамирез", "Бендер", "Шмидт", "Бутько", "Одинсон", "Перевозчиков" };
        }
    }
}
