using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Books
{
    public class Store : IStore
    {
        private List<IBook> Publications { get; } = new List<IBook>();

        public Store()
        {
            var initialBooks = new List<IBook>
            {
                new Book("Мастер и Маргарита", "Булгаков", "Фантастика"),
                new Book("Понедельник начинается в субботу", "Стругацкие", "Фантастика"),
                new Book("Автостопом по галактике", "Дуглас Адамс", "Фантастика"),
                new Book("Гиперион", "Дэн Симмонс", "Фантастика"),

                new Book("1984", "Оруэлл", "Антиутопия"),
                new Book("О дивный новый мир", "Хаксли", "Антиутопия"),
                new Book("Мы", "Замятин", "Антиутопия"),
                new Book("451 градус по Фаренгейту", "Брэдбери", "Антиутопия"),

                new Book("Убийство в «Восточном экспрессе»", "Агата Кристи", "Детектив"),
                new Book("Шерлок Холмс: Собака Баскервилей", "Конан Дойл", "Детектив"),
                new Book("Десять негритят", "Агата Кристи", "Детектив"),
                new Book("Молчание ягнят", "Томас Харрис", "Детектив"),

                new Book("Преступление и наказание", "Достоевский", "Классика"),
                new Book("Война и мир", "Толстой", "Классика"),
                new Book("Герой нашего времени", "Лермонтов", "Классика"),
                new Book("Анна Каренина", "Толстой", "Классика")
            };

            Publications.AddRange(initialBooks);
        }

        public List<IBook> GetAllBooks()
        {
            return Publications.ToList();
        }
        public List<IBook> FindBooksByTitle(string title)
        {
            return Publications
                .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<IBook> FindBooksByGenre(string genre)
        {
            return Publications
                .Where(b => b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public List<IBook> FindBooksByAuthor(string author)
        {
            return Publications
                .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
