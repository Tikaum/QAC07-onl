using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace ConsoleApp8
{
    internal class Store : IStore
    {
        List<(int, string, string, double)> allBooks = new List<(int Id, string Name, string Genre, double Price)>()
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
        
        
        public void ShowAllBookNames()        //- готов
        {
            foreach (var books in allBooks)
            {
                Console.WriteLine($"{books.Item1}. {books.Item2}");
            }            
        }
        public void FindBook()                  //- НЕ готов
        {
            Console.Write("Введите название книги: ");
            string findName = Console.ReadLine();
            Console.WriteLine($"Ваше название книги: {findName}");
        }
        public void ShowGenreBooks()            //- готов
        {
            foreach (var genre in allBooks)
            {                   
                Console.WriteLine($"{genre.Item1}. {genre.Item3}");
                                             
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
                            Console.WriteLine($"{books.Item1}. {books.Item3}");
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (var books in FantasticBooks)
                        {
                            Console.WriteLine($"{books.Item1}. {books.Item3}");
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (var books in NonfictionBooks)
                        {
                            Console.WriteLine($"{books.Item1}. {books.Item3}");
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (var books in MemoirsBooks)
                        {
                            Console.WriteLine($"{books.Item1}. {books.Item3}");
                        }
                        break;
                    }
                case 5:
                    {
                        foreach (var books in DetectiveBooks)
                        {
                            Console.WriteLine($"{books.Item1}. {books.Item3}");
                        }
                        break;
                    }

            }

        }

        

        public void ShowMenu()                
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

        public void chooseBookInCatalog()
        {
            Console.Write("1. Посмотреть карточку книги\n2. Выбрать книгу и добавить ее в корзину\n3. Вернуться в меню");
            int action = Convert.ToInt32(Console.ReadLine());
            if (action == 1)
            {

            }

            else if (action == 2)
            {
                Console.Write("Введите номер книги, подтвердите ввод и она добавится в корзину ");

            }
        }

        public void chooseBchooseBookInCatalogook()
        {
            throw new NotImplementedException();
        }
    }
}
