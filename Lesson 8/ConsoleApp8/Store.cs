namespace ConsoleApp8
{
    internal class Store : IStore
    {        
        public List<string> booksGenre = new List<string>() 
        {   "1. Fantasy",
            "2. Fantastic",
            "3. Non-fiction",
            "4. Memoirs",
            "5. Detective" };
        List<string> booksFantasy = new List<string>()
        {   "1. Властелин колец", 
            "2. Хроники Нарнии",
            "3. Ведьмак", 
            "4.Волшебник Земноморья",
            "5.Архив Буресвета" };
        List<string> booksFantastic = new List<string>()
        {   "6. Дюна",
            "7. Основание",
            "8. Солярис",
            "9. Собачье сердце",
            "10. Голодные игры" };
        List<string> booksNonFiction = new List<string>()
        {   "11. НИ СЫ. Будь уверен в своих силах и не позволяй сомнениям мешать тебе двигаться вперед",
            "12. Просто делай! Делай просто!",
            "13.Брать, давать и наслаждаться. Как оставаться в ресурсе, что бы с вами ни происходило",
            "14. Тонкое искусство пофигизма. Парадоксальный способ жить счастливо",
            "15.Зеленый свет"};
        List<string> booksMemoirs = new List<string>()
        {   "16. Крутой маршрут",
            "17. Другие берега",
            "18. Записки кавалерист-девицы",
            "19. Одноэтажная Америка",
            "20. Мемуары" };
        List<string> booksDetective = new List<string>()
        {   "21. Десять негритят",
            "22. Убийство Роджера Экройда",
            "23. Собака Баскервилей",
            "24. Талантливый мистер Рипли",
            "25. Имя розы" };
        
        public void FindBook()
        {
            Console.Write("Введите название книги: ");
            string findName = Console.ReadLine();
            Console.Write("Ваше название книги: ", findName);
        }

        public void ShowAllBooks()        
        {
            Console.WriteLine();
            Console.WriteLine("Список всех наших книг:");
            foreach (var allbooks in booksFantasy)
            {
                Console.WriteLine(allbooks);
            }

            foreach (var allbooks in booksFantastic)
            {
                Console.WriteLine(allbooks);
            }

            foreach (var allbooks in booksNonFiction)
            {
                Console.WriteLine(allbooks);
            }

            foreach (var allbooks in booksMemoirs)
            {
                Console.WriteLine(allbooks);
            }

            foreach (var allbooks in booksDetective)
            {
                Console.WriteLine(allbooks);
            }
            Console.WriteLine();
        }

        public void ShowGenreBooks()
        {
            foreach (var Genre in booksGenre)
            {
                Console.WriteLine(Genre);
            }
            
            Console.WriteLine("Выберите номер литературного жанра и введите его");
            int genreNumber = Convert.ToInt32(Console.ReadLine());

            switch (genreNumber)
            {
                case 1:
                    {
                        foreach (var allbooks in booksFantasy)
                        {
                            Console.WriteLine(allbooks);
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (var allbooks in booksFantastic)
                        {
                            Console.WriteLine(allbooks);
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (var allbooks in booksNonFiction)
                        {
                            Console.WriteLine(allbooks);
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (var allbooks in booksMemoirs)
                        {
                            Console.WriteLine(allbooks);
                        }
                        break;
                    }
                case 5:
                    {
                        foreach (var allbooks in booksDetective)
                        {
                            Console.WriteLine(allbooks);
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


    }
}
