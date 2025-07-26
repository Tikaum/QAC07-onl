using BookStore.Interfaces;
using Homework8;

namespace BookStore
{
    public class Store : IStore
    {
        public Store()
        {
            _books = new List<Book>();
            InitialBookList();
        }

        public List<Book> _books = new List<Book>();                

        public void InitialBookList()
        {
            _books.Add(new Book(1, "Властелин колец", "Fantasy", 234.12));
            _books.Add(new Book(2, "Хроники Нарнии", "Fantasy", 455.60));
            _books.Add(new Book(3, "Ведьмак", "Fantasy", 7987.23));
            _books.Add(new Book(4, "Волшебник Земноморья", "Fantasy", 67.45));
            _books.Add(new Book(5, "Архив Буресвета", "Fantasy", 897.45));
            _books.Add(new Book(6, "Дюна", "Fantastic", 293.34));
            _books.Add(new Book(7, "Песнь песней", "Fantastic", 23.94));
            _books.Add(new Book(8, "Солярис", "Fantastic", 60.32));
            _books.Add(new Book(9, "Собачье сердце", "Fantastic", 29.83));
            _books.Add(new Book(10, "Голодные игры", "Fantastic", 47.86));
            _books.Add(new Book(11, "НИ СЫ. Будь уверен в своих силах и не позволяй сомнениям мешать тебе двигаться вперед", "Non-fiction", 39.48));
            _books.Add(new Book(12, "Просто делай! Делай просто!", "Non-fiction", 29.62));
            _books.Add(new Book(13, "Брать, давать и наслаждаться. Как оставаться в ресурсе, что бы с вами ни происходило", "Non-fiction", 37.62));
            _books.Add(new Book(14, "Тонкое искусство пофигизма. Парадоксальный способ жить счастливо", "Non-fiction", 59.92));
            _books.Add(new Book(15, "Зеленый свет", "Non-fiction", 37.99));
            _books.Add(new Book(16, "Крутой маршрут", "Memoirs", 884.34));
            _books.Add(new Book(17, "Другие берега", "Memoirs", 2349.00));
            _books.Add(new Book(18, "Записки кавалерист-девицы", "Memoirs", 5423.43));
            _books.Add(new Book(19, "Одноэтажная Америка", "Memoirs", 257.49));
            _books.Add(new Book(20, "Мемуары Гейши", "Memoirs", 558.47));
            _books.Add(new Book(21, "Десять негритят", "Detective", 948.74));
            _books.Add(new Book(22, "Убийство Роджера Экройда", "Detective", 385.83));
            _books.Add(new Book(23, "Собака Баскервилей", "Detective", 9478.58));
            _books.Add(new Book(24, "Талантливый мистер Рипли", "Detective", 396.59));
            _books.Add(new Book(25, "Имя розы", "Detective", 8454.92));
        }
        
             
        
        //Ищем книгу по ИД        
        public Book FindBookById(int id)
        {
            foreach (Book book in _books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;  
        }

        //Ищем книгу по названию
        public List<Book> SearchBooksByName (string searchQuery)        
        {
            return _books.Where(book => book.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
        }

        //Ищем книгу по жанру
        public List<Book> SearchBooksByGenre(int searchQuery)
        {
            switch (searchQuery)
            {
                case 1:
                    {
                        return _books.Where(book => book.Genre == "Fantasy").ToList();
                    }                  

                case 2:
                    {
                        return _books.Where(book => book.Genre == "Fantastic").ToList();
                    }
                    
                case 3:
                    {
                        return _books.Where(book => book.Genre == "Non-fiction").ToList();
                    }
                    
                case 4:
                    {
                        return _books.Where(book => book.Genre == "Memoirs").ToList();
                    }
                    
                case 5:
                    {
                        return _books.Where(book => book.Genre == "Detective").ToList();
                    }
                    
                default:
                    {
                        Console.WriteLine("Такого жанра у нас нет");
                        return new List<Book>();
                    }
                    

            }
        }


    }
}
