using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace Homework8
{
    public class Store : IStore
    {
        public List<(int, string, string, double)> allBooks = new List<(int Id, string Name, string Genre, double Price)>()
        {
            (1, "Властелин колец", "Fantasy", 234.12),
            (2, "Хроники Нарнии", "Fantasy", 455.60),
            (3, "Ведьмак", "Fantasy", 7987.23),
            (4, "Волшебник Земноморья", "Fantasy", 67.45),
            (5, "Архив Буресвета", "Fantasy", 897.45),
            (6, "Дюна", "Fantastic", 293.34),
            (7, "Основание", "Fantastic", 79.65),
            (8, "Солярис", "Fantastic", 60.32),
            (9, "Собачье сердце", "Fantastic", 29.83),
            (10, "Голодные игры", "Fantastic", 47.86),
            (11, "НИ СЫ. Будь уверен в своих силах и не позволяй сомнениям мешать тебе двигаться вперед", "Non-fiction", 39.48),
            (12, "Просто делай! Делай просто!", "Non-fiction", 29.62),
            (13, "Брать, давать и наслаждаться. Как оставаться в ресурсе, что бы с вами ни происходило", "Non-fiction", 37.62),
            (14, "Тонкое искусство пофигизма. Парадоксальный способ жить счастливо", "Non-fiction", 59.92),
            (15, "Зеленый свет", "Non-fiction", 37.99),
            (16, "Крутой маршрут", "Memoirs", 884.34),
            (17, "Другие берега", "Memoirs", 2349.00),
            (18, "Записки кавалерист-девицы", "Memoirs", 5423.43),
            (19, "Одноэтажная Америка", "Memoirs", 257.49),
            (20, "Мемуары Гейши", "Memoirs", 558.47),
            (21, "Десять негритят", "Detective", 948.74),
            (22, "Убийство Роджера Экройда", "Detective", 385.83),
            (23, "Собака Баскервилей", "Detective", 9478.58),
            (24, "Талантливый мистер Рипли", "Detective", 396.59),
            (25, "Имя розы", "Detective", 8454.92),
        };

        public int ChoiceBookNumberInAllBooks = 0;

        public void ShowAllBookNames()        //- готов
        {
            Console.WriteLine();
            foreach (var books in allBooks)
            {
                Console.WriteLine($"{books.Item1}. {books.Item2}");
            }
        }
        public void FindBook()                  //- НЕ готов
        {
            Console.Write("Введите название книги: ");
            string FindName = Console.ReadLine();
            var FoundBook = allBooks.Where(book => book.Item2 == FindName).ToList();

            if (FoundBook.Count > 0)
            {
                foreach (var books in FoundBook)
                {
                    Console.WriteLine(books.Item2);
                }
            }
            else
            {
                Console.WriteLine("Таких книг у нас нет");
            }
        }
        public void ShowGenreBooks()            //- готов
        {
            List<string> NamesOfGenre = new List<string>() { "1. Fantasy", "2. Fantastic", "3. Non-fiction", "4. Memoirs", "5. Detective" };

            foreach (var genre in NamesOfGenre)
            {
                Console.WriteLine(genre);
            }

            Console.WriteLine("Выберите номер литературного жанра и введите его");
            int genreNumber = Convert.ToInt32(Console.ReadLine());

            var FantasyBooks = allBooks.Where(book => book.Item3 == "Fantasy").ToList();
            var FantasticBooks = allBooks.Where(book => book.Item3 == "Fantastic").ToList();
            var NonfictionBooks = allBooks.Where(book => book.Item3 == "Non-fiction").ToList();
            var MemoirsBooks = allBooks.Where(book => book.Item3 == "Memoirs").ToList();
            var DetectiveBooks = allBooks.Where(book => book.Item3 == "Detective").ToList();

            switch (genreNumber)
            {

                case 1:
                    {
                        foreach (var books in FantasyBooks)
                        {
                            Console.WriteLine($"{books.Item1}. {books.Item2}");                           
                        }
                        break;                        
                    }
                case 2:
                    {
                        foreach (var books in FantasticBooks)
                        {
                            Console.WriteLine($"{books.Item1}. {books.Item2}");                            
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (var books in NonfictionBooks)
                        {
                            Console.WriteLine($"{books.Item1}. {books.Item2}");                           
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (var books in MemoirsBooks)
                        {
                            Console.WriteLine($"{books.Item1}. {books.Item2}");                            
                        }
                        break;
                    }
                case 5:
                    {
                        foreach (var books in DetectiveBooks)
                        {
                            Console.WriteLine($"{books.Item1}. {books.Item2}");                            
                        }
                        break;
                    }
                    Console.WriteLine();
            }

            СhoiceBookInGenre();

        }

        public void ShowMenu()                // готов
        {
            string[] menuItem = {"Добро пожаловать в наш книжный магазин!",
                "Выберите пунтк меню и нажмите его номер:",
                "1. Просмотреть список всех доступных книг",
                "2. Просмотреть список книг по жанру",
                "3. Искать книгу по названию",
                "4. Просмотреть содержимое корзины",
                "5. Купить книги добавленные в корзину",
                "6. Завершить покупки"};

            for (int i = 0; i < menuItem.Length; i++)
            {
                string action = menuItem[i];
                Console.WriteLine(action);
            }
        }

        public void СhoiceBookInGenre()
        {
            Console.WriteLine("Выберите дальнейшее действие:" +
                "\n1. Выбрать книгу и посмотреть ее карточку." +
                "\n2. Выбрать книгу и добавить ее в корзину." +
                "\n3. Вернуться в главное меню.");

            int ChoiceBookInOneGenre = Convert.ToInt32(Console.ReadLine());

            if (ChoiceBookInOneGenre == 1)
            {
                Books instansBooks = new Books();
                instansBooks.ShowCardBook();
                
            }

            else if (ChoiceBookInOneGenre == 2)
            {
                Console.WriteLine("Введите номер книги, подтвердите ввод и она добавится в корзину ");
            }
        }
    }
}
